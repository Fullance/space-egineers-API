namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI.Ingame.Utilities;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyWaypointInfo : IEquatable<MyWaypointInfo>
    {
        public static MyWaypointInfo Empty;
        public readonly string Name;
        public readonly double X;
        public readonly double Y;
        public readonly double Z;
        public Vector3D Coords;
        private static bool IsPrecededByWhitespace(ref TextPtr ptr)
        {
            TextPtr ptr2 = ptr - 1;
            char c = ptr2.Char;
            if (!ptr2.IsOutOfBounds() && !char.IsWhiteSpace(c))
            {
                return !char.IsLetterOrDigit(c);
            }
            return true;
        }

        public static void FindAll(string source, List<MyWaypointInfo> gpsList)
        {
            TextPtr ptr = new TextPtr(source);
            gpsList.Clear();
            while (!ptr.IsOutOfBounds())
            {
                MyWaypointInfo info;
                if (((char.ToUpperInvariant(ptr.Char) == 'G') && IsPrecededByWhitespace(ref ptr)) && TryParse(ref ptr, out info))
                {
                    gpsList.Add(info);
                }
                else
                {
                    ptr = TextPtr.op_Increment(ptr);
                }
            }
        }

        public static bool TryParse(string text, out MyWaypointInfo gps)
        {
            if (text == null)
            {
                gps = Empty;
                return false;
            }
            TextPtr ptr = new TextPtr(text);
            bool flag = TryParse(ref ptr, out gps);
            if (flag && !ptr.IsOutOfBounds())
            {
                gps = Empty;
                return false;
            }
            return flag;
        }

        private static bool TryParse(ref TextPtr ptr, out MyWaypointInfo gps)
        {
            StringSegment segment;
            StringSegment segment2;
            StringSegment segment3;
            StringSegment segment4;
            while (char.IsWhiteSpace(ptr.Char))
            {
                ptr = TextPtr.op_Increment(ptr);
            }
            if (!ptr.StartsWithCaseInsensitive("gps:"))
            {
                gps = Empty;
                return false;
            }
            ptr += 4;
            if (!GrabSegment(ref ptr, out segment))
            {
                gps = Empty;
                return false;
            }
            if (!GrabSegment(ref ptr, out segment2))
            {
                gps = Empty;
                return false;
            }
            if (!GrabSegment(ref ptr, out segment3))
            {
                gps = Empty;
                return false;
            }
            if (GrabSegment(ref ptr, out segment4))
            {
                double num;
                double num2;
                double num3;
                while (char.IsWhiteSpace(ptr.Char))
                {
                    ptr = TextPtr.op_Increment(ptr);
                }
                if (!double.TryParse(segment2.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out num))
                {
                    gps = Empty;
                    return false;
                }
                if (!double.TryParse(segment3.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out num2))
                {
                    gps = Empty;
                    return false;
                }
                if (!double.TryParse(segment4.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out num3))
                {
                    gps = Empty;
                    return false;
                }
                string name = segment.ToString();
                gps = new MyWaypointInfo(name, num, num2, num3);
                return true;
            }
            gps = Empty;
            return false;
        }

        private static bool GrabSegment(ref TextPtr ptr, out StringSegment segment)
        {
            if (ptr.IsOutOfBounds())
            {
                segment = new StringSegment();
                return false;
            }
            TextPtr ptr2 = ptr;
            while (!ptr.IsOutOfBounds() && (ptr.Char != ':'))
            {
                ptr = TextPtr.op_Increment(ptr);
            }
            if (ptr.Char != ':')
            {
                segment = new StringSegment();
                return false;
            }
            segment = new StringSegment(ptr2.Content, ptr2.Index, ptr.Index - ptr2.Index);
            ptr = TextPtr.op_Increment(ptr);
            return true;
        }

        public MyWaypointInfo(string name, double x, double y, double z)
        {
            this.Name = name ?? "";
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Coords = new Vector3D(x, y, z);
        }

        public MyWaypointInfo(string name, Vector3D coords) : this(name, coords.X, coords.Y, coords.Z)
        {
        }

        public bool IsEmpty() => 
            (this.Name == null);

        public override string ToString() => 
            string.Format(CultureInfo.InvariantCulture, "GPS:{0}:{1:R}:{2:R}:{3:R}:", new object[] { this.Name, this.X, this.Y, this.Z });

        public bool Equals(MyWaypointInfo other) => 
            this.Equals(other, 0.0001);

        public bool Equals(MyWaypointInfo other, double epsilon) => 
            (((string.Equals(this.Name, other.Name) && (Math.Abs((double) (this.X - other.X)) < epsilon)) && (Math.Abs((double) (this.Y - other.Y)) < epsilon)) && (Math.Abs((double) (this.Z - other.Z)) < epsilon));

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }
            return ((obj is MyWaypointInfo) && this.Equals((MyWaypointInfo) obj));
        }

        public override int GetHashCode()
        {
            int num = (this.Name != null) ? this.Name.GetHashCode() : 0;
            num = (num * 0x18d) ^ this.X.GetHashCode();
            num = (num * 0x18d) ^ this.Y.GetHashCode();
            return ((num * 0x18d) ^ this.Z.GetHashCode());
        }

        public Vector3D ToVector3D() => 
            new Vector3D(this.X, this.Y, this.Z);

        static MyWaypointInfo()
        {
            Empty = new MyWaypointInfo();
        }
    }
}

