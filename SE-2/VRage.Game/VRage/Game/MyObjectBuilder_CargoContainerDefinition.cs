namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CargoContainerDefinition : MyObjectBuilder_CubeBlockDefinition
    {
        [ProtoMember(13)]
        public Vector3 InventorySize;
    }
}

