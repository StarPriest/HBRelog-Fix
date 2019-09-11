using System;
using System.Runtime.InteropServices;
using System.Text;
using Process.NET;


namespace HighVoltz.HBRelog.WoW.Lua
{
    public class LuaTString
    {
        private LuaTStringHeader _luaTString;
        
        private readonly ProcessSharp _Processsharp;

        public LuaTString(ProcessSharp memory, IntPtr address)
        {
            Address = address;
            _Processsharp = memory;
            _luaTString = memory.Memory.Read<LuaTStringHeader>(address);
        }

        public readonly IntPtr Address;

        public uint Hash { get { return _luaTString.Hash; } }

        private string _string;
        public string Value
        {
            get
            {
                return (_string ?? (_string = _Processsharp.Memory.Read(Address + Size, Encoding.UTF8, _luaTString.Length)));
            }
        }

        public override string ToString()
        {
            return Value;
        }

        private const int Size = 20;

        [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 1)]
        struct LuaTStringHeader
        {
            readonly public LuaCommonHeader Header;
            private readonly byte reserved1;
            private readonly byte reserved2;
            public readonly uint Hash;
            public readonly int Length;
        }
    }
}
