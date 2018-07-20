namespace VRage.Game
{
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct ColorDefinitionHSV
    {
        [XmlAttribute]
        public int H;
        [XmlAttribute]
        public int S;
        [XmlAttribute]
        public int V;
        [XmlAttribute]
        public int Hue
        {
            get => 
                this.H;
            set
            {
                this.H = value;
            }
        }
        [XmlAttribute]
        public int Saturation
        {
            get => 
                this.S;
            set
            {
                this.S = value;
            }
        }
        [XmlAttribute]
        public int Value
        {
            get => 
                this.V;
            set
            {
                this.V = value;
            }
        }
        public bool ShouldSerializeHue() => 
            false;

        public bool ShouldSerializeSaturation() => 
            false;

        public bool ShouldSerializeValue() => 
            false;

        public bool IsValid() => 
            (((((this.H >= 0) && (this.H <= 360)) && ((this.S >= -100) && (this.S <= 100))) && (this.V >= -100)) && (this.V <= 100));

        public static implicit operator Vector3(ColorDefinitionHSV definition)
        {
            definition.H = definition.H % 360;
            if (definition.H < 0)
            {
                definition.H += 360;
            }
            return new Vector3(((float) definition.H) / 360f, MathHelper.Clamp((float) (((float) definition.S) / 100f), (float) -1f, (float) 1f), MathHelper.Clamp((float) (((float) definition.V) / 100f), (float) -1f, (float) 1f));
        }

        public static implicit operator ColorDefinitionHSV(Vector3 vector) => 
            new ColorDefinitionHSV { 
                H = (int) MathHelper.Clamp((float) (vector.Z * 100f), (float) -100f, (float) 100f),
                S = (int) MathHelper.Clamp((float) (vector.Y * 100f), (float) -100f, (float) 100f),
                V = (int) MathHelper.Clamp((float) (vector.Z * 360f), (float) 0f, (float) 360f)
            };

        public override string ToString() => 
            $"H:{this.H} S:{this.S} V:{this.V}";
    }
}

