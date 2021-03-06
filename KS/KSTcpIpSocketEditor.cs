﻿namespace KS
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class KSTcpIpSocketEditor : UserControl
    {
        private IContainer components;
        private Label label1;
        private Label label2;
        public ParamChanged OnParamChanged;
        private TextBox textBoxIP;
        private TextBox textBoxPort;

        public KSTcpIpSocketEditor()
        {
            this.InitializeComponent();
            this.Param = "127.0.0.1,61898";
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
            this.label1 = new Label();
            this.textBoxIP = new TextBox();
            this.label2 = new Label();
            this.textBoxPort = new TextBox();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP :";
            this.textBoxIP.Location = new Point(0x27, 15);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new Size(0x65, 20);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Text = "127.0.0.1";
            this.textBoxIP.TextChanged += new EventHandler(this.textBoxIP_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x98, 0x12);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2b, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PORT :";
            this.textBoxPort.Location = new Point(0xc5, 15);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new Size(0x2e, 20);
            this.textBoxPort.TabIndex = 3;
            this.textBoxPort.Text = "61898";
            this.textBoxPort.TextChanged += new EventHandler(this.textBoxPort_TextChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.textBoxPort);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBoxIP);
            base.Controls.Add(this.label1);
            base.Name = "KSTcpIpSocketEditor";
            base.Size = new Size(260, 0x2d);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void textBoxIP_TextChanged(object sender, EventArgs e)
        {
            if (this.OnParamChanged != null)
            {
                this.OnParamChanged(this.Param);
            }
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (this.OnParamChanged != null)
            {
                this.OnParamChanged(this.Param);
            }
        }

        public string Param
        {
            get
            {
                return (((this.textBoxIP.Text.Length > 0) ? this.textBoxIP.Text : "127.0.0.1") + "," + ((this.textBoxPort.Text.Length > 0) ? this.textBoxPort.Text : "61898"));
            }
            set
            {
                try
                {
                    string[] strArray = value.Split(new char[] { ',' });
                    this.textBoxIP.Text = strArray[0];
                    this.textBoxPort.Text = strArray[1];
                }
                catch (Exception)
                {
                    this.textBoxIP.Text = "127.0.0.1";
                    this.textBoxPort.Text = "61898";
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

