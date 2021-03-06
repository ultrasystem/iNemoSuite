﻿namespace ControlLibrary.MKI062V1
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FrameData
    {
        public uint TimeStamp;
        public FrameComponents Accelometer;
        public FrameComponentsG Gyroscope;
        public FrameComponents Magnetic;
        public ushort Pressure;
        public short Temperature;
        public object[] ToObjArray()
        {
            return new object[] { this.TimeStampInMillis, this.Accelometer.X, this.Accelometer.Y, this.Accelometer.Z, this.Gyroscope.X, this.Gyroscope.Y1, this.Gyroscope.Y2, this.Gyroscope.Z, this.Magnetic.X, this.Magnetic.Y, this.Magnetic.Z, this.PressureInMbar, this.TemperatureInC };
        }

        public double PressureInMbar
        {
            get
            {
                return (((double) this.Pressure) / 10.0);
            }
        }
        public double TemperatureInC
        {
            get
            {
                return (((double) this.Temperature) / 10.0);
            }
        }
        public double TimeStampInMillis
        {
            get
            {
                return (((double) this.TimeStamp) / 1000.0);
            }
        }
    }
}

