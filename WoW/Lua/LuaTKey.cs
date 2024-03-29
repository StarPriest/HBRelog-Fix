﻿using System;
using Process.NET;


namespace HighVoltz.HBRelog.WoW.Lua
{
    public class LuaTKey
    {
        private LuaTKeyStruct _luaTKeyStruct;

        private readonly ProcessSharp _memory;

        public LuaTKey(ProcessSharp memory, LuaTKeyStruct luaTKeyStruct)
        {
            _luaTKeyStruct = luaTKeyStruct;
            _memory = memory;
        }

        public LuaNode Next
        {
            get
            {
                try
                {
                    return _luaTKeyStruct.NextNodePtr != IntPtr.Zero ? new LuaNode(_memory, _luaTKeyStruct.NextNodePtr) : null;
                }
                catch (System.AccessViolationException)
                {
                    return null;
                }
            }
        }

        private LuaValue _value;
        public LuaValue Value
        {
            get { return _value ?? (_value = new LuaValue(_memory, _luaTKeyStruct.Value)); }
        }

        public LuaType Type { get { return _luaTKeyStruct.Type;}}

    }
}
