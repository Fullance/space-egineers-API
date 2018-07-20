namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_ComponentDefinition : MyObjectBuilder_PhysicalItemDefinition
    {
        [ProtoMember(15)]
        public float DeconstructionEfficiency = 1f;
        [ProtoMember(13)]
        public float DropProbability;
        [ProtoMember(11)]
        public int MaxIntegrity;
    }
}

