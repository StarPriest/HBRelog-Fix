﻿using System;
using System.Text;

namespace HighVoltz.HBRelog.WoW.FrameXml
{
    public class Texture : VisibleRegion
    {
        public Texture(WowManager wowManager, IntPtr address) : base(wowManager, address) { }

        private bool triedGetPath;
        private string _texturePath = string.Empty;

        public string TexturePath
        {
            get
            {
                if (!triedGetPath)
                {
                    var ptr = WowManager.Processsharp.Memory.Read<IntPtr>(Address + Offsets.Texture.TexturePathObjectOffset);
                    if (ptr != IntPtr.Zero)
                    {
                        ptr = WowManager.Processsharp.Memory.Read<IntPtr>(ptr + Offsets.Texture.TexturePathOffset);
                        if (ptr != IntPtr.Zero)
                            _texturePath = WowManager.Processsharp.Memory.Read(ptr, Encoding.UTF8, 260);
                    }
	                triedGetPath = true;
                }
                return _texturePath;
            }
        }
    }
}
