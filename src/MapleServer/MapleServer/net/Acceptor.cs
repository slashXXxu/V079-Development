using MapleServer.lib;
using System;
using System.Net;
using System.Net.Sockets;

namespace MapleServer.net
{
    public abstract class Acceptor
    {
        private TcpListener _listener;
        public ushort port { get; private set; }
        private bool Stopped = true; 
        protected Acceptor(ushort _port)
        {
            port = _port;
            Start();
        }
        public void Start()
        {
            if (!Stopped)
            {
                return;
            }
            //if (Type.GetType("Mono.Runtime") == null){} ??
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start(200);
            Stopped = false;
            _listener.BeginAcceptSocket(EndAccept, _listener);
        }
        public void Stop()
        {
            if (Stopped)
            {
                return;
            }
            Stopped = true;
            if (_listener!=null)
            {
                _listener.Stop();
                _listener = null;
            }
        }

        private void EndAccept(IAsyncResult ar)
        {
            if (Stopped)
            {
                return;
            } else
            {
                var listener = (TcpListener)ar.AsyncState;
                try
                {
                    OnAccept(listener.EndAcceptSocket(ar));
                }
                catch { }
                listener.BeginAcceptSocket(EndAccept, listener);
            }
        }
        public abstract void OnAccept(Socket pSocket); //抽象事件
    }
}
