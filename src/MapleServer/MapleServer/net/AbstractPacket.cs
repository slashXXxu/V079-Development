using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleServer.net
{
    public abstract class AbstractPacket
    {
        protected MemoryStream _stream;

        public byte[] ToArray()
        {
            return _stream.ToArray();
        }
    }
}
