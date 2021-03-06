﻿namespace KS
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

	[Serializable]
    public class KSKit : ISerializable
    {
		public KSSocket BridgedSocket { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public KSSocket DirectSocket { get; set; }
		public Image Photo { get; set; }
		public KSSocketAvailable SelectedSocket { get; set; }
		public string Url { get; set; }

        public KSKit()
        {
            DirectSocket = new KSSocket();
            BridgedSocket = new KSSocket();
            SelectedSocket = KSSocketAvailable.Direct;
            Code = "";
            Description = "";
            Url = "";
        }

        public KSKit(KSKit obj) : this()
        {
            if (obj != null)
            {
                DirectSocket = new KSSocket(obj.DirectSocket);
                BridgedSocket = new KSSocket(obj.BridgedSocket);
                SelectedSocket = obj.SelectedSocket;
                Code = obj.Code;
                Description = obj.Description;
                Url = obj.Url;
                Photo = obj.Photo;
            }
        }

        public KSKit(SerializationInfo info, StreamingContext ctxt) : this()
        {
            Code = (string) info.GetValue("Code", typeof(string));
            Description = (string) info.GetValue("Description", typeof(string));
            DirectSocket = (KSSocket) info.GetValue("DirectSocket", typeof(KSSocket));
            BridgedSocket = (KSSocket) info.GetValue("BridgedSocket", typeof(KSSocket));
            SelectedSocket = (KSSocketAvailable) info.GetValue("SelectedSocket", typeof(KSSocketAvailable));
            Photo = (Image) info.GetValue("Photo", typeof(Image));
            Url = (string) info.GetValue("Url", typeof(string));
        }

        public override bool Equals(object obj)
        {
            return (Code == obj.ToString());
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Code", Code);
            info.AddValue("Description", Description);
            info.AddValue("DirectSocket", DirectSocket);
            info.AddValue("BridgedSocket", BridgedSocket);
            info.AddValue("SelectedSocket", SelectedSocket);
            info.AddValue("Photo", Photo);
            info.AddValue("Url", Url);
        }

        public bool IsValid()
        {
            return (Code.Length != 0);
        }

        public override string ToString()
        {
            return Code;
        }

        public KSSocket Socket
        {
            get
            {
                switch (SelectedSocket)
                {
                    case KSSocketAvailable.Bridged:
                        return BridgedSocket;
                }
                return DirectSocket;
            }
        }
    }
}

