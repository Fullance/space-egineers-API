namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRageMath;

    [ProtoContract]
    public class MyPlanetMaterialPlacementRule : MyPlanetMaterialDefinition, ICloneable
    {
        [ProtoMember(0x5e)]
        public SerializableRange Height;
        [ProtoMember(0x61)]
        public SymmetricSerializableRange Latitude;
        [ProtoMember(100)]
        public SerializableRange Longitude;
        [ProtoMember(0x67)]
        public SerializableRange Slope;

        public MyPlanetMaterialPlacementRule()
        {
            this.Height = new SerializableRange(0f, 1f);
            this.Latitude = new SymmetricSerializableRange(-90f, 90f, true);
            this.Longitude = new SerializableRange(-180f, 180f);
            this.Slope = new SerializableRange(0f, 90f);
        }

        public MyPlanetMaterialPlacementRule(MyPlanetMaterialPlacementRule copyFrom)
        {
            this.Height = new SerializableRange(0f, 1f);
            this.Latitude = new SymmetricSerializableRange(-90f, 90f, true);
            this.Longitude = new SerializableRange(-180f, 180f);
            this.Slope = new SerializableRange(0f, 90f);
            this.Height = copyFrom.Height;
            this.Latitude = copyFrom.Latitude;
            this.Longitude = copyFrom.Longitude;
            this.Slope = copyFrom.Slope;
            base.Material = copyFrom.Material;
            base.Value = copyFrom.Value;
            base.MaxDepth = copyFrom.MaxDepth;
            base.Layers = copyFrom.Layers;
        }

        public bool Check(float height, float latitude, float slope) => 
            ((this.Height.ValueBetween(height) && this.Latitude.ValueBetween(latitude)) && this.Slope.ValueBetween(slope));

        public object Clone() => 
            new MyPlanetMaterialPlacementRule(this);

        public override bool IsRule =>
            true;
    }
}

