﻿namespace ControlLibrary.MKI062V2
{
    using System;
    using System.Runtime.InteropServices;

    internal class STDFU_EX_Wrapper
    {
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_Erase();
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_FlashDevice();
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_GetStatus(ref int Status, ref double Percent);
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_Init(string FilePathName);
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_LeaveDFU();
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_Release();
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_RunApplication();
        [DllImport("STDFU_EX.dll")]
        public static extern STDFU_EX_Error STDFU_EX_Verify();

        public enum STDFU_EX_Error
        {
            STDFU_EX_ERROR_NONE,
            STDFU_EX_ERROR_INVALID_FILE,
            STDFU_EX_ERROR_DEVICE_NOT_AVAILABLE,
            STDFU_EX_ERROR_OPERATION_IN_PROGRESS,
            STDFU_EX_ERROR_ON_START_OPERATION,
            STDFU_EX_ERROR_NOT_INITIALIZED,
            STDFU_EX_ERROR_ON_CREATE_MAPPING,
            STDFU_EX_ERROR_INVALID_OPERATION,
            STDFU_EX_ERROR_VERIFY_FAIL,
            STDFU_EX_ERROR_ON_LEAVE_DFU
        }
    }
}

