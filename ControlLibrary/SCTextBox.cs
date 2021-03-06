﻿namespace ControlLibrary
{
    using System;
    using System.Windows.Forms;

    public class SCTextBox : TextBox
    {
        private ulong mMaxValue;
        private ulong mMinValue;
        private bool mOnlyNumeric;
        private const int WM_PASTE = 770;

        public SCTextBox()
        {
            this.AcceptOnlyNumber = true;
            this.MinValue = 0L;
            this.MaxValue = ulong.MaxValue;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.AcceptOnlyNumber)
            {
                if ((char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar)) || (char.IsSeparator(e.KeyChar) || char.IsPunctuation(e.KeyChar)))
                {
                    e.Handled = true;
                }
                else if (char.IsNumber(e.KeyChar))
                {
                    string text = this.Text;
                    if (this.SelectionLength > 0)
                    {
                        text = this.Text.Remove(base.SelectionStart, this.SelectionLength);
                    }
                    ulong num = Convert.ToUInt64(text.Insert(base.SelectionStart, e.KeyChar.ToString()));
                    if ((num > this.MaxValue) || (num < this.MinValue))
                    {
                        e.Handled = true;
                    }
                }
            }
            base.OnKeyPress(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (Control.ModifierKeys.CompareTo(Keys.Control) == 0)
            {
                if (m.Msg != 770)
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        public bool AcceptOnlyNumber
        {
            get
            {
                return this.mOnlyNumeric;
            }
            set
            {
                this.mOnlyNumeric = value;
            }
        }

        public ulong MaxValue
        {
            get
            {
                return this.mMaxValue;
            }
            set
            {
                this.mMaxValue = value;
            }
        }

        public ulong MinValue
        {
            get
            {
                return this.mMinValue;
            }
            set
            {
                this.mMinValue = value;
            }
        }
    }
}

