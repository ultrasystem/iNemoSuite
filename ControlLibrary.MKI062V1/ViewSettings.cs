﻿namespace ControlLibrary.MKI062V1
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ViewSettings : Form
    {
        private Button CancelBtn;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox[] checkBoxList;
        private bool[] checkedValues;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GyroscopeYAxe mGyroscope;
        private Button OkBtn;
        public View_Change OnViewChange;
        private RadioButton radioButton1;
        private RadioButton radioButton2;

        public ViewSettings()
        {
            this.InitializeComponent();
            this.checkBoxList = new CheckBox[] { this.checkBox1, this.checkBox2, this.checkBox3, this.checkBox4, this.checkBox5, this.checkBox6 };
            this.checkedValues = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                this.checkedValues[i] = true;
            }
            this.radioButton1.Checked = true;
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
            this.groupBox1 = new GroupBox();
            this.radioButton2 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.CancelBtn = new Button();
            this.OkBtn = new Button();
            this.groupBox2 = new GroupBox();
            this.checkBox5 = new CheckBox();
            this.checkBox4 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox1 = new CheckBox();
            this.groupBox3 = new GroupBox();
            this.checkBox6 = new CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new Point(0xc4, 0x51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xa5, 0x4c);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gyroscope";
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(0x11, 50);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x59, 0x11);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Show Y2 axis";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new Point(0x11, 0x1c);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x59, 0x11);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Show Y1 axis";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new Point(0x11d, 0xa5);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new Size(0x4b, 0x17);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Location = new Point(0xca, 0xa5);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new Size(0x4b, 0x17);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new EventHandler(this.OkBtn_Click);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new Point(15, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xa5, 0x8f);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plot view";
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = CheckState.Checked;
            this.checkBox5.Location = new Point(15, 0x76);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new Size(0x56, 0x11);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Temperature";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = CheckState.Checked;
            this.checkBox4.Location = new Point(15, 0x5f);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(0x43, 0x11);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Pressure";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = CheckState.Checked;
            this.checkBox3.Location = new Point(15, 0x48);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(0x5e, 0x11);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Magnetometer";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = CheckState.Checked;
            this.checkBox2.Location = new Point(15, 0x31);
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
            base.AcceptButton = this.OkBtn;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.CancelBtn;
            base.ClientSize = new Size(0x176, 0xc5);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.OkBtn);
            base.Controls.Add(this.CancelBtn);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ViewSettings";
            this.Text = "Settings";
            base.Shown += new EventHandler(this.ViewSettings_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
                if (this.radioButton1.Checked)
                {
                    this.mGyroscope = GyroscopeYAxe.Select_Y1;
                }
                else
                {
                    this.mGyroscope = GyroscopeYAxe.Select_Y2;
                }
                for (int i = 0; i < 6; i++)
                {
                    this.checkedValues[i] = this.checkBoxList[i].Checked;
                }
            }
            else
            {
                if (this.mGyroscope == GyroscopeYAxe.Select_Y1)
                {
                    this.radioButton1.Checked = true;
                }
                else
                {
                    this.radioButton2.Checked = true;
                }
                for (int j = 0; j < 6; j++)
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

        public bool Gyroscope
        {
            get
            {
                return this.checkedValues[1];
            }
        }

        public GyroscopeYAxe GyroscopeSelection
        {
            get
            {
                return this.mGyroscope;
            }
        }

        public bool Magnetormeter
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

        public bool Report
        {
            get
            {
                return this.checkedValues[5];
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
            Magnetormeter,
            Pressure,
            Temperature,
            Report
        }
    }
}

