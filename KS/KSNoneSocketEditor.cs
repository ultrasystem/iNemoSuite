﻿namespace KS
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class KSNoneSocketEditor : UserControl
    {
        private IContainer components;
        public ParamChanged OnParamChanged;
        private string param;

        public KSNoneSocketEditor()
        {
            this.InitializeComponent();
            this.Param = "";
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
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Name = "DcpNoneSocketEditor";
            base.Size = new Size(260, 0x2d);
            base.ResumeLayout(false);
        }

        public string Param
        {
            get
            {
                return this.param;
            }
            set
            {
                this.param = value;
            }
        }

        public delegate void ParamChanged(string param);
    }
}

