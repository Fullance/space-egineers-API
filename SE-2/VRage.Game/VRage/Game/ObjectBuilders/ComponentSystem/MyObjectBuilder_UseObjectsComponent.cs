namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_UseObjectsComponent : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(13)]
        public uint CustomDetectorsCount;
        [DefaultValue((string) null), ProtoMember(0x13)]
        public Matrix[] CustomDetectorsMatrices;
        [DefaultValue((string) null), ProtoMember(0x10)]
        public string[] CustomDetectorsNames;
    }
}

