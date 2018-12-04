﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MapleServer.net
{
    public class SocketInfo
    {
        public SocketInfo(Socket socket, short headerLength) : this(socket, headerLength, false)
        {
        }

        public SocketInfo(Socket socket, short headerLength, bool noEncryption)
        {
            Socket = socket;
            State = StateEnum.Header;
            NoEncryption = noEncryption;
            DataBuffer = new byte[headerLength];
            Index = 0;
        }

        /// <summary>
        /// The SocketInfo's socket
        /// </summary>
        public readonly Socket Socket;

        public bool NoEncryption;

        /// <summary>
        /// The Session's state of what data to receive
        /// </summary>
        public StateEnum State;

        /// <summary>
        /// The buffer of data to recieve
        /// </summary>
        public byte[] DataBuffer;

        /// <summary>
        /// The index of the current data
        /// </summary>
        public int Index;

        /// <summary>
        /// The SocketInfo's state of data
        /// </summary>
        public enum StateEnum { Header, Content }
    }
}
