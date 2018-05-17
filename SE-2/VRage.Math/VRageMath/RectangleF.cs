namespace VRageMath
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RectangleF : IEquatable<RectangleF>
    {
        public Vector2 Position;
        public Vector2 Size;
        public RectangleF(Vector2 position, Vector2 size)
        {
            this.Position = position;
            this.Size = size;
        }

        public RectangleF(float x, float y, float width, float height)
        {
            this.Position = new Vector2(x, y);
            this.Size = new Vector2(width, height);
        }

        public bool Contains(int x, int y) => 
            (((x >= this.X) && (x <= (this.X + this.Width))) && ((y >= this.Y) && (y <= (this.Y + this.Height))));

        public bool Contains(float x, float y) => 
            (((x >= this.X) && (x <= (this.X + this.Width))) && ((y >= this.Y) && (y <= (this.Y + this.Height))));

        public bool Contains(Vector2 vector2D) => 
            (((vector2D.X >= this.X) && (vector2D.X <= (this.X + this.Width))) && ((vector2D.Y >= this.Y) && (vector2D.Y <= (this.Y + this.Height))));

        public bool Contains(Point point) => 
            (((point.X >= this.X) && (point.X <= (this.X + this.Width))) && ((point.Y >= this.Y) && (point.Y <= (this.Y + this.Height))));

        public float X
        {
            get => 
                this.Position.X;
            set
            {
                this.Position.X = value;
            }
        }
        public float Y
        {
            get => 
                this.Position.Y;
            set
            {
                this.Position.Y = value;
            }
        }
        public float Width
        {
            get => 
                this.Size.X;
            set
            {
                this.Size.X = value;
            }
        }
        public float Height
        {
            get => 
                this.Size.Y;
            set
            {
                this.Size.Y = value;
            }
        }
        public bool Equals(RectangleF other) => 
            ((((other.X == this.X) && (other.Y == this.Y)) && (other.Width == this.Width)) && (other.Height == this.Height));

        public static void Intersect(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
        {
            float num = value1.X + value1.Width;
            float num2 = value2.X + value2.Width;
            float num3 = value1.Y + value1.Height;
            float num4 = value2.Y + value2.Height;
            float x = (value1.X > value2.X) ? value1.X : value2.X;
            float y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            float num7 = (num < num2) ? num : num2;
            float num8 = (num3 < num4) ? num3 : num4;
            if ((num7 > x) && (num8 > y))
            {
                result = new RectangleF(x, y, num7 - x, num8 - y);
            }
            else
            {
                result = new RectangleF(0f, 0f, 0f, 0f);
            }
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }
            if (obj.GetType() != typeof(RectangleF))
            {
                return false;
            }
            return this.Equals((RectangleF) obj);
        }

        public override int GetHashCode()
        {
            int num = (this.X.GetHashCode() * 0x18d) ^ this.Y.GetHashCode();
            num = (num * 0x18d) ^ this.Width.GetHashCode();
            return ((num * 0x18d) ^ this.Height.GetHashCode());
        }

        public static bool operator ==(RectangleF left, RectangleF right) => 
            left.Equals(right);

        public static bool operator !=(RectangleF left, RectangleF right) => 
            !left.Equals(right);

        public override string ToString() => 
            $"(X: {this.X} Y: {this.Y} W: {this.Width} H: {this.Height})";
    }
}

