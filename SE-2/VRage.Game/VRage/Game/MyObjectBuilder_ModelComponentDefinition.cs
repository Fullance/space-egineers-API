namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ModelComponentDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [ProtoMember(0x11)]
        public float Mass;
        [ModdableContentFile("mwm"), ProtoMember(0x17)]
        public string Model = @"Models\Components\Sphere.mwm";
        [ProtoMember(14)]
        public Vector3 Size;
        [DefaultValue((string) null), ProtoMember(20)]
        public float? Volume = null;
    }
}

