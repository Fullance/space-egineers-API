namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRageMath;

    [ProtoContract]
    public class MyPlanetSurfaceRule : ICloneable
    {
        [ProtoMember(150)]
        public SerializableRange Height = new SerializableRange(0f, 1f);
        [ProtoMember(0x99)]
        public SymmetricSerializableRange Latitude = new SymmetricSerializableRange(-90f, 90f, true);
        [ProtoMember(0x9c)]
        public SerializableRange Longitude = new SerializableRange(-180f, 180f);
        [ProtoMember(0x9f)]
        public SerializableRange Slope = new SerializableRange(0f, 90f);

        public bool Check(float height, float latitude, float longitude, float slope) => 
            (((this.Height.ValueBetween(height) && this.Latitude.ValueBetween(latitude)) && this.Longitude.ValueBetween(longitude)) && this.Slope.ValueBetween(slope));

        public object Clone() => 
            new MyPlanetSurfaceRule { 
                Height = this.Height,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Slope = this.Slope
            };
    }
}

