﻿namespace iNEMO_Application
{
    using ControlLibrary;
    using ControlLibrary.MKI062V1;
    using ControlLibrary.MKI062V2;
    using iNEMO_Application.Properties;
    using KS;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.IO.Ports;
    using System.Windows.Forms;

    public class MainForm : Form
    {
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ColumnHeader Action;
        private ToolStripMenuItem clearLogToolStripMenuItem;
        private CommunicationBase communicationMain;
        private IContainer components;
        private bool configurationLoaded;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private KSSelector kitSelector;
        private ListView ListLog;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem logBarToolStripMenuItem;
        private string mDeviceSelected;
        private MenuStrip menuStrip1;
        private string mFileName;
        private ToolStripMenuItem newToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private SaveFileDialog saveLogFileDialog;
        private ToolStripMenuItem saveLogToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private SerialPort serialPort1;
        private SplitContainer splitContainer;
        private ToolStripMenuItem statusbarToolStripMenuItem;
        private StatusStrip statusStrip1;
        private TabPage tabLog;
        private TabControl tabOutputs;
        private ColumnHeader Timestamp;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonLoad;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonSave;
        private ToolStripButton toolStripButtonSaveAs;
        private ToolStripContainer toolStripContainer1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ViewBase userCtrlMain;
		private ToolStripMenuItem kitEditorToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;

        public MainForm()
        {
            InitializeComponent();

            mDeviceSelected = "";
            KSDataProvider provider = new KSDataProvider();
            provider.Load("inemo.dbk");
            KSKit selKit = provider.MoveTo(KSDataProvider.CursorStep.CursorLast);
            provider = null;
            try
            {
                selKit.Socket.Param = SerialPort.GetPortNames()[SerialPort.GetPortNames().Length - 1];
            }
            catch
            {
                selKit.Socket.Param = "";
            }
            kitSelector = new KSSelector("inemo.dbk", selKit);
            kitSelector.ShowInTaskbar = false;
            SetDeviceAndCommunication();
            FileDataName = null;
            OnTCP_Change(TCP_State.TCP_STATE_SERVER_STOP, "TCP/IP Demo server stopped");
            DeviceSelection();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            if (communicationMain.DeviceConnected)
            {
                about.ShowAbout(base.Handle, communicationMain.MCUID, communicationMain.FirmwareVersion, communicationMain.HardwareVersion);
            }
            else
            {
                about.ShowAbout(base.Handle, communicationMain.DeviceType.ToString() + " not connected", "", "");
            }
        }

        private bool AddDataInPlot(object data)
        {
            bool flag = true;
            try
            {
                userCtrlMain.AddDataObject(data);
            }
            catch
            {
                flag = false;
                AddInLogBar("Error: Out of memory.");
            }
            return flag;
        }

        private void AddInLogBar(string srtMessage)
        {
            ListLog.Items.Add(DateTime.Now.ToLongTimeString()).SubItems.Add(srtMessage);
            ListLog.Items[ListLog.Items.Count - 1].EnsureVisible();
            ListLog.Refresh();
            saveLogToolStripMenuItem.Enabled = true;
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListLog.Items.Clear();
            saveLogToolStripMenuItem.Enabled = false;
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "iNEMO.chm");
        }

        private void DeviceSelection()
        {
            if (!communicationMain.DeviceConnected)
            {
                if (userCtrlMain.DataAvailable)
                {
                    MessageBox.Show("Change device settings not available. \n\nClear data before procede", "Error on change device", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (kitSelector.ShowDialog() == DialogResult.OK)
                {
                    SetDeviceAndCommunication();
                }
            }
            else
            {
                MessageBox.Show("Change device settings not available. \n\nDisconnect before procede", "Error on change device", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tabOutputs = new System.Windows.Forms.TabControl();
			this.tabLog = new System.Windows.Forms.TabPage();
			this.ListLog = new System.Windows.Forms.ListView();
			this.Timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveLogFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.kitEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.tabOutputs.SuspendLayout();
			this.tabLog.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(739, 502);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(739, 555);
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
			this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 0);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(739, 25);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.AutoSize = false;
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 20);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(64, 20);
			this.toolStripStatusLabel2.Text = "TCP info";
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.tabOutputs);
			this.splitContainer.Size = new System.Drawing.Size(739, 502);
			this.splitContainer.SplitterDistance = 381;
			this.splitContainer.TabIndex = 4;
			// 
			// tabOutputs
			// 
			this.tabOutputs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabOutputs.Controls.Add(this.tabLog);
			this.tabOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabOutputs.Location = new System.Drawing.Point(0, 0);
			this.tabOutputs.Multiline = true;
			this.tabOutputs.Name = "tabOutputs";
			this.tabOutputs.SelectedIndex = 0;
			this.tabOutputs.Size = new System.Drawing.Size(739, 117);
			this.tabOutputs.TabIndex = 0;
			// 
			// tabLog
			// 
			this.tabLog.Controls.Add(this.ListLog);
			this.tabLog.Location = new System.Drawing.Point(4, 4);
			this.tabLog.Margin = new System.Windows.Forms.Padding(0);
			this.tabLog.Name = "tabLog";
			this.tabLog.Size = new System.Drawing.Size(731, 91);
			this.tabLog.TabIndex = 0;
			this.tabLog.Text = "Log";
			this.tabLog.UseVisualStyleBackColor = true;
			// 
			// ListLog
			// 
			this.ListLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Timestamp,
            this.Action});
			this.ListLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListLog.Location = new System.Drawing.Point(0, 0);
			this.ListLog.Margin = new System.Windows.Forms.Padding(0);
			this.ListLog.Name = "ListLog";
			this.ListLog.Size = new System.Drawing.Size(731, 91);
			this.ListLog.TabIndex = 0;
			this.ListLog.UseCompatibleStateImageBehavior = false;
			this.ListLog.View = System.Windows.Forms.View.Details;
			// 
			// Timestamp
			// 
			this.Timestamp.Text = "Timestamp";
			this.Timestamp.Width = 111;
			// 
			// Action
			// 
			this.Action.Text = "Message";
			this.Action.Width = 800;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(739, 28);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem4,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveLogToolStripMenuItem,
            this.clearLogToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.loadToolStripMenuItem.Text = "Load...";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
			// 
			// saveLogToolStripMenuItem
			// 
			this.saveLogToolStripMenuItem.Enabled = false;
			this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
			this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.saveLogToolStripMenuItem.Text = "Save log";
			this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
			// 
			// clearLogToolStripMenuItem
			// 
			this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
			this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.clearLogToolStripMenuItem.Text = "Clear log";
			this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusbarToolStripMenuItem,
            this.logBarToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// statusbarToolStripMenuItem
			// 
			this.statusbarToolStripMenuItem.Checked = true;
			this.statusbarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.statusbarToolStripMenuItem.Name = "statusbarToolStripMenuItem";
			this.statusbarToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.statusbarToolStripMenuItem.Text = "Statusbar";
			this.statusbarToolStripMenuItem.Click += new System.EventHandler(this.statusbarToolStripMenuItem_Click);
			// 
			// logBarToolStripMenuItem
			// 
			this.logBarToolStripMenuItem.Checked = true;
			this.logBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.logBarToolStripMenuItem.Name = "logBarToolStripMenuItem";
			this.logBarToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.logBarToolStripMenuItem.Text = "Log bar";
			this.logBarToolStripMenuItem.Click += new System.EventHandler(this.logBarToolStripMenuItem_Click);
			// 
			// toolToolStripMenuItem
			// 
			this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitEditorToolStripMenuItem});
			this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
			this.toolToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.toolToolStripMenuItem.Text = "Tools";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contentsToolStripMenuItem.Image")));
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.contentsToolStripMenuItem.Text = "Contents";
			this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonLoad,
            this.toolStripSeparator1,
            this.toolStripButtonSave,
            this.toolStripButtonSaveAs});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(64, 25);
			this.toolStrip1.TabIndex = 5;
			// 
			// toolStripButtonNew
			// 
			this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
			this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonNew.Name = "toolStripButtonNew";
			this.toolStripButtonNew.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonNew.Text = "toolStripButton1";
			this.toolStripButtonNew.ToolTipText = "New data file";
			this.toolStripButtonNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// toolStripButtonLoad
			// 
			this.toolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoad.Image")));
			this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonLoad.Name = "toolStripButtonLoad";
			this.toolStripButtonLoad.Size = new System.Drawing.Size(23, 20);
			this.toolStripButtonLoad.Text = "Load data file";
			this.toolStripButtonLoad.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonSave
			// 
			this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSave.Enabled = false;
			this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
			this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSave.Name = "toolStripButtonSave";
			this.toolStripButtonSave.Size = new System.Drawing.Size(23, 20);
			this.toolStripButtonSave.Text = "Save";
			this.toolStripButtonSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripButtonSaveAs
			// 
			this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveAs.Image")));
			this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
			this.toolStripButtonSaveAs.Size = new System.Drawing.Size(23, 20);
			this.toolStripButtonSaveAs.Text = "Save as...";
			this.toolStripButtonSaveAs.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "tsv";
			this.saveFileDialog.Filter = "Tab Separated Values(*.tsv)|*.tsv";
			this.saveFileDialog.InitialDirectory = "Environment.SpecialFolder.MyDocuments";
			this.saveFileDialog.Title = "Save acquisition data file";
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "*.tsv";
			this.openFileDialog.Title = "Load acquistion data file";
			// 
			// saveLogFileDialog
			// 
			this.saveLogFileDialog.DefaultExt = "log";
			this.saveLogFileDialog.Filter = "Log file (*.log)|*.log";
			this.saveLogFileDialog.InitialDirectory = "Environment.SpecialFolder.MyDocuments";
			// 
			// serialPort1
			// 
			this.serialPort1.BaudRate = 115200;
			this.serialPort1.Parity = System.IO.Ports.Parity.Odd;
			this.serialPort1.PortName = "COM6";
			// 
			// kitEditorToolStripMenuItem
			// 
			this.kitEditorToolStripMenuItem.Name = "kitEditorToolStripMenuItem";
			this.kitEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.kitEditorToolStripMenuItem.Text = "Kit Editor";
			this.kitEditorToolStripMenuItem.Click += new System.EventHandler(this.kitEditorToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 555);
			this.Controls.Add(this.toolStripContainer1);
			this.Name = "MainForm";
			this.Text = "iNEMO ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MainForm_HelpRequested);
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			this.tabOutputs.ResumeLayout(false);
			this.tabLog.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

        }

        private void LoadDeviceConfiguration(DeviceManaged deviceType)
        {
            switch (deviceType)
            {
                case DeviceManaged.STEVAL_MKI062V1:
                    userCtrlMain = new ControlLibrary.MKI062V1.MainUserControl();
                    communicationMain = new ControlLibrary.MKI062V1.CommunicationControl();
                    break;

                case DeviceManaged.STEVAL_MKI062V2:
                    userCtrlMain = new ControlLibrary.MKI062V2.MainUserControl();
                    communicationMain = new ControlLibrary.MKI062V2.CommunicationControl();
                    break;
            }
            userCtrlMain.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(userCtrlMain);
            toolStripContainer1.TopToolStripPanel.Controls.Clear();
            communicationMain.OnCommunicationSettings_Change = (CoomunicationSettings_Change) Delegate.Combine(communicationMain.OnCommunicationSettings_Change, new CoomunicationSettings_Change(OnCommChange));
            communicationMain.OnMessageToLog = (MessageToLog) Delegate.Combine(communicationMain.OnMessageToLog, new MessageToLog(AddInLogBar));
            communicationMain.OnDataReceived = (DataReceived) Delegate.Combine(communicationMain.OnDataReceived, new DataReceived(AddDataInPlot));
            communicationMain.OnStart = (StartAcquisition) Delegate.Combine(communicationMain.OnStart, new StartAcquisition(OnStartAcquistion));
            communicationMain.OnStop = (StopAcquistion) Delegate.Combine(communicationMain.OnStop, new StopAcquistion(OnStopAcquisition));
            communicationMain.OnTCPState_Change = (TCPState_Change) Delegate.Combine(communicationMain.OnTCPState_Change, new TCPState_Change(OnTCP_Change));
            userCtrlMain.OnClear = (ClearEvent) Delegate.Combine(userCtrlMain.OnClear, new ClearEvent(communicationMain.Clear));
            userCtrlMain.OnSave = (SaveEvent) Delegate.Combine(userCtrlMain.OnSave, new SaveEvent(SaveFromClear));
            userCtrlMain.OnMessageToLog = (MessageToLog) Delegate.Combine(userCtrlMain.OnMessageToLog, new MessageToLog(AddInLogBar));
            toolStripStatusLabel1.Text = communicationMain.CommSettingsInfo;

			toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
			toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
			toolStripContainer1.TopToolStripPanel.Controls.Add(communicationMain.LocalToolBar);
            toolStripContainer1.TopToolStripPanel.Controls.Add(userCtrlMain.LocalToolBar);
            menuStrip1.AllowMerge = false;
            ((ToolStripMenuItem) menuStrip1.Items["toolToolStripMenuItem"]).DropDownItems.AddRange(userCtrlMain.LocalMenuBarTool);
            ((ToolStripMenuItem) menuStrip1.Items["toolToolStripMenuItem"]).DropDownItems.AddRange(communicationMain.LocalMenuBarTool);
            ((ToolStripMenuItem) menuStrip1.Items["viewToolStripMenuItem"]).DropDownItems.AddRange(userCtrlMain.LocalMenuBarView);
            base.Visible = true;
            configurationLoaded = true;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = true;
            openFileDialog.InitialDirectory = saveFileDialog.InitialDirectory;
            openFileDialog.Filter = saveFileDialog.Filter;
            if (userCtrlMain.DataAvailable)
            {
                flag = userCtrlMain.ClearData();
            }
            if (flag && (openFileDialog.ShowDialog() == DialogResult.OK))
            {
                FileDataName = openFileDialog.FileName;
                userCtrlMain.LoadDataFile(FileDataName);
            }
        }

        private void logBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logBarToolStripMenuItem.Checked = !logBarToolStripMenuItem.Checked;
            splitContainer.Panel2Collapsed = !logBarToolStripMenuItem.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flag = false;
            if (communicationMain.DeviceConnected)
            {
                MessageBox.Show("Device already connected. \n\nClose connection before exit application.", "Error on close application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }
            if (!flag && userCtrlMain.DataAvailable)
            {
                flag = !userCtrlMain.ClearData();
            }
            e.Cancel = flag;
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "iNEMO.chm");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userCtrlMain.DataAvailable)
            {
                userCtrlMain.ClearData();
                FileDataName = null;
            }
            AddInLogBar("New data file");
            DeviceSelection();
        }

        private void OnCommChange()
        {
            toolStripStatusLabel1.Text = communicationMain.CommSettingsInfo;
            userCtrlMain.EnableRotationDataView = communicationMain.IsModeAHRSEnabled;
            userCtrlMain.DeviceSensors = communicationMain.DeviceSensors;
        }

        public void OnStartAcquistion()
        {
            userCtrlMain.ClearData(false);
            userCtrlMain.EnableRotationDataView = communicationMain.IsModeAHRSEnabled;
            userCtrlMain.DeviceSensors = communicationMain.DeviceSensors;
            userCtrlMain.SetVisibleFirst();
        }

        public void OnStopAcquisition()
        {
        }

        public void OnTCP_Change(TCP_State state, string strMessage)
        {
            switch (state)
            {
                case TCP_State.TCP_STATE_SERVER_START:
                    toolStripStatusLabel2.Image = Resources.wait2;
                    break;

                case TCP_State.TCP_STATE_SERVER_STOP:
                    toolStripStatusLabel2.Image = Resources.stop2;
                    break;

                case TCP_State.TCP_STATE_SENDING_DATA:
                    toolStripStatusLabel2.Image = Resources.connected2;
                    break;
            }
            toolStripStatusLabel2.Text = strMessage;
        }

        private void RemoveDeviceConfiguration()
        {
            if (configurationLoaded)
            {
                base.Visible = false;
                splitContainer.Panel1.Controls.Clear();
                ((ToolStripMenuItem) menuStrip1.Items["toolToolStripMenuItem"]).DropDownItems.Clear();
                ((ToolStripMenuItem) menuStrip1.Items["viewToolStripMenuItem"]).DropDownItems.RemoveAt(2);
                if (userCtrlMain != null)
                {
                    userCtrlMain = null;
                }
                if (communicationMain != null)
                {
                    communicationMain = null;
                }
                configurationLoaded = false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileDataName == null)
            {
                saveFileDialog.FileName = StringFileName;
            }
            else
            {
                saveFileDialog.FileName = FileDataName;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileDataName = saveFileDialog.FileName;
                userCtrlMain.SaveFunction(FileDataName);
            }
        }

        private void SaveFromClear()
        {
            if (FileDataName == null)
            {
                saveFileDialog.FileName = StringFileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileDataName = saveFileDialog.FileName;
                }
            }
            if (FileDataName != null)
            {
                userCtrlMain.SaveFunction(FileDataName);
            }
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            saveLogFileDialog.FileName = "iNEMO_LOG_" + now.Year.ToString() + now.Month.ToString("d2") + now.Day.ToString("d2") + "_" + now.Hour.ToString("d2") + now.Minute.ToString("d2") + now.Second.ToString("d2");
            if (saveLogFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveLogFileDialog.FileName);
                if (writer != null)
                {
                    writer.Write("Timestamp\t");
                    writer.Write("Message");
                    writer.WriteLine();
                    foreach (ListViewItem item in ListLog.Items)
                    {
                        writer.Write(item.Text + "\t");
                        writer.Write(item.SubItems[1].Text);
                        writer.WriteLine();
                    }
                    writer.Close();
                    ListLog.Items.Clear();
                    saveLogToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileDataName != null)
            {
                userCtrlMain.SaveFunction(FileDataName);
            }
        }

        private void SetDeviceAndCommunication()
        {
            if (kitSelector.SelectedKit.IsValid())
            {
                if (mDeviceSelected != kitSelector.SelectedKit.Code)
                {
                    if (kitSelector.SelectedKit.Code == "STEVAL-MKI062V1")
                    {
                        RemoveDeviceConfiguration();
                        LoadDeviceConfiguration(DeviceManaged.STEVAL_MKI062V1);
                    }
                    else
                    {
                        RemoveDeviceConfiguration();
                        LoadDeviceConfiguration(DeviceManaged.STEVAL_MKI062V2);
                    }
                }
                communicationMain.CommunicationModule = "PL_001";
                if (kitSelector.SelectedKit.Socket.Type == KSSocketType.TcpIp)
                {
                    communicationMain.CommunicationModule = "PL_TCPIP";
                }
                communicationMain.CommunicationPort = kitSelector.SelectedKit.Socket.Param;
                communicationMain.CommunicationConfiguration = kitSelector.SelectedKit.Socket.Protocol;
                mDeviceSelected = kitSelector.SelectedKit.Code;
            }
            else
            {
                RemoveDeviceConfiguration();
                LoadDeviceConfiguration(DeviceManaged.STEVAL_MKI062V2);
            }
        }

        private void ShowSpash()
        {
            new Splash().Show(this);
        }

        private void statusbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusbarToolStripMenuItem.Checked = !statusbarToolStripMenuItem.Checked;
            statusStrip1.Visible = statusbarToolStripMenuItem.Checked;
        }

        private string FileDataName
        {
            get
            {
                return mFileName;
            }
            set
            {
                mFileName = value;
                if ((mFileName != null) && (mFileName != ""))
                {
                    saveToolStripMenuItem.Enabled = true;
                    toolStripButtonSave.Enabled = true;
                    Text = "iNEMO - [" + mFileName + "]";
                }
                else
                {
                    saveToolStripMenuItem.Enabled = false;
                    toolStripButtonSave.Enabled = false;
                    Text = "iNEMO ";
                }
            }
        }

        private string StringFileName
        {
            get
            {
                return communicationMain.AcquisitionInfo;
            }
        }

		private KSDbEditor kitEditor = null;

		private void kitEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(kitEditor == null)
				kitEditor = new KSDbEditor();
			kitEditor.ShowDialog();
		}
    }
}

