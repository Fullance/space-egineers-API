namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Unsharper;
    using VRageMath.PackedVector;

    [Serializable, StructLayout(LayoutKind.Sequential), UnsharperDisableReflection, ProtoContract]
    public struct Color : IPackedVector<uint>, IPackedVector, IEquatable<Color>
    {
        [ProtoMember(0x11)]
        public uint PackedValue;
        public byte X
        {
            get => 
                this.R;
            set
            {
                this.R = value;
            }
        }
        public byte Y
        {
            get => 
                this.G;
            set
            {
                this.G = value;
            }
        }
        public byte Z
        {
            get => 
                this.B;
            set
            {
                this.B = value;
            }
        }
        public byte R
        {
            get => 
                ((byte) this.PackedValue);
            set
            {
                this.PackedValue = (this.PackedValue & 0xffffff00) | value;
            }
        }
        public byte G
        {
            get => 
                ((byte) (this.PackedValue >> 8));
            set
            {
                this.PackedValue = (this.PackedValue & 0xffff00ff) | ((uint) (value << 8));
            }
        }
        public byte B
        {
            get => 
                ((byte) (this.PackedValue >> 0x10));
            set
            {
                this.PackedValue = (this.PackedValue & 0xff00ffff) | ((uint) (value << 0x10));
            }
        }
        public byte A
        {
            get => 
                ((byte) (this.PackedValue >> 0x18));
            set
            {
                this.PackedValue = (this.PackedValue & 0xffffff) | ((uint) (value << 0x18));
            }
        }
        public static Color Transparent =>
            new Color(0);
        public static Color AliceBlue =>
            new Color(0xfffff8f0);
        public static Color AntiqueWhite =>
            new Color(0xffd7ebfa);
        public static Color Aqua =>
            new Color(0xffffff00);
        public static Color Aquamarine =>
            new Color(0xffd4ff7f);
        public static Color Azure =>
            new Color(0xfffffff0);
        public static Color Beige =>
            new Color(0xffdcf5f5);
        public static Color Bisque =>
            new Color(0xffc4e4ff);
        public static Color Black =>
            new Color(0xff000000);
        public static Color BlanchedAlmond =>
            new Color(0xffcdebff);
        public static Color Blue =>
            new Color(0xffff0000);
        public static Color BlueViolet =>
            new Color(0xffe22b8a);
        public static Color Brown =>
            new Color(0xff2a2aa5);
        public static Color BurlyWood =>
            new Color(0xff87b8de);
        public static Color CadetBlue =>
            new Color(0xffa09e5f);
        public static Color Chartreuse =>
            new Color(0xff00ff7f);
        public static Color Chocolate =>
            new Color(0xff1e69d2);
        public static Color Coral =>
            new Color(0xff507fff);
        public static Color CornflowerBlue =>
            new Color(0xffed9564);
        public static Color Cornsilk =>
            new Color(0xffdcf8ff);
        public static Color Crimson =>
            new Color(0xff3c14dc);
        public static Color Cyan =>
            new Color(0xffffff00);
        public static Color DarkBlue =>
            new Color(0xff8b0000);
        public static Color DarkCyan =>
            new Color(0xff8b8b00);
        public static Color DarkGoldenrod =>
            new Color(0xff0b86b8);
        public static Color DarkGray =>
            new Color(0xffa9a9a9);
        public static Color DarkGreen =>
            new Color(0xff006400);
        public static Color DarkKhaki =>
            new Color(0xff6bb7bd);
        public static Color DarkMagenta =>
            new Color(0xff8b008b);
        public static Color DarkOliveGreen =>
            new Color(0xff2f6b55);
        public static Color DarkOrange =>
            new Color(0xff008cff);
        public static Color DarkOrchid =>
            new Color(0xffcc3299);
        public static Color DarkRed =>
            new Color(0xff00008b);
        public static Color DarkSalmon =>
            new Color(0xff7a96e9);
        public static Color DarkSeaGreen =>
            new Color(0xff8bbc8f);
        public static Color DarkSlateBlue =>
            new Color(0xff8b3d48);
        public static Color DarkSlateGray =>
            new Color(0xff4f4f2f);
        public static Color DarkTurquoise =>
            new Color(0xffd1ce00);
        public static Color DarkViolet =>
            new Color(0xffd30094);
        public static Color DeepPink =>
            new Color(0xff9314ff);
        public static Color DeepSkyBlue =>
            new Color(0xffffbf00);
        public static Color DimGray =>
            new Color(0xff696969);
        public static Color DodgerBlue =>
            new Color(0xffff901e);
        public static Color Firebrick =>
            new Color(0xff2222b2);
        public static Color FloralWhite =>
            new Color(0xfff0faff);
        public static Color ForestGreen =>
            new Color(0xff228b22);
        public static Color Fuchsia =>
            new Color(0xffff00ff);
        public static Color Gainsboro =>
            new Color(0xffdcdcdc);
        public static Color GhostWhite =>
            new Color(0xfffff8f8);
        public static Color Gold =>
            new Color(0xff00d7ff);
        public static Color Goldenrod =>
            new Color(0xff20a5da);
        public static Color Gray =>
            new Color(0xff808080);
        public static Color Green =>
            new Color(0xff008000);
        public static Color GreenYellow =>
            new Color(0xff2fffad);
        public static Color Honeydew =>
            new Color(0xfff0fff0);
        public static Color HotPink =>
            new Color(0xffb469ff);
        public static Color IndianRed =>
            new Color(0xff5c5ccd);
        public static Color Indigo =>
            new Color(0xff82004b);
        public static Color Ivory =>
            new Color(0xfff0ffff);
        public static Color Khaki =>
            new Color(0xff8ce6f0);
        public static Color Lavender =>
            new Color(0xfffae6e6);
        public static Color LavenderBlush =>
            new Color(0xfff5f0ff);
        public static Color LawnGreen =>
            new Color(0xff00fc7c);
        public static Color LemonChiffon =>
            new Color(0xffcdfaff);
        public static Color LightBlue =>
            new Color(0xffe6d8ad);
        public static Color LightCoral =>
            new Color(0xff8080f0);
        public static Color LightCyan =>
            new Color(0xffffffe0);
        public static Color LightGoldenrodYellow =>
            new Color(0xffd2fafa);
        public static Color LightGreen =>
            new Color(0xff90ee90);
        public static Color LightGray =>
            new Color(0xffd3d3d3);
        public static Color LightPink =>
            new Color(0xffc1b6ff);
        public static Color LightSalmon =>
            new Color(0xff7aa0ff);
        public static Color LightSeaGreen =>
            new Color(0xffaab220);
        public static Color LightSkyBlue =>
            new Color(0xffface87);
        public static Color LightSlateGray =>
            new Color(0xff998877);
        public static Color LightSteelBlue =>
            new Color(0xffdec4b0);
        public static Color LightYellow =>
            new Color(0xffe0ffff);
        public static Color Lime =>
            new Color(0xff00ff00);
        public static Color LimeGreen =>
            new Color(0xff32cd32);
        public static Color Linen =>
            new Color(0xffe6f0fa);
        public static Color Magenta =>
            new Color(0xffff00ff);
        public static Color Maroon =>
            new Color(0xff000080);
        public static Color MediumAquamarine =>
            new Color(0xffaacd66);
        public static Color MediumBlue =>
            new Color(0xffcd0000);
        public static Color MediumOrchid =>
            new Color(0xffd355ba);
        public static Color MediumPurple =>
            new Color(0xffdb7093);
        public static Color MediumSeaGreen =>
            new Color(0xff71b33c);
        public static Color MediumSlateBlue =>
            new Color(0xffee687b);
        public static Color MediumSpringGreen =>
            new Color(0xff9afa00);
        public static Color MediumTurquoise =>
            new Color(0xffccd148);
        public static Color MediumVioletRed =>
            new Color(0xff8515c7);
        public static Color MidnightBlue =>
            new Color(0xff701919);
        public static Color MintCream =>
            new Color(0xfffafff5);
        public static Color MistyRose =>
            new Color(0xffe1e4ff);
        public static Color Moccasin =>
            new Color(0xffb5e4ff);
        public static Color NavajoWhite =>
            new Color(0xffaddeff);
        public static Color Navy =>
            new Color(0xff800000);
        public static Color OldLace =>
            new Color(0xffe6f5fd);
        public static Color Olive =>
            new Color(0xff008080);
        public static Color OliveDrab =>
            new Color(0xff238e6b);
        public static Color Orange =>
            new Color(0xff00a5ff);
        public static Color OrangeRed =>
            new Color(0xff0045ff);
        public static Color Orchid =>
            new Color(0xffd670da);
        public static Color PaleGoldenrod =>
            new Color(0xffaae8ee);
        public static Color PaleGreen =>
            new Color(0xff98fb98);
        public static Color PaleTurquoise =>
            new Color(0xffeeeeaf);
        public static Color PaleVioletRed =>
            new Color(0xff9370db);
        public static Color PapayaWhip =>
            new Color(0xffd5efff);
        public static Color PeachPuff =>
            new Color(0xffb9daff);
        public static Color Peru =>
            new Color(0xff3f85cd);
        public static Color Pink =>
            new Color(0xffcbc0ff);
        public static Color Plum =>
            new Color(0xffdda0dd);
        public static Color PowderBlue =>
            new Color(0xffe6e0b0);
        public static Color Purple =>
            new Color(0xff800080);
        public static Color Red =>
            new Color(0xff0000ff);
        public static Color RosyBrown =>
            new Color(0xff8f8fbc);
        public static Color RoyalBlue =>
            new Color(0xffe16941);
        public static Color SaddleBrown =>
            new Color(0xff13458b);
        public static Color Salmon =>
            new Color(0xff7280fa);
        public static Color SandyBrown =>
            new Color(0xff60a4f4);
        public static Color SeaGreen =>
            new Color(0xff578b2e);
        public static Color SeaShell =>
            new Color(0xffeef5ff);
        public static Color Sienna =>
            new Color(0xff2d52a0);
        public static Color Silver =>
            new Color(0xffc0c0c0);
        public static Color SkyBlue =>
            new Color(0xffebce87);
        public static Color SlateBlue =>
            new Color(0xffcd5a6a);
        public static Color SlateGray =>
            new Color(0xff908070);
        public static Color Snow =>
            new Color(0xfffafaff);
        public static Color SpringGreen =>
            new Color(0xff7fff00);
        public static Color SteelBlue =>
            new Color(0xffb48246);
        public static Color Tan =>
            new Color(0xff8cb4d2);
        public static Color Teal =>
            new Color(0xff808000);
        public static Color Thistle =>
            new Color(0xffd8bfd8);
        public static Color Tomato =>
            new Color(0xff4763ff);
        public static Color Turquoise =>
            new Color(0xffd0e040);
        public static Color Violet =>
            new Color(0xffee82ee);
        public static Color Wheat =>
            new Color(0xffb3def5);
        public static Color White =>
            new Color(uint.MaxValue);
        public static Color WhiteSmoke =>
            new Color(0xfff5f5f5);
        public static Color Yellow =>
            new Color(0xff00ffff);
        public static Color YellowGreen =>
            new Color(0xff32cd9a);
        public Color(uint packedValue)
        {
            this.PackedValue = packedValue;
        }

        public Color(int r, int g, int b)
        {
            if ((((r | g) | b) & -256) != 0)
            {
                r = ClampToByte64((long) r);
                g = ClampToByte64((long) g);
                b = ClampToByte64((long) b);
            }
            g = g << 8;
            b = b << 0x10;
            this.PackedValue = (uint) (((r | g) | b) | -16777216);
        }

        public Color(int r, int g, int b, int a)
        {
            if (((((r | g) | b) | a) & -256) != 0)
            {
                r = ClampToByte32(r);
                g = ClampToByte32(g);
                b = ClampToByte32(b);
                a = ClampToByte32(a);
            }
            g = g << 8;
            b = b << 0x10;
            a = a << 0x18;
            this.PackedValue = (uint) (((r | g) | b) | a);
        }

        public Color(float rgb)
        {
            this.PackedValue = PackHelper(rgb, rgb, rgb, 1f);
        }

        public Color(float r, float g, float b)
        {
            this.PackedValue = PackHelper(r, g, b, 1f);
        }

        public Color(float r, float g, float b, float a)
        {
            this.PackedValue = PackHelper(r, g, b, a);
        }

        public Color(Color color, float a)
        {
            this.PackedValue = PackHelper(((float) color.R) / 255f, ((float) color.G) / 255f, ((float) color.B) / 255f, a);
        }

        public Color(Vector3 vector)
        {
            this.PackedValue = PackHelper(vector.X, vector.Y, vector.Z, 1f);
        }

        public Color(Vector4 vector)
        {
            this.PackedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        public static Color operator *(Color value, float scale)
        {
            Color color;
            uint packedValue = value.PackedValue;
            uint num2 = (byte) packedValue;
            uint num3 = (byte) (packedValue >> 8);
            uint num4 = (byte) (packedValue >> 0x10);
            uint num5 = (byte) (packedValue >> 0x18);
            scale *= 65536f;
            uint num6 = (scale >= 0.0) ? ((scale <= 16777215.0) ? ((uint) scale) : 0xffffff) : 0;
            uint num7 = (num2 * num6) >> 0x10;
            uint num8 = (num3 * num6) >> 0x10;
            uint num9 = (num4 * num6) >> 0x10;
            uint num10 = (num5 * num6) >> 0x10;
            if (num7 > 0xff)
            {
                num7 = 0xff;
            }
            if (num8 > 0xff)
            {
                num8 = 0xff;
            }
            if (num9 > 0xff)
            {
                num9 = 0xff;
            }
            if (num10 > 0xff)
            {
                num10 = 0xff;
            }
            color.PackedValue = ((num7 | (num8 << 8)) | (num9 << 0x10)) | (num10 << 0x18);
            return color;
        }

        public static Color operator +(Color value, Color other) => 
            new Color(value.R + other.R, value.G + other.G, value.B + other.B, value.A + other.A);

        public static Color operator *(Color value, Color other)
        {
            Vector4 vector = value.ToVector4();
            Vector4 vector2 = other.ToVector4();
            return new Color(vector.X * vector2.X, vector.Y * vector2.Y, vector.Z * vector2.Z, vector.W * vector2.W);
        }

        public static bool operator ==(Color a, Color b) => 
            a.Equals(b);

        public static bool operator !=(Color a, Color b) => 
            !a.Equals(b);

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            this.PackedValue = PackHelper(vector.X, vector.Y, vector.Z, vector.W);
        }

        public static Color FromNonPremultiplied(Vector4 vector)
        {
            Color color;
            color.PackedValue = PackHelper(vector.X * vector.W, vector.Y * vector.W, vector.Z * vector.W, vector.W);
            return color;
        }

        public static Color FromNonPremultiplied(int r, int g, int b, int a)
        {
            Color color;
            r = ClampToByte64((r * a) / 0xffL);
            g = ClampToByte64((g * a) / 0xffL);
            b = ClampToByte64((b * a) / 0xffL);
            a = ClampToByte32(a);
            g = g << 8;
            b = b << 0x10;
            a = a << 0x18;
            color.PackedValue = (uint) (((r | g) | b) | a);
            return color;
        }

        private static uint PackHelper(float vectorX, float vectorY, float vectorZ, float vectorW) => 
            (((PackUtils.PackUNorm(255f, vectorX) | (PackUtils.PackUNorm(255f, vectorY) << 8)) | (PackUtils.PackUNorm(255f, vectorZ) << 0x10)) | (PackUtils.PackUNorm(255f, vectorW) << 0x18));

        private static int ClampToByte32(int value)
        {
            if (value < 0)
            {
                return 0;
            }
            if (value > 0xff)
            {
                return 0xff;
            }
            return value;
        }

        private static int ClampToByte64(long value)
        {
            if (value < 0L)
            {
                return 0;
            }
            if (value > 0xffL)
            {
                return 0xff;
            }
            return (int) value;
        }

        public Vector3 ToVector3()
        {
            Vector3 vector;
            vector.X = PackUtils.UnpackUNorm(0xff, this.PackedValue);
            vector.Y = PackUtils.UnpackUNorm(0xff, this.PackedValue >> 8);
            vector.Z = PackUtils.UnpackUNorm(0xff, this.PackedValue >> 0x10);
            return vector;
        }

        public Vector4 ToVector4()
        {
            Vector4 vector;
            vector.X = PackUtils.UnpackUNorm(0xff, this.PackedValue);
            vector.Y = PackUtils.UnpackUNorm(0xff, this.PackedValue >> 8);
            vector.Z = PackUtils.UnpackUNorm(0xff, this.PackedValue >> 0x10);
            vector.W = PackUtils.UnpackUNorm(0xff, this.PackedValue >> 0x18);
            return vector;
        }

        public static Color Lerp(Color value1, Color value2, float amount)
        {
            Color color;
            uint packedValue = value1.PackedValue;
            uint num2 = value2.PackedValue;
            int num3 = (byte) packedValue;
            int num4 = (byte) (packedValue >> 8);
            int num5 = (byte) (packedValue >> 0x10);
            int num6 = (byte) (packedValue >> 0x18);
            int num7 = (byte) num2;
            int num8 = (byte) (num2 >> 8);
            int num9 = (byte) (num2 >> 0x10);
            int num10 = (byte) (num2 >> 0x18);
            int num11 = (int) PackUtils.PackUNorm(65536f, amount);
            int num12 = num3 + (((num7 - num3) * num11) >> 0x10);
            int num13 = num4 + (((num8 - num4) * num11) >> 0x10);
            int num14 = num5 + (((num9 - num5) * num11) >> 0x10);
            int num15 = num6 + (((num10 - num6) * num11) >> 0x10);
            color.PackedValue = (uint) (((num12 | (num13 << 8)) | (num14 << 0x10)) | (num15 << 0x18));
            return color;
        }

        public static Color Multiply(Color value, float scale)
        {
            Color color;
            uint packedValue = value.PackedValue;
            uint num2 = (byte) packedValue;
            uint num3 = (byte) (packedValue >> 8);
            uint num4 = (byte) (packedValue >> 0x10);
            uint num5 = (byte) (packedValue >> 0x18);
            scale *= 65536f;
            uint num6 = (scale >= 0.0) ? ((scale <= 16777215.0) ? ((uint) scale) : 0xffffff) : 0;
            uint num7 = (num2 * num6) >> 0x10;
            uint num8 = (num3 * num6) >> 0x10;
            uint num9 = (num4 * num6) >> 0x10;
            uint num10 = (num5 * num6) >> 0x10;
            if (num7 > 0xff)
            {
                num7 = 0xff;
            }
            if (num8 > 0xff)
            {
                num8 = 0xff;
            }
            if (num9 > 0xff)
            {
                num9 = 0xff;
            }
            if (num10 > 0xff)
            {
                num10 = 0xff;
            }
            color.PackedValue = ((num7 | (num8 << 8)) | (num9 << 0x10)) | (num10 << 0x18);
            return color;
        }

        public override string ToString() => 
            string.Format(CultureInfo.CurrentCulture, "{{R:{0} G:{1} B:{2} A:{3}}}", new object[] { this.R, this.G, this.B, this.A });

        public override int GetHashCode() => 
            this.PackedValue.GetHashCode();

        public override bool Equals(object obj) => 
            ((obj is Color) && this.Equals((Color) obj));

        public bool Equals(Color other) => 
            this.PackedValue.Equals(other.PackedValue);

        public static implicit operator Color(Vector3 v) => 
            new Color(v.X, v.Y, v.Z, 1f);

        public static implicit operator Vector3(Color v) => 
            v.ToVector3();

        public static implicit operator Color(Vector4 v) => 
            new Color(v.X, v.Y, v.Z, v.W);

        public static implicit operator Vector4(Color v) => 
            v.ToVector4();

        uint IPackedVector<uint>.PackedValue
        {
            get => 
                this.PackedValue;
            set
            {
                this.PackedValue = value;
            }
        }
        public static Color Lighten(Color inColor, double inAmount) => 
            new Color((int) Math.Min((double) 255.0, (double) (inColor.R + (255.0 * inAmount))), (int) Math.Min((double) 255.0, (double) (inColor.G + (255.0 * inAmount))), (int) Math.Min((double) 255.0, (double) (inColor.B + (255.0 * inAmount))), inColor.A);

        public static Color Darken(Color inColor, double inAmount) => 
            new Color((int) Math.Max((double) 0.0, (double) (inColor.R - (255.0 * inAmount))), (int) Math.Max((double) 0.0, (double) (inColor.G - (255.0 * inAmount))), (int) Math.Max((double) 0.0, (double) (inColor.B - (255.0 * inAmount))), inColor.A);

        public unsafe Color ToGray()
        {
            Vector4 vector = *((Vector4*) this);
            float r = ((0.2989f * vector.X) + (0.587f * vector.Y)) + (0.114f * vector.Z);
            return new Color(r, r, r, vector.W);
        }
    }
}

