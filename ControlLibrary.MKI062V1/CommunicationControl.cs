﻿namespace ControlLibrary.MKI062V1
{
    using ControlLibrary;
    using ControlLibrary.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class CommunicationControl : CommunicationBase
    {
        private ToolStripMenuItem Acquisition;
        private ToolStripMenuItem Communication;
        private IContainer components;
        private ToolStripMenuItem Connect;
        private ToolStripMenuItem Continous;
        private ComSettings dlgCom;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Samples;
        private iNEMO_SDK_Wrapper sdkCom;
        private ToolStripMenuItem Settings;
        private ToolStripMenuItem Start;
        private ToolStripMenuItem Stop;
        private Timer timer1;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton10;
        private ToolStripButton toolStripButton11;
        private ToolStripButton toolStripButton13;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripComboBox toolStripComboBox2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSCTexBox toolStripTextBox2;

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
            toolStripLabel1.Text = "";
        }

        private void Continous_Click(object sender, EventArgs e)
        {
            toolStripComboBox2.SelectedIndex = 1;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitComponent()
        {
            dlgCom = new ComSettings();
            sdkCom = new iNEMO_SDK_Wrapper();
            toolStripTextBox2.Text = "1000";
            Settings.Click += new EventHandler(Settings_Click);
            toolStripComboBox1.SelectedIndexChanged += new EventHandler(toolStripComboBox1_SelectedIndexChanged);
            toolStripComboBox2.SelectedIndexChanged += new EventHandler(toolStripComboBox2_SelectedIndexChanged);
            toolStripButton10.Click += new EventHandler(toolStripButton10_Click);
            toolStripButton11.Click += new EventHandler(toolStripButton11_Click);
            toolStripButton13.Click += new EventHandler(toolStripButton13_Click);
            Connect.Click += new EventHandler(toolStripButton10_Click);
            Start.Click += new EventHandler(toolStripButton11_Click);
            Stop.Click += new EventHandler(toolStripButton13_Click);
            toolStripTextBox2.TextChanged += new EventHandler(toolStripTextBox2_TextChanged);
            Samples.Click += new EventHandler(Samples_Click);
            Continous.Click += new EventHandler(Continous_Click);
            timer1.Interval = 30;
            timer1.Enabled = false;
            base.DeviceConnected = false;
            Settings.Enabled = false;
            toolStripButton11.Enabled = false;
            toolStripButton13.Enabled = false;
            toolStripLabel1.Visible = false;
            Start.Enabled = false;
            Stop.Enabled = false;
            toolStripProgressBar1.Visible = true;
            toolStripComboBox2.SelectedIndex = 0;
            toolStripComboBox1.SelectedIndex = toolStripComboBox1.Items.Count - 1;
            Clear();
        }

        private void InitializeComponent()
        {
            components = new Container();
            toolStrip2 = new ToolStrip();
            toolStripButton10 = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripComboBox2 = new ToolStripComboBox();
            toolStripButton11 = new ToolStripButton();
            toolStripButton13 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripProgressBar1 = new ToolStripProgressBar();
            menuStrip1 = new MenuStrip();
            Communication = new ToolStripMenuItem();
            Connect = new ToolStripMenuItem();
            Acquisition = new ToolStripMenuItem();
            Samples = new ToolStripMenuItem();
            Continous = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            Start = new ToolStripMenuItem();
            Stop = new ToolStripMenuItem();
            Settings = new ToolStripMenuItem();
            timer1 = new Timer(components);
            toolStripLabel1 = new ToolStripLabel();
            toolStripTextBox2 = new ToolStripSCTexBox();
            toolStrip2.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton10, toolStripSeparator5, toolStripComboBox1, toolStripComboBox2, toolStripTextBox2, toolStripButton11, toolStripButton13, toolStripSeparator2, toolStripProgressBar1, toolStripLabel1 });
            toolStrip2.Location = new Point(0, 0x30);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(0x29f, 0x19);
            toolStrip2.TabIndex = 10;
            toolStrip2.Text = "Acquisition toolbar";
            toolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton10.Image = Resources.Connect;
            toolStripButton10.ImageTransparentColor = Color.Magenta;
            toolStripButton10.Name = "toolStripButton10";
            toolStripButton10.Size = new Size(0x17, 0x16);
            toolStripButton10.Text = "Connect";
            toolStripButton10.ToolTipText = "Connect/Disconnect";
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 0x19);
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.Items.AddRange(new object[] { "1", "10", "25", "50" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(0x4b, 0x19);
            toolStripComboBox1.ToolTipText = "Data acquisition frequency (Hz)";
            toolStripComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox2.Items.AddRange(new object[] { "Samples", "Continous" });
            toolStripComboBox2.Name = "toolStripComboBox2";
            toolStripComboBox2.Size = new Size(90, 0x19);
            toolStripComboBox2.ToolTipText = "Acquisition Mode";
            toolStripButton11.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton11.Image = Resources.StartAcquistion;
            toolStripButton11.ImageTransparentColor = Color.Magenta;
            toolStripButton11.Name = "toolStripButton11";
            toolStripButton11.Size = new Size(0x17, 0x16);
            toolStripButton11.Text = "Start";
            toolStripButton13.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton13.Image = Resources.StopAcquistion;
            toolStripButton13.ImageTransparentColor = Color.Magenta;
            toolStripButton13.Name = "toolStripButton13";
            toolStripButton13.Size = new Size(0x17, 0x16);
            toolStripButton13.Text = "Stop";
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 0x19);
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 0x16);
            toolStripProgressBar1.Step = 2;
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar1.ToolTipText = "Acquisition progress";
            menuStrip1.Items.AddRange(new ToolStripItem[] { Communication });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(200, 0x18);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            Communication.DropDownItems.AddRange(new ToolStripItem[] { Connect, Acquisition, Settings });
            Communication.Name = "Communication";
            Communication.Size = new Size(0x5b, 20);
            Communication.Text = "Communication";
            Connect.Name = "Connect";
            Connect.Size = new Size(0x88, 0x16);
            Connect.Text = "Connect";
            Acquisition.DropDownItems.AddRange(new ToolStripItem[] { Samples, Continous, toolStripSeparator1, Start, Stop });
            Acquisition.Name = "Acquisition";
            Acquisition.Size = new Size(0x88, 0x16);
            Acquisition.Text = "Acquisition";
            Samples.Checked = true;
            Samples.CheckState = CheckState.Checked;
            Samples.Name = "Samples";
            Samples.Size = new Size(0x85, 0x16);
            Samples.Text = "Samples";
            Continous.Name = "Continous";
            Continous.Size = new Size(0x85, 0x16);
            Continous.Text = "Continous";
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(130, 6);
            Start.Name = "Start";
            Start.Size = new Size(0x85, 0x16);
            Start.Text = "Start";
            Stop.Name = "Stop";
            Stop.Size = new Size(0x85, 0x16);
            Stop.Text = "Stop";
            Settings.Name = "Settings";
            Settings.Size = new Size(0x88, 0x16);
            Settings.Text = "Settings...";
            timer1.Tick += new EventHandler(timer1_Tick);
            toolStripLabel1.AutoSize = false;
            toolStripLabel1.BackColor = SystemColors.Info;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(70, 0x16);
            toolStripLabel1.TextAlign = ContentAlignment.MiddleRight;
            toolStripLabel1.ToolTipText = "Number of samples";
            toolStripTextBox2.AcceptOnlyNumber = true;
            toolStripTextBox2.MaxLength = 5;
            toolStripTextBox2.MaxValue = 0xffffL;
            toolStripTextBox2.MinValue = 1L;
            toolStripTextBox2.Name = "toolStripTextBox2";
            toolStripTextBox2.Size = new Size(80, 0x15);
            toolStripTextBox2.TextBoxAlign = HorizontalAlignment.Right;
            toolStripTextBox2.ToolTipText = "Number of samples (Max 65535)";
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
        }

        private void Samples_Click(object sender, EventArgs e)
        {
            toolStripComboBox2.SelectedIndex = 0;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            dlgCom.ShowDialog();
            if (base.OnCommunicationSettings_Change != null)
            {
                base.OnCommunicationSettings_Change();
            }
        }

        private void StartStopEnabler(bool start)
        {
            timer1.Enabled = start;
            toolStripButton11.Enabled = !start;
            Start.Enabled = toolStripButton11.Enabled;
            toolStripButton13.Enabled = start;
            Stop.Enabled = toolStripButton13.Enabled;
            toolStripTextBox2.Enabled = !start;
            toolStripComboBox1.Enabled = !start;
            toolStripComboBox2.Enabled = !start;
            toolStripProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FrameData data = new FrameData();
            bool flag = false;
            if (base.DeviceConnected)
            {
                while (sdkCom.GetSample(ref data) == 0)
                {
                    UpdateInfoToolbar(data.TimeStamp);
                    if (base.OnDataReceived != null)
                    {
                        flag = !base.OnDataReceived(data);
                    }
                    if (flag || ((toolStripComboBox2.SelectedIndex == 0) && (data.TimeStamp == (TimeStampDelta * (NumSamples - 1)))))
                    {
                        toolStripButton13.PerformClick();
                    }
                }
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            string str;
            if (base.DeviceConnected)
            {
                if (timer1.Enabled)
                {
                    toolStripButton13.PerformClick();
                }
                sdkCom.Disconnect();
                str = DeviceType.ToString() + " Disconnected";
            }
            else if (sdkCom.Connect(base.ConnectionString) == 0)
            {
                str = DeviceType.ToString() + " Connected @ " + base.CommunicationPort;
            }
            else
            {
                str = DeviceType.ToString() + "  not recognized on " + base.CommunicationPort;
            }
            base.DeviceConnected = sdkCom.IsConnected();
            toolStripButton10.Checked = base.DeviceConnected;
            Connect.Checked = base.DeviceConnected;
            if (base.DeviceConnected)
            {
                toolStripButton11.Enabled = true;
                toolStripButton13.Enabled = false;
            }
            else
            {
                toolStripButton11.Enabled = false;
                toolStripButton13.Enabled = false;
            }
            if (base.OnMessageToLog != null)
            {
                base.OnMessageToLog(str);
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
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
                toolStripLabel1.Text = "";
                StartStopEnabler(true);
                int nSamples = 0;
                if (toolStripComboBox2.SelectedIndex == 0)
                {
                    nSamples = NumSamples;
                }
                sdkCom.Start(Sampling, nSamples);
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("Start aquisition " + CommSettingsInfo);
                }
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                sdkCom.Stop();
                StartStopEnabler(false);
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("Stop aquisition");
                }
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (base.OnCommunicationSettings_Change != null)
            {
                base.OnCommunicationSettings_Change();
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Samples.Checked = toolStripComboBox2.SelectedIndex == 0;
            Continous.Checked = !Samples.Checked;
            if (toolStripComboBox2.SelectedIndex == 0)
            {
                toolStripTextBox2.Visible = true;
                toolStripProgressBar1.Visible = true;
                toolStripLabel1.Visible = false;
            }
            else
            {
                toolStripTextBox2.Visible = false;
                toolStripProgressBar1.Visible = false;
                toolStripLabel1.Visible = true;
            }
            if (base.OnCommunicationSettings_Change != null)
            {
                base.OnCommunicationSettings_Change();
            }
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (base.OnCommunicationSettings_Change != null)
            {
                base.OnCommunicationSettings_Change();
            }
        }

        private void UpdateInfoToolbar(uint Sample)
        {
            try
            {
                if (toolStripComboBox2.SelectedIndex == 0)
                {
                    if (Sample > 0)
                    {
                        toolStripProgressBar1.Value = (int) ((((double) Sample) / ((double) (NumSamples * TimeStampDelta))) * 100.0);
                    }
                }
                else
                {
                    toolStripLabel1.Text = ((uint) (((double) (Sample + 1)) / ((double) TimeStampDelta))).ToString();
                }
            }
            catch
            {
            }
        }

        public override string CommSettingsInfo
        {
            get
            {
                string str = (("Port: " + base.CommunicationPort) + ", Sampling: " + toolStripComboBox1.Text + " (Hz)") + ", Acquistion Mode: " + toolStripComboBox2.Text;
                if (toolStripComboBox2.SelectedIndex == 0)
                {
                    str = str + " [" + NumSamples.ToString() + "]";
                    if (toolStripTextBox2.Text.Length > 0)
                    {
                        object obj2 = str;
                        str = string.Concat(new object[] { obj2, ", Duration: ", ((double) (TimeStampDelta * NumSamples)) / 1000.0, " (s)" });
                    }
                }
                return str;
            }
        }

        public override string DeviceNickName
        {
            get
            {
                return "iNEMO";
            }
        }

        public override DeviceSensorDataAvailable DeviceSensors
        {
            get
            {
                return (DeviceSensorDataAvailable.DSDA_ACELEROMETER | DeviceSensorDataAvailable.DSDA_GYROSCOPE | DeviceSensorDataAvailable.DSDA_MAGNETOMER | DeviceSensorDataAvailable.DSDA_PRESSURE | DeviceSensorDataAvailable.DSDA_TEMPERATURE);
            }
        }

        public override DeviceManaged DeviceType
        {
            get
            {
                return DeviceManaged.STEVAL_MKI062V1;
            }
        }

        public override string FirmwareVersion
        {
            get
            {
                string str;
                sdkCom.GetVersion(out str);
                return str;
            }
        }

        public override string HardwareVersion
        {
            get
            {
                return "";
            }
        }

        public override bool IsModeAHRSEnabled
        {
            get
            {
                return false;
            }
        }

        public override ToolStripItemCollection LocalMenuBarTool
        {
            get
            {
                return menuStrip1.Items;
            }
        }

        public override ToolStrip LocalToolBar
        {
            get
            {
                return toolStrip2;
            }
        }

        public override string MCUID
        {
            get
            {
                return "";
            }
        }

        private int NumSamples
        {
            get
            {
                if (toolStripTextBox2.Text == "")
                {
                    return (int) toolStripTextBox2.MinValue;
                }
                return Convert.ToInt32(toolStripTextBox2.Text);
            }
        }

        private int Sampling
        {
            get
            {
                return Convert.ToInt32(toolStripComboBox1.Text);
            }
        }

        private uint TimeStampDelta
        {
            get
            {
                return (uint) (1000.0 / ((double) Sampling));
            }
        }
    }
}

