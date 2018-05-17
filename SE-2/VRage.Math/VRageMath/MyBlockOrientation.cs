namespace VRageMath
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyBlockOrientation
    {
        public static readonly MyBlockOrientation Identity;
        [ProtoMember(15)]
        public Base6Directions.Direction Forward;
        [ProtoMember(0x12)]
        public Base6Directions.Direction Up;
        public Base6Directions.Direction Left =>
            Base6Directions.GetLeft(this.Up, this.Forward);
        public bool IsValid =>
            Base6Directions.IsValidBlockOrientation(this.Forward, this.Up);
        public MyBlockOrientation(Base6Directions.Direction forward, Base6Directions.Direction up)
        {
            this.Forward = forward;
            this.Up = up;
        }

        public MyBlockOrientation(ref Quaternion q)
        {
            this.Forward = Base6Directions.GetForward((Quaternion) q);
            this.Up = Base6Directions.GetUp((Quaternion) q);
        }

        public MyBlockOrientation(ref Matrix m)
        {
            this.Forward = Base6Directions.GetForward(ref m);
            this.Up = Base6Directions.GetUp(ref m);
        }

        public void GetQuaternion(out Quaternion result)
        {
            Matrix matrix;
            this.GetMatrix(out matrix);
            Quaternion.CreateFromRotationMatrix(ref matrix, out result);
        }

        public void GetMatrix(out Matrix result)
        {
            Vector3 vector;
            Vector3 vector2;
            Base6Directions.GetVector(this.Forward, out vector);
            Base6Directions.GetVector(this.Up, out vector2);
            Matrix.CreateWorld(ref Vector3.Zero, ref vector, ref vector2, out result);
        }

        public override int GetHashCode() => 
            ((((byte) this.Forward) << 0x10) | ((int) this.Up));

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                MyBlockOrientation? nullable = obj as MyBlockOrientation?;
                if (nullable.HasValue)
                {
                    return (this == nullable.Value);
                }
            }
            return false;
        }

        public override string ToString() => 
            $"[Forward:{this.Forward}, Up:{this.Up}]";

        public Base6Directions.Direction TransformDirection(Base6Directions.Direction baseDirection)
        {
            Base6Directions.Axis axis = Base6Directions.GetAxis(baseDirection);
            int num = (int) (baseDirection % Base6Directions.Direction.Left);
            switch (axis)
            {
                case Base6Directions.Axis.ForwardBackward:
                    if (num != 1)
                    {
                        return this.Forward;
                    }
                    return Base6Directions.GetFlippedDirection(this.Forward);

                case Base6Directions.Axis.LeftRight:
                    if (num != 1)
                    {
                        return this.Left;
                    }
                    return Base6Directions.GetFlippedDirection(this.Left);
            }
            if (num != 1)
            {
                return this.Up;
            }
            return Base6Directions.GetFlippedDirection(this.Up);
        }

        public Base6Directions.Direction TransformDirectionInverse(Base6Directions.Direction baseDirection)
        {
            Base6Directions.Axis axis = Base6Directions.GetAxis(baseDirection);
            if (axis == Base6Directions.GetAxis(this.Forward))
            {
                if (baseDirection != this.Forward)
                {
                    return Base6Directions.Direction.Backward;
                }
                return Base6Directions.Direction.Forward;
            }
            if (axis == Base6Directions.GetAxis(this.Left))
            {
                if (baseDirection != this.Left)
                {
                    return Base6Directions.Direction.Right;
                }
                return Base6Directions.Direction.Left;
            }
            if (baseDirection != this.Up)
            {
                return Base6Directions.Direction.Down;
            }
            return Base6Directions.Direction.Up;
        }

        public static bool operator ==(MyBlockOrientation orientation1, MyBlockOrientation orientation2) => 
            ((orientation1.Forward == orientation2.Forward) && (orientation1.Up == orientation2.Up));

        public static bool operator !=(MyBlockOrientation orientation1, MyBlockOrientation orientation2)
        {
            if (orientation1.Forward == orientation2.Forward)
            {
                return (orientation1.Up != orientation2.Up);
            }
            return true;
        }

        static MyBlockOrientation()
        {
            Identity = new MyBlockOrientation(Base6Directions.Direction.Forward, Base6Directions.Direction.Up);
        }
    }
}

