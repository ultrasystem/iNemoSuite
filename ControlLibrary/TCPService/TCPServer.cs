﻿namespace TCPService
{
    using ControlLibrary;
    using System;
    using System.Collections;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public class TCPServer
    {
        public static IPEndPoint DEFAULT_IP_END_POINT = new IPEndPoint(DEFAULT_SERVER, DEFAULT_PORT);
        public static int DEFAULT_PORT = 0x7919;
        public static IPAddress DEFAULT_SERVER = IPAddress.Parse("0.0.0.0");
        private Thread m_purgingThread;
        private TcpListener m_server;
        private Thread m_serverThread;
        private ArrayList m_socketListenersList;
        private bool m_stopPurging;
        private bool m_stopServer;
        private bool mStarted;
        public MessageToLog OnMessageToLog;

        public TCPServer()
        {
            this.Init(DEFAULT_IP_END_POINT);
        }

        public TCPServer(int port)
        {
            this.Init(new IPEndPoint(DEFAULT_SERVER, port));
        }

        public TCPServer(IPAddress serverIP)
        {
            this.Init(new IPEndPoint(serverIP, DEFAULT_PORT));
        }

        public TCPServer(IPEndPoint ipNport)
        {
            this.Init(ipNport);
        }

        public TCPServer(IPAddress serverIP, int port)
        {
            this.Init(new IPEndPoint(serverIP, port));
        }

        ~TCPServer()
        {
            this.StopServer();
        }

        private void Init(IPEndPoint ipNport)
        {
            try
            {
                this.m_server = new TcpListener(ipNport);
            }
            catch (Exception)
            {
                this.m_server = null;
            }
        }

        private void PurgingThreadStart()
        {
            while (!this.m_stopPurging)
            {
                ArrayList list = new ArrayList();
                lock (this.m_socketListenersList)
                {
                    foreach (TCPSocketListener listener in this.m_socketListenersList)
                    {
                        if (listener.IsMarkedForDeletion())
                        {
                            if (this.OnMessageToLog != null)
                            {
                                this.OnMessageToLog("TCP/IP Client Disconnected {" + listener.ClientInfo + "}");
                            }
                            list.Add(listener);
                            listener.StopSocketListener();
                        }
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        this.m_socketListenersList.Remove(list[i]);
                    }
                }
                list = null;
                Thread.Sleep(0x3e8);
            }
        }

        public void SendDataToAllClients(byte[] data)
        {
            lock (this.m_socketListenersList)
            {
                foreach (TCPSocketListener listener in this.m_socketListenersList)
                {
                    listener.SendData(data);
                }
            }
        }

        private void ServerThreadStart()
        {
            Socket clientSocket = null;
            TCPSocketListener listener = null;
            while (!this.m_stopServer)
            {
                try
                {
                    clientSocket = this.m_server.AcceptSocket();
                    listener = new TCPSocketListener(clientSocket);
                    lock (this.m_socketListenersList)
                    {
                        this.m_socketListenersList.Add(listener);
                    }
                    listener.StartSocketListener();
                    if (this.OnMessageToLog != null)
                    {
                        this.OnMessageToLog("TCP/IP Client Connected {" + clientSocket.RemoteEndPoint.ToString() + "}");
                    }
                    continue;
                }
                catch (SocketException)
                {
                    this.m_stopServer = true;
                    continue;
                }
            }
        }

        public bool StartServer()
        {
            bool flag = false;
            if (this.m_server != null)
            {
                this.m_socketListenersList = new ArrayList();
                try
                {
                    this.m_server.Start();
                    flag = true;
                }
                catch (SocketException)
                {
                }
                if (flag)
                {
                    this.m_serverThread = new Thread(new ThreadStart(this.ServerThreadStart));
                    this.m_serverThread.Start();
                    this.m_purgingThread = new Thread(new ThreadStart(this.PurgingThreadStart));
                    this.m_purgingThread.Priority = ThreadPriority.Lowest;
                    this.m_purgingThread.Start();
                }
            }
            this.mStarted = flag;
            return flag;
        }

        private void StopAllSocketListers()
        {
            foreach (TCPSocketListener listener in this.m_socketListenersList)
            {
                listener.StopSocketListener();
            }
            this.m_socketListenersList.Clear();
            this.m_socketListenersList = null;
        }

        public void StopServer()
        {
            if ((this.m_server != null) && this.mStarted)
            {
                this.m_stopServer = true;
                this.m_server.Stop();
                this.mStarted = false;
                this.m_serverThread.Join(0x3e8);
                if (this.m_serverThread.IsAlive)
                {
                    this.m_serverThread.Abort();
                }
                this.m_serverThread = null;
                this.m_stopPurging = true;
                this.m_purgingThread.Join(0x3e8);
                if (this.m_purgingThread.IsAlive)
                {
                    this.m_purgingThread.Abort();
                }
                this.m_purgingThread = null;
                this.m_server = null;
                this.StopAllSocketListers();
            }
        }

        public string ServerInfo
        {
            get
            {
                if (this.m_server != null)
                {
                    return this.m_server.LocalEndpoint.ToString();
                }
                return "Server Not Started";
            }
        }

        public bool Started
        {
            get
            {
                return this.mStarted;
            }
        }
    }
}

