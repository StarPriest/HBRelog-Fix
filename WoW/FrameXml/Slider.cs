using System;
using System.Windows.Forms;

namespace HighVoltz.HBRelog.WoW.FrameXml
{
    public class Slider : Frame
    {
        public Slider(WowManager wowManager, IntPtr address) : base(wowManager, address) { }

        public bool IsEnabled => (SliderFlags & SliderFlags.Disabled) == 0;


	    public SliderFlags SliderFlags => (SliderFlags)WowManager.Processsharp.Memory.Read<uint>(Address + Offsets.Slider.Flags);


		public Orientation Orientation
        {
            get
            {
                var ori = WowManager.Processsharp.Memory.Read<int>(Address + Offsets.Slider.OrientationOffset);
                return ori == 1 ? Orientation.Vertical : Orientation.Horizontal;
            }
        }

        public float MinValue => WowManager.Processsharp.Memory.Read<float>(Address + Offsets.Slider.MinValueOffset);

	    public float MaxValue => WowManager.Processsharp.Memory.Read<float>(Address + Offsets.Slider.MaxValueOffset) + MinValue;

	    public float Value => WowManager.Processsharp.Memory.Read<float>(Address + Offsets.Slider.ValueOffset) + MinValue;

	    public float ValueStep => WowManager.Processsharp.Memory.Read<float>(Address + Offsets.Slider.ValueStepOffset) + MinValue;


	    public Texture ThumbTexture
        {
            get
            {
                var ptr = WowManager.Processsharp.Memory.Read<IntPtr>(Address + Offsets.Slider.ThumbTextureOffset);
                return ptr != IntPtr.Zero ? GetUIObjectFromPointer<Texture>(WowManager, ptr) : null;
            }
        }
    }

	[Flags]
	public enum SliderFlags
	{
		Disabled = 1 << 3,
	}
}
