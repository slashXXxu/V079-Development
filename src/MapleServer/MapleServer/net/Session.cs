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
        private SessionType sERVER_TO_CLIENT;
        private Socket socket;

        public Session(Socket socket, SessionType sERVER_TO_CLIENT)
        {
            this.socket = socket;
            this.sERVER_TO_CLIENT = sERVER_TO_CLIENT;
        }
    }
}
