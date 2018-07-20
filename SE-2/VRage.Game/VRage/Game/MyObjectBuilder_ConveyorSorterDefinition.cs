namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_ConveyorSorterDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        [ProtoMember(0x13)]
        public Vector3 InventorySize;
        [ProtoMember(0x10)]
        public float PowerInput = 0.001f;
        [ProtoMember(13)]
        public string ResourceSinkGroup;
    }
}

