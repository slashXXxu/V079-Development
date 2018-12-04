using MapleServer.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MapleServer.net
{
    public class Session
    {
        private SessionType _type;
        private readonly Socket _socket;
        public Action<PacketReader> OnPacketReceived;
        public Action<Session> OnClientDisconnected;
        public Action<ErrorLogger> HandleException;
        //public Action<short version, byte serverIdentifier> OnInitPacketReceived;
        public Session(Socket socket, SessionType type)
        {
            _socket = socket;
            _type = type;
        }
        public void WaitForData()
        {
            WaitForData(new SocketInfo(_socket, 4));
        }

        public void WaitForDataNoEncryption()
        {
            WaitForData(new SocketInfo(_socket, 2, true));
        }
        private void WaitForData(SocketInfo socketInfo)
        {
            try
            {
                _socket.BeginReceive(socketInfo.DataBuffer,
                    socketInfo.Index,
                    socketInfo.DataBuffer.Length - socketInfo.Index,
                    SocketFlags.None,
                    new AsyncCallback(OnDataReceived),
                    socketInfo);
            }
            catch (Exception se)
            {
                HandleException?.Invoke(new ErrorLogger(ErrorLevel.Exception, string.Format("[错误信息] 接收客户端数据出错：{0}",se.ToString())));
                OnClientDisconnected?.Invoke(this);
            }
        }
        private void OnDataReceived(IAsyncResult iar) {
            SocketInfo socketInfo = (SocketInfo)iar.AsyncState;
            try
            {
                int received = socketInfo.Socket.EndReceive(iar);
                if (received == 0 || _socket.Poll(1000, SelectMode.SelectRead))
                {
                    OnClientDisconnected?.Invoke(this);
                    return;
                }
                socketInfo.Index += received;
            } catch
            {

            }
        }
        public Socket Socket
        {
            get { return _socket; }
        }

        public SessionType Type
        {
            get { return _type; }
        }
    }
}
