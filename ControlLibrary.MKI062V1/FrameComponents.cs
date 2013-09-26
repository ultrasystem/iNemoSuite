﻿namespace ControlLibrary.MKI062V1
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FrameComponents
    {
        public short X;
        public short Y;
        public short Z;
    }
}

