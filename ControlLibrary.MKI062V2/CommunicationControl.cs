﻿namespace ControlLibrary.MKI062V2
{
    using ControlLibrary;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TCPService;

    public class CommunicationControl : CommunicationBase
    {
        private ToolStripMenuItem Acquisition;
        private INEMO2_MODULES availableModules;
        private ToolStripMenuItem Communication;
        private IContainer components;
        private ToolStripMenuItem Connect;
        private ToolStripMenuItem Continous;
        private DebugTrace dbgTrace;
        private INEMO2_FrameData DeviceData;
        private ComSettings dlgCom;
        private frmSensorSettings dlgSensorSetting;
        private ToolStripMenuItem Enter_DFU_Mode;
        private ToolStripMenuItem Identify;
        private TCPServer m_Server;
        private MenuStrip menuStripCommMenu;
        private ToolStripMenuItem ResetDevice;
        private ToolStripMenuItem Samples;
        private INEMO2_Device sdk2Com;
        private ToolStripMenuItem SensorSetting;
        private ToolStripMenuItem Settings;
        private ToolStripMenuItem Start;
        private ToolStripMenuItem Stop;
        private List<string> TCPMessages;
        private Timer TimerGetSamples;
        private Timer TimerUpdateTCPLogMessage;
        private ToolStripButton toolStripBtnConnect;
        private ToolStripButton toolStripBtnSensorSetting;
        private ToolStripButton toolStripBtnStart;
        private ToolStripButton toolStripBtnStop;
        private ToolStripComboBox toolStripCmbMode;
        private ToolStrip toolStripCommBar;
        private ToolStripLabel toolStripLblNumSamples;
        private ToolStripProgressBar toolStripProgressBarAcqSample;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSCTexBox toolStripTxtSamples;
        private ToolStripMenuItem Trace;

        public CommunicationControl()
        {
            InitializeComponent();
            InitComponent();
        }

        public CommunicationControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitComponent();
        }

        public override void Clear()
        {
            base.StartAcquisition = DateTime.MinValue;
            toolStripLblNumSamples.Text = "";
        }

        private void Continous_Click(object sender, EventArgs e)
        {
            toolStripCmbMode.SelectedIndex = 1;
        }

        private void dbgTrace_Disposed(object sender, EventArgs e)
        {
            Trace.Enabled = true;
            dbgTrace.Device = null;
            dbgTrace = null;
            if (base.OnMessageToLog != null)
            {
                base.OnMessageToLog("TRACE Window closed");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Enter_DFU_Mode_Click(object sender, EventArgs e)
        {
            string strMessage = DeviceType.ToString() + " not connected";
            if (base.DeviceConnected)
            {
                strMessage = "";
                if (MessageBox.Show("Entering in DFU mode the device cannot be connected\nagain until the DFU application will leave the DFU mode.\n\nAre you sure to enter in DFU mode?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    strMessage = DeviceType.ToString() + " fail to enter in DFU mode";
                    if (sdk2Com.EnterDFUMode() == INEMO2_DeviceError.INEMO2_ERROR_NONE)
                    {
                        toolStripBtnConnect.PerformClick();
                        strMessage = DeviceType.ToString() + " is in DFU mode";
                        if ((base.OnMessageToLog != null) && (strMessage != ""))
                        {
                            base.OnMessageToLog(strMessage);
                        }
                        strMessage = "";
                        new frmUploadFirmware { OnMessageToLogSettings = new MessageToLog(MessageToLogFromSetting) }.ShowDialog();
                    }
                }
            }
            else if (MessageBox.Show("Be sure that your STEVAL-MKI062V2 device is in DFU (Device Firmware Upgrade) mode.\nTo start the device in DFU mode you need to plug the device with the SW2 button pressed.\n\nAre you sure to upgrade the device firmware?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                new frmUploadFirmware { OnMessageToLogSettings = new MessageToLog(MessageToLogFromSetting) }.ShowDialog();
            }
            if ((base.OnMessageToLog != null) && (strMessage != ""))
            {
                base.OnMessageToLog(strMessage);
            }
        }

        private void Identify_Click(object sender, EventArgs e)
        {
            string strMessage = DeviceType.ToString() + " not connected";
            if (base.DeviceConnected)
            {
                strMessage = DeviceType.ToString() + " Identify command not supported";
                if (sdk2Com.Identify() == INEMO2_DeviceError.INEMO2_ERROR_NONE)
                {
                    strMessage = DeviceType.ToString() + " device identified successfully";
                }
            }
            if ((base.OnMessageToLog != null) && (strMessage != ""))
            {
                base.OnMessageToLog(strMessage);
            }
        }

        public void InitComponent()
        {
            dlgCom = new ComSettings();
            sdk2Com = new INEMO2_Device();
            dlgSensorSetting = new frmSensorSettings(sdk2Com);
            DeviceData = new INEMO2_FrameData();
            toolStripTxtSamples.Text = "1000";
            toolStripTxtSamples.AutoSize = false;
            toolStripTxtSamples.Width = 15;
            TCPMessages = new List<string>();
            m_Server = null;
            dbgTrace = null;
            availableModules = INEMO2_MODULES.INEMO2_MODULES_NONE;
            Settings.Click += new EventHandler(Settings_Click);
            toolStripCmbMode.SelectedIndexChanged += new EventHandler(toolStripCmbMode_SelectedIndexChanged);
            toolStripBtnConnect.Click += new EventHandler(toolStripBtnConnect_Click);
            toolStripBtnSensorSetting.Click += new EventHandler(toolStripBtnSensorSetting_Click);
            toolStripBtnStart.Click += new EventHandler(toolStripBtnStart_Click);
            toolStripBtnStop.Click += new EventHandler(toolStripBtnStop_Click);
            Connect.Click += new EventHandler(toolStripBtnConnect_Click);
            SensorSetting.Click += new EventHandler(toolStripBtnSensorSetting_Click);
            Start.Click += new EventHandler(toolStripBtnStart_Click);
            Stop.Click += new EventHandler(toolStripBtnStop_Click);
            ResetDevice.Click += new EventHandler(ResetDevice_Click);
            Enter_DFU_Mode.Click += new EventHandler(Enter_DFU_Mode_Click);
            Trace.Click += new EventHandler(Trace_Click);
            Identify.Click += new EventHandler(Identify_Click);
            toolStripTxtSamples.TextChanged += new EventHandler(toolStripTxtSamples_TextChanged);
            Samples.Click += new EventHandler(Samples_Click);
            Continous.Click += new EventHandler(Continous_Click);
            dlgSensorSetting.OnMessageToLogSettings = (MessageToLog) Delegate.Combine(dlgSensorSetting.OnMessageToLogSettings, new MessageToLog(MessageToLogFromSetting));
            TimerGetSamples.Interval = 30;
            TimerGetSamples.Enabled = false;
            base.DeviceConnected = false;
            toolStripBtnStart.Enabled = false;
            toolStripBtnStop.Enabled = false;
            toolStripLblNumSamples.Visible = false;
            toolStripBtnSensorSetting.Enabled = false;
            SensorSetting.Enabled = false;
            Start.Enabled = false;
            Stop.Enabled = false;
            toolStripProgressBarAcqSample.Visible = true;
            toolStripCmbMode.SelectedIndex = 1;
            Clear();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CommunicationControl));
            this.toolStripCommBar = new ToolStrip();
            this.toolStripBtnConnect = new ToolStripButton();
            this.toolStripBtnSensorSetting = new ToolStripButton();
            this.toolStripSeparator5 = new ToolStripSeparator();
            this.toolStripCmbMode = new ToolStripComboBox();
            this.toolStripTxtSamples = new ToolStripSCTexBox();
            this.toolStripBtnStart = new ToolStripButton();
            this.toolStripBtnStop = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.toolStripProgressBarAcqSample = new ToolStripProgressBar();
            this.toolStripLblNumSamples = new ToolStripLabel();
            this.menuStripCommMenu = new MenuStrip();
            this.Communication = new ToolStripMenuItem();
            this.Connect = new ToolStripMenuItem();
            this.SensorSetting = new ToolStripMenuItem();
            this.Acquisition = new ToolStripMenuItem();
            this.Samples = new ToolStripMenuItem();
            this.Continous = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.Start = new ToolStripMenuItem();
            this.Stop = new ToolStripMenuItem();
            this.Settings = new ToolStripMenuItem();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.Identify = new ToolStripMenuItem();
            this.Trace = new ToolStripMenuItem();
            this.Enter_DFU_Mode = new ToolStripMenuItem();
            this.ResetDevice = new ToolStripMenuItem();
            this.TimerGetSamples = new Timer(this.components);
            this.TimerUpdateTCPLogMessage = new Timer(this.components);
            this.toolStripCommBar.SuspendLayout();
            this.menuStripCommMenu.SuspendLayout();
            this.toolStripCommBar.Items.AddRange(new ToolStripItem[] { this.toolStripBtnConnect, this.toolStripBtnSensorSetting, this.toolStripSeparator5, this.toolStripCmbMode, this.toolStripTxtSamples, this.toolStripBtnStart, this.toolStripBtnStop, this.toolStripSeparator2, this.toolStripProgressBarAcqSample, this.toolStripLblNumSamples });
            this.toolStripCommBar.Location = new Point(0, 0x30);
            this.toolStripCommBar.Name = "toolStripCommBar";
            this.toolStripCommBar.Size = new Size(0x29f, 0x19);
            this.toolStripCommBar.TabIndex = 10;
            this.toolStripCommBar.Text = "Acquisition toolbar";
            this.toolStripBtnConnect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripBtnConnect.Image = (Image) resources.GetObject("toolStripBtnConnect.Image");
            this.toolStripBtnConnect.ImageTransparentColor = Color.Magenta;
            this.toolStripBtnConnect.Name = "toolStripBtnConnect";
            this.toolStripBtnConnect.Size = new Size(0x17, 0x16);
            this.toolStripBtnConnect.Text = "Connect";
            this.toolStripBtnConnect.ToolTipText = "Connect/Disconnect";
            this.toolStripBtnSensorSetting.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSensorSetting.Image = (Image) resources.GetObject("toolStripBtnSensorSetting.Image");
            this.toolStripBtnSensorSetting.ImageTransparentColor = Color.Magenta;
            this.toolStripBtnSensorSetting.Name = "toolStripBtnSensorSetting";
            this.toolStripBtnSensorSetting.Size = new Size(0x17, 0x16);
            this.toolStripBtnSensorSetting.Text = "SensorSetting";
            this.toolStripBtnSensorSetting.ToolTipText = "Settings of sensors";
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new Size(6, 0x19);
            this.toolStripCmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            this.toolStripCmbMode.Items.AddRange(new object[] { "Samples", "Continous" });
            this.toolStripCmbMode.Name = "toolStripCmbMode";
            this.toolStripCmbMode.Size = new Size(90, 0x19);
            this.toolStripCmbMode.ToolTipText = "Acquisition Mode";
            this.toolStripTxtSamples.AcceptOnlyNumber = true;
            this.toolStripTxtSamples.MaxLength = 5;
            this.toolStripTxtSamples.MaxValue = 0xffffL;
            this.toolStripTxtSamples.MinValue = 1L;
            this.toolStripTxtSamples.Name = "toolStripTxtSamples";
            this.toolStripTxtSamples.Size = new Size(80, 0x15);
            this.toolStripTxtSamples.TextBoxAlign = HorizontalAlignment.Right;
            this.toolStripTxtSamples.ToolTipText = "Number of samples (Max 65535)";
            this.toolStripBtnStart.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripBtnStart.Image = (Image) resources.GetObject("toolStripBtnStart.Image");
            this.toolStripBtnStart.ImageTransparentColor = Color.Magenta;
            this.toolStripBtnStart.Name = "toolStripBtnStart";
            this.toolStripBtnStart.Size = new Size(0x17, 0x16);
            this.toolStripBtnStart.Text = "Start";
            this.toolStripBtnStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripBtnStop.Image = (Image) resources.GetObject("toolStripBtnStop.Image");
            this.toolStripBtnStop.ImageTransparentColor = Color.Magenta;
            this.toolStripBtnStop.Name = "toolStripBtnStop";
            this.toolStripBtnStop.Size = new Size(0x17, 0x16);
            this.toolStripBtnStop.Text = "Stop";
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 0x19);
            this.toolStripProgressBarAcqSample.Name = "toolStripProgressBarAcqSample";
            this.toolStripProgressBarAcqSample.Size = new Size(100, 0x16);
            this.toolStripProgressBarAcqSample.Step = 2;
            this.toolStripProgressBarAcqSample.Style = ProgressBarStyle.Continuous;
            this.toolStripProgressBarAcqSample.ToolTipText = "Acquisition progress";
            this.toolStripLblNumSamples.AutoSize = false;
            this.toolStripLblNumSamples.BackColor = SystemColors.Info;
            this.toolStripLblNumSamples.Name = "toolStripLblNumSamples";
            this.toolStripLblNumSamples.Size = new Size(70, 0x16);
            this.toolStripLblNumSamples.TextAlign = ContentAlignment.MiddleRight;
            this.toolStripLblNumSamples.ToolTipText = "Number of samples";
            this.menuStripCommMenu.Items.AddRange(new ToolStripItem[] { this.Communication });
            this.menuStripCommMenu.Location = new Point(0, 0);
            this.menuStripCommMenu.Name = "menuStripCommMenu";
            this.menuStripCommMenu.Size = new Size(200, 0x18);
            this.menuStripCommMenu.TabIndex = 0;
            this.menuStripCommMenu.Text = "menuStrip1";
            this.Communication.DropDownItems.AddRange(new ToolStripItem[] { this.Connect, this.SensorSetting, this.Acquisition, this.Settings, this.toolStripSeparator3, this.Identify, this.Trace, this.Enter_DFU_Mode, this.ResetDevice });
            this.Communication.Name = "Communication";
            this.Communication.Size = new Size(0x6a, 20);
            this.Communication.Text = "Communication";
            this.Connect.Name = "Connect";
            this.Connect.Size = new Size(160, 0x16);
            this.Connect.Text = "Connect";
            this.SensorSetting.Name = "SensorSetting";
            this.SensorSetting.Size = new Size(160, 0x16);
            this.SensorSetting.Text = "Sensor Setting...";
            this.Acquisition.DropDownItems.AddRange(new ToolStripItem[] { this.Samples, this.Continous, this.toolStripSeparator1, this.Start, this.Stop });
            this.Acquisition.Name = "Acquisition";
            this.Acquisition.Size = new Size(160, 0x16);
            this.Acquisition.Text = "Acquisition";
            this.Samples.Checked = true;
            this.Samples.CheckState = CheckState.Checked;
            this.Samples.Name = "Samples";
            this.Samples.Size = new Size(0x81, 0x16);
            this.Samples.Text = "Samples";
            this.Continous.Name = "Continous";
            this.Continous.Size = new Size(0x81, 0x16);
            this.Continous.Text = "Continous";
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(0x7e, 6);
            this.Start.Name = "Start";
            this.Start.Size = new Size(0x81, 0x16);
            this.Start.Text = "Start";
            this.Stop.Name = "Stop";
            this.Stop.Size = new Size(0x81, 0x16);
            this.Stop.Text = "Stop";
            this.Settings.Name = "Settings";
            this.Settings.Size = new Size(160, 0x16);
            this.Settings.Text = "Settings...";
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(0x9d, 6);
            this.Identify.Name = "Identify";
            this.Identify.Size = new Size(160, 0x16);
            this.Identify.Text = "Identify";
            this.Trace.Name = "Trace";
            this.Trace.Size = new Size(160, 0x16);
            this.Trace.Text = "Trace";
            this.Enter_DFU_Mode.Name = "Enter_DFU_Mode";
            this.Enter_DFU_Mode.Size = new Size(160, 0x16);
            this.Enter_DFU_Mode.Text = "Firmware upgrade...";
            this.ResetDevice.Name = "ResetDevice";
            this.ResetDevice.Size = new Size(160, 0x16);
            this.ResetDevice.Text = "Reset Device";
            this.TimerGetSamples.Tick += new EventHandler(this.TimerGetSamples_Tick);
            this.TimerUpdateTCPLogMessage.Interval = 500;
            this.TimerUpdateTCPLogMessage.Tick += new EventHandler(this.TimerUpdateTCPLogMessage_Tick);
            this.toolStripCommBar.ResumeLayout(false);
            this.toolStripCommBar.PerformLayout();
            this.menuStripCommMenu.ResumeLayout(false);
            this.menuStripCommMenu.PerformLayout();
        }

        private void MessageToLogFromSetting(string str)
        {
            if ((base.OnMessageToLog != null) && (str != ""))
            {
                base.OnMessageToLog(str);
            }
        }

        private void ResetDevice_Click(object sender, EventArgs e)
        {
            string strMessage = this.DeviceType.ToString() + " not connected";
            if (base.DeviceConnected)
            {
                strMessage = "";
                if (MessageBox.Show("Resetting the device the connection will be lost.\nA re-connection needs to work with the device.\n\nAre you sure to reset device?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strMessage = "Fail to reset " + this.DeviceType.ToString();
                    if (this.sdk2Com.ResetDevice() == INEMO2_DeviceError.INEMO2_ERROR_NONE)
                    {
                        this.toolStripBtnConnect.PerformClick();
                        strMessage = this.DeviceType.ToString() + "  Resetted";
                    }
                }
            }
            if ((base.OnMessageToLog != null) && (strMessage != ""))
            {
                base.OnMessageToLog(strMessage);
            }
        }

        private void Samples_Click(object sender, EventArgs e)
        {
            this.toolStripCmbMode.SelectedIndex = 0;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            this.dlgCom.ShowDialog();
            if (base.OnCommunicationSettings_Change != null)
            {
                base.OnCommunicationSettings_Change();
            }
        }

        private void StartStopEnabler(bool start)
        {
            this.TimerGetSamples.Enabled = start;
            this.toolStripBtnStart.Enabled = !start;
            this.Start.Enabled = this.toolStripBtnStart.Enabled;
            this.toolStripBtnStop.Enabled = start;
            this.Stop.Enabled = this.toolStripBtnStop.Enabled;
            this.toolStripBtnSensorSetting.Enabled = !start;
            this.SensorSetting.Enabled = !start;
            this.toolStripTxtSamples.Enabled = !start;
            this.toolStripCmbMode.Enabled = !start;
            this.ResetDevice.Enabled = !start;
            this.Enter_DFU_Mode.Enabled = !start;
            this.toolStripProgressBarAcqSample.Value = 0;
        }

        private static byte[] StructureToByteArray(object obj)
        {
            int cb = Marshal.SizeOf(obj);
            byte[] destination = new byte[cb];
            IntPtr ptr = Marshal.AllocHGlobal(cb);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, destination, 0, cb);
            Marshal.FreeHGlobal(ptr);
            return destination;
        }

        public void TCPMessage(string message)
        {
            this.TCPMessages.Add(message);
        }

        private void TimerGetSamples_Tick(object sender, EventArgs e)
        {
            bool flag = false;
            if (base.DeviceConnected)
            {
                while (this.sdk2Com.GetSample(ref this.DeviceData) == INEMO2_DeviceError.INEMO2_ERROR_NONE)
                {
                    this.UpdateInfoToolbar(this.DeviceData.TimeStamp);
                    if (base.OnDataReceived != null)
                    {
                        flag = !base.OnDataReceived(this.DeviceData);
                    }
                    if (this.m_Server != null)
                    {
                        this.m_Server.SendDataToAllClients(StructureToByteArray(this.DeviceData));
                    }
                    if (flag || ((this.toolStripCmbMode.SelectedIndex == 0) && (this.DeviceData.TimeStamp == (this.TimeStampDelta * (this.NumSamples - 1)))))
                    {
                        this.toolStripBtnStop.PerformClick();
                    }
                }
            }
        }

        private void TimerUpdateTCPLogMessage_Tick(object sender, EventArgs e)
        {
            lock (this.TCPMessages)
            {
                for (int i = 0; i < this.TCPMessages.Count; i++)
                {
                    if ((this.TCPMessages[i] != "") && (base.OnMessageToLog != null))
                    {
                        base.OnMessageToLog(this.TCPMessages[i]);
                    }
                }
                this.TCPMessages.Clear();
            }
        }

        private void toolStripBtnConnect_Click(object sender, EventArgs e)
        {
            string strMessage = DeviceType.ToString() + " Disconnected";
            sdk2Com.AHRS_Enabled = false;
            if (base.DeviceConnected)
            {
                if (TimerGetSamples.Enabled)
                    toolStripBtnStop.PerformClick();
                sdk2Com.Disconnect();
                availableModules = INEMO2_MODULES.INEMO2_MODULES_NONE;
            }
            else if (this.sdk2Com.Connect(base.ConnectionString) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
                strMessage = this.DeviceType.ToString() + "  not recognized on " + base.CommunicationPort;

            base.DeviceConnected = sdk2Com.IsConnected();
            toolStripBtnConnect.Checked = base.DeviceConnected;
            Connect.Checked = base.DeviceConnected;
            Settings.Enabled = !base.DeviceConnected;
            toolStripBtnSensorSetting.Enabled = base.DeviceConnected;
            SensorSetting.Enabled = base.DeviceConnected;
            if (base.DeviceConnected)
            {
                availableModules = INEMO2_MODULES.INEMO2_MODULES_NONE;
                sdk2Com.GetModules(ref availableModules);
                sdk2Com.AHRS_Enabled = ModuleAHRS;
                toolStripBtnStart.Enabled = true;
                toolStripBtnStop.Enabled = false;
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog(DeviceType.ToString() + " Connected @ " + base.CommunicationPort);
                }
                string[] fWOnlyVer = FWOnlyVer;
                dlgSensorSetting.GoodVersion = true;
                try
                {
                    if (fWOnlyVer.Length < 2)
                    {
                        throw new InvalidExpressionException("Invalid Number of version digits");
                    }
                    if (VersionToUint64(Convert.ToUInt16(fWOnlyVer[0]), Convert.ToUInt16(fWOnlyVer[1])) < VersionToUint64(2, 2))
                    {
                        throw new InvalidExpressionException("Invalid version number");
                    }
                }
                catch
                {
                    dlgSensorSetting.GoodVersion = false;
                    MessageBox.Show(DeviceType.ToString() + " device firmware not upgraded!\n\nUpgrade the firmware to the version 2.2.0 or higher to use all application functionalities.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (base.OnMessageToLog != null)
                    {
                        base.OnMessageToLog(DeviceType.ToString() + " device firmware not upgraded!");
                    }
                }
                dlgSensorSetting.HWVersion = HardwareVersion;
                dlgSensorSetting.FWVersion = FirmwareVersion;
                dlgSensorSetting.DevGuid = MCUID;
                dlgSensorSetting.SWVersion = Application.ProductName + " " + Application.ProductVersion;
                dlgSensorSetting.CtrlVersion = Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                dlgSensorSetting.LoadDeviceDataSettings();
                if (base.OnCommunicationSettings_Change != null)
                {
                    base.OnCommunicationSettings_Change();
                }
                if (dlgCom.EnableServer)
                {
                    m_Server = new TCPServer(dlgCom.IpPort);
                    m_Server.OnMessageToLog = (MessageToLog) Delegate.Combine(m_Server.OnMessageToLog, new MessageToLog(TCPMessage));
                    if (m_Server.StartServer())
                    {
                        TimerUpdateTCPLogMessage.Enabled = true;
                        if (base.OnMessageToLog != null)
                        {
                            base.OnMessageToLog("TCP/IP server for demos @ " + m_Server.ServerInfo + " started");
                        }
                    }
                    else
                    {
                        if (base.OnMessageToLog != null)
                        {
                            base.OnMessageToLog("TCP/IP server for demos @ " + m_Server.ServerInfo + " failed to start");
                        }
                        MessageBox.Show("The demo server failed to start on port " + dlgCom.IpPort + ".\nTry to change the port number on communication settings dialog\nand to connect again to the device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            else
            {
                toolStripBtnStart.Enabled = false;
                toolStripBtnStop.Enabled = false;
                if ((m_Server != null) && m_Server.Started)
                {
                    m_Server.StopServer();
                    m_Server = null;
                    TimerUpdateTCPLogMessage.Enabled = false;
                    if (base.OnMessageToLog != null)
                    {
                        base.OnMessageToLog("TCP/IP server for demos stopped");
                    }
                }
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog(strMessage);
                }
            }
            if ((m_Server != null) && m_Server.Started)
            {
                if (base.OnTCPState_Change != null)
                {
                    base.OnTCPState_Change(TCP_State.TCP_STATE_SERVER_START, "TCP/IP Demo server started");
                }
            }
            else if (base.OnTCPState_Change != null)
            {
                base.OnTCPState_Change(TCP_State.TCP_STATE_SERVER_STOP, "TCP/IP Demo server stopped");
            }
        }

        private void toolStripBtnSensorSetting_Click(object sender, EventArgs e)
        {
            if (base.DeviceConnected && !AcquisitionStarted)
            {
                dlgSensorSetting.ShowSettingDialog(ModuleAHRS);
                if (base.OnCommunicationSettings_Change != null)
                {
                    base.OnCommunicationSettings_Change();
                }
            }
        }

        private void toolStripBtnStart_Click(object sender, EventArgs e)
        {
            if (base.DeviceConnected)
            {
                if (base.OnStart != null)
                {
                    base.OnStart();
                }
                if (base.StartAcquisition == DateTime.MinValue)
                {
                    base.StartAcquisition = DateTime.Now;
                }
                toolStripLblNumSamples.Text = "";
                StartStopEnabler(true);
                int nSamples = 0;
                if (toolStripCmbMode.SelectedIndex == 0)
                {
                    nSamples = NumSamples;
                }
                sdk2Com.Start(dlgSensorSetting.OutputMode, dlgSensorSetting.OutputData, Sampling, nSamples);
                if ((m_Server != null) && (base.OnTCPState_Change != null))
                {
                    base.OnTCPState_Change(TCP_State.TCP_STATE_SENDING_DATA, "TCP/IP Demo server > sending data to clients");
                }
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("Start aquisition " + CommSettingsInfo);
                }
            }
        }

        private void toolStripBtnStop_Click(object sender, EventArgs e)
        {
            if (TimerGetSamples.Enabled)
            {
                sdk2Com.Stop();
                StartStopEnabler(false);
                if (base.OnStop != null)
                {
                    base.OnStop();
                }
                if ((m_Server != null) && (base.OnTCPState_Change != null))
                {
                    base.OnTCPState_Change(TCP_State.TCP_STATE_SERVER_START, "TCP/IP Demo server started");
                }
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("Stop aquisition");
                }
            }
        }

        private void toolStripCmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Samples.Checked = toolStripCmbMode.SelectedIndex == 0;
            Continous.Checked = !Samples.Checked;
            if (toolStripCmbMode.SelectedIndex == 0)
            {
                toolStripTxtSamples.Visible = true;
                toolStripProgressBarAcqSample.Visible = true;
                toolStripLblNumSamples.Visible = false;
            }
            else
            {
                toolStripTxtSamples.Visible = false;
                toolStripProgressBarAcqSample.Visible = false;
                toolStripLblNumSamples.Visible = true;
            }
            if (base.OnCommunicationSettings_Change != null)
            {
                base.OnCommunicationSettings_Change();
            }
        }

        private void toolStripTxtSamples_TextChanged(object sender, EventArgs e)
        {
            if (base.OnCommunicationSettings_Change != null)
            {
                base.OnCommunicationSettings_Change();
            }
        }

        private void Trace_Click(object sender, EventArgs e)
        {
            if (Trace.Enabled && (dbgTrace == null))
            {
                dbgTrace = new DebugTrace();
                dbgTrace.Device = sdk2Com;
                dbgTrace.Disposed += new EventHandler(dbgTrace_Disposed);
                dbgTrace.Show();
                Trace.Enabled = false;
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("TRACE Window opened");
                }
            }
        }

        private void UpdateInfoToolbar(uint Sample)
        {
            try
            {
                if (toolStripCmbMode.SelectedIndex == 0)
                {
                    if (Sample > 0)
                    {
                        toolStripProgressBarAcqSample.Value = (int) ((((double) Sample) / ((double) (NumSamples * TimeStampDelta))) * 100.0);
                    }
                }
                else
                {
                    toolStripLblNumSamples.Text = ((uint) (((double) (Sample + 1)) / ((double) TimeStampDelta))).ToString();
                }
            }
            catch
            {
            }
        }

        public ulong VersionToUint64(ushort major, ushort minor)
        {
            return (ulong) ((major * 0x3e8) + minor);
        }

        public bool AcquisitionStarted
        {
            get
            {
                return TimerGetSamples.Enabled;
            }
        }

        public override string CommSettingsInfo
        {
            get
            {
                string str = (("Port: " + base.CommunicationPort) + ", Sampling: " + Sampling.ToString() + " (Hz)") + ", Acquistion Mode: " + toolStripCmbMode.Text;
                if (toolStripCmbMode.SelectedIndex == 0)
                {
                    str = str + " [" + NumSamples.ToString() + "]";
                    if (toolStripTxtSamples.Text.Length > 0)
                    {
                        object obj2 = str;
                        str = string.Concat(new object[] { obj2, ", Duration: ", ((double) (TimeStampDelta * NumSamples)) / 1000.0, " (s)" });
                    }
                }
                if (IsModeAHRSEnabled)
                {
                    str = str + " - AHRS [Enabled]";
                }
                return str;
            }
        }

        public override string DeviceNickName
        {
            get
            {
                return "iNEMO2";
            }
        }

        public override DeviceSensorDataAvailable DeviceSensors
        {
            get
            {
                if (!base.DeviceConnected)
                {
                    return DeviceSensorDataAvailable.DSDA_ALL;
                }
                DeviceSensorDataAvailable available = DeviceSensorDataAvailable.DSDA_NONE;
                if ((dlgSensorSetting.OutputData & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_ACC) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_ACC)
                {
                    available |= DeviceSensorDataAvailable.DSDA_ACELEROMETER;
                }
                if ((dlgSensorSetting.OutputData & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_GYRO) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_GYRO)
                {
                    available |= DeviceSensorDataAvailable.DSDA_GYROSCOPE;
                }
                if ((dlgSensorSetting.OutputData & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_MAG) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_MAG)
                {
                    available |= DeviceSensorDataAvailable.DSDA_MAGNETOMER;
                }
                if ((dlgSensorSetting.OutputData & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_PRESS) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_PRESS)
                {
                    available |= DeviceSensorDataAvailable.DSDA_PRESSURE;
                }
                if ((dlgSensorSetting.OutputData & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_TEMP) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_TEMP)
                {
                    available |= DeviceSensorDataAvailable.DSDA_TEMPERATURE;
                }
                if ((dlgSensorSetting.OutputMode & INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_AHRS) == INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_AHRS)
                {
                    available |= DeviceSensorDataAvailable.DSDA_ROTATION;
                    available |= DeviceSensorDataAvailable.DSDA_QUATERNION;
                }
                return available;
            }
        }

        public override DeviceManaged DeviceType
        {
            get
            {
                return DeviceManaged.STEVAL_MKI062V2;
            }
        }

        public override string FirmwareVersion
        {
            get
            {
                string str;
                string str2;
                if (sdk2Com.GetInfo(INEMO2_DeviceInfoText.INEMO2_INFOTEXT_FW_VERSION, out str) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
                {
                    str = "";
                }
                if (sdk2Com.GetInfo(INEMO2_DeviceInfoText.INEMO2_INFOTEXT_AHRS_LIBRARY, out str2) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
                {
                    str2 = "";
                }
                if (str2 != "")
                {
                    str = str + " - " + str2;
                }
                if (str != "")
                {
                    str = "Firmware :" + str;
                }
                return str;
            }
        }

        public string[] FWOnlyVer
        {
            get
            {
                string str;
                if (sdk2Com.GetInfo(INEMO2_DeviceInfoText.INEMO2_INFOTEXT_FW_VERSION, out str) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
                {
                    str = "";
                }
                str = str.Trim();
                str = str.Substring(str.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }));
                if (str != "")
                {
                    return str.Split(new char[] { '.' });
                }
                return new string[0];
            }
        }

        public override string HardwareVersion
        {
            get
            {
                string str;
                if (sdk2Com.GetInfo(INEMO2_DeviceInfoText.INEMO2_INFOTEXT_HW_VERSION, out str) == INEMO2_DeviceError.INEMO2_ERROR_NONE)
                {
                    return ("Hardware :" + str);
                }
                return "";
            }
        }

        public ushort IPServerPort
        {
            get
            {
                return dlgCom.IpPort;
            }
        }

        public override bool IsModeAHRSEnabled
        {
            get
            {
                return ((dlgSensorSetting.OutputMode & INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_AHRS) == INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_AHRS);
            }
        }

        public override ToolStripItemCollection LocalMenuBarTool
        {
            get
            {
                return menuStripCommMenu.Items;
            }
        }

        public override ToolStrip LocalToolBar
        {
            get
            {
                return toolStripCommBar;
            }
        }

        public override string MCUID
        {
            get
            {
                string str;
                if (sdk2Com.GetInfo(INEMO2_DeviceInfoText.INEMO2_INFOTEXT_MCUID, out str) == INEMO2_DeviceError.INEMO2_ERROR_NONE)
                {
                    return ("MCU ID :{" + str + "}");
                }
                return "";
            }
        }

        public bool ModuleAHRS
        {
            get
            {
                return ((availableModules & INEMO2_MODULES.INEMO2_MODULES_AHRS) == INEMO2_MODULES.INEMO2_MODULES_AHRS);
            }
        }

        public bool ModuleTrace
        {
            get
            {
                return ((availableModules & INEMO2_MODULES.INEMO2_MODULES_TRACE) == INEMO2_MODULES.INEMO2_MODULES_TRACE);
            }
        }

        private int NumSamples
        {
            get
            {
                if (toolStripTxtSamples.Text == "")
                {
                    return (int) toolStripTxtSamples.MinValue;
                }
                return Convert.ToInt32(toolStripTxtSamples.Text);
            }
        }

        private int Sampling
        {
            get
            {
                return dlgSensorSetting.Frequency;
            }
        }

        private uint TimeStampDelta
        {
            get
            {
                return (uint) (1000.0 / ((double) Sampling));
            }
        }

        private enum StartMode
        {
            Mode_Normal,
            Mode_AHRS
        }
    }
}

