﻿namespace iNEMO_Application
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    internal class About
    {
        private string m_Copyright = "STMicroelectronics, 2011";
        private string m_Email = "ctnsupport.sdd@st.com";
        private string m_FileProduct = "iNEMO Suite.exe";
        private string m_Group = "IMS - Systems Lab and Technical Marketing";
        private List<string> m_Modules = new List<string>();
        private string m_Subject = "This application is for iNEMO Boards acquistion data";
        private string m_Title = "About...";

        public About()
        {
            this.m_Modules.Add("ControlLibrary.dll");
            this.m_Modules.Add("ControlLibrary.MKI062V1.dll");
            this.m_Modules.Add("ControlLibrary.MKI062V2.dll");
            this.m_Modules.Add("iNEMO_SDK.dll");
            this.m_Modules.Add("iNEMO2_SDK.dll");
            this.m_Modules.Add("TL_002.dll");
            this.m_Modules.Add("PL_001.dll");
        }

        public void ShowAbout(IntPtr lHandle, string DeviceInfo, string FirmWareInfo, string HardwareInfo)
        {
            STABOUT_Create(lHandle.ToInt32());
            STABOUT_Clear();
            foreach (string str in this.m_Modules)
            {
                STABOUT_InsertModule(str);
            }
            STABOUT_InsertInfo("");
            STABOUT_InsertInfo(DeviceInfo);
            STABOUT_InsertInfo(FirmWareInfo);
            STABOUT_InsertInfo(HardwareInfo);
            STABOUT_Show(this.m_Title, this.m_FileProduct, this.m_Copyright, this.m_Group, this.m_Subject, this.m_Email, 1);
        }

        [DllImport("STAbout.dll")]
        private static extern int STABOUT_Clear();
        [DllImport("STAbout.dll")]
        private static extern int STABOUT_Create(int wParent);
        [DllImport("STAbout.dll")]
        private static extern int STABOUT_InsertFile(string szFileName);
        [DllImport("STAbout.dll")]
        private static extern int STABOUT_InsertInfo(string szRow);
        [DllImport("STAbout.dll")]
        private static extern int STABOUT_InsertModule(string szFileName);
        [DllImport("STAbout.dll")]
        private static extern int STABOUT_Show(string szTitle, string szFileProduct, string szCopyright, string szGroup, string szSubject, string szEmail, int iAboutType);
    }
}

