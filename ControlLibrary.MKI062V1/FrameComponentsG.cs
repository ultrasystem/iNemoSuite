﻿namespace ControlLibrary.MKI062V1
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FrameComponentsG
    {
        public short X;
        public short Y1;
        public short Y2;
        public short Z;
    }
}

