namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [Obsolete("This is here only for backwards compatibility, the component has renamed from Character to Basic!"), ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CraftingComponentCharacter : MyObjectBuilder_CraftingComponentBase
    {
    }
}

