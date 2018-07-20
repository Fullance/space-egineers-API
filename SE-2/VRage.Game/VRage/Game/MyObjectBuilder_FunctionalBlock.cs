namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_FunctionalBlock : MyObjectBuilder_TerminalBlock
    {
        [ProtoMember(11)]
        public bool Enabled = true;
    }
}

