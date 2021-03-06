﻿namespace ControlLibrary.MKI062V2
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct INEMO2_Output
    {
        public INEMO2_OUTPUT_MODE Mode;
        public INEMO2_OUTPUT_DATA Data;
        public uint Frequency;
        public INEMO2_OUTPUT_TYPE Type;
        public uint Samples;
    }
}

