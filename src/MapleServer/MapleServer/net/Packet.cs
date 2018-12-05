using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleServer.net
{
    public class Packet : IDisposable
    {
        private MemoryStream _stream;
        private BinaryReader _Reader;
        private BinaryWriter _Writer;
        public MemoryStream GetStream()
        {
            return _stream;
        }
        public long PacketCreationTime
        {
            get
            {
                return (long)((Stopwatch.GetTimestamp() * (1.0 / Stopwatch.Frequency)) * 1000.0);
            }
        }
        public byte Opcode { get; private set; }
        public Packet(byte[] pData) : this(pData, pData.Length){}
        public Packet(byte[] pData, int length) //读操作
        {
            _stream = new MemoryStream(pData, 0, length, false);
            _Reader = new BinaryReader(_stream);
            Opcode = ReadByte();
            Position = 0;
        }
        public Packet() //写
        {
            _stream = new MemoryStream();
            _Writer = new BinaryWriter(_stream);
        }
        public Packet(byte pOpcode) //写
        {
            _stream = new MemoryStream();
            _Writer = new BinaryWriter(_stream);
            WriteByte(pOpcode);
        }
        public void Dispose()
        {
            if(_stream!=null)
            {
                _stream.Dispose();
            }
            if (_Reader != null)
            {
                _Reader.Dispose();
            }
            if (_Writer !=null)
            {
                _Writer.Dispose();
            }
        }
        public byte[] getBuffer()
        {
            return _stream.ToArray();
        }
        public int Length
        {
            get
            {
                return (int)_stream.Length;
            }
        }

        public int Position
        {
            get
            {
                return (int)_stream.Position;
            }
            set
            {
                _stream.Position = value;
            }
        }
        public void Reset(int pPosition = 0)
        {
            _stream.Position = pPosition;
        }
        public void Skip(int count)
        {
            if (count + Position > Length)
            {
                count = 0;
            }
            Position += count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Length * 3);
            foreach (var b in getBuffer())
            {
                sb.AppendFormat("{0:X2} ", b);
            }
            return sb.ToString();
        }
        #region 读流部分
        public byte[] ReadLeftOverBytes() //读剩下的数据
        {
            return ReadBytes(Length - Position);
        }
        public byte[] ReadBytes(int pLen)
        {
            return _Reader.ReadBytes(pLen);
        }

        public bool ReadBool()
        {
            return _Reader.ReadByte() != 0;
        }
        public byte ReadByte()
        {
            return _Reader.ReadByte();
        }

        public sbyte ReadSbyte()
        {
            return _Reader.ReadSByte();
        }
        public short ReadShort()
        {
            return _Reader.ReadInt16();
        }
        public int ReadInt()
        {
            return _Reader.ReadInt32();
        }
        public long ReadLong()
        {
            return _Reader.ReadInt64();
        }
        public ushort ReadUShort()
        {
            return _Reader.ReadUInt16();
        }
        public uint ReadUInt()
        {
            return _Reader.ReadUInt32();
        }
        public ulong ReadULong()
        {
            return _Reader.ReadUInt64();
        }
        public double ReadDouble()
        {
            return _Reader.ReadDouble();
        }
        public float ReadFloat()
        {
            return _Reader.ReadSingle();
        }
        public string ReadString(short pLen = -1) {
            short len = pLen == -1 ? ReadShort() : pLen;
            return Encoding.GetEncoding("gbk").GetString(ReadBytes(pLen));
        }
        #endregion
        #region 写流部分
        public void WriteBytes(byte[] val) {
            _Writer.Write(val);
        }

        public void WriteByte(byte val)
        {
            if (Length == 0)
                Opcode = val;
            _Writer.Write(val);
        }
        public void WriteSByte(sbyte val) {
            _Writer.Write(val);
        }
        public void WriteBool(bool val) {
            WriteByte(val == true ? (byte)1 : (byte)0);
        }
        public void WriteShort(short val) {
            _Writer.Write(val);
        }
        public void WriteInt(int val) {
            _Writer.Write(val);
        }
        public void WriteLong(long val) {
            _Writer.Write(val);
        }
        public void WriteUShort(ushort val) {
            _Writer.Write(val);
        }
        public void WriteUInt(uint val) {
            _Writer.Write(val);
        }
        public void WriteULong(ulong val) {
            _Writer.Write(val);
        }
        public void WriteDouble(double val) {
            _Writer.Write(val);
        }
        public void WriteFloat(float val) {
            _Writer.Write(val);
        }
        public void WriteString(string val) {
            WriteShort((short)Encoding.GetEncoding("gbk").GetBytes(val).Length);
            _Writer.Write(Encoding.GetEncoding("gbk").GetBytes(val));
        }
        public void WriteString(string val, int maxlen) {
            if (Encoding.GetEncoding("gbk").GetBytes(val).Length > maxlen)
            {
                val = val.Substring(0, maxlen);
            }
            WriteBytes(Encoding.GetEncoding("gbk").GetBytes(val));
            for (int a = Encoding.GetEncoding("gbk").GetBytes(val).Length; a < maxlen; a++)
            {
                WriteByte(0);
            }
        }
        public void WriteString26(string val) {
            WriteString(val, 26);
        }

        public void WriteHexString(string pInput)
        {
            pInput = pInput.Replace(" ", "");
            if (pInput.Length % 2 != 0)
            {
                throw new Exception("Hex String is incorrect (size)");
            }
            for (int i = 0; i < pInput.Length; i += 2)
            {
                WriteByte(byte.Parse(pInput.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
            }
        }
        #endregion
    }
}
