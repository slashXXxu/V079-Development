using MapleServer.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MapleServer.net
{
    public class Acceptor : IDisposable
    {
        private readonly Socket _listener;

        /// <summary>
        /// 定义客户端连接事件
        /// </summary>
        public event EventHandler<Session> OnClientConnected;//事件方法：表示在该事件提供数据时处理该方法
        /// <summary>
        /// 定义异常信息处理事件
        /// </summary>
        public event EventHandler<ErrorLogger> HandleException;

        public Acceptor() //实例化
        {
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void StartListening(int port)
        {
            _listener.Bind(new IPEndPoint(IPAddress.Any, port));
            _listener.Listen(20);//同时连接等候数
            WaitForClientConnect();
        }
        private void WaitForClientConnect()
        {
            _listener.BeginAccept(asyncResult => {
                try
                {
                    Socket socket = _listener.EndAccept(asyncResult);
                    Session session = new Session(socket, SessionType.SERVER_TO_CLIENT);
                    session.WaitForData();
                    OnClientConnected?.Invoke(this, session);//触发客户端连接事件
                    WaitForClientConnect();
                }
                catch (ObjectDisposedException ode)
                {
                    HandleException?.Invoke(this, new ErrorLogger(ErrorLevel.ObjectDisposedException, ode.ToString()));
                }
                catch (Exception se)
                {
                    HandleException?.Invoke(this, new ErrorLogger(ErrorLevel.Exception, se.ToString()));
                }
            }
            , null);
        }
        public void Dispose()
        {
            _listener.Close();//关闭服务器
            GC.SuppressFinalize(this);//系统垃圾回收
        }
    }
}
