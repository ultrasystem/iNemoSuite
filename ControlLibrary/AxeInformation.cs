﻿namespace ControlLibrary
{
    using iPlotLibrary;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct AxeInformation
    {
        private string mName;
        private string mUnit;
        private double mMinValue;
        private double mMaxValue;
        private bool mVisible;
        private AxeColor mColor;
        private TxiPlotLineStyle mLineStyle;
        private int mPrecision;
        private string mStrType;
        public int Precision
        {
            get
            {
                return this.mPrecision;
            }
            set
            {
                this.mPrecision = value;
            }
        }
        public string StrType
        {
            get
            {
                return this.mStrType;
            }
            set
            {
                this.mStrType = value;
            }
        }
        public AxeColor Color
        {
            get
            {
                return this.mColor;
            }
            set
            {
                this.mColor = value;
            }
        }
        public TxiPlotLineStyle LineStyle
        {
            get
            {
                return this.mLineStyle;
            }
            set
            {
                this.mLineStyle = value;
            }
        }
        public bool Visible
        {
            get
            {
                return this.mVisible;
            }
            set
            {
                this.mVisible = value;
            }
        }
        public string Name
        {
            get
            {
                return this.mName;
            }
            set
            {
                this.mName = value;
            }
        }
        public string Unit
        {
            get
            {
                return this.mUnit;
            }
            set
            {
                this.mUnit = value;
            }
        }
        public double MinValue
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
        public double MaxValue
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
    }
}

