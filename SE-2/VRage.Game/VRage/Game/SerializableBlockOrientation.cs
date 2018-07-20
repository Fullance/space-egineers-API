namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct SerializableBlockOrientation
    {
        public static readonly SerializableBlockOrientation Identity;
        [ProtoMember(12), XmlAttribute]
        public Base6Directions.Direction Forward;
        [ProtoMember(15), XmlAttribute]
        public Base6Directions.Direction Up;
        public SerializableBlockOrientation(Base6Directions.Direction forward, Base6Directions.Direction up)
        {
            this.Forward = forward;
            this.Up = up;
        }

        public SerializableBlockOrientation(ref Quaternion q)
        {
            this.Forward = Base6Directions.GetForward((Quaternion) q);
            this.Up = Base6Directions.GetUp((Quaternion) q);
        }

        public static implicit operator MyBlockOrientation(SerializableBlockOrientation v)
        {
            if (Base6Directions.IsValidBlockOrientation(v.Forward, v.Up))
            {
                return new MyBlockOrientation(v.Forward, v.Up);
            }
            if (v.Up == Base6Directions.Direction.Forward)
            {
                return new MyBlockOrientation(v.Forward, Base6Directions.Direction.Up);
            }
            return MyBlockOrientation.Identity;
        }

        public static implicit operator SerializableBlockOrientation(MyBlockOrientation v) => 
            new SerializableBlockOrientation(v.Forward, v.Up);

        public static bool operator ==(SerializableBlockOrientation a, SerializableBlockOrientation b) => 
            ((a.Forward == b.Forward) && (a.Up == b.Up));

        public static bool operator !=(SerializableBlockOrientation a, SerializableBlockOrientation b)
        {
            if (a.Forward == b.Forward)
            {
                return (a.Up != b.Up);
            }
            return true;
        }

        static SerializableBlockOrientation()
        {
            Identity = new SerializableBlockOrientation(Base6Directions.Direction.Forward, Base6Directions.Direction.Up);
        }
    }
}

