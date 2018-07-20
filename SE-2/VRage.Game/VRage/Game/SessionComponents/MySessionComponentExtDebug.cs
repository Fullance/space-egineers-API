namespace VRage.Game.SessionComponents
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using VRage.Collections;
    using VRage.Game.Components;
    using VRage.Utils;

    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation)]
    public class MySessionComponentExtDebug : MySessionComponentBase
    {
        public static bool ForceDisable;
        public const int GameDebugPort = 0x32c8;
        private bool m_active;
        private byte[] m_arrayBuffer = new byte[0x2800];
        private ConcurrentCachingList<MyDebugClientInfo> m_clients = new ConcurrentCachingList<MyDebugClientInfo>(1);
        private TcpListener m_listener;
        private Thread m_listenerThread;
        private ConcurrentCachingList<ReceivedMsgHandler> m_receivedMsgHandlers = new ConcurrentCachingList<ReceivedMsgHandler>();
        private IntPtr m_tempBuffer;
        private const int MsgSizeLimit = 0x2800;
        public static MySessionComponentExtDebug Static;

        public event ReceivedMsgHandler ReceivedMsg
        {
            add
            {
                this.m_receivedMsgHandlers.Add(value);
                this.m_receivedMsgHandlers.ApplyAdditions();
            }
            remove
            {
                if (this.m_receivedMsgHandlers.Contains<ReceivedMsgHandler>(value))
                {
                    this.m_receivedMsgHandlers.Remove(value, false);
                    this.m_receivedMsgHandlers.ApplyRemovals();
                }
            }
        }

        public void Dispose()
        {
            this.m_receivedMsgHandlers.ClearList();
            if (this.m_active)
            {
                this.StopServer();
            }
            if (this.m_tempBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(this.m_tempBuffer);
            }
        }

        public bool IsHandlerRegistered(ReceivedMsgHandler handler) => 
            this.m_receivedMsgHandlers.Contains<ReceivedMsgHandler>(handler);

        public override void LoadData()
        {
            if (Static != null)
            {
                this.m_listenerThread = Static.m_listenerThread;
                this.m_listener = Static.m_listener;
                this.m_clients = Static.m_clients;
                this.m_active = Static.m_active;
                this.m_arrayBuffer = Static.m_arrayBuffer;
                this.m_tempBuffer = Static.m_tempBuffer;
                this.m_receivedMsgHandlers = Static.m_receivedMsgHandlers;
                Static = this;
                base.LoadData();
            }
            else
            {
                Static = this;
                if (this.m_tempBuffer == IntPtr.Zero)
                {
                    this.m_tempBuffer = Marshal.AllocHGlobal(0x2800);
                }
                if (!ForceDisable)
                {
                    this.StartServer();
                }
                base.LoadData();
            }
        }

        private void ReadMessagesFromClients(MyDebugClientInfo clientInfo)
        {
            Socket client = clientInfo.TcpClient.Client;
            while (client.Available >= 0)
            {
                bool flag = false;
                if (!clientInfo.LastHeader.IsValid && (client.Available >= MyExternalDebugStructures.MsgHeaderSize))
                {
                    client.Receive(this.m_arrayBuffer, MyExternalDebugStructures.MsgHeaderSize, SocketFlags.None);
                    Marshal.Copy(this.m_arrayBuffer, 0, this.m_tempBuffer, MyExternalDebugStructures.MsgHeaderSize);
                    clientInfo.LastHeader = (MyExternalDebugStructures.CommonMsgHeader) Marshal.PtrToStructure(this.m_tempBuffer, typeof(MyExternalDebugStructures.CommonMsgHeader));
                    flag = true;
                }
                if (clientInfo.LastHeader.IsValid && (client.Available >= clientInfo.LastHeader.MsgSize))
                {
                    client.Receive(this.m_arrayBuffer, clientInfo.LastHeader.MsgSize, SocketFlags.None);
                    if ((this.m_receivedMsgHandlers != null) && (this.m_receivedMsgHandlers.Count > 0))
                    {
                        Marshal.Copy(this.m_arrayBuffer, 0, this.m_tempBuffer, clientInfo.LastHeader.MsgSize);
                        foreach (ReceivedMsgHandler handler in this.m_receivedMsgHandlers)
                        {
                            if (handler != null)
                            {
                                handler(clientInfo.LastHeader, this.m_tempBuffer);
                            }
                        }
                    }
                    clientInfo.LastHeader = new MyExternalDebugStructures.CommonMsgHeader();
                    flag = true;
                }
                if (!flag)
                {
                    return;
                }
            }
        }

        public bool SendMessageToClients<TMessage>(TMessage msg) where TMessage: struct, MyExternalDebugStructures.IExternalDebugMsg
        {
            int msgSize = Marshal.SizeOf(typeof(TMessage));
            Marshal.StructureToPtr<MyExternalDebugStructures.CommonMsgHeader>(MyExternalDebugStructures.CommonMsgHeader.Create(msg.GetTypeStr(), msgSize), this.m_tempBuffer, true);
            Marshal.Copy(this.m_tempBuffer, this.m_arrayBuffer, 0, MyExternalDebugStructures.MsgHeaderSize);
            Marshal.StructureToPtr<TMessage>(msg, this.m_tempBuffer, true);
            Marshal.Copy(this.m_tempBuffer, this.m_arrayBuffer, MyExternalDebugStructures.MsgHeaderSize, msgSize);
            foreach (MyDebugClientInfo info in this.m_clients)
            {
                try
                {
                    if (info.TcpClient.Client != null)
                    {
                        info.TcpClient.Client.Send(this.m_arrayBuffer, 0, MyExternalDebugStructures.MsgHeaderSize + msgSize, SocketFlags.None);
                    }
                }
                catch (SocketException)
                {
                    info.TcpClient.Close();
                }
            }
            return true;
        }

        private void ServerListenerProc()
        {
            Thread.CurrentThread.Name = "External Debugging Listener";
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Loopback, 0x32c8) {
                    ExclusiveAddressUse = false
                };
                this.m_listener = listener;
                this.m_listener.Start();
            }
            catch (SocketException exception)
            {
                MyLog.Default.WriteLine("Cannot start debug listener.");
                MyLog.Default.WriteLine(exception);
                this.m_listener = null;
                this.m_active = false;
                return;
            }
            MyLog.Default.WriteLine("External debugger: listening...");
            try
            {
                while (true)
                {
                    TcpClient client = this.m_listener.AcceptTcpClient();
                    client.Client.Blocking = true;
                    MyLog.Default.WriteLine("External debugger: accepted client.");
                    MyDebugClientInfo entity = new MyDebugClientInfo {
                        TcpClient = client,
                        LastHeader = MyExternalDebugStructures.CommonMsgHeader.Create("UNKNOWN", 0)
                    };
                    this.m_clients.Add(entity);
                    this.m_clients.ApplyAdditions();
                }
            }
            catch (SocketException exception2)
            {
                if (exception2.SocketErrorCode == SocketError.Interrupted)
                {
                    this.m_listener.Stop();
                    this.m_listener = null;
                    MyLog.Default.WriteLine("External debugger: interrupted.");
                    return;
                }
                if ((MyLog.Default != null) && MyLog.Default.LogEnabled)
                {
                    MyLog.Default.WriteLine(exception2);
                }
            }
            this.m_listener.Stop();
            this.m_listener = null;
        }

        private bool StartServer()
        {
            if (!this.m_active)
            {
                Thread thread = new Thread(new ThreadStart(this.ServerListenerProc)) {
                    IsBackground = true
                };
                this.m_listenerThread = thread;
                this.m_listenerThread.Start();
                this.m_active = true;
                return true;
            }
            return false;
        }

        private void StopServer()
        {
            if (this.m_active && (this.m_listenerThread != null))
            {
                this.m_listener.Stop();
                foreach (MyDebugClientInfo info in this.m_clients)
                {
                    if (info.TcpClient != null)
                    {
                        info.TcpClient.Client.Disconnect(true);
                        info.TcpClient.Close();
                    }
                }
                this.m_clients.ClearImmediate();
                this.m_active = false;
            }
        }

        protected override void UnloadData()
        {
            this.m_receivedMsgHandlers.ClearImmediate();
            base.UnloadData();
        }

        public override void UpdateBeforeSimulation()
        {
            foreach (MyDebugClientInfo info in this.m_clients)
            {
                if (((info == null) || (info.TcpClient == null)) || ((info.TcpClient.Client == null) || !info.TcpClient.Connected))
                {
                    if (((info != null) && (info.TcpClient != null)) && ((info.TcpClient.Client != null) && info.TcpClient.Client.Connected))
                    {
                        info.TcpClient.Client.Disconnect(true);
                        info.TcpClient.Close();
                    }
                    this.m_clients.Remove(info, false);
                }
                else if (info.TcpClient.Connected && (info.TcpClient.Available > 0))
                {
                    this.ReadMessagesFromClients(info);
                }
            }
            this.m_clients.ApplyRemovals();
        }

        public bool HasClients =>
            (this.m_clients.Count > 0);

        private class MyDebugClientInfo
        {
            public MyExternalDebugStructures.CommonMsgHeader LastHeader;
            public System.Net.Sockets.TcpClient TcpClient;
        }

        public delegate void ReceivedMsgHandler(MyExternalDebugStructures.CommonMsgHeader messageHeader, IntPtr messageData);
    }
}

