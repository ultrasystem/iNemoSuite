﻿namespace ControlLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ComSettings : Form
    {
        private Button btnCancel;
        private CheckBox checkBoxTCPIP;
        private IContainer components;
        private GroupBox groupBoxTCPIP;
        private NumericUpDown ipPortNumber;
        private Label label2;
        private bool mEnableServer;
        private ushort mIpPort;
        private Button OkBtn;

        public ComSettings()
        {
            this.InitializeComponent();
            this.checkBoxTCPIP.Checked = true;
            this.ipPortNumber.Value = 31001M;
            this.UpdateData();
        }

        private void ComSettings_Shown(object sender, EventArgs e)
        {
            this.checkBoxTCPIP.Checked = this.mEnableServer;
            this.ipPortNumber.Value = this.mIpPort;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.OkBtn = new Button();
            this.btnCancel = new Button();
            this.checkBoxTCPIP = new CheckBox();
            this.ipPortNumber = new NumericUpDown();
            this.label2 = new Label();
            this.groupBoxTCPIP = new GroupBox();
            this.ipPortNumber.BeginInit();
            this.groupBoxTCPIP.SuspendLayout();
            base.SuspendLayout();
            this.OkBtn.Location = new Point(0x61, 0x72);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new Size(0x4b, 0x17);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new EventHandler(this.OkBtn_Click);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(0xbd, 0x72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.checkBoxTCPIP.AutoSize = true;
            this.checkBoxTCPIP.Location = new Point(11, 0x1b);
            this.checkBoxTCPIP.Name = "checkBoxTCPIP";
            this.checkBoxTCPIP.Size = new Size(0xd9, 0x11);
            this.checkBoxTCPIP.TabIndex = 12;
            this.checkBoxTCPIP.Text = "Enable TCP/IP server for demos to start ";
            this.checkBoxTCPIP.UseVisualStyleBackColor = true;
            this.ipPortNumber.Location = new Point(0x9e, 0x39);
            int[] bits = new int[4];
            bits[0] = 0xffdc;
            this.ipPortNumber.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 0x400;
            this.ipPortNumber.Minimum = new decimal(numArray2);
            this.ipPortNumber.Name = "ipPortNumber";
            this.ipPortNumber.Size = new Size(0x4f, 20);
            this.ipPortNumber.TabIndex = 13;
            int[] numArray3 = new int[4];
            numArray3[0] = 0x7919;
            this.ipPortNumber.Value = new decimal(numArray3);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(8, 60);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Listen IP port";
            this.groupBoxTCPIP.Controls.Add(this.label2);
            this.groupBoxTCPIP.Controls.Add(this.checkBoxTCPIP);
            this.groupBoxTCPIP.Controls.Add(this.ipPortNumber);
            this.groupBoxTCPIP.Location = new Point(11, 14);
            this.groupBoxTCPIP.Name = "groupBoxTCPIP";
            this.groupBoxTCPIP.Size = new Size(250, 0x5e);
            this.groupBoxTCPIP.TabIndex = 15;
            this.groupBoxTCPIP.TabStop = false;
            this.groupBoxTCPIP.Text = "Demos server settings";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x114, 0x90);
            base.Controls.Add(this.groupBoxTCPIP);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.OkBtn);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ComSettings";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "TCP/IP demo server settings";
            base.Shown += new EventHandler(this.ComSettings_Shown);
            this.ipPortNumber.EndInit();
            this.groupBoxTCPIP.ResumeLayout(false);
            this.groupBoxTCPIP.PerformLayout();
            base.ResumeLayout(false);
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.UpdateData();
            base.Close();
        }

        private void UpdateData()
        {
            this.mEnableServer = this.checkBoxTCPIP.Checked;
            this.mIpPort = (ushort) this.ipPortNumber.Value;
        }

        public bool EnableServer
        {
            get
            {
                return this.mEnableServer;
            }
        }

        public ushort IpPort
        {
            get
            {
                return this.mIpPort;
            }
        }
    }
}

