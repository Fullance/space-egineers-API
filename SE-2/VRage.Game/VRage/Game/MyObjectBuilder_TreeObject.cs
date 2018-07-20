namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_TreeObject : MyObjectBuilder_PhysicalObject
    {
        public override bool CanStack(MyObjectBuilder_PhysicalObject a) => 
            false;
    }
}

