namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyEnvironmentItems(typeof(MyObjectBuilder_DestroyableItem)), XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_DestroyableItems : MyObjectBuilder_EnvironmentItems
    {
    }
}

