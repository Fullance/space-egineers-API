namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_AmmoMagazine : MyObjectBuilder_PhysicalObject
    {
        [ProtoMember(11)]
        public int ProjectilesCount;
    }
}

