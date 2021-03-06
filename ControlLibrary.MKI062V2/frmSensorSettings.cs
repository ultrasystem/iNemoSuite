﻿namespace ControlLibrary.MKI062V2
{
    using ControlLibrary;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class frmSensorSettings : Form
    {
        private Button btnACCRestore;
        private Button btnCancel;
        private Button btnGyrRestore;
        private Button btnMagRestore;
        private Button btnOK;
        private Button btnPressRestore;
        private Button btnTempRestore;
        private CheckBox chkACC_HPF;
        private CheckBox chkAcc_HPF_Ref;
        private CheckBox chkOutAcc;
        private CheckBox chkOutAHRS;
        private CheckBox chkOutGyr;
        private CheckBox chkOutMag;
        private CheckBox chkOutPres;
        private CheckBox chkOutRawData;
        private CheckBox chkOutTemp;
        private ComboBox cmbACC_HPF_ODR;
        private ComboBox cmbAccFS;
        private ComboBox cmbAccODR;
        private ComboBox cmbFS_RP;
        private ComboBox cmbFS_Y;
        private ComboBox cmbMagFS;
        private ComboBox cmbMagODR;
        private ComboBox cmbMagOM;
        private ComboBox cmbOutFreq;
        private ComboBox cmbPresODR;
        private IContainer components;
        private const string FileVersion = "FILE VERSION 1.0.0";
        private INEMO2_Output getRegOutPut;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private NumericUpDown intACC_HPF_RefValue;
        private NumericUpDown intACCOffset_X;
        private NumericUpDown intACCOffset_Y;
        private NumericUpDown intACCOffset_Z;
        private NumericUpDown intGyrOffset_P;
        private NumericUpDown intGyrOffset_R;
        private NumericUpDown intGyrOffset_Y;
        private NumericUpDown intMagOffset_X;
        private NumericUpDown intMagOffset_Y;
        private NumericUpDown intMagOffset_Z;
        private NumericUpDown intPressOffset;
        private NumericUpDown intTempOffset;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label32;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private string m_CtrlVersion;
        private string m_DevGuid;
        private string m_FWVersion;
        private bool m_GoodVersion;
        private string m_HWVersion;
        private string m_SWVersion;
        public MessageToLog OnMessageToLogSettings;
        private OpenFileDialog openFileDialogCfg;
        private SaveFileDialog saveFileDialogCfg;
        private INEMO2_Device sdk2comm;
        private bool SettingsChanged_Acc;
        private bool SettingsChanged_Gyr;
        private bool SettingsChanged_Mag;
        private bool SettingsChanged_Out;
        private bool SettingsChanged_Pres;
        private bool SettingsChanged_Temp;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripBtnExport;
        private ToolStripButton toolStripBtnImport;
        private ToolTip toolTip1;
        private TextBox txtACC_HPF_Cutoff;

        public frmSensorSettings(INEMO2_Device comm)
        {
            this.InitializeComponent();
            this.sdk2comm = comm;
            foreach (TabPage page in this.tabControl1.TabPages)
            {
                foreach (Control control in page.Controls)
                {
                    if (control is ComboBox)
                    {
                        ((ComboBox) control).SelectedIndex = 0;
                    }
                }
            }
            this.cmbACC_HPF_ODR.SelectedIndex = 0;
            this.SettingsChanged_Out = false;
            this.SettingsChanged_Acc = false;
            this.SettingsChanged_Mag = false;
            this.SettingsChanged_Gyr = false;
            this.SettingsChanged_Pres = false;
            this.SettingsChanged_Temp = false;
            this.getRegOutPut = new INEMO2_Output();
        }

        private void btnACCRestore_Click(object sender, EventArgs e)
        {
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 0);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 1);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 2);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 3);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 4);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 5);
            this.SettingsChanged_Acc = this.LoadDeviceDataSettings_Acc();
        }

        private void btnGyrRestore_Click(object sender, EventArgs e)
        {
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_RP, 1);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_RP, 2);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_Y, 1);
            this.SettingsChanged_Gyr = this.LoadDeviceDataSettings_Gyr();
        }

        private void btnMagRestore_Click(object sender, EventArgs e)
        {
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 0);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 1);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 2);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 3);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 4);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 5);
            this.SettingsChanged_Mag = this.LoadDeviceDataSettings_Mag();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPressRestore_Click(object sender, EventArgs e)
        {
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_PRESS, 0);
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_PRESS, 1);
            this.SettingsChanged_Pres = this.LoadDeviceDataSettings_Pres();
        }

        private void btnTempRestore_Click(object sender, EventArgs e)
        {
            this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_TEMP, 0);
            this.SettingsChanged_Temp = this.LoadDeviceDataSettings_Temp();
        }

        private short ByteArrayToInt16(byte[] buf)
        {
            return (short) ((buf[0] << 8) + buf[1]);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = this.chkACC_HPF.Checked;
            this.UpdateCutOff();
        }

        private void chkAccRef_CheckedChanged(object sender, EventArgs e)
        {
            this.intACC_HPF_RefValue.Enabled = this.chkAcc_HPF_Ref.Checked;
        }

        private void chkAHRS_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbOutFreq.Enabled = !this.chkOutAHRS.Checked;
            if (!this.cmbOutFreq.Enabled)
            {
                this.cmbOutFreq.SelectedIndex = 4;
            }
            if (this.chkOutAHRS.Checked)
            {
                this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 0);
                this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 1);
                this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 2);
                this.SettingsChanged_Acc = this.LoadDeviceDataSettings_Acc();
                this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 0);
                this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 1);
                this.sdk2comm.RestoreDefault(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 2);
                this.SettingsChanged_Mag = this.LoadDeviceDataSettings_Mag();
            }
            this.cmbAccODR.Enabled = !this.chkOutAHRS.Checked;
            this.cmbAccFS.Enabled = !this.chkOutAHRS.Checked;
            this.chkACC_HPF.Enabled = !this.chkOutAHRS.Checked;
            this.cmbMagODR.Enabled = !this.chkOutAHRS.Checked;
            this.cmbMagFS.Enabled = !this.chkOutAHRS.Checked;
            this.cmbMagOM.Enabled = !this.chkOutAHRS.Checked;
        }

        private void cmbACC_HPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateCutOff();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ExportConfigurationToFile(string strFileName)
        {
            StreamWriter writer = new StreamWriter(strFileName);
            this.Cursor = Cursors.WaitCursor;
            if (this.OnMessageToLogSettings != null)
            {
                this.OnMessageToLogSettings("Saving configuration file [" + strFileName + "]");
            }
            if (writer != null)
            {
                writer.WriteLine("FILE VERSION 1.0.0");
                writer.WriteLine(this.SWVersion);
                writer.WriteLine(this.CtrlVersion);
                writer.WriteLine(this.HWVersion);
                writer.WriteLine(this.FWVersion);
                writer.WriteLine(this.DevGuid);
                string str = "Output; ";
                str = (((((((str + "Accelerometer=" + this.chkOutAcc.Checked.ToString() + "; ") + "Magnetometer=" + this.chkOutMag.Checked.ToString() + "; ") + "Gyroscope=" + this.chkOutGyr.Checked.ToString() + "; ") + "Pressure=" + this.chkOutPres.Checked.ToString() + "; ") + "Temperature=" + this.chkOutTemp.Checked.ToString() + "; ") + "Raw=" + this.chkOutRawData.Checked.ToString() + "; ") + "AHRS=" + this.chkOutAHRS.Checked.ToString() + "; ") + "Frequency=" + this.cmbOutFreq.Text + "; ";
                writer.WriteLine(str);
                str = "Accelerometer; ";
                str = ((((((((str + "Offset_X=" + this.intACCOffset_X.Value.ToString() + "; ") + "Offset_Y=" + this.intACCOffset_Y.Value.ToString() + "; ") + "Offset_Z=" + this.intACCOffset_Z.Value.ToString() + "; ") + "ODR=" + this.cmbAccODR.Text + "; ") + "FS=" + this.cmbAccFS.Text + "; ") + "HPF=" + this.chkACC_HPF.Checked.ToString() + "; ") + "HPF_ODR=" + this.cmbACC_HPF_ODR.Text + "; ") + "HPF_REF=" + this.chkAcc_HPF_Ref.Checked.ToString() + "; ") + "HPF_REF_VAL=" + this.intACC_HPF_RefValue.Value.ToString() + "; ";
                writer.WriteLine(str);
                str = "Magnetometer; ";
                str = (((((str + "Offset_X=" + this.intMagOffset_X.Value.ToString() + "; ") + "Offset_Y=" + this.intMagOffset_Y.Value.ToString() + "; ") + "Offset_Z=" + this.intMagOffset_Z.Value.ToString() + "; ") + "ODR=" + this.cmbMagODR.Text + "; ") + "FS=" + this.cmbMagFS.Text + "; ") + "OM=" + this.cmbMagOM.Text + "; ";
                writer.WriteLine(str);
                str = "Gyroscope; ";
                str = ((str + "Offset_R=" + this.intGyrOffset_R.Value.ToString() + "; ") + "Offset_P=" + this.intGyrOffset_P.Value.ToString() + "; ") + "Offset_Y=" + this.intGyrOffset_Y.Value.ToString() + "; ";
                writer.WriteLine(str);
                str = "Pressure; ";
                str = (str + "Offset_P=" + this.intPressOffset.Value.ToString() + "; ") + "ODR=" + this.cmbPresODR.Text + "; ";
                writer.WriteLine(str);
                str = "Temperature; ";
                str = str + "Offset_T=" + this.intTempOffset.Value.ToString() + "; ";
                writer.WriteLine(str);
                writer.Close();
            }
            if (this.OnMessageToLogSettings != null)
            {
                this.OnMessageToLogSettings("Saved configuration file [" + strFileName + "]");
            }
            this.Cursor = Cursors.Default;
        }

        private void ImportConfigurationFromFile(string strFileToLoad)
        {
            StreamReader reader = null;
            string[] strArray3 = new string[6];
            bool flag = true;
            this.Cursor = Cursors.WaitCursor;
            if (this.OnMessageToLogSettings != null)
            {
                this.OnMessageToLogSettings("Loading configuration file [" + strFileToLoad + "]");
            }
            try
            {
                reader = new StreamReader(strFileToLoad);
            }
            catch (Exception exception)
            {
                if (this.OnMessageToLogSettings != null)
                {
                    this.OnMessageToLogSettings("Error opening the selected file :" + exception.Message);
                }
                MessageBox.Show("Error opening the selected file :" + exception.Message);
                flag = false;
            }
            if (flag)
            {
                try
                {
                    for (int i = 0; i < 6; i++)
                    {
                        strArray3[i] = reader.ReadLine();
                    }
                    if (strArray3[0].CompareTo("FILE VERSION 1.0.0") != 0)
                    {
                        MessageBox.Show("Incompatible configuration file version ", "Error", MessageBoxButtons.OK);
                        if (this.OnMessageToLogSettings != null)
                        {
                            this.OnMessageToLogSettings("Incompatible configuration file version [" + strFileToLoad + "]");
                        }
                        flag = false;
                    }
                    if ((flag && ((strArray3[1].CompareTo(this.SWVersion) != 0) || (strArray3[2].CompareTo(this.CtrlVersion) != 0))) && (MessageBox.Show("The configuration file was saved with a different software version!\n\nContinue to import?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.No))
                    {
                        flag = false;
                    }
                    if ((flag && (strArray3[3].CompareTo(this.HWVersion) != 0)) && (MessageBox.Show("The configuration file was saved for a different hardware version!\n\nContinue to import?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.No))
                    {
                        flag = false;
                    }
                    if ((flag && (strArray3[4].CompareTo(this.FWVersion) != 0)) && (MessageBox.Show("The configuration file was saved for a different Firmware version!\n\nContinue to import?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.No))
                    {
                        flag = false;
                    }
                    if ((flag && (strArray3[5].CompareTo(this.DevGuid) != 0)) && (MessageBox.Show("The configuration file was saved for a different device!\n\nContinue to import?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.No))
                    {
                        flag = false;
                    }
                }
                catch
                {
                    if (this.OnMessageToLogSettings != null)
                    {
                        this.OnMessageToLogSettings("Unkwnon header file format [" + strFileToLoad + "] ");
                    }
                    flag = false;
                }
            }
            if (flag)
            {
                string[] strArray2 = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (strArray2.Length > 0)
                {
                    foreach (string str2 in strArray2)
                    {
                        string str3;
                        string[] cfg = str2.ToLower().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if ((cfg.Length > 0) && ((str3 = cfg[0].Trim()) != null))
                        {
                            if (!(str3 == "output"))
                            {
                                if (str3 == "accelerometer")
                                {
                                    goto Label_02B2;
                                }
                                if (str3 == "magnetometer")
                                {
                                    goto Label_02BC;
                                }
                                if (str3 == "gyroscope")
                                {
                                    goto Label_02C6;
                                }
                                if (str3 == "pressure")
                                {
                                    goto Label_02D0;
                                }
                                if (str3 == "temperature")
                                {
                                    goto Label_02DA;
                                }
                            }
                            else
                            {
                                this.LoadParam_OUT(cfg);
                            }
                        }
                        continue;
                    Label_02B2:
                        this.LoadParam_ACC(cfg);
                        continue;
                    Label_02BC:
                        this.LoadParam_MAG(cfg);
                        continue;
                    Label_02C6:
                        this.LoadParam_GYR(cfg);
                        continue;
                    Label_02D0:
                        this.LoadParam_PRES(cfg);
                        continue;
                    Label_02DA:
                        this.LoadParam_TEMP(cfg);
                    }
                }
            }
            if (flag && (this.OnMessageToLogSettings != null))
            {
                this.OnMessageToLogSettings("Loaded configuration file [" + strFileToLoad + "]");
            }
            reader.Close();
            this.Cursor = Cursors.Default;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmSensorSettings));
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.label28 = new Label();
            this.cmbOutFreq = new ComboBox();
            this.chkOutAHRS = new CheckBox();
            this.chkOutRawData = new CheckBox();
            this.groupBox7 = new GroupBox();
            this.chkOutAcc = new CheckBox();
            this.chkOutTemp = new CheckBox();
            this.chkOutMag = new CheckBox();
            this.chkOutPres = new CheckBox();
            this.chkOutGyr = new CheckBox();
            this.tabPage2 = new TabPage();
            this.chkACC_HPF = new CheckBox();
            this.btnACCRestore = new Button();
            this.groupBox1 = new GroupBox();
            this.label11 = new Label();
            this.label10 = new Label();
            this.label2 = new Label();
            this.intACCOffset_X = new NumericUpDown();
            this.intACCOffset_Z = new NumericUpDown();
            this.intACCOffset_Y = new NumericUpDown();
            this.groupBox2 = new GroupBox();
            this.txtACC_HPF_Cutoff = new TextBox();
            this.label30 = new Label();
            this.intACC_HPF_RefValue = new NumericUpDown();
            this.chkAcc_HPF_Ref = new CheckBox();
            this.label5 = new Label();
            this.cmbACC_HPF_ODR = new ComboBox();
            this.label4 = new Label();
            this.cmbAccFS = new ComboBox();
            this.label3 = new Label();
            this.cmbAccODR = new ComboBox();
            this.tabPage3 = new TabPage();
            this.btnMagRestore = new Button();
            this.groupBox3 = new GroupBox();
            this.label15 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.intMagOffset_X = new NumericUpDown();
            this.intMagOffset_Z = new NumericUpDown();
            this.intMagOffset_Y = new NumericUpDown();
            this.label8 = new Label();
            this.cmbMagOM = new ComboBox();
            this.label6 = new Label();
            this.cmbMagFS = new ComboBox();
            this.label7 = new Label();
            this.cmbMagODR = new ComboBox();
            this.tabPage4 = new TabPage();
            this.btnGyrRestore = new Button();
            this.label27 = new Label();
            this.cmbFS_RP = new ComboBox();
            this.groupBox4 = new GroupBox();
            this.label21 = new Label();
            this.label22 = new Label();
            this.label23 = new Label();
            this.intGyrOffset_R = new NumericUpDown();
            this.intGyrOffset_Y = new NumericUpDown();
            this.intGyrOffset_P = new NumericUpDown();
            this.label9 = new Label();
            this.cmbFS_Y = new ComboBox();
            this.tabPage5 = new TabPage();
            this.btnPressRestore = new Button();
            this.groupBox5 = new GroupBox();
            this.label29 = new Label();
            this.intPressOffset = new NumericUpDown();
            this.label1 = new Label();
            this.cmbPresODR = new ComboBox();
            this.tabPage6 = new TabPage();
            this.btnTempRestore = new Button();
            this.groupBox6 = new GroupBox();
            this.label32 = new Label();
            this.intTempOffset = new NumericUpDown();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label18 = new Label();
            this.label19 = new Label();
            this.label20 = new Label();
            this.label24 = new Label();
            this.label25 = new Label();
            this.label26 = new Label();
            this.toolStrip1 = new ToolStrip();
            this.toolStripBtnImport = new ToolStripButton();
            this.toolStripBtnExport = new ToolStripButton();
            this.toolTip1 = new ToolTip(this.components);
            this.saveFileDialogCfg = new SaveFileDialog();
            this.openFileDialogCfg = new OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.intACCOffset_X.BeginInit();
            this.intACCOffset_Z.BeginInit();
            this.intACCOffset_Y.BeginInit();
            this.groupBox2.SuspendLayout();
            this.intACC_HPF_RefValue.BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.intMagOffset_X.BeginInit();
            this.intMagOffset_Z.BeginInit();
            this.intMagOffset_Y.BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.intGyrOffset_R.BeginInit();
            this.intGyrOffset_Y.BeginInit();
            this.intGyrOffset_P.BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.intPressOffset.BeginInit();
            this.tabPage6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.intTempOffset.BeginInit();
            this.toolStrip1.SuspendLayout();
            base.SuspendLayout();
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new Point(11, 0x1c);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x196, 0xc1);
            this.tabControl1.TabIndex = 2;
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.cmbOutFreq);
            this.tabPage1.Controls.Add(this.chkOutAHRS);
            this.tabPage1.Controls.Add(this.chkOutRawData);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new Point(4, 0x16);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new Size(0x18e, 0xa7);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "Output";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.label28.AutoSize = true;
            this.label28.Location = new Point(0x88, 0x4b);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x85, 13);
            this.label28.TabIndex = 3;
            this.label28.Text = "Acquisition Frequency (Hz)";
            this.cmbOutFreq.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOutFreq.FormattingEnabled = true;
            this.cmbOutFreq.Items.AddRange(new object[] { "1", "10", "25", "30", "50", "100", "400" });
            this.cmbOutFreq.Location = new Point(0x8b, 0x5f);
            this.cmbOutFreq.Name = "cmbOutFreq";
            this.cmbOutFreq.Size = new Size(80, 0x15);
            this.cmbOutFreq.TabIndex = 4;
            this.chkOutAHRS.AutoSize = true;
            this.chkOutAHRS.Location = new Point(0x8b, 0x2a);
            this.chkOutAHRS.Name = "chkOutAHRS";
            this.chkOutAHRS.Size = new Size(0x5e, 0x11);
            this.chkOutAHRS.TabIndex = 2;
            this.chkOutAHRS.Text = "AHRS Module";
            this.chkOutAHRS.UseVisualStyleBackColor = true;
            this.chkOutAHRS.CheckedChanged += new EventHandler(this.chkAHRS_CheckedChanged);
            this.chkOutRawData.AutoSize = true;
            this.chkOutRawData.Location = new Point(0x8b, 0x13);
            this.chkOutRawData.Name = "chkOutRawData";
            this.chkOutRawData.Size = new Size(0x48, 0x11);
            this.chkOutRawData.TabIndex = 1;
            this.chkOutRawData.Text = "Raw data";
            this.chkOutRawData.UseVisualStyleBackColor = true;
            this.groupBox7.Controls.Add(this.chkOutAcc);
            this.groupBox7.Controls.Add(this.chkOutTemp);
            this.groupBox7.Controls.Add(this.chkOutMag);
            this.groupBox7.Controls.Add(this.chkOutPres);
            this.groupBox7.Controls.Add(this.chkOutGyr);
            this.groupBox7.Location = new Point(5, 10);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0x7d, 0x87);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Sensors output";
            this.chkOutAcc.AutoSize = true;
            this.chkOutAcc.Checked = true;
            this.chkOutAcc.CheckState = CheckState.Checked;
            this.chkOutAcc.Location = new Point(10, 0x13);
            this.chkOutAcc.Name = "chkOutAcc";
            this.chkOutAcc.Size = new Size(0x5e, 0x11);
            this.chkOutAcc.TabIndex = 1;
            this.chkOutAcc.Text = "Accelerometer";
            this.chkOutAcc.UseVisualStyleBackColor = true;
            this.chkOutTemp.AutoSize = true;
            this.chkOutTemp.Checked = true;
            this.chkOutTemp.CheckState = CheckState.Checked;
            this.chkOutTemp.Location = new Point(10, 0x6f);
            this.chkOutTemp.Name = "chkOutTemp";
            this.chkOutTemp.Size = new Size(0x56, 0x11);
            this.chkOutTemp.TabIndex = 5;
            this.chkOutTemp.Text = "Temperature";
            this.chkOutTemp.UseVisualStyleBackColor = true;
            this.chkOutMag.AutoSize = true;
            this.chkOutMag.Checked = true;
            this.chkOutMag.CheckState = CheckState.Checked;
            this.chkOutMag.Location = new Point(10, 0x2a);
            this.chkOutMag.Name = "chkOutMag";
            this.chkOutMag.Size = new Size(0x5e, 0x11);
            this.chkOutMag.TabIndex = 2;
            this.chkOutMag.Text = "Magnetometer";
            this.chkOutMag.UseVisualStyleBackColor = true;
            this.chkOutPres.AutoSize = true;
            this.chkOutPres.Checked = true;
            this.chkOutPres.CheckState = CheckState.Checked;
            this.chkOutPres.Location = new Point(10, 0x58);
            this.chkOutPres.Name = "chkOutPres";
            this.chkOutPres.Size = new Size(0x43, 0x11);
            this.chkOutPres.TabIndex = 4;
            this.chkOutPres.Text = "Pressure";
            this.chkOutPres.UseVisualStyleBackColor = true;
            this.chkOutGyr.AutoSize = true;
            this.chkOutGyr.Checked = true;
            this.chkOutGyr.CheckState = CheckState.Checked;
            this.chkOutGyr.Location = new Point(10, 0x41);
            this.chkOutGyr.Name = "chkOutGyr";
            this.chkOutGyr.Size = new Size(0x4d, 0x11);
            this.chkOutGyr.TabIndex = 3;
            this.chkOutGyr.Text = "Gyroscope";
            this.chkOutGyr.UseVisualStyleBackColor = true;
            this.tabPage2.Controls.Add(this.chkACC_HPF);
            this.tabPage2.Controls.Add(this.btnACCRestore);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cmbAccFS);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cmbAccODR);
            this.tabPage2.Location = new Point(4, 0x16);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0x18e, 0xa7);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Accelerometer";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.chkACC_HPF.AutoSize = true;
            this.chkACC_HPF.BackColor = Color.White;
            this.chkACC_HPF.Location = new Point(0x105, 10);
            this.chkACC_HPF.Name = "chkACC_HPF";
            this.chkACC_HPF.Size = new Size(0x63, 0x11);
            this.chkACC_HPF.TabIndex = 5;
            this.chkACC_HPF.Text = "High Pass Filter";
            this.chkACC_HPF.UseVisualStyleBackColor = false;
            this.chkACC_HPF.CheckedChanged += new EventHandler(this.checkBox6_CheckedChanged);
            this.btnACCRestore.Location = new Point(5, 0x8d);
            this.btnACCRestore.Name = "btnACCRestore";
            this.btnACCRestore.Size = new Size(0x4b, 0x17);
            this.btnACCRestore.TabIndex = 7;
            this.btnACCRestore.Text = "Restore";
            this.toolTip1.SetToolTip(this.btnACCRestore, "Restore default value for the sensor");
            this.btnACCRestore.UseVisualStyleBackColor = true;
            this.btnACCRestore.Click += new EventHandler(this.btnACCRestore_Click);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.intACCOffset_X);
            this.groupBox1.Controls.Add(this.intACCOffset_Z);
            this.groupBox1.Controls.Add(this.intACCOffset_Y);
            this.groupBox1.Location = new Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x7d, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Offset (milli-g)";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(6, 0x4e);
            this.label11.Name = "label11";
            this.label11.Size = new Size(14, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Z";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(6, 0x34);
            this.label10.Name = "label10";
            this.label10.Size = new Size(14, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Y";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 0x1a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(14, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "X";
            this.intACCOffset_X.Location = new Point(0x1a, 0x18);
            int[] bits = new int[4];
            bits[0] = 0x7fff;
            this.intACCOffset_X.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 0x8000;
            numArray2[3] = -2147483648;
            this.intACCOffset_X.Minimum = new decimal(numArray2);
            this.intACCOffset_X.Name = "intACCOffset_X";
            this.intACCOffset_X.Size = new Size(90, 20);
            this.intACCOffset_X.TabIndex = 1;
            this.intACCOffset_Z.Location = new Point(0x1a, 0x4c);
            int[] numArray3 = new int[4];
            numArray3[0] = 0x7fff;
            this.intACCOffset_Z.Maximum = new decimal(numArray3);
            int[] numArray4 = new int[4];
            numArray4[0] = 0x8000;
            numArray4[3] = -2147483648;
            this.intACCOffset_Z.Minimum = new decimal(numArray4);
            this.intACCOffset_Z.Name = "intACCOffset_Z";
            this.intACCOffset_Z.Size = new Size(90, 20);
            this.intACCOffset_Z.TabIndex = 5;
            this.intACCOffset_Y.Location = new Point(0x1a, 50);
            int[] numArray5 = new int[4];
            numArray5[0] = 0x7fff;
            this.intACCOffset_Y.Maximum = new decimal(numArray5);
            int[] numArray6 = new int[4];
            numArray6[0] = 0x8000;
            numArray6[3] = -2147483648;
            this.intACCOffset_Y.Minimum = new decimal(numArray6);
            this.intACCOffset_Y.Name = "intACCOffset_Y";
            this.intACCOffset_Y.Size = new Size(90, 20);
            this.intACCOffset_Y.TabIndex = 3;
            this.groupBox2.Controls.Add(this.txtACC_HPF_Cutoff);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.intACC_HPF_RefValue);
            this.groupBox2.Controls.Add(this.chkAcc_HPF_Ref);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbACC_HPF_ODR);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new Point(0xfd, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x8b, 0x91);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.txtACC_HPF_Cutoff.Location = new Point(7, 0x55);
            this.txtACC_HPF_Cutoff.Name = "txtACC_HPF_Cutoff";
            this.txtACC_HPF_Cutoff.ReadOnly = true;
            this.txtACC_HPF_Cutoff.Size = new Size(0x4b, 20);
            this.txtACC_HPF_Cutoff.TabIndex = 3;
            this.label30.AutoSize = true;
            this.label30.Location = new Point(5, 0x16);
            this.label30.Name = "label30";
            this.label30.Size = new Size(0x52, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "ODR divided by";
            this.intACC_HPF_RefValue.Enabled = false;
            this.intACC_HPF_RefValue.Location = new Point(0x58, 0x76);
            int[] numArray7 = new int[4];
            numArray7[0] = 0xff;
            this.intACC_HPF_RefValue.Maximum = new decimal(numArray7);
            this.intACC_HPF_RefValue.Name = "intACC_HPF_RefValue";
            this.intACC_HPF_RefValue.Size = new Size(0x2c, 20);
            this.intACC_HPF_RefValue.TabIndex = 5;
            int[] numArray8 = new int[4];
            numArray8[0] = 0xff;
            this.intACC_HPF_RefValue.Value = new decimal(numArray8);
            this.chkAcc_HPF_Ref.AutoSize = true;
            this.chkAcc_HPF_Ref.BackColor = Color.White;
            this.chkAcc_HPF_Ref.Location = new Point(6, 0x77);
            this.chkAcc_HPF_Ref.Name = "chkAcc_HPF_Ref";
            this.chkAcc_HPF_Ref.Size = new Size(0x4c, 0x11);
            this.chkAcc_HPF_Ref.TabIndex = 4;
            this.chkAcc_HPF_Ref.Text = "Reference";
            this.chkAcc_HPF_Ref.UseVisualStyleBackColor = false;
            this.chkAcc_HPF_Ref.CheckedChanged += new EventHandler(this.chkAccRef_CheckedChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(5, 0x45);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x5b, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cut-off Frequency";
            this.cmbACC_HPF_ODR.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbACC_HPF_ODR.FormattingEnabled = true;
            this.cmbACC_HPF_ODR.Items.AddRange(new object[] { "50", "100", "200", "400" });
            this.cmbACC_HPF_ODR.Location = new Point(6, 0x27);
            this.cmbACC_HPF_ODR.Name = "cmbACC_HPF_ODR";
            this.cmbACC_HPF_ODR.Size = new Size(0x4c, 0x15);
            this.cmbACC_HPF_ODR.TabIndex = 1;
            this.cmbACC_HPF_ODR.SelectedIndexChanged += new EventHandler(this.cmbACC_HPF_SelectedIndexChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x88, 60);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Full scale (g)";
            this.cmbAccFS.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAccFS.FormattingEnabled = true;
            this.cmbAccFS.Items.AddRange(new object[] { "+/- 2", "+/- 4", "+/- 8" });
            this.cmbAccFS.Location = new Point(0x8b, 0x4c);
            this.cmbAccFS.Name = "cmbAccFS";
            this.cmbAccFS.Size = new Size(0x5f, 0x15);
            this.cmbAccFS.TabIndex = 4;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x88, 0x11);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Output Data Rate (Hz)";
            this.cmbAccODR.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAccODR.FormattingEnabled = true;
            this.cmbAccODR.Items.AddRange(new object[] { "50", "100", "400", "1000" });
            this.cmbAccODR.Location = new Point(0x8b, 0x21);
            this.cmbAccODR.Name = "cmbAccODR";
            this.cmbAccODR.Size = new Size(0x5f, 0x15);
            this.cmbAccODR.TabIndex = 2;
            this.cmbAccODR.SelectedIndexChanged += new EventHandler(this.cmbACC_HPF_SelectedIndexChanged);
            this.tabPage3.Controls.Add(this.btnMagRestore);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cmbMagOM);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.cmbMagFS);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.cmbMagODR);
            this.tabPage3.Location = new Point(4, 0x16);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new Size(0x18e, 0xa7);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Magnetometer";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.btnMagRestore.Location = new Point(5, 0x8d);
            this.btnMagRestore.Name = "btnMagRestore";
            this.btnMagRestore.Size = new Size(0x4b, 0x17);
            this.btnMagRestore.TabIndex = 7;
            this.btnMagRestore.Text = "Restore";
            this.toolTip1.SetToolTip(this.btnMagRestore, "Restore default value for the sensor");
            this.btnMagRestore.UseVisualStyleBackColor = true;
            this.btnMagRestore.Click += new EventHandler(this.btnMagRestore_Click);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.intMagOffset_X);
            this.groupBox3.Controls.Add(this.intMagOffset_Z);
            this.groupBox3.Controls.Add(this.intMagOffset_Y);
            this.groupBox3.Location = new Point(5, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x7d, 110);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Offset (milli-Gauss)";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(6, 0x4e);
            this.label15.Name = "label15";
            this.label15.Size = new Size(14, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Z";
            this.label16.AutoSize = true;
            this.label16.Location = new Point(6, 0x34);
            this.label16.Name = "label16";
            this.label16.Size = new Size(14, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Y";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(6, 0x1a);
            this.label17.Name = "label17";
            this.label17.Size = new Size(14, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "X";
            this.intMagOffset_X.Location = new Point(0x1a, 0x18);
            int[] numArray9 = new int[4];
            numArray9[0] = 0x7fff;
            this.intMagOffset_X.Maximum = new decimal(numArray9);
            int[] numArray10 = new int[4];
            numArray10[0] = 0x8000;
            numArray10[3] = -2147483648;
            this.intMagOffset_X.Minimum = new decimal(numArray10);
            this.intMagOffset_X.Name = "intMagOffset_X";
            this.intMagOffset_X.Size = new Size(90, 20);
            this.intMagOffset_X.TabIndex = 1;
            this.intMagOffset_Z.Location = new Point(0x1a, 0x4c);
            int[] numArray11 = new int[4];
            numArray11[0] = 0x7fff;
            this.intMagOffset_Z.Maximum = new decimal(numArray11);
            int[] numArray12 = new int[4];
            numArray12[0] = 0x8000;
            numArray12[3] = -2147483648;
            this.intMagOffset_Z.Minimum = new decimal(numArray12);
            this.intMagOffset_Z.Name = "intMagOffset_Z";
            this.intMagOffset_Z.Size = new Size(90, 20);
            this.intMagOffset_Z.TabIndex = 5;
            this.intMagOffset_Y.Location = new Point(0x1a, 50);
            int[] numArray13 = new int[4];
            numArray13[0] = 0x7fff;
            this.intMagOffset_Y.Maximum = new decimal(numArray13);
            int[] numArray14 = new int[4];
            numArray14[0] = 0x8000;
            numArray14[3] = -2147483648;
            this.intMagOffset_Y.Minimum = new decimal(numArray14);
            this.intMagOffset_Y.Name = "intMagOffset_Y";
            this.intMagOffset_Y.Size = new Size(90, 20);
            this.intMagOffset_Y.TabIndex = 3;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x88, 0x67);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x53, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Operating Mode";
            this.cmbMagOM.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMagOM.FormattingEnabled = true;
            this.cmbMagOM.Items.AddRange(new object[] { "Normal", "Positive bias", "Negative bias" });
            this.cmbMagOM.Location = new Point(0x8b, 0x77);
            this.cmbMagOM.Name = "cmbMagOM";
            this.cmbMagOM.Size = new Size(0x6b, 0x15);
            this.cmbMagOM.TabIndex = 6;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x88, 60);
            this.label6.Name = "label6";
            this.label6.Size = new Size(90, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Full scale (Gauss)";
            this.cmbMagFS.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMagFS.FormattingEnabled = true;
            this.cmbMagFS.Items.AddRange(new object[] { "+/- 1.3", "+/- 1.9", "+/- 2.5", "+/- 4.0", "+/- 4.7", "+/- 5.6", "+/- 8.1" });
            this.cmbMagFS.Location = new Point(0x8b, 0x4c);
            this.cmbMagFS.Name = "cmbMagFS";
            this.cmbMagFS.Size = new Size(0x6b, 0x15);
            this.cmbMagFS.TabIndex = 4;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x88, 0x11);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x71, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Output Data Rate (Hz)";
            this.cmbMagODR.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMagODR.FormattingEnabled = true;
            this.cmbMagODR.Items.AddRange(new object[] { "0.75", "1.5", "3", "7.5", "15", "30", "75" });
            this.cmbMagODR.Location = new Point(0x8b, 0x21);
            this.cmbMagODR.Name = "cmbMagODR";
            this.cmbMagODR.Size = new Size(0x6b, 0x15);
            this.cmbMagODR.TabIndex = 2;
            this.tabPage4.Controls.Add(this.btnGyrRestore);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.cmbFS_RP);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.cmbFS_Y);
            this.tabPage4.Location = new Point(4, 0x16);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new Size(0x18e, 0xa7);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Gyroscope";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.btnGyrRestore.Location = new Point(5, 0x8d);
            this.btnGyrRestore.Name = "btnGyrRestore";
            this.btnGyrRestore.Size = new Size(0x4b, 0x17);
            this.btnGyrRestore.TabIndex = 5;
            this.btnGyrRestore.Text = "Restore";
            this.toolTip1.SetToolTip(this.btnGyrRestore, "Restore default value for the sensor");
            this.btnGyrRestore.UseVisualStyleBackColor = true;
            this.btnGyrRestore.Click += new EventHandler(this.btnGyrRestore_Click);
            this.label27.AutoSize = true;
            this.label27.Location = new Point(0x88, 0x11);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x85, 13);
            this.label27.TabIndex = 1;
            this.label27.Text = "Full scale (dps) (Roll/Pitch)";
            this.cmbFS_RP.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFS_RP.Enabled = false;
            this.cmbFS_RP.FormattingEnabled = true;
            this.cmbFS_RP.Items.AddRange(new object[] { "+/- 300", "+/- 1200" });
            this.cmbFS_RP.Location = new Point(0x8b, 0x21);
            this.cmbFS_RP.Name = "cmbFS_RP";
            this.cmbFS_RP.Size = new Size(0x6b, 0x15);
            this.cmbFS_RP.TabIndex = 2;
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.intGyrOffset_R);
            this.groupBox4.Controls.Add(this.intGyrOffset_Y);
            this.groupBox4.Controls.Add(this.intGyrOffset_P);
            this.groupBox4.Location = new Point(5, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x7d, 110);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Offset (dps)";
            this.label21.AutoSize = true;
            this.label21.Location = new Point(6, 0x4e);
            this.label21.Name = "label21";
            this.label21.Size = new Size(14, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Y";
            this.label22.AutoSize = true;
            this.label22.Location = new Point(6, 0x34);
            this.label22.Name = "label22";
            this.label22.Size = new Size(14, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "P";
            this.label23.AutoSize = true;
            this.label23.Location = new Point(6, 0x1a);
            this.label23.Name = "label23";
            this.label23.Size = new Size(15, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "R";
            this.intGyrOffset_R.Location = new Point(0x1a, 0x18);
            int[] numArray15 = new int[4];
            numArray15[0] = 180;
            this.intGyrOffset_R.Maximum = new decimal(numArray15);
            int[] numArray16 = new int[4];
            numArray16[0] = 180;
            numArray16[3] = -2147483648;
            this.intGyrOffset_R.Minimum = new decimal(numArray16);
            this.intGyrOffset_R.Name = "intGyrOffset_R";
            this.intGyrOffset_R.Size = new Size(90, 20);
            this.intGyrOffset_R.TabIndex = 1;
            this.intGyrOffset_Y.Location = new Point(0x1a, 0x4c);
            int[] numArray17 = new int[4];
            numArray17[0] = 180;
            this.intGyrOffset_Y.Maximum = new decimal(numArray17);
            int[] numArray18 = new int[4];
            numArray18[0] = 180;
            numArray18[3] = -2147483648;
            this.intGyrOffset_Y.Minimum = new decimal(numArray18);
            this.intGyrOffset_Y.Name = "intGyrOffset_Y";
            this.intGyrOffset_Y.Size = new Size(90, 20);
            this.intGyrOffset_Y.TabIndex = 5;
            this.intGyrOffset_P.Location = new Point(0x1a, 50);
            int[] numArray19 = new int[4];
            numArray19[0] = 90;
            this.intGyrOffset_P.Maximum = new decimal(numArray19);
            int[] numArray20 = new int[4];
            numArray20[0] = 90;
            numArray20[3] = -2147483648;
            this.intGyrOffset_P.Minimum = new decimal(numArray20);
            this.intGyrOffset_P.Name = "intGyrOffset_P";
            this.intGyrOffset_P.Size = new Size(90, 20);
            this.intGyrOffset_P.TabIndex = 3;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x88, 60);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x6b, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Full scale (dps) (Yaw)";
            this.cmbFS_Y.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFS_Y.Enabled = false;
            this.cmbFS_Y.FormattingEnabled = true;
            this.cmbFS_Y.Items.AddRange(new object[] { "+/- 300", "+/- 1200" });
            this.cmbFS_Y.Location = new Point(0x8b, 0x4c);
            this.cmbFS_Y.Name = "cmbFS_Y";
            this.cmbFS_Y.Size = new Size(0x6b, 0x15);
            this.cmbFS_Y.TabIndex = 4;
            this.tabPage5.Controls.Add(this.btnPressRestore);
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.cmbPresODR);
            this.tabPage5.Location = new Point(4, 0x16);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new Size(0x18e, 0xa7);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Pressure";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.btnPressRestore.Location = new Point(5, 0x8d);
            this.btnPressRestore.Name = "btnPressRestore";
            this.btnPressRestore.Size = new Size(0x4b, 0x17);
            this.btnPressRestore.TabIndex = 3;
            this.btnPressRestore.Text = "Restore";
            this.toolTip1.SetToolTip(this.btnPressRestore, "Restore default value for the sensor");
            this.btnPressRestore.UseVisualStyleBackColor = true;
            this.btnPressRestore.Click += new EventHandler(this.btnPressRestore_Click);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.intPressOffset);
            this.groupBox5.Location = new Point(5, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x7d, 110);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Offset (milli-bar)";
            this.label29.AutoSize = true;
            this.label29.Location = new Point(6, 0x1a);
            this.label29.Name = "label29";
            this.label29.Size = new Size(14, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "P";
            this.intPressOffset.Location = new Point(0x1a, 0x18);
            int[] numArray21 = new int[4];
            numArray21[0] = 0x2af8;
            this.intPressOffset.Maximum = new decimal(numArray21);
            this.intPressOffset.Name = "intPressOffset";
            this.intPressOffset.Size = new Size(90, 20);
            this.intPressOffset.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x88, 0x11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output Data Rate (Hz)";
            this.cmbPresODR.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPresODR.FormattingEnabled = true;
            this.cmbPresODR.Items.AddRange(new object[] { "7", "12.5" });
            this.cmbPresODR.Location = new Point(0x8b, 0x21);
            this.cmbPresODR.Name = "cmbPresODR";
            this.cmbPresODR.Size = new Size(0x6b, 0x15);
            this.cmbPresODR.TabIndex = 2;
            this.tabPage6.Controls.Add(this.btnTempRestore);
            this.tabPage6.Controls.Add(this.groupBox6);
            this.tabPage6.Location = new Point(4, 0x16);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new Size(0x18e, 0xa7);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Temperature";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.btnTempRestore.Location = new Point(5, 0x8d);
            this.btnTempRestore.Name = "btnTempRestore";
            this.btnTempRestore.Size = new Size(0x4b, 0x17);
            this.btnTempRestore.TabIndex = 1;
            this.btnTempRestore.Text = "Restore";
            this.toolTip1.SetToolTip(this.btnTempRestore, "Restore default value for the sensor");
            this.btnTempRestore.UseVisualStyleBackColor = true;
            this.btnTempRestore.Click += new EventHandler(this.btnTempRestore_Click);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.intTempOffset);
            this.groupBox6.Location = new Point(5, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x7d, 110);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Offset (d\x00baC)";
            this.label32.AutoSize = true;
            this.label32.Location = new Point(6, 0x1a);
            this.label32.Name = "label32";
            this.label32.Size = new Size(14, 13);
            this.label32.TabIndex = 0;
            this.label32.Text = "T";
            this.intTempOffset.Location = new Point(0x1a, 0x18);
            int[] numArray22 = new int[4];
            numArray22[0] = 0x4e2;
            this.intTempOffset.Maximum = new decimal(numArray22);
            int[] numArray23 = new int[4];
            numArray23[0] = 550;
            numArray23[3] = -2147483648;
            this.intTempOffset.Minimum = new decimal(numArray23);
            this.intTempOffset.Name = "intTempOffset";
            this.intTempOffset.Size = new Size(90, 20);
            this.intTempOffset.TabIndex = 1;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(0x103, 0xe3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(340, 0xe3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.label12.AutoSize = true;
            this.label12.Location = new Point(6, 0x4e);
            this.label12.Name = "label12";
            this.label12.Size = new Size(14, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Z";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(6, 0x34);
            this.label13.Name = "label13";
            this.label13.Size = new Size(14, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Y";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(6, 0x1a);
            this.label14.Name = "label14";
            this.label14.Size = new Size(14, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "X";
            this.label18.AutoSize = true;
            this.label18.Location = new Point(6, 0x4e);
            this.label18.Name = "label18";
            this.label18.Size = new Size(14, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Z";
            this.label19.AutoSize = true;
            this.label19.Location = new Point(6, 0x34);
            this.label19.Name = "label19";
            this.label19.Size = new Size(14, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "Y";
            this.label20.AutoSize = true;
            this.label20.Location = new Point(6, 0x1a);
            this.label20.Name = "label20";
            this.label20.Size = new Size(14, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "X";
            this.label24.AutoSize = true;
            this.label24.Location = new Point(6, 0x4e);
            this.label24.Name = "label24";
            this.label24.Size = new Size(14, 13);
            this.label24.TabIndex = 10;
            this.label24.Text = "Z";
            this.label25.AutoSize = true;
            this.label25.Location = new Point(6, 0x34);
            this.label25.Name = "label25";
            this.label25.Size = new Size(14, 13);
            this.label25.TabIndex = 9;
            this.label25.Text = "Y";
            this.label26.AutoSize = true;
            this.label26.Location = new Point(6, 0x1a);
            this.label26.Name = "label26";
            this.label26.Size = new Size(14, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "X";
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripBtnImport, this.toolStripBtnExport });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(0x1ab, 0x19);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripBtnImport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripBtnImport.Image = (Image) manager.GetObject("toolStripBtnImport.Image");
            this.toolStripBtnImport.ImageTransparentColor = Color.Magenta;
            this.toolStripBtnImport.Name = "toolStripBtnImport";
            this.toolStripBtnImport.Size = new Size(0x17, 0x16);
            this.toolStripBtnImport.Text = "Load";
            this.toolStripBtnImport.ToolTipText = "Import configuration sensors from file";
            this.toolStripBtnImport.Click += new EventHandler(this.toolStripBtnImport_Click);
            this.toolStripBtnExport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExport.Image = (Image) manager.GetObject("toolStripBtnExport.Image");
            this.toolStripBtnExport.ImageTransparentColor = Color.Magenta;
            this.toolStripBtnExport.Name = "toolStripBtnExport";
            this.toolStripBtnExport.Size = new Size(0x17, 0x16);
            this.toolStripBtnExport.Text = "Save";
            this.toolStripBtnExport.ToolTipText = "Export configuration sensors to file";
            this.toolStripBtnExport.Click += new EventHandler(this.toolStripBtnExport_Click);
            this.saveFileDialogCfg.DefaultExt = "cfg";
            this.saveFileDialogCfg.Filter = "Sensors configuration file(*.cfg)|*.cfg";
            this.saveFileDialogCfg.InitialDirectory = "Environment.SpecialFolder.MyDocuments";
            this.saveFileDialogCfg.Title = "Export sensors configuration to file";
            this.openFileDialogCfg.DefaultExt = "*.cfg";
            this.openFileDialogCfg.InitialDirectory = "Environment.SpecialFolder.MyDocuments";
            this.openFileDialogCfg.Title = "Import sensors configuration from file";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(0x1ab, 0x106);
            base.Controls.Add(this.toolStrip1);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.tabControl1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSensorSettings";
            this.Text = "Sensor Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.intACCOffset_X.EndInit();
            this.intACCOffset_Z.EndInit();
            this.intACCOffset_Y.EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.intACC_HPF_RefValue.EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.intMagOffset_X.EndInit();
            this.intMagOffset_Z.EndInit();
            this.intMagOffset_Y.EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.intGyrOffset_R.EndInit();
            this.intGyrOffset_Y.EndInit();
            this.intGyrOffset_P.EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.intPressOffset.EndInit();
            this.tabPage6.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.intTempOffset.EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void LoadDeviceDataSettings()
        {
            if (this.GoodVersion)
            {
                this.SettingsChanged_Out = this.LoadDeviceDataSettings_Out();
                this.SettingsChanged_Acc = this.LoadDeviceDataSettings_Acc();
                this.SettingsChanged_Mag = this.LoadDeviceDataSettings_Mag();
                this.SettingsChanged_Gyr = this.LoadDeviceDataSettings_Gyr();
                this.SettingsChanged_Pres = this.LoadDeviceDataSettings_Pres();
                this.SettingsChanged_Temp = this.LoadDeviceDataSettings_Temp();
                if (((!this.SettingsChanged_Out && !this.SettingsChanged_Acc) && (!this.SettingsChanged_Mag && !this.SettingsChanged_Gyr)) && ((!this.SettingsChanged_Pres && !this.SettingsChanged_Temp) && (this.OnMessageToLogSettings != null)))
                {
                    this.OnMessageToLogSettings("Loaded registers");
                }
            }
        }

        private bool LoadDeviceDataSettings_Acc()
        {
            bool flag = false;
            byte[] regValue = new byte[0];
            bool flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 0, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1))
            {
                this.cmbAccODR.SelectedIndex = regValue[0] & 3;
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if (((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 1, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1)) && (regValue[0] < 4))
            {
                switch (regValue[0])
                {
                    case 0:
                    case 1:
                        this.cmbAccFS.SelectedIndex = regValue[0];
                        flag2 = false;
                        break;

                    case 3:
                        this.cmbAccFS.SelectedIndex = 2;
                        flag2 = false;
                        break;
                }
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 2, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intACC_HPF_RefValue.Value = regValue[1];
                this.chkAcc_HPF_Ref.Checked = (regValue[0] & 0x10) == 0x10;
                this.cmbACC_HPF_ODR.SelectedIndex = (regValue[0] & 12) >> 2;
                this.chkACC_HPF.Checked = (regValue[0] & 0x20) == 0x20;
                this.cmbAccODR.SelectedIndex = regValue[0] & 3;
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 3, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intACCOffset_X.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 4, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intACCOffset_Y.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 5, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intACCOffset_Z.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            if ((this.OnMessageToLogSettings != null) && flag)
            {
                this.OnMessageToLogSettings("Load Accelerometer Settings fails");
            }
            return flag;
        }

        private bool LoadDeviceDataSettings_Gyr()
        {
            bool flag = false;
            byte[] regValue = new byte[0];
            bool flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_RP, 0, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1))
            {
                if (regValue[0] == 4)
                {
                    this.cmbFS_RP.SelectedIndex = 0;
                    flag2 = false;
                }
                if (regValue[0] == 8)
                {
                    this.cmbFS_RP.SelectedIndex = 0;
                    flag2 = false;
                }
            }
            flag = flag || flag2;
            flag2 = true;
            if (((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_Y, 0, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1)) && (regValue[0] == 4))
            {
                this.cmbFS_RP.SelectedIndex = 0;
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_RP, 1, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intGyrOffset_R.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_RP, 2, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intGyrOffset_P.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_Y, 1, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intGyrOffset_Y.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            if ((this.OnMessageToLogSettings != null) && flag)
            {
                this.OnMessageToLogSettings("Load Gyroscope Settings fails");
            }
            return flag;
        }

        private bool LoadDeviceDataSettings_Mag()
        {
            bool flag = false;
            byte[] regValue = new byte[0];
            bool flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 0, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1))
            {
                this.cmbMagODR.SelectedIndex = regValue[0] & 7;
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 1, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1))
            {
                this.cmbMagFS.SelectedIndex = (regValue[0] & 7) - 1;
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 2, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1))
            {
                this.cmbMagOM.SelectedIndex = regValue[0] & 3;
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 3, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intMagOffset_X.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 4, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intMagOffset_Y.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 5, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intMagOffset_Z.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            if ((this.OnMessageToLogSettings != null) && flag)
            {
                this.OnMessageToLogSettings("Load Magnetometer Settings fails");
            }
            return flag;
        }

        private bool LoadDeviceDataSettings_Out()
        {
            bool flag = false;
            bool flag2 = true;
            if (this.sdk2comm.GetOutput(ref this.getRegOutPut) == INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                this.chkOutAHRS.Checked = (this.getRegOutPut.Mode & INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_AHRS) == INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_AHRS;
                this.chkOutRawData.Checked = (this.getRegOutPut.Mode & INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_RAW) == INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_RAW;
                this.chkOutAcc.Checked = (this.getRegOutPut.Data & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_ACC) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_ACC;
                this.chkOutGyr.Checked = (this.getRegOutPut.Data & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_GYRO) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_GYRO;
                this.chkOutMag.Checked = (this.getRegOutPut.Data & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_MAG) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_MAG;
                this.chkOutPres.Checked = (this.getRegOutPut.Data & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_PRESS) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_PRESS;
                this.chkOutTemp.Checked = (this.getRegOutPut.Data & INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_TEMP) == INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_TEMP;
                int num = this.cmbOutFreq.FindString(this.getRegOutPut.Frequency.ToString());
                if (num >= 0)
                {
                    this.cmbOutFreq.SelectedIndex = num;
                }
                flag2 = false;
            }
            flag = flag || flag2;
            if ((this.OnMessageToLogSettings != null) && flag)
            {
                this.OnMessageToLogSettings("Load device settigs for output fails");
            }
            return flag;
        }

        private bool LoadDeviceDataSettings_Pres()
        {
            bool flag = false;
            byte[] regValue = new byte[0];
            bool flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_PRESS, 0, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 1))
            {
                if (regValue[0] == 1)
                {
                    this.cmbPresODR.SelectedIndex = 0;
                    flag2 = false;
                }
                if (regValue[0] == 3)
                {
                    this.cmbPresODR.SelectedIndex = 1;
                    flag2 = false;
                }
            }
            flag = flag || flag2;
            flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_PRESS, 1, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intPressOffset.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            if ((this.OnMessageToLogSettings != null) && flag)
            {
                this.OnMessageToLogSettings("Load Press Settings fails");
            }
            return flag;
        }

        private bool LoadDeviceDataSettings_Temp()
        {
            bool flag = false;
            byte[] regValue = new byte[0];
            bool flag2 = true;
            if ((this.sdk2comm.GetReg(INEMO2_SENSORS.INEMO2_SENSORS_TEMP, 0, ref regValue) == INEMO2_DeviceError.INEMO2_ERROR_NONE) && (regValue.Length == 2))
            {
                this.intTempOffset.Value = this.ByteArrayToInt16(regValue);
                flag2 = false;
            }
            flag = flag || flag2;
            if ((this.OnMessageToLogSettings != null) && flag)
            {
                this.OnMessageToLogSettings("Load Temp Settings fails");
            }
            return flag;
        }

        private bool LoadParam_ACC(string[] cfg)
        {
            bool flag = true;
            try
            {
                foreach (string str in cfg)
                {
                    string[] strArray = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray.Length == 2)
                    {
                        switch (strArray[0].Trim())
                        {
                            case "offset_x":
                                this.intACCOffset_X.Value = Convert.ToDecimal(strArray[1]);
                                break;

                            case "offset_y":
                                this.intACCOffset_Y.Value = Convert.ToDecimal(strArray[1]);
                                break;

                            case "offset_z":
                                this.intACCOffset_Z.Value = Convert.ToDecimal(strArray[1]);
                                break;

                            case "odr":
                                this.cmbAccODR.SelectedIndex = this.cmbAccODR.FindString(strArray[1]);
                                break;

                            case "fs":
                                this.cmbAccFS.SelectedIndex = this.cmbAccFS.FindString(strArray[1]);
                                break;

                            case "hpf":
                                this.chkACC_HPF.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "hpf_odr":
                                this.cmbACC_HPF_ODR.SelectedIndex = this.cmbACC_HPF_ODR.FindString(strArray[1]);
                                break;

                            case "hpf_ref":
                                this.chkAcc_HPF_Ref.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "hpf_ref_val":
                                this.intACC_HPF_RefValue.Value = Convert.ToDecimal(strArray[1]);
                                break;
                        }
                    }
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private bool LoadParam_GYR(string[] cfg)
        {
            bool flag = true;
            try
            {
                foreach (string str in cfg)
                {
                    string str2;
                    string[] strArray = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if ((strArray.Length == 2) && ((str2 = strArray[0].Trim()) != null))
                    {
                        if (!(str2 == "offset_r"))
                        {
                            if (str2 == "offset_p")
                            {
                                goto Label_0080;
                            }
                            if (str2 == "offset_y")
                            {
                                goto Label_0095;
                            }
                        }
                        else
                        {
                            this.intGyrOffset_R.Value = Convert.ToDecimal(strArray[1]);
                        }
                    }
                    continue;
                Label_0080:
                    this.intGyrOffset_P.Value = Convert.ToDecimal(strArray[1]);
                    continue;
                Label_0095:
                    this.intGyrOffset_Y.Value = Convert.ToDecimal(strArray[1]);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private bool LoadParam_MAG(string[] cfg)
        {
            bool flag = true;
            try
            {
                foreach (string str in cfg)
                {
                    string str2;
                    string[] strArray = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if ((strArray.Length == 2) && ((str2 = strArray[0].Trim()) != null))
                    {
                        if (!(str2 == "offset_x"))
                        {
                            if (str2 == "offset_y")
                            {
                                goto Label_00B3;
                            }
                            if (str2 == "offset_z")
                            {
                                goto Label_00C8;
                            }
                            if (str2 == "odr")
                            {
                                goto Label_00DD;
                            }
                            if (str2 == "fs")
                            {
                                goto Label_00F8;
                            }
                            if (str2 == "om")
                            {
                                goto Label_0113;
                            }
                        }
                        else
                        {
                            this.intMagOffset_X.Value = Convert.ToDecimal(strArray[1]);
                        }
                    }
                    continue;
                Label_00B3:
                    this.intMagOffset_Y.Value = Convert.ToDecimal(strArray[1]);
                    continue;
                Label_00C8:
                    this.intMagOffset_Z.Value = Convert.ToDecimal(strArray[1]);
                    continue;
                Label_00DD:
                    this.cmbMagODR.SelectedIndex = this.cmbMagODR.FindString(strArray[1]);
                    continue;
                Label_00F8:
                    this.cmbMagFS.SelectedIndex = this.cmbMagFS.FindString(strArray[1]);
                    continue;
                Label_0113:
                    this.cmbMagOM.SelectedIndex = this.cmbMagOM.FindString(strArray[1]);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private bool LoadParam_OUT(string[] cfg)
        {
            bool flag = true;
            try
            {
                foreach (string str in cfg)
                {
                    string[] strArray = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray.Length == 2)
                    {
                        switch (strArray[0].Trim())
                        {
                            case "accelerometer":
                                this.chkOutAcc.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "magnetometer":
                                this.chkOutMag.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "gyroscope":
                                this.chkOutGyr.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "pressure":
                                this.chkOutPres.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "temperature":
                                this.chkOutTemp.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "raw":
                                this.chkOutRawData.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "ahrs":
                                this.chkOutAHRS.Checked = Convert.ToBoolean(strArray[1]);
                                break;

                            case "frequency":
                                this.cmbOutFreq.SelectedIndex = this.cmbOutFreq.FindString(strArray[1]);
                                break;
                        }
                    }
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private bool LoadParam_PRES(string[] cfg)
        {
            bool flag = true;
            try
            {
                foreach (string str in cfg)
                {
                    string str2;
                    string[] strArray = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if ((strArray.Length == 2) && ((str2 = strArray[0].Trim()) != null))
                    {
                        if (!(str2 == "offset_p"))
                        {
                            if (str2 == "odr")
                            {
                                goto Label_0072;
                            }
                        }
                        else
                        {
                            this.intPressOffset.Value = Convert.ToDecimal(strArray[1]);
                        }
                    }
                    continue;
                Label_0072:
                    this.cmbPresODR.SelectedIndex = this.cmbPresODR.FindString(strArray[1]);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private bool LoadParam_TEMP(string[] cfg)
        {
            bool flag = true;
            try
            {
                foreach (string str in cfg)
                {
                    string str2;
                    string[] strArray = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (((strArray.Length == 2) && ((str2 = strArray[0].Trim()) != null)) && (str2 == "offset_t"))
                    {
                        this.intTempOffset.Value = Convert.ToDecimal(strArray[1]);
                    }
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public void ShowSettingDialog(bool AHRS_available)
        {
            if (!this.GoodVersion)
            {
                MessageBox.Show("Device firmware not upgraded!\n\nUpgrade the firmware to the version 2.2.0 or higher to have all settings available.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.chkOutAHRS.Enabled = AHRS_available;
            this.LoadDeviceDataSettings();
            if (base.ShowDialog() == DialogResult.OK)
            {
                this.UpLoadDeviceDataSettings();
            }
        }

        private void toolStripBtnExport_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string str = now.Year.ToString("d2") + now.Month.ToString("d2") + now.Day.ToString("d2") + "_" + now.Hour.ToString("d2") + now.Minute.ToString("d2") + now.Second.ToString("d2");
            this.saveFileDialogCfg.FileName = "iNEMO_Cfg_" + str;
            if (this.saveFileDialogCfg.ShowDialog() == DialogResult.OK)
            {
                this.ExportConfigurationToFile(this.saveFileDialogCfg.FileName);
            }
        }

        private void toolStripBtnImport_Click(object sender, EventArgs e)
        {
            this.openFileDialogCfg.FileName = "";
            if (this.openFileDialogCfg.ShowDialog() == DialogResult.OK)
            {
                this.ImportConfigurationFromFile(this.openFileDialogCfg.FileName);
            }
        }

        private void UpdateCutOff()
        {
            if (this.chkACC_HPF.Checked)
            {
                try
                {
                    this.txtACC_HPF_Cutoff.Text = ((Convert.ToDecimal(this.cmbAccODR.Text) / Convert.ToDecimal(this.cmbACC_HPF_ODR.Text))).ToString("0.###") + " Hz";
                }
                catch
                {
                }
            }
            else
            {
                this.txtACC_HPF_Cutoff.Text = "N.A.";
            }
        }

        public void UpLoadDeviceDataSettings()
        {
            bool flag = this.UpLoadDeviceDataSettings_Out();
            if (this.GoodVersion)
            {
                bool flag2 = this.UpLoadDeviceDataSettings_Acc();
                bool flag3 = this.UpLoadDeviceDataSettings_Mag();
                bool flag4 = this.UpLoadDeviceDataSettings_Gyr();
                bool flag5 = this.UpLoadDeviceDataSettings_Pres();
                bool flag6 = this.UpLoadDeviceDataSettings_Temp();
                if (((flag && flag2) && (flag3 && flag4)) && ((flag5 && flag6) && (this.OnMessageToLogSettings != null)))
                {
                    this.OnMessageToLogSettings("Uploaded registers");
                }
            }
        }

        private bool UpLoadDeviceDataSettings_Acc()
        {
            bool flag = true;
            byte[] regValue = new byte[] { (byte) this.cmbAccODR.SelectedIndex };
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 0, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) this.cmbAccFS.SelectedIndex;
            if (regValue[0] == 2)
            {
                regValue[0] = 3;
            }
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 1, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue = new byte[] { 0, 0 };
            regValue[0] = (byte) (((byte) this.cmbAccODR.SelectedIndex) & 3);
            if (this.chkACC_HPF.Checked)
            {
                regValue[0] = (byte) (regValue[0] | 0x20);
                if (this.chkAcc_HPF_Ref.Checked)
                {
                    regValue[0] = (byte) (regValue[0] | 0x10);
                }
                regValue[0] = (byte) (regValue[0] | ((((byte) this.cmbACC_HPF_ODR.SelectedIndex) << 2) & 12));
                regValue[1] = (byte) this.intACC_HPF_RefValue.Value;
            }
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 2, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) ((((short) this.intACCOffset_X.Value) & 0xff00) >> 8);
            regValue[1] = (byte) (((short) this.intACCOffset_X.Value) & 0xff);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 3, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) ((((short) this.intACCOffset_Y.Value) & 0xff00) >> 8);
            regValue[1] = (byte) (((short) this.intACCOffset_Y.Value) & 0xff);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 4, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) ((((short) this.intACCOffset_Z.Value) & 0xff00) >> 8);
            regValue[1] = (byte) (((short) this.intACCOffset_Z.Value) & 0xff);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_ACC, 5, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            if ((this.OnMessageToLogSettings != null) && !flag)
            {
                this.OnMessageToLogSettings("UpLoad Accelerometer Settings fails");
            }
            return flag;
        }

        private bool UpLoadDeviceDataSettings_Gyr()
        {
            bool flag = true;
            byte[] regValue = new byte[] { (byte) ((((short) this.intGyrOffset_R.Value) & 0xff00) >> 8), (byte) (((short) this.intGyrOffset_R.Value) & 0xff) };
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_RP, 1, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) ((((short) this.intGyrOffset_P.Value) & 0xff00) >> 8);
            regValue[1] = (byte) (((short) this.intGyrOffset_P.Value) & 0xff);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_RP, 2, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) ((((short) this.intGyrOffset_Y.Value) & 0xff00) >> 8);
            regValue[1] = (byte) (((short) this.intGyrOffset_Y.Value) & 0xff);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_GYRO_Y, 1, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            if ((this.OnMessageToLogSettings != null) && !flag)
            {
                this.OnMessageToLogSettings("UpLoad Gyroscope Settings fails");
            }
            return flag;
        }

        private bool UpLoadDeviceDataSettings_Mag()
        {
            bool flag = true;
            byte[] regValue = new byte[] { (byte) this.cmbMagODR.SelectedIndex };
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 0, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) (this.cmbMagFS.SelectedIndex + 1);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 1, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) this.cmbMagOM.SelectedIndex;
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 2, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue = new byte[] { (byte) ((((short) this.intMagOffset_X.Value) & 0xff00) >> 8), (byte) (((short) this.intMagOffset_X.Value) & 0xff) };
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 3, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) ((((short) this.intMagOffset_Y.Value) & 0xff00) >> 8);
            regValue[1] = (byte) (((short) this.intMagOffset_Y.Value) & 0xff);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 4, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue[0] = (byte) ((((short) this.intMagOffset_Z.Value) & 0xff00) >> 8);
            regValue[1] = (byte) (((short) this.intMagOffset_Z.Value) & 0xff);
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_MAG, 5, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            if ((this.OnMessageToLogSettings != null) && !flag)
            {
                this.OnMessageToLogSettings("UpLoad Magnetometer Settings fails");
            }
            return flag;
        }

        private bool UpLoadDeviceDataSettings_Out()
        {
            bool flag = true;
            this.getRegOutPut.Mode = this.OutputMode;
            this.getRegOutPut.Data = this.OutputData;
            this.getRegOutPut.Frequency = (uint) this.Frequency;
            if (this.sdk2comm.SetOutput(this.getRegOutPut) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            if ((this.OnMessageToLogSettings != null) && !flag)
            {
                this.OnMessageToLogSettings("UpLoad Output Settings fails");
            }
            return flag;
        }

        private bool UpLoadDeviceDataSettings_Pres()
        {
            bool flag = true;
            byte[] regValue = new byte[1];
            if (this.cmbPresODR.SelectedIndex == 0)
            {
                regValue[0] = 1;
            }
            if (this.cmbPresODR.SelectedIndex == 1)
            {
                regValue[0] = 3;
            }
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_PRESS, 0, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            regValue = new byte[] { (byte) ((((short) this.intPressOffset.Value) & 0xff00) >> 8), (byte) (((short) this.intPressOffset.Value) & 0xff) };
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_PRESS, 1, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            if ((this.OnMessageToLogSettings != null) && !flag)
            {
                this.OnMessageToLogSettings("UpLoad Press Settings fails");
            }
            return flag;
        }

        private bool UpLoadDeviceDataSettings_Temp()
        {
            bool flag = true;
            byte[] regValue = new byte[] { (byte) ((((short) this.intTempOffset.Value) & 0xff00) >> 8), (byte) (((short) this.intTempOffset.Value) & 0xff) };
            if (this.sdk2comm.SetReg(INEMO2_SENSORS.INEMO2_SENSORS_TEMP, 0, regValue) != INEMO2_DeviceError.INEMO2_ERROR_NONE)
            {
                flag = false;
            }
            if ((this.OnMessageToLogSettings != null) && !flag)
            {
                this.OnMessageToLogSettings("UpLoad Temperature Settings fails");
            }
            return flag;
        }

        public string CtrlVersion
        {
            get
            {
                return this.m_CtrlVersion;
            }
            set
            {
                this.m_CtrlVersion = value;
            }
        }

        public string DevGuid
        {
            get
            {
                return this.m_DevGuid;
            }
            set
            {
                this.m_DevGuid = value;
            }
        }

        public int Frequency
        {
            get
            {
                try
                {
                    return Convert.ToInt16(this.cmbOutFreq.Text);
                }
                catch
                {
                    return 50;
                }
            }
        }

        public string FWVersion
        {
            get
            {
                return this.m_FWVersion;
            }
            set
            {
                this.m_FWVersion = value;
            }
        }

        public bool GoodVersion
        {
            get
            {
                return this.m_GoodVersion;
            }
            set
            {
                this.m_GoodVersion = value;
                this.tabPage2.Enabled = this.m_GoodVersion;
                this.tabPage3.Enabled = this.m_GoodVersion;
                this.tabPage4.Enabled = this.m_GoodVersion;
                this.tabPage5.Enabled = this.m_GoodVersion;
                this.tabPage6.Enabled = this.m_GoodVersion;
                this.toolStrip1.Enabled = this.m_GoodVersion;
                this.groupBox7.Enabled = this.m_GoodVersion;
            }
        }

        public string HWVersion
        {
            get
            {
                return this.m_HWVersion;
            }
            set
            {
                this.m_HWVersion = value;
            }
        }

        public INEMO2_OUTPUT_DATA OutputData
        {
            get
            {
                INEMO2_OUTPUT_DATA inemo_output_data = (INEMO2_OUTPUT_DATA) 0;
                if (this.chkOutAcc.Checked)
                {
                    inemo_output_data |= INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_ACC;
                }
                if (this.chkOutGyr.Checked)
                {
                    inemo_output_data |= INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_GYRO;
                }
                if (this.chkOutMag.Checked)
                {
                    inemo_output_data |= INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_MAG;
                }
                if (this.chkOutPres.Checked)
                {
                    inemo_output_data |= INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_PRESS;
                }
                if (this.chkOutTemp.Checked)
                {
                    inemo_output_data |= INEMO2_OUTPUT_DATA.INEMO2_OUTPUT_DATA_TEMP;
                }
                return inemo_output_data;
            }
        }

        public INEMO2_OUTPUT_MODE OutputMode
        {
            get
            {
                INEMO2_OUTPUT_MODE inemo_output_mode = INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_DEFAULT;
                if (this.chkOutAHRS.Checked)
                {
                    inemo_output_mode |= INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_AHRS;
                }
                if (this.chkOutRawData.Checked)
                {
                    inemo_output_mode |= INEMO2_OUTPUT_MODE.INEMO2_OUTPUT_MODE_RAW;
                }
                return inemo_output_mode;
            }
        }

        public string SWVersion
        {
            get
            {
                return this.m_SWVersion;
            }
            set
            {
                this.m_SWVersion = value;
            }
        }
    }
}

