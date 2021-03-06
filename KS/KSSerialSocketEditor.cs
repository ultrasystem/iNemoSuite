﻿namespace KS
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO.Ports;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class KSSerialSocketEditor : UserControl
    {
        private Button buttonComListRefresh;
        private ComboBox comboBoxComPort;
        private IContainer components;
        private Label label1;
        public ParamChanged OnParamChanged;
        private SerialPort serialPort1;

        public KSSerialSocketEditor()
        {
            this.InitializeComponent();
            this.fillComboSerialPort();
        }

        private void buttonComListRefresh_Click(object sender, EventArgs e)
        {
            this.fillComboSerialPort();
        }

        private void comboBoxComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.OnParamChanged != null)
            {
                this.OnParamChanged(this.Param);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void fillComboSerialPort()
        {
            string s = "";
            if (this.comboBoxComPort.Items.Count > 0)
            {
                s = this.comboBoxComPort.SelectedItem.ToString();
            }
            this.comboBoxComPort.Items.Clear();
            this.comboBoxComPort.Items.AddRange(SerialPort.GetPortNames());
            this.comboBoxComPort.Enabled = this.comboBoxComPort.Items.Count > 0;
            if (this.comboBoxComPort.Items.Count > 0)
            {
                if (s.Length > 0)
                {
                    int num = this.comboBoxComPort.FindStringExact(s);
                    this.comboBoxComPort.SelectedIndex = Math.Max(0, num);
                }
                else
                {
                    this.comboBoxComPort.SelectedIndex = this.comboBoxComPort.Items.Count - 1;
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(KSSerialSocketEditor));
            this.label1 = new Label();
            this.comboBoxComPort = new ComboBox();
            this.buttonComListRefresh = new Button();
            this.serialPort1 = new SerialPort(this.components);
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3d, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port :";
            this.comboBoxComPort.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new Point(0x4e, 13);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new Size(0x88, 0x15);
            this.comboBoxComPort.TabIndex = 1;
            this.comboBoxComPort.SelectedIndexChanged += new EventHandler(this.comboBoxComPort_SelectedIndexChanged);
            this.buttonComListRefresh.Image = (Image) resources.GetObject("buttonComListRefresh.Image");
            this.buttonComListRefresh.Location = new Point(220, 7);
            this.buttonComListRefresh.Name = "buttonComListRefresh";
            this.buttonComListRefresh.Size = new Size(0x25, 0x20);
            this.buttonComListRefresh.TabIndex = 2;
            this.buttonComListRefresh.UseVisualStyleBackColor = true;
            this.buttonComListRefresh.Click += new EventHandler(this.buttonComListRefresh_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.buttonComListRefresh);
            base.Controls.Add(this.comboBoxComPort);
            base.Controls.Add(this.label1);
            base.Name = "KSSerialSocketEditor";
            base.Size = new Size(260, 0x2d);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public string Param
        {
            get
            {
                string str = "";
                try
                {
                    str = this.comboBoxComPort.SelectedItem.ToString();
                }
                catch
                {
                }
                return str;
            }
            set
            {
                if (this.comboBoxComPort.Items.Count > 0)
                {
                    if (value.Length > 0)
                    {
                        this.comboBoxComPort.SelectedItem = value;
                    }
                    else
                    {
                        this.comboBoxComPort.SelectedIndex = this.comboBoxComPort.Items.Count - 1;
                    }
                }
                if (this.OnParamChanged != null)
                {
                    this.OnParamChanged(this.Param);
                }
            }
        }

        public delegate void ParamChanged(string param);
    }
}

