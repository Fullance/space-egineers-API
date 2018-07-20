namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct MyEncounterId
    {
        [ProtoMember(12)]
        public BoundingBoxD BoundingBox;
        [ProtoMember(14)]
        public int Seed;
        [ProtoMember(0x10)]
        public int EncounterId;
        public Vector3D PlacePosition;
        public MyEncounterId(BoundingBoxD box, int seed, int encounterId)
        {
            this.BoundingBox = box;
            this.Seed = seed;
            this.EncounterId = encounterId;
            this.PlacePosition = Vector3D.Zero;
        }

        public static bool operator ==(MyEncounterId x, MyEncounterId y) => 
            (((x.BoundingBox == y.BoundingBox) && (x.Seed == y.Seed)) && (x.EncounterId == y.EncounterId));

        public static bool operator !=(MyEncounterId x, MyEncounterId y) => 
            !(x == y);

        public override bool Equals(object o)
        {
            try
            {
                return (this == ((MyEncounterId) o));
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode() => 
            ((this.BoundingBox.GetHashCode() << 0x10) ^ this.Seed);
    }
}

