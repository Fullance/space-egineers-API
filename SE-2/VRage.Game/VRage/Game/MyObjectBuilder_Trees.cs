namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyEnvironmentItems(typeof(MyObjectBuilder_Tree))]
    public class MyObjectBuilder_Trees : MyObjectBuilder_EnvironmentItems
    {
    }
}

