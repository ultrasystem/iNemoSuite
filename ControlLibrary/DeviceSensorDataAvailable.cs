﻿namespace ControlLibrary
{
    using System;

    public enum DeviceSensorDataAvailable : uint
    {
        DSDA_ACELEROMETER = 1,
        DSDA_ALL = 0x7f,
        DSDA_GYROSCOPE = 4,
        DSDA_MAGNETOMER = 2,
        DSDA_NONE = 0,
        DSDA_PRESSURE = 8,
        DSDA_QUATERNION = 0x40,
        DSDA_ROTATION = 0x20,
        DSDA_TEMPERATURE = 0x10
    }
}

