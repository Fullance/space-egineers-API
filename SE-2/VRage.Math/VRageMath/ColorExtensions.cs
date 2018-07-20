namespace VRageMath
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public static class ColorExtensions
    {
        public static VRageMath.Color Alpha(this VRageMath.Color c, float a) => 
            new VRageMath.Color(c, a);

        public static Vector3 ColorToHSV(this VRageMath.Color rgb)
        {
            System.Drawing.Color color = System.Drawing.Color.FromArgb(rgb.R, rgb.G, rgb.B);
            int num = Math.Max(color.R, Math.Max(color.G, color.B));
            int num2 = Math.Min(color.R, Math.Min(color.G, color.B));
            float x = color.GetHue() / 360f;
            float y = (num == 0) ? 0f : (1f - ((1f * num2) / ((float) num)));
            return new Vector3(x, y, ((float) num) / 255f);
        }

        public static Vector3 ColorToHSVDX11(this VRageMath.Color rgb)
        {
            System.Drawing.Color color = System.Drawing.Color.FromArgb(rgb.R, rgb.G, rgb.B);
            int num = Math.Max(color.R, Math.Max(color.G, color.B));
            int num2 = Math.Min(color.R, Math.Min(color.G, color.B));
            float x = color.GetHue() / 360f;
            float y = (num == 0) ? -1f : (1f - ((2f * num2) / ((float) num)));
            return new Vector3(x, y, -1f + ((2f * num) / 255f));
        }

        public static VRageMath.Color HexToColor(string hex)
        {
            if ((hex.Length > 0) && !hex.StartsWith("#"))
            {
                hex = "#" + hex;
            }
            System.Drawing.Color color = ColorTranslator.FromHtml(hex);
            return new VRageMath.Color(color.R, color.G, color.B);
        }

        public static Vector4 HexToVector4(string hex)
        {
            if ((hex.Length > 0) && !hex.StartsWith("#"))
            {
                hex = "#" + hex;
            }
            System.Drawing.Color color = ColorTranslator.FromHtml(hex);
            return (Vector4) (new Vector4((float) color.R, (float) color.G, (float) color.B, 255f) / 255f);
        }

        public static VRageMath.Color HSVtoColor(this Vector3 HSV) => 
            new VRageMath.Color((Vector3) ((((Hue(HSV.X) - 1f) * HSV.Y) + 1f) * HSV.Z));

        private static Vector3 Hue(float H)
        {
            float num = Math.Abs((float) ((H * 6f) - 3f)) - 1f;
            float num2 = 2f - Math.Abs((float) ((H * 6f) - 2f));
            float num3 = 2f - Math.Abs((float) ((H * 6f) - 4f));
            return new Vector3(MathHelper.Clamp(num, 0f, 1f), MathHelper.Clamp(num2, 0f, 1f), MathHelper.Clamp(num3, 0f, 1f));
        }

        public static float HueDistance(this VRageMath.Color color, float hue)
        {
            float num2 = Math.Abs((float) (color.ColorToHSV().X - hue));
            return Math.Min(num2, 1f - num2);
        }

        public static float HueDistance(this VRageMath.Color color, VRageMath.Color otherColor) => 
            color.HueDistance(otherColor.ColorToHSV().X);

        public static uint PackHSVToUint(this Vector3 HSV)
        {
            int num = (int) Math.Round((double) (HSV.X * 360f));
            int num2 = (int) Math.Round((double) ((HSV.Y * 100f) + 100f));
            int num3 = (int) Math.Round((double) ((HSV.Z * 100f) + 100f));
            num2 = num2 << 0x10;
            num3 = num3 << 0x18;
            return (uint) ((num | num2) | num3);
        }

        public static Vector4 PremultiplyColor(this Vector4 c) => 
            new Vector4(c.X * c.W, c.Y * c.W, c.Z * c.W, c.W);

        public static VRageMath.Color Shade(this VRageMath.Color c, float r) => 
            new VRageMath.Color((int) (c.R * r), (int) (c.G * r), (int) (c.B * r), c.A);

        public static Vector3 TemperatureToRGB(float temperature)
        {
            Vector3 vector = new Vector3();
            temperature /= 100f;
            if (temperature <= 66f)
            {
                vector.X = 1f;
                vector.Y = (float) MathHelper.Saturate((double) ((0.390081579 * Math.Log((double) temperature)) - 0.631841444));
            }
            else
            {
                float num = temperature - 60f;
                vector.X = (float) MathHelper.Saturate((double) (1.292936186 * Math.Pow((double) num, -0.1332047592)));
                vector.Y = (float) MathHelper.Saturate((double) (1.129890861 * Math.Pow((double) num, -0.0755148492)));
            }
            if (temperature >= 66f)
            {
                vector.Z = 1f;
                return vector;
            }
            if (temperature <= 19f)
            {
                vector.Z = 0f;
                return vector;
            }
            vector.Z = (float) MathHelper.Saturate((double) ((0.543206789 * Math.Log((double) (temperature - 10f))) - 1.196254089));
            return vector;
        }

        public static VRageMath.Color Tint(this VRageMath.Color c, float r) => 
            new VRageMath.Color((int) (c.R + ((0xff - c.R) * r)), (int) (c.G + ((0xff - c.G) * r)), (int) (c.B + ((0xff - c.B) * r)), c.A);

        public static Vector3 ToGray(this Vector3 c) => 
            new Vector3(((0.2126f * c.X) + (0.7152f * c.Y)) + (0.0722f * c.Z));

        public static Vector4 ToGray(this Vector4 c)
        {
            float x = ((0.2126f * c.X) + (0.7152f * c.Y)) + (0.0722f * c.Z);
            return new Vector4(x, x, x, c.W);
        }

        public static Vector3 ToHsv(this Vector3 rgb)
        {
            Vector4 vector = new Vector4(0f, -0.3333333f, 0.6666667f, -1f);
            Vector4 vector2 = (rgb.Z > rgb.Y) ? new Vector4(rgb.X, rgb.Y, vector.W, vector.Z) : new Vector4(rgb.Y, rgb.Z, vector.X, vector.Y);
            Vector4 vector3 = (vector2.X > rgb.X) ? new Vector4(vector2.X, vector2.Y, vector2.W, rgb.X) : new Vector4(rgb.X, vector2.Y, vector2.Z, vector2.X);
            float num = vector3.X - Math.Min(vector3.W, vector3.Y);
            float num2 = 1E-10f;
            return new Vector3(Math.Abs((double) (vector3.Z + (((double) (vector3.W - vector3.Y)) / ((6.0 * num) + num2)))), (double) (num / (vector3.X + num2)), (double) vector3.X);
        }

        public static Vector3 ToLinearRGB(this Vector3 c) => 
            new Vector3(ToLinearRGBComponent(c.X), ToLinearRGBComponent(c.Y), ToLinearRGBComponent(c.Z));

        public static Vector4 ToLinearRGB(this Vector4 c) => 
            new Vector4(ToLinearRGBComponent(c.X), ToLinearRGBComponent(c.Y), ToLinearRGBComponent(c.Z), c.W);

        public static float ToLinearRGBComponent(float c)
        {
            if (c > 0.04045f)
            {
                return (float) Math.Pow((double) ((c + 0.055f) / 1.055f), 2.4000000953674316);
            }
            return (c / 12.92f);
        }

        public static Vector3 ToSRGB(this Vector3 c) => 
            new Vector3(ToSRGBComponent(c.X), ToSRGBComponent(c.Y), ToSRGBComponent(c.Z));

        public static Vector4 ToSRGB(this Vector4 c) => 
            new Vector4(ToSRGBComponent(c.X), ToSRGBComponent(c.Y), ToSRGBComponent(c.Z), c.W);

        public static float ToSRGBComponent(float c)
        {
            if (c > 0.0031308f)
            {
                return ((((float) Math.Pow((double) c, 0.41666665010982157)) * 1.055f) - 0.055f);
            }
            return (c * 12.92f);
        }

        public static Vector4 UnmultiplyColor(this Vector4 c)
        {
            if (c.W == 0f)
            {
                return Vector4.Zero;
            }
            return new Vector4(c.X / c.W, c.Y / c.W, c.Z / c.W, c.W);
        }

        public static Vector3 UnpackHSVFromUint(uint packed)
        {
            ushort num = (ushort) packed;
            byte num2 = (byte) (packed >> 0x10);
            byte num3 = (byte) (packed >> 0x18);
            return new Vector3(((float) num) / 360f, ((float) (num2 - 100)) / 100f, ((float) (num3 - 100)) / 100f);
        }
    }
}

