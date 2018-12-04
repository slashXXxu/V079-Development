using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleServer.net
{
    public class PacketWriter : AbstractPacket,IDisposable
    {
        /// <summary>
        /// 二进制写入工具
        /// </summary>
        private readonly BinaryWriter _binWriter;

        /// <summary>
        /// 内存流中数据量长度
        /// </summary>
        public ushort Length
        {
            get { return (ushort)_stream.Length; }
        }

        /// <summary>
        /// 实例化
        /// </summary>
        public PacketWriter()
        {
            _stream = new MemoryStream();
            _binWriter = new BinaryWriter(_stream, Encoding.GetEncoding("gbk"));
        }

        public PacketWriter(byte[] data)
        {
            _stream = new MemoryStream(data);
            _binWriter = new BinaryWriter(_stream, Encoding.GetEncoding("gbk"));
        }
        /*
        public PacketWriter(SMSG pHeader)
        {
            _stream = new MemoryStream();
            _binWriter = new BinaryWriter(_stream, Encoding.GetEncoding("gbk"));
            WriteShort((short)pHeader);
        }

        public PacketWriter(IMSG pHeader)
        {
            _stream = new MemoryStream();
            _binWriter = new BinaryWriter(_stream, Encoding.GetEncoding("gbk"));
            WriteShort((short)pHeader);
        }*/

        public PacketWriter(short pHeader)
        {
            _stream = new MemoryStream();
            _binWriter = new BinaryWriter(_stream, Encoding.ASCII);
            WriteShort(pHeader);
        }

        /// <summary>
        /// Restart writing from the point specified. This will overwrite data in the packet.
        /// </summary>
        /// <param name="length">The point of the packet to start writing from.</param>
        public void Reset(int length)
        {
            _stream.Seek(length, SeekOrigin.Begin);
        }

        /// <summary>
        /// Writes a byte to the stream
        /// </summary>
        /// <param name="@byte">The byte to write</param>
        public void WriteByte(byte @byte)
        {
            _binWriter.Write(@byte);
        }

        /// <summary>
        /// Writes a byte array to the stream
        /// </summary>
        /// <param name="@bytes">The byte array to write</param>
        public void WriteBytes(byte[] @bytes)
        {
            _binWriter.Write(@bytes);
        }

        /// <summary>
        /// Writes a boolean to the stream
        /// </summary>
        /// <param name="@bool">The boolean to write</param>
        public void WriteBool(bool @bool)
        {
            _binWriter.Write(@bool);
        }

        /// <summary>
        /// Writes a short to the stream
        /// </summary>
        /// <param name="@short">The short to write</param>
        public void WriteShort(short @short)
        {
            _binWriter.Write(@short);
        }

        /// <summary>
        /// Writes a short to the stream
        /// </summary>
        /// <param name="@short">The short to write</param>
        public void WriteUShort(ushort @ushort)
        {
            _binWriter.Write(@ushort);
        }

        /// <summary>
        /// Writes an int to the stream
        /// </summary>
        /// <param name="@int">The int to write</param>
        public void WriteInt(int @int)
        {
            _binWriter.Write(@int);
        }

        /// <summary>
        /// Writes an unsigned int to the stream
        /// </summary>
        /// <param name="@int">The int to write</param>
        public void WriteUInt(uint @uint)
        {
            _binWriter.Write(@uint);
        }

        /// <summary>
        /// Writes a long to the stream
        /// </summary>
        /// <param name="@long">The long to write</param>
        public void WriteLong(long @long)
        {
            _binWriter.Write(@long);
        }

        /// <summary>
        /// Writes an unsigned long to the stream
        /// </summary>
        /// <param name="@long">The long to write</param>
        public void WriteULong(ulong @ulong)
        {
            _binWriter.Write(@ulong);
        }

        /// <summary>
        /// Writes a string to the stream
        /// </summary>
        /// <param name="@string">The string to write</param>
        public void WriteString(String @string)
        {
            _binWriter.Write(@string.ToCharArray());
        }

        /// <summary>
        /// Writes a string prefixed with a [short] length before it, to the stream
        /// </summary>
        /// <param name="@string">The string to write</param>
        public void WriteMapleString(String @string)
        {
            WriteShort((short)Encoding.Default.GetBytes(@string).Length);
            WriteString(@string);
        }

        public void WriteMapleString(string pValue, int pLen)
        {
            if (pValue.Length > pLen) throw new Exception("String is bigger than len");
            foreach (char c in pValue) WriteByte((byte)c);
            if (pValue.Length != pLen)
            {
                for (int i = 0; i < (pLen - pValue.Length); i++) { WriteByte(0x00); }
            }
            else return;
        }

        /// <summary>
        /// Writes a hex-string to the stream
        /// </summary>
        /// <param name="@string">The hex-string to write</param>
        public void WriteHexString(String hexString)
        {
            //WriteBytes(HexEncoding.GetBytes(hexString));
        }

        /// <summary>
        /// Sets a byte in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@byte">The byte to set</param>
        public void SetByte(long index, int @byte)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteByte((byte)@byte);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets a byte array in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@bytes">The bytes to set</param>
        public void SetBytes(long index, byte[] @bytes)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteBytes(@bytes);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets a bool in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@bool">The bool to set</param>
        public void SetBool(long index, bool @bool)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteBool(@bool);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets a short in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@short">The short to set</param>
        public void SetShort(long index, int @short)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteShort((short)@short);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets an int in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@int">The int to set</param>
        public void SetInt(long index, int @int)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteInt(@int);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets a long in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@long">The long to set</param>
        public void SetLong(long index, long @long)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteLong(@long);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets a long in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@string">The long to set</param>
        public void SetString(long index, string @string)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteString(@string);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets a string prefixed with a [short] length before it, in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@string">The string to set</param>
        public void SetMapleString(long index, string @string)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteMapleString(@string);
            _stream.Position = oldIndex;
        }

        /// <summary>
        /// Sets a hex-string in the stream
        /// </summary>
        /// <param name="index">The index of the stream to set data at</param>
        /// <param name="@string">The hex-string to set</param>
        public void SetHexString(long index, string @string)
        {
            long oldIndex = _stream.Position;
            _stream.Position = index;
            WriteHexString(@string);
            _stream.Position = oldIndex;
        }

        public void Dispose()
        {
            if (_stream != null && _binWriter != null)
            {
                _stream.Close();
                _binWriter.Close();
            }
        }
    }
}
