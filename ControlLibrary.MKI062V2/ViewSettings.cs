﻿namespace ControlLibrary.MKI062V2
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ViewSettings : Form
    {
        private Button CancelBtn;
        private CheckBox checkBox1;
        private CheckBox checkBox10;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox[] checkBoxList;
        private bool[] checkedValues;
        private IContainer components;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button OkBtn;
        public View_Change OnViewChange;

        public ViewSettings()
        {
            this.InitializeComponent();
            this.checkBoxList = new CheckBox[] { this.checkBox1, this.checkBox2, this.checkBox3, this.checkBox4, this.checkBox5, this.checkBox6, this.checkBox7, this.checkBox9, this.checkBox8, this.checkBox10 };
            this.checkedValues = new bool[this.checkBoxList.GetLength(0)];
            for (int i = 0; i < this.checkBoxList.GetLength(0); i++)
            {
                this.checkedValues[i] = true;
            }
            this.UpdateData();
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
            this.CancelBtn = new Button();
            this.OkBtn = new Button();
            this.groupBox2 = new GroupBox();
            this.checkBox9 = new CheckBox();
            this.checkBox7 = new CheckBox();
            this.checkBox5 = new CheckBox();
            this.checkBox4 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.groupBox3 = new GroupBox();
            this.checkBox6 = new CheckBox();
            this.checkBox8 = new CheckBox();
            this.checkBox10 = new CheckBox();
            this.groupBox4 = new GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            base.SuspendLayout();
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new Point(0x11d, 0x10d);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(0x4b, 0x17);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Location = new Point(0xca, 0x10d);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new Size(0x4b, 0x17);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new EventHandler(this.OkBtn_Click);
            this.groupBox2.Controls.Add(this.checkBox9);
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new Point(15, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xa5, 0xf4);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plot view";
            this.checkBox9.AutoSize = true;
            this.checkBox9.Checked = true;
            this.checkBox9.CheckState = CheckState.Checked;
            this.checkBox9.Location = new Point(15, 0xd4);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new Size(0x4e, 0x11);
            this.checkBox9.TabIndex = 7;
            this.checkBox9.Text = "Quaternion";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox7.AutoSize = true;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = CheckState.Checked;
            this.checkBox7.Location = new Point(15, 0xb5);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new Size(0x42, 0x11);
            this.checkBox7.TabIndex = 5;
            this.checkBox7.Text = "Rotation";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = CheckState.Checked;
            this.checkBox5.Location = new Point(15, 150);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new Size(0x56, 0x11);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Temperature";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = CheckState.Checked;
            this.checkBox4.Location = new Point(15, 0x77);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(0x43, 0x11);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Pressure";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = CheckState.Checked;
            this.checkBox3.Location = new Point(15, 0x58);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(0x5e, 0x11);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Magnetometer";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = CheckState.Checked;
            this.checkBox2.Location = new Point(15, 0x39);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(0x4d, 0x11);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Gyroscope";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = CheckState.Checked;
            this.checkBox1.Location = new Point(15, 0x1a);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x5e, 0x11);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Accelerometer";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Location = new Point(0xc3, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xa5, 0x3d);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report view";
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = CheckState.Checked;
            this.checkBox6.Location = new Point(0x12, 0x1a);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new Size(0x53, 0x11);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Text = "Show report";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox8.AutoSize = true;
            this.checkBox8.Checked = true;
            this.checkBox8.CheckState = CheckState.Checked;
            this.checkBox8.Location = new Point(0x11, 0x1f);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new Size(0x75, 0x11);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.Text = "Show large buttons";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new Point(0x11, 0x3e);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new Size(0x4f, 0x11);
            this.checkBox10.TabIndex = 7;
            this.checkBox10.Text = "Ring Buffer";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.groupBox4.Controls.Add(this.checkBox8);
            this.groupBox4.Controls.Add(this.checkBox10);
            this.groupBox4.Location = new Point(0xc4, 0xa4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xa4, 0x5e);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "View && acquisition";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x176, 0x130);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.OkBtn);
            base.Controls.Add(this.CancelBtn);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ViewSettings";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Settings";
            base.Shown += new EventHandler(this.ViewSettings_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            base.ResumeLayout(false);
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.UpdateData();
            if (this.OnViewChange != null)
            {
                this.OnViewChange();
            }
            base.Close();
        }

        private void UpdateData()
        {
            this.UpdateData(true);
        }

        private void UpdateData(bool direction)
        {
            if (direction)
            {
                for (int i = 0; i < this.checkBoxList.GetLength(0); i++)
                {
                    this.checkedValues[i] = this.checkBoxList[i].Checked;
                }
            }
            else
            {
                for (int j = 0; j < this.checkBoxList.GetLength(0); j++)
                {
                    this.checkBoxList[j].Checked = this.checkedValues[j];
                }
            }
        }

        private void ViewSettings_Shown(object sender, EventArgs e)
        {
            this.UpdateData(false);
        }

        public bool Accelerometer
        {
            get
            {
                return this.checkedValues[0];
            }
        }

        public bool BigIcons
        {
            get
            {
                return this.checkedValues[8];
            }
        }

        public bool Gyroscope
        {
            get
            {
                return this.checkedValues[1];
            }
        }

        public bool Magnetometer
        {
            get
            {
                return this.checkedValues[2];
            }
        }

        public bool Pressure
        {
            get
            {
                return this.checkedValues[3];
            }
        }

        public bool Quaternion
        {
            get
            {
                return this.checkedValues[7];
            }
        }

        public bool Report
        {
            get
            {
                return this.checkedValues[5];
            }
        }

        public bool RingBuffer
        {
            get
            {
                return this.checkedValues[9];
            }
        }

        public bool Rotation
        {
            get
            {
                return this.checkedValues[6];
            }
        }

        public bool Temperature
        {
            get
            {
                return this.checkedValues[4];
            }
        }

        private enum IdxCheckbox
        {
            Accelerometer,
            Gyroscope,
            Magnetometer,
            Pressure,
            Temperature,
            Report,
            Rotation,
            Quaternion,
            BigIcons,
            RingBuffer
        }
    }
}

