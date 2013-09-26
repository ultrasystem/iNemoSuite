﻿namespace ControlLibrary.MKI062V2
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Quaternion
    {
        public float Q0;
        public float Q1;
        public float Q2;
        public float Q3;
    }
}

