namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public struct ColorDefinitionRGBA
    {
        [ProtoMember(13), XmlAttribute]
        public byte R;
        [ProtoMember(0x10), XmlAttribute]
        public byte G;
        [XmlAttribute, ProtoMember(20)]
        public byte B;
        [ProtoMember(0x18), XmlAttribute]
        public byte A;
        [XmlAttribute]
        public byte Red
        {
            get => 
                this.R;
            set
            {
                this.R = value;
            }
        }
        [XmlAttribute]
        public byte Green
        {
            get => 
                this.G;
            set
            {
                this.G = value;
            }
        }
        [XmlAttribute]
        public byte Blue
        {
            get => 
                this.B;
            set
            {
                this.B = value;
            }
        }
        [XmlAttribute]
        public byte Alpha
        {
            get => 
                this.A;
            set
            {
                this.A = value;
            }
        }
        [XmlAttribute]
        public string Hex
        {
            get => 
                this.GetHex();
            set
            {
                this.SetHex(value);
            }
        }
        public bool ShouldSerializeRed() => 
            false;

        public bool ShouldSerializeGreen() => 
            false;

        public bool ShouldSerializeBlue() => 
            false;

        public bool ShouldSerializeAlpha() => 
            false;

        public bool ShouldSerializeHex() => 
            false;

        private string GetHex() => 
            $"#{this.A:X2}{this.R:X2}{this.G:X2}{this.B:X2}";

        private void SetHex(string hex)
        {
            if (!string.IsNullOrEmpty(hex))
            {
                uint num;
                hex = hex.Trim(new char[] { ' ', '#' });
                uint.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out num);
                if (hex.Length < 8)
                {
                    num |= 0xff000000;
                }
                this.A = (byte) ((-16777216 & num) >> 0x18);
                this.R = (byte) ((0xff0000 & num) >> 0x10);
                this.G = (byte) ((0xff00 & num) >> 8);
                this.B = (byte) (0xff & num);
            }
        }

        public ColorDefinitionRGBA(string hex) : this(0, 0, 0, 0xff)
        {
            this.Hex = hex;
        }

        public ColorDefinitionRGBA(byte red, byte green, byte blue, byte alpha = 0xff)
        {
            this.R = red;
            this.G = green;
            this.B = blue;
            this.A = alpha;
        }

        public static implicit operator Color(ColorDefinitionRGBA definitionRgba) => 
            new Color(definitionRgba.R, definitionRgba.G, definitionRgba.B, definitionRgba.A);

        public static implicit operator ColorDefinitionRGBA(Color color) => 
            new ColorDefinitionRGBA { 
                A = color.A,
                B = color.B,
                G = color.G,
                R = color.R
            };

        public static implicit operator Vector4(ColorDefinitionRGBA definitionRgba) => 
            new Vector4(((float) definitionRgba.R) / 255f, ((float) definitionRgba.G) / 255f, ((float) definitionRgba.B) / 255f, ((float) definitionRgba.A) / 255f);

        public static implicit operator ColorDefinitionRGBA(Vector4 vector) => 
            new ColorDefinitionRGBA { 
                A = (byte) (vector.W * 255f),
                B = (byte) (vector.Z * 255f),
                G = (byte) (vector.Y * 255f),
                R = (byte) (vector.X * 255f)
            };

        public override string ToString() => 
            $"R:{this.R} G:{this.G} B:{this.B} A:{this.A}";
    }
}

