﻿namespace ControlLibrary.MKI062V1
{
    using ControlLibrary;
    using ControlLibrary.Properties;
    using iPlotLibrary;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class MainUserControl : ViewBase
    {
        private ToolStripMenuItem accelerometerToolStripMenuItem;
        private BindingSource bindingSource1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private ToolStripMenuItem clearToolStripMenuItem;
        private IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyPlotToolStripMenuItem;
        private ToolStripMenuItem cursorsToolStripMenuItem;
        private DataSet dataSet1;
        private DataTable dataTable1;
        private ToolStripMenuItem dataViewToolStripMenuItem;
        private ViewSettings dlgViewSettings;
        private ToolStripMenuItem enableTrackingToolStripMenuItem;
        private ToolStripMenuItem goToMaxToolStripMenuItem;
        private ToolStripMenuItem goToMinToolStripMenuItem;
        private ToolStripMenuItem gyroscopeToolStripMenuItem;
        private ToolStripMenuItem magneticToolStripMenuItem;
        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private bool mNotSaved;
        private PictureBox pictureBox1;
        private ToolStripMenuItem pressureToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem stackedViewToolStripMenuItem;
        private ToolStripMenuItem tableToolStripMenuItem;
        private ToolStripMenuItem temperatureToolStripMenuItem;
        private ToolStripMenuItem toolMenuToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton10;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton9;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSCTexBox toolStripTextBox1;
        private CommonControl userControl1;
        private CommonControl userControl2;
        private CommonControl userControl3;
        private CommonControl userControl4;
        private CommonControl userControl5;
        private CommonDataView userControl6;
        private VirtualPanel virtualPanel;
        private ToolStripMenuItem zomOutToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomToFitToolStripMenuItem;

        public MainUserControl()
        {
            this.InitializeComponent();
            this.virtualPanel = new VirtualPanel(this);
            this.userControl1 = new CommonControl();
            this.userControl2 = new CommonControl();
            this.userControl3 = new CommonControl();
            this.userControl4 = new CommonControl();
            this.userControl5 = new CommonControl();
            this.userControl6 = new CommonDataView();
            this.dlgViewSettings = new ViewSettings();
            AxeInformation item = new AxeInformation();
            this.dataSet1.Tables[0].PrimaryKey = new DataColumn[] { this.dataSet1.Tables[0].Columns.Add("Timestamp", System.Type.GetType("System.Double")) };
            ControlComponentConfiguration ctrlConf = new ControlComponentConfiguration {
                DataInMemory = this.dataSet1.Tables[0],
                GroupName = "Accelerometer"
            };
            ctrlConf.Axes.Clear();
            item.Name = "X";
            item.Unit = "mg";
            item.MinValue = -2000.0;
            item.MaxValue = 2000.0;
            item.Visible = true;
            item.Color = AxeColor.XColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            item.Name = "Y";
            item.Color = AxeColor.YColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            item.Name = "Z";
            item.Color = AxeColor.ZColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            ctrlConf.ShowStacked = true;
            this.userControl1.Configure(ctrlConf);
            ctrlConf.Axes.Clear();
            ctrlConf.GroupName = "Gyroscope";
            item.Name = "X";
            item.Unit = "dps";
            item.MinValue = -300.0;
            item.MaxValue = 300.0;
            item.Color = AxeColor.XColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            item.Name = "Y1";
            item.Color = AxeColor.YColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            item.Name = "Y2";
            item.Visible = false;
            item.Color = AxeColor.YColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            item.Name = "Z";
            item.Visible = true;
            item.Color = AxeColor.ZColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            ctrlConf.ShowStacked = true;
            this.userControl2.Configure(ctrlConf);
            ctrlConf.Axes.Clear();
            ctrlConf.GroupName = "Magnetometer";
            item.Name = "X";
            item.Unit = "mGa";
            item.MinValue = -700.0;
            item.MaxValue = 700.0;
            item.Color = AxeColor.XColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            item.Name = "Y";
            item.Color = AxeColor.YColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            item.Name = "Z";
            item.Color = AxeColor.ZColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            ctrlConf.Axes.Add(item);
            ctrlConf.ShowStacked = true;
            this.userControl3.Configure(ctrlConf);
            ctrlConf.Axes.Clear();
            ctrlConf.GroupName = "";
            item.Name = "Pressure";
            item.Unit = "mbar";
            item.MinValue = 800.0;
            item.MaxValue = 1100.0;
            item.Color = AxeColor.XColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            item.Precision = 1;
            item.StrType = "System.Double";
            ctrlConf.Axes.Add(item);
            ctrlConf.ShowStacked = true;
            this.userControl4.Configure(ctrlConf);
            ctrlConf.Axes.Clear();
            ctrlConf.GroupName = "";
            item.Name = "Temperature";
            item.Unit = "\x00baC";
            item.MinValue = -10.0;
            item.MaxValue = 70.0;
            item.Color = AxeColor.XColor;
            item.LineStyle = TxiPlotLineStyle.iplsSolid;
            item.Precision = 1;
            item.StrType = "System.Double";
            ctrlConf.Axes.Add(item);
            ctrlConf.ShowStacked = true;
            this.userControl5.Configure(ctrlConf);
            ctrlConf.Source = this.bindingSource1;
            this.userControl6.Configure(ctrlConf);
            this.virtualPanel.Add(this.button1, this.userControl1, this.accelerometerToolStripMenuItem);
            this.virtualPanel.Add(this.button2, this.userControl2, this.gyroscopeToolStripMenuItem);
            this.virtualPanel.Add(this.button3, this.userControl3, this.magneticToolStripMenuItem);
            this.virtualPanel.Add(this.button5, this.userControl4, this.pressureToolStripMenuItem);
            this.virtualPanel.Add(this.button4, this.userControl5, this.temperatureToolStripMenuItem);
            this.virtualPanel.Add(this.button6, this.userControl6, this.tableToolStripMenuItem);
            this.virtualPanel.BackColor = this.BackColor;
            this.virtualPanel.AdjustLayout(base.Size);
            this.button1.PerformClick();
            this.menuStrip1.Visible = false;
            this.menuStrip2.Visible = false;
            this.toolStripButton1.Checked = true;
            this.toolStripButton2.Checked = false;
            this.toolStripButton3.Checked = true;
            this.stackedViewToolStripMenuItem.Checked = this.toolStripButton1.Checked;
            this.cursorsToolStripMenuItem.Checked = this.toolStripButton2.Checked;
            this.enableTrackingToolStripMenuItem.Checked = this.toolStripButton3.Checked;
            this.toolStripComboBox1.SelectedIndex = 0;
            this.SetVisibleData();
            this.ThereAreDataNotSaved = false;
        }

        public override void AddDataObject(object data)
        {
            double[] dataarr = new double[4];
            double[] numArray2 = new double[5];
            double[] numArray3 = new double[4];
            double[] numArray4 = new double[2];
            double[] numArray5 = new double[2];
            if (data is FrameData)
            {
                double num;
                double num2;
                double num3;
                FrameData data2 = (FrameData) data;
                this.DataDocument.Add(data2.ToObjArray());
                FrameData data3 = (FrameData) data;
                numArray5[0] = num = data3.TimeStampInMillis;
                numArray4[0] = num2 = num;
                numArray3[0] = num3 = num2;
                dataarr[0] = numArray2[0] = num3;
                dataarr[1] = ((FrameData) data).Accelometer.X;
                dataarr[2] = ((FrameData) data).Accelometer.Y;
                dataarr[3] = ((FrameData) data).Accelometer.Z;
                numArray2[1] = ((FrameData) data).Gyroscope.X;
                numArray2[2] = ((FrameData) data).Gyroscope.Y1;
                numArray2[3] = ((FrameData) data).Gyroscope.Y2;
                numArray2[4] = ((FrameData) data).Gyroscope.Z;
                numArray3[1] = ((FrameData) data).Magnetic.X;
                numArray3[2] = ((FrameData) data).Magnetic.Y;
                numArray3[3] = ((FrameData) data).Magnetic.Z;
                FrameData data4 = (FrameData) data;
                numArray4[1] = data4.PressureInMbar;
                FrameData data5 = (FrameData) data;
                numArray5[1] = data5.TemperatureInC;
                this.userControl1.AddData(dataarr);
                this.userControl2.AddData(numArray2);
                this.userControl3.AddData(numArray3);
                this.userControl4.AddData(numArray4);
                this.userControl5.AddData(numArray5);
                this.ThereAreDataNotSaved = true;
            }
        }

        public override bool ClearData()
        {
            return this.ClearData(true);
        }

        public override bool ClearData(bool enableAsk)
        {
            bool flag = true;
            this.Cursor = Cursors.WaitCursor;
            if (((base.OnSave != null) && this.ThereAreDataNotSaved) && enableAsk)
            {
                switch (MessageBox.Show("There are data not saved. \n\nDo you want save before proceed?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk))
                {
                    case DialogResult.Yes:
                        base.OnSave();
                        break;

                    case DialogResult.Cancel:
                        flag = false;
                        break;
                }
            }
            if (flag)
            {
                this.userControl1.ClearData();
                this.userControl2.ClearData();
                this.userControl3.ClearData();
                this.userControl4.ClearData();
                this.userControl5.ClearData();
                this.DataDocument.Clear();
                if (base.OnClear != null)
                {
                    base.OnClear();
                }
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("Data buffer cleared");
                }
                this.ThereAreDataNotSaved = false;
            }
            this.Cursor = Cursors.Default;
            return flag;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }

        private void copyPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((CommonControlBase) this.virtualPanel.Selected.UserControl).Copy();
        }

        private void cursorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton2.Checked = !this.toolStripButton2.Checked;
            this.cursorsToolStripMenuItem.Checked = this.toolStripButton2.Checked;
            this.userControl1.ShowCursor = !this.userControl1.ShowCursor;
            this.userControl2.ShowCursor = !this.userControl2.ShowCursor;
            this.userControl3.ShowCursor = !this.userControl3.ShowCursor;
            this.userControl4.ShowCursor = !this.userControl4.ShowCursor;
            this.userControl5.ShowCursor = !this.userControl5.ShowCursor;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void enableTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton3.Checked = !this.toolStripButton3.Checked;
            this.enableTrackingToolStripMenuItem.Checked = this.toolStripButton3.Checked;
            this.userControl1.TrackingEnabled = this.toolStripButton3.Checked;
            this.userControl2.TrackingEnabled = this.toolStripButton3.Checked;
            this.userControl3.TrackingEnabled = this.toolStripButton3.Checked;
            this.userControl4.TrackingEnabled = this.toolStripButton3.Checked;
            this.userControl5.TrackingEnabled = this.toolStripButton3.Checked;
        }

        private void goToMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((CommonControlBase) this.virtualPanel.Selected.UserControl).GoToMax();
        }

        private void goToMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((CommonControlBase) this.virtualPanel.Selected.UserControl).GoToMin();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.toolStrip1 = new ToolStrip();
            this.toolStripButton1 = new ToolStripButton();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.toolStripButton2 = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripButton3 = new ToolStripButton();
            this.toolStripSeparator4 = new ToolStripSeparator();
            this.toolStripButton7 = new ToolStripButton();
            this.toolStripButton8 = new ToolStripButton();
            this.toolStripButton9 = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.toolStripButton4 = new ToolStripButton();
            this.toolStripButton5 = new ToolStripButton();
            this.toolStripButton6 = new ToolStripButton();
            this.toolStripSeparator5 = new ToolStripSeparator();
            this.toolStripButton10 = new ToolStripButton();
            this.menuStrip1 = new MenuStrip();
            this.toolMenuToolStripMenuItem = new ToolStripMenuItem();
            this.stackedViewToolStripMenuItem = new ToolStripMenuItem();
            this.cursorsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripSeparator();
            this.enableTrackingToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem2 = new ToolStripSeparator();
            this.goToMinToolStripMenuItem = new ToolStripMenuItem();
            this.goToMaxToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem3 = new ToolStripSeparator();
            this.zoomToFitToolStripMenuItem = new ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new ToolStripMenuItem();
            this.zomOutToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem6 = new ToolStripSeparator();
            this.clearToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip2 = new MenuStrip();
            this.dataViewToolStripMenuItem = new ToolStripMenuItem();
            this.accelerometerToolStripMenuItem = new ToolStripMenuItem();
            this.gyroscopeToolStripMenuItem = new ToolStripMenuItem();
            this.magneticToolStripMenuItem = new ToolStripMenuItem();
            this.pressureToolStripMenuItem = new ToolStripMenuItem();
            this.temperatureToolStripMenuItem = new ToolStripMenuItem();
            this.tableToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem5 = new ToolStripSeparator();
            this.settingsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem7 = new ToolStripSeparator();
            this.copyPlotToolStripMenuItem = new ToolStripMenuItem();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.dataSet1 = new DataSet();
            this.dataTable1 = new DataTable();
            this.bindingSource1 = new BindingSource(this.components);
            this.button2 = new Button();
            this.button6 = new Button();
            this.button5 = new Button();
            this.button4 = new Button();
            this.button3 = new Button();
            this.button1 = new Button();
            this.pictureBox1 = new PictureBox();
            this.toolStripComboBox1 = new ToolStripComboBox();
            this.toolStripTextBox1 = new ToolStripSCTexBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.dataSet1.BeginInit();
            this.dataTable1.BeginInit();
            ((ISupportInitialize) this.bindingSource1).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.toolStrip1.Dock = DockStyle.None;
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { 
                this.toolStripButton1, this.toolStripSeparator3, this.toolStripButton2, this.toolStripSeparator1, this.toolStripButton3, this.toolStripSeparator4, this.toolStripButton7, this.toolStripButton8, this.toolStripTextBox1, this.toolStripButton9, this.toolStripSeparator2, this.toolStripComboBox1, this.toolStripButton4, this.toolStripButton5, this.toolStripButton6, this.toolStripSeparator5, 
                this.toolStripButton10
             });
            this.toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new Point(0, 0x30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(0x1e3, 0x19);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = Resources.CascadeWindowsHS;
            this.toolStripButton1.ImageTransparentColor = Color.Magenta;
            this.toolStripButton1.MergeIndex = 1;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new Size(0x17, 0x16);
            this.toolStripButton1.Text = "Stacking view";
            this.toolStripButton1.Click += new EventHandler(this.stackedViewToolStripMenuItem_Click);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(6, 0x19);
            this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = Resources.ShowRulelinesHS;
            this.toolStripButton2.ImageTransparentColor = Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new Size(0x17, 0x16);
            this.toolStripButton2.Text = "Show/Hide cursor";
            this.toolStripButton2.Click += new EventHandler(this.cursorsToolStripMenuItem_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 0x19);
            this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = Resources.Tracking;
            this.toolStripButton3.ImageTransparentColor = Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new Size(0x17, 0x16);
            this.toolStripButton3.Text = "Enable Tracking";
            this.toolStripButton3.ToolTipText = "Enable Tracking";
            this.toolStripButton3.Click += new EventHandler(this.enableTrackingToolStripMenuItem_Click);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new Size(6, 0x19);
            this.toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = Resources.GotoMin;
            this.toolStripButton7.ImageTransparentColor = Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new Size(0x17, 0x16);
            this.toolStripButton7.Text = "Go to begin";
            this.toolStripButton7.Click += new EventHandler(this.goToMinToolStripMenuItem_Click);
            this.toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = Resources.GotoMax;
            this.toolStripButton8.ImageTransparentColor = Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new Size(0x17, 0x16);
            this.toolStripButton8.Text = "Go to end";
            this.toolStripButton8.Click += new EventHandler(this.goToMaxToolStripMenuItem_Click);
            this.toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = Resources.GoTo;
            this.toolStripButton9.ImageTransparentColor = Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new Size(0x17, 0x16);
            this.toolStripButton9.Text = "Go to";
            this.toolStripButton9.Click += new EventHandler(this.toolStripButton9_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 0x19);
            this.toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = Resources.ZoomToFit;
            this.toolStripButton4.ImageTransparentColor = Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new Size(0x17, 0x16);
            this.toolStripButton4.Text = "Zoom to Fit";
            this.toolStripButton4.Click += new EventHandler(this.zoomToFitToolStripMenuItem_Click);
            this.toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = Resources.ZoomIn;
            this.toolStripButton5.ImageTransparentColor = Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new Size(0x17, 0x16);
            this.toolStripButton5.Text = "ZoomIn";
            this.toolStripButton5.Click += new EventHandler(this.zoomInToolStripMenuItem_Click);
            this.toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = Resources.ZoomOut;
            this.toolStripButton6.ImageTransparentColor = Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new Size(0x17, 0x16);
            this.toolStripButton6.Text = "ZoomOut";
            this.toolStripButton6.Click += new EventHandler(this.zomOutToolStripMenuItem_Click);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new Size(6, 0x19);
            this.toolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = Resources.Clear;
            this.toolStripButton10.ImageTransparentColor = Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new Size(0x17, 0x16);
            this.toolStripButton10.Text = "Clear";
            this.toolStripButton10.Click += new EventHandler(this.clearToolStripMenuItem_Click);
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.toolMenuToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0x18);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x29f, 0x18);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            this.toolMenuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.stackedViewToolStripMenuItem, this.cursorsToolStripMenuItem, this.toolStripMenuItem1, this.enableTrackingToolStripMenuItem, this.toolStripMenuItem2, this.goToMinToolStripMenuItem, this.goToMaxToolStripMenuItem, this.toolStripMenuItem3, this.zoomToFitToolStripMenuItem, this.zoomInToolStripMenuItem, this.zomOutToolStripMenuItem, this.toolStripMenuItem6, this.clearToolStripMenuItem });
            this.toolMenuToolStripMenuItem.Name = "toolMenuToolStripMenuItem";
            this.toolMenuToolStripMenuItem.Size = new Size(0x3b, 20);
            this.toolMenuToolStripMenuItem.Text = "Controls";
            this.stackedViewToolStripMenuItem.Name = "stackedViewToolStripMenuItem";
            this.stackedViewToolStripMenuItem.Size = new Size(160, 0x16);
            this.stackedViewToolStripMenuItem.Text = "Stacked View";
            this.stackedViewToolStripMenuItem.Click += new EventHandler(this.stackedViewToolStripMenuItem_Click);
            this.cursorsToolStripMenuItem.Name = "cursorsToolStripMenuItem";
            this.cursorsToolStripMenuItem.Size = new Size(160, 0x16);
            this.cursorsToolStripMenuItem.Text = "Cursors";
            this.cursorsToolStripMenuItem.Click += new EventHandler(this.cursorsToolStripMenuItem_Click);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(0x9d, 6);
            this.enableTrackingToolStripMenuItem.Name = "enableTrackingToolStripMenuItem";
            this.enableTrackingToolStripMenuItem.Size = new Size(160, 0x16);
            this.enableTrackingToolStripMenuItem.Text = "Enable Tracking";
            this.enableTrackingToolStripMenuItem.Click += new EventHandler(this.enableTrackingToolStripMenuItem_Click);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(0x9d, 6);
            this.goToMinToolStripMenuItem.Name = "goToMinToolStripMenuItem";
            this.goToMinToolStripMenuItem.Size = new Size(160, 0x16);
            this.goToMinToolStripMenuItem.Text = "Go to Begin";
            this.goToMinToolStripMenuItem.ToolTipText = "Go to begin";
            this.goToMinToolStripMenuItem.Click += new EventHandler(this.goToMinToolStripMenuItem_Click);
            this.goToMaxToolStripMenuItem.Name = "goToMaxToolStripMenuItem";
            this.goToMaxToolStripMenuItem.Size = new Size(160, 0x16);
            this.goToMaxToolStripMenuItem.Text = "Go to End";
            this.goToMaxToolStripMenuItem.ToolTipText = "Go to End";
            this.goToMaxToolStripMenuItem.Click += new EventHandler(this.goToMaxToolStripMenuItem_Click);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size(0x9d, 6);
            this.zoomToFitToolStripMenuItem.Name = "zoomToFitToolStripMenuItem";
            this.zoomToFitToolStripMenuItem.Size = new Size(160, 0x16);
            this.zoomToFitToolStripMenuItem.Text = "Zoom to Fit";
            this.zoomToFitToolStripMenuItem.Click += new EventHandler(this.zoomToFitToolStripMenuItem_Click);
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new Size(160, 0x16);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new EventHandler(this.zoomInToolStripMenuItem_Click);
            this.zomOutToolStripMenuItem.Name = "zomOutToolStripMenuItem";
            this.zomOutToolStripMenuItem.Size = new Size(160, 0x16);
            this.zomOutToolStripMenuItem.Text = "Zoom Out";
            this.zomOutToolStripMenuItem.Click += new EventHandler(this.zomOutToolStripMenuItem_Click);
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new Size(0x9d, 6);
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new Size(160, 0x16);
            this.clearToolStripMenuItem.Text = "Clear ";
            this.clearToolStripMenuItem.Click += new EventHandler(this.clearToolStripMenuItem_Click);
            this.menuStrip2.Items.AddRange(new ToolStripItem[] { this.dataViewToolStripMenuItem });
            this.menuStrip2.Location = new Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new Size(0x29f, 0x18);
            this.menuStrip2.TabIndex = 8;
            this.menuStrip2.Text = "menuStrip2";
            this.dataViewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.accelerometerToolStripMenuItem, this.gyroscopeToolStripMenuItem, this.magneticToolStripMenuItem, this.pressureToolStripMenuItem, this.temperatureToolStripMenuItem, this.tableToolStripMenuItem, this.toolStripMenuItem5, this.settingsToolStripMenuItem, this.toolStripMenuItem7, this.copyPlotToolStripMenuItem });
            this.dataViewToolStripMenuItem.Name = "dataViewToolStripMenuItem";
            this.dataViewToolStripMenuItem.Size = new Size(0x43, 20);
            this.dataViewToolStripMenuItem.Text = "Data View";
            this.accelerometerToolStripMenuItem.Name = "accelerometerToolStripMenuItem";
            this.accelerometerToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.accelerometerToolStripMenuItem.Text = "Accelerometer";
            this.gyroscopeToolStripMenuItem.Name = "gyroscopeToolStripMenuItem";
            this.gyroscopeToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.gyroscopeToolStripMenuItem.Text = "Gyroscope";
            this.magneticToolStripMenuItem.Name = "magneticToolStripMenuItem";
            this.magneticToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.magneticToolStripMenuItem.Text = "Magnetometer";
            this.pressureToolStripMenuItem.Name = "pressureToolStripMenuItem";
            this.pressureToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.pressureToolStripMenuItem.Text = "Pressure";
            this.temperatureToolStripMenuItem.Name = "temperatureToolStripMenuItem";
            this.temperatureToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.temperatureToolStripMenuItem.Text = "Temperature";
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.tableToolStripMenuItem.Text = "Report";
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new Size(0x98, 6);
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new EventHandler(this.settingsToolStripMenuItem_Click);
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new Size(0x98, 6);
            this.copyPlotToolStripMenuItem.Name = "copyPlotToolStripMenuItem";
            this.copyPlotToolStripMenuItem.Size = new Size(0x9b, 0x16);
            this.copyPlotToolStripMenuItem.Text = "Copy";
            this.copyPlotToolStripMenuItem.ToolTipText = "Copy plot image to clipboard";
            this.copyPlotToolStripMenuItem.Click += new EventHandler(this.copyPlotToolStripMenuItem_Click);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x3d, 4);
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new DataTable[] { this.dataTable1 });
            this.dataTable1.TableName = "Table1";
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.DataMember = "Table1";
            this.bindingSource1.DataSource = this.dataSet1;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.Image = Resources.Gyroscopeb;
            this.button2.Location = new Point(0xce, 0x76);
            this.button2.Margin = new Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x54, 0x54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Gyroscope";
            this.button2.TextAlign = ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = FlatStyle.Flat;
            this.button6.Image = Resources.Dataview;
            this.button6.Location = new Point(0, 0xf7);
            this.button6.Margin = new Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new Size(0x54, 0x54);
            this.button6.TabIndex = 10;
            this.button6.Text = "Report";
            this.button6.TextAlign = ContentAlignment.BottomCenter;
            this.button6.TextImageRelation = TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = true;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = FlatStyle.Flat;
            this.button5.Image = Resources.Pressure1;
            this.button5.Location = new Point(0x13a, 0xca);
            this.button5.Margin = new Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new Size(0x54, 0x54);
            this.button5.TabIndex = 9;
            this.button5.Text = "Pressure";
            this.button5.TextAlign = ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = true;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = FlatStyle.Flat;
            this.button4.Image = Resources.thermometer;
            this.button4.Location = new Point(0xc5, 0xd3);
            this.button4.Margin = new Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x54, 0x54);
            this.button4.TabIndex = 3;
            this.button4.Text = "Temperature";
            this.button4.TextAlign = ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = FlatStyle.Flat;
            this.button3.Image = Resources.Compassb;
            this.button3.Location = new Point(510, 0x76);
            this.button3.Margin = new Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x54, 0x54);
            this.button3.TabIndex = 2;
            this.button3.Text = "Magnetometer";
            this.button3.TextAlign = ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Image = Resources.accelerometer;
            this.button1.Location = new Point(0x189, 0x76);
            this.button1.Margin = new Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x54, 0x54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Accelerometer";
            this.button1.TextAlign = ContentAlignment.TopCenter;
            this.button1.TextImageRelation = TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.pictureBox1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.pictureBox1.Image = Resources._64x64_32bit;
            this.pictureBox1.Location = new Point(0x254, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x40, 0x40);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] { "Horizontal Zoom ", "Vertical Zoom", "All" });
            this.toolStripComboBox1.MaxDropDownItems = 3;
            this.toolStripComboBox1.MaxLength = 0x10;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new Size(100, 0x19);
            this.toolStripComboBox1.ToolTipText = "Zoom mode selection";
            this.toolStripTextBox1.AcceptOnlyNumber = true;
            this.toolStripTextBox1.MaxLength = 10;
            this.toolStripTextBox1.MaxValue = 0x100000000L;
            this.toolStripTextBox1.MinValue = 0L;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new Size(80, 0x15);
            this.toolStripTextBox1.TextBoxAlign = HorizontalAlignment.Right;
            this.toolStripTextBox1.ToolTipText = "Go to";
            this.toolStripTextBox1.KeyPress += new KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            this.BackColor = SystemColors.Control;
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button6);
            base.Controls.Add(this.button5);
            base.Controls.Add(this.button4);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.menuStrip1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.menuStrip2);
            base.Controls.Add(this.toolStrip1);
            base.Controls.Add(this.pictureBox1);
            base.Name = "MainUserControl";
            base.Size = new Size(0x29f, 0x14b);
            base.Resize += new EventHandler(this.MainUserControl_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.dataSet1.EndInit();
            this.dataTable1.EndInit();
            ((ISupportInitialize) this.bindingSource1).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public override void LoadDataFile(string strFileToLoad)
        {
            StreamReader reader = null;
            string[] strArray;
            FrameData data = new FrameData();
            bool flag = true;
            this.Cursor = Cursors.WaitCursor;
            if (base.OnMessageToLog != null)
            {
                base.OnMessageToLog("Loading data file [" + strFileToLoad + "]");
            }
            try
            {
                reader = new StreamReader(strFileToLoad);
            }
            catch (Exception exception)
            {
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("Error opening the selected file :" + exception.Message);
                }
                MessageBox.Show("Error opening the selected file :" + exception.Message);
                flag = false;
            }
            if (flag)
            {
                try
                {
                    bool flag2 = false;
                    strArray = reader.ReadLine().Split(new char[] { '\t' }, 13);
                    if (((strArray.Length == 13) && (strArray[0] == "Timestamp")) && (strArray[11] == "Pressure"))
                    {
                        flag2 = true;
                    }
                    if (!flag2)
                    {
                        if (base.OnMessageToLog != null)
                        {
                            base.OnMessageToLog("Unkwnon file format [" + strFileToLoad + "]");
                        }
                        flag = false;
                    }
                }
                catch
                {
                    if (base.OnMessageToLog != null)
                    {
                        base.OnMessageToLog("Unkwnon header file format [" + strFileToLoad + "] ");
                    }
                    flag = false;
                }
            }
            if (flag)
            {
                try
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        strArray = str.Split(new char[] { '\t' }, 13);
                        if (strArray.Length == 13)
                        {
                            data.TimeStamp = Convert.ToUInt32(strArray[0]);
                            data.Accelometer.X = Convert.ToInt16(strArray[1]);
                            data.Accelometer.Y = Convert.ToInt16(strArray[2]);
                            data.Accelometer.Z = Convert.ToInt16(strArray[3]);
                            data.Gyroscope.X = Convert.ToInt16(strArray[4]);
                            data.Gyroscope.Y1 = Convert.ToInt16(strArray[5]);
                            data.Gyroscope.Y2 = Convert.ToInt16(strArray[6]);
                            data.Gyroscope.Z = Convert.ToInt16(strArray[7]);
                            data.Magnetic.X = Convert.ToInt16(strArray[8]);
                            data.Magnetic.Y = Convert.ToInt16(strArray[9]);
                            data.Magnetic.Z = Convert.ToInt16(strArray[10]);
                            data.Pressure = Convert.ToUInt16(strArray[11]);
                            data.Temperature = Convert.ToInt16(strArray[12]);
                            this.AddDataObject(data);
                        }
                    }
                }
                catch (Exception exception2)
                {
                    if (base.OnMessageToLog != null)
                    {
                        base.OnMessageToLog("Error reading line " + exception2.Message);
                    }
                    flag = false;
                }
            }
            if (flag)
            {
                this.ThereAreDataNotSaved = false;
                if (base.OnMessageToLog != null)
                {
                    base.OnMessageToLog("Loaded data file [" + strFileToLoad + "]");
                }
            }
            reader.Close();
            this.Cursor = Cursors.Default;
        }

        private void MainUserControl_Resize(object sender, EventArgs e)
        {
            this.virtualPanel.AdjustLayout(base.Size);
        }

        public override void SaveFunction(string strFileName)
        {
            StreamWriter writer = new StreamWriter(strFileName);
            this.Cursor = Cursors.WaitCursor;
            if (base.OnMessageToLog != null)
            {
                base.OnMessageToLog("Saving data file [" + strFileName + "]");
            }
            if (writer != null)
            {
                writer.Write("Timestamp\t");
                writer.Write("Accelerometer-X\t");
                writer.Write("Accelerometer-Y\t");
                writer.Write("Accelerometer-Z\t");
                writer.Write("Gyroscope-X\t");
                writer.Write("Gyroscope-Y1\t");
                writer.Write("Gyroscope-Y2\t");
                writer.Write("Gyroscope-Z\t");
                writer.Write("Magnetometer-X\t");
                writer.Write("Magnetometer-Y\t");
                writer.Write("Magnetometer-Z\t");
                writer.Write("Pressure\t");
                writer.Write("Temperature\t");
                writer.WriteLine();
                foreach (DataRow row in this.DataDocument)
                {
                    writer.Write("{0}\t", ((uint) (Convert.ToDouble(row.ItemArray[0]) * 1000.0)).ToString());
                    writer.Write("{0}\t", row.ItemArray[1]);
                    writer.Write("{0}\t", row.ItemArray[2]);
                    writer.Write("{0}\t", row.ItemArray[3]);
                    writer.Write("{0}\t", row.ItemArray[4]);
                    writer.Write("{0}\t", row.ItemArray[5]);
                    writer.Write("{0}\t", row.ItemArray[6]);
                    writer.Write("{0}\t", row.ItemArray[7]);
                    writer.Write("{0}\t", row.ItemArray[8]);
                    writer.Write("{0}\t", row.ItemArray[9]);
                    writer.Write("{0}\t", row.ItemArray[10]);
                    writer.Write("{0}\t", ((ushort) (Convert.ToDouble(row.ItemArray[11]) * 10.0)).ToString());
                    writer.Write("{0}\t", ((ushort) (Convert.ToDouble(row.ItemArray[12]) * 10.0)).ToString());
                    writer.WriteLine();
                }
                writer.Close();
            }
            this.ThereAreDataNotSaved = false;
            if (base.OnMessageToLog != null)
            {
                base.OnMessageToLog("Saved data file [" + strFileName + "]");
            }
            this.Cursor = Cursors.Default;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dlgViewSettings.ShowDialog();
            this.SetVisibleData();
        }

        private void SetVisibleData()
        {
            if (this.dlgViewSettings.GyroscopeSelection == GyroscopeYAxe.Select_Y1)
            {
                this.userControl2.SetVisbleDataAxe(1, true);
                this.userControl2.SetVisbleDataAxe(2, false);
            }
            else
            {
                this.userControl2.SetVisbleDataAxe(1, false);
                this.userControl2.SetVisbleDataAxe(2, true);
            }
            this.virtualPanel.SelectionList[0].Enable = this.dlgViewSettings.Accelerometer;
            this.virtualPanel.SelectionList[1].Enable = this.dlgViewSettings.Gyroscope;
            this.virtualPanel.SelectionList[2].Enable = this.dlgViewSettings.Magnetormeter;
            this.virtualPanel.SelectionList[3].Enable = this.dlgViewSettings.Pressure;
            this.virtualPanel.SelectionList[4].Enable = this.dlgViewSettings.Temperature;
            this.virtualPanel.SelectionList[5].Enable = this.dlgViewSettings.Report;
        }

        public override void SetVisibleFirst()
        {
            if (!this.virtualPanel.Selected.Enable)
            {
                foreach (SingleSelection selection in this.virtualPanel.SelectionList)
                {
                    if (selection.Enable)
                    {
                        selection.Button.PerformClick();
                        break;
                    }
                }
            }
        }

        private void stackedViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton1.Checked = !this.toolStripButton1.Checked;
            this.stackedViewToolStripMenuItem.Checked = this.toolStripButton1.Checked;
            this.userControl1.ShowStacked = !this.userControl1.ShowStacked;
            this.userControl2.ShowStacked = !this.userControl2.ShowStacked;
            this.userControl3.ShowStacked = !this.userControl3.ShowStacked;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (this.toolStripTextBox1.Text.Length != 0)
            {
                ((CommonControlBase) this.virtualPanel.Selected.UserControl).GoTo(Convert.ToDouble(this.toolStripTextBox1.Text));
            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.toolStripButton9.PerformClick();
            }
        }

        private void zomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.toolStripComboBox1.SelectedIndex == 0) || (this.toolStripComboBox1.SelectedIndex == 2))
            {
                ((CommonControlBase) this.virtualPanel.Selected.UserControl).ZoomOut();
            }
            if ((this.toolStripComboBox1.SelectedIndex == 1) || (this.toolStripComboBox1.SelectedIndex == 2))
            {
                ((CommonControlBase) this.virtualPanel.Selected.UserControl).ZoomOutV();
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.toolStripComboBox1.SelectedIndex == 0) || (this.toolStripComboBox1.SelectedIndex == 2))
            {
                ((CommonControlBase) this.virtualPanel.Selected.UserControl).ZoomIn();
            }
            if ((this.toolStripComboBox1.SelectedIndex == 1) || (this.toolStripComboBox1.SelectedIndex == 2))
            {
                ((CommonControlBase) this.virtualPanel.Selected.UserControl).ZoomInV();
            }
        }

        private void zoomToFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.toolStripComboBox1.SelectedIndex == 0) || (this.toolStripComboBox1.SelectedIndex == 2))
            {
                ((CommonControlBase) this.virtualPanel.Selected.UserControl).ZoomToFit();
            }
            if ((this.toolStripComboBox1.SelectedIndex == 1) || (this.toolStripComboBox1.SelectedIndex == 2))
            {
                ((CommonControlBase) this.virtualPanel.Selected.UserControl).ZoomToFitV();
            }
        }

        public override bool DataAvailable
        {
            get
            {
                return (this.DataDocument.Count > 0);
            }
        }

        public DataRowCollection DataDocument
        {
            get
            {
                return this.dataSet1.Tables[0].Rows;
            }
        }

        public override DeviceSensorDataAvailable DeviceSensors
        {
            get
            {
                return (DeviceSensorDataAvailable.DSDA_ACELEROMETER | DeviceSensorDataAvailable.DSDA_GYROSCOPE | DeviceSensorDataAvailable.DSDA_MAGNETOMER | DeviceSensorDataAvailable.DSDA_PRESSURE | DeviceSensorDataAvailable.DSDA_TEMPERATURE);
            }
            set
            {
            }
        }

        public override bool EnableRotationDataView
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public override ToolStripItemCollection LocalMenuBarTool
        {
            get
            {
                return this.menuStrip1.Items;
            }
        }

        public override ToolStripItemCollection LocalMenuBarView
        {
            get
            {
                return this.menuStrip2.Items;
            }
        }

        public override ToolStrip LocalToolBar
        {
            get
            {
                return this.toolStrip1;
            }
        }

        public bool ThereAreDataNotSaved
        {
            get
            {
                return this.mNotSaved;
            }
            set
            {
                this.mNotSaved = value;
            }
        }
    }
}

