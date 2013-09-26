﻿namespace ControlLibrary.MKI062V2
{
    using System;

    public enum INEMO2_OUTPUT_DATA
    {
        INEMO2_OUTPUT_DATA_ACC = 1,
        INEMO2_OUTPUT_DATA_ALL = 0x1f,
        INEMO2_OUTPUT_DATA_GYRO = 2,
        INEMO2_OUTPUT_DATA_MAG = 4,
        INEMO2_OUTPUT_DATA_PRESS = 8,
        INEMO2_OUTPUT_DATA_TEMP = 0x10
    }
}

