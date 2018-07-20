namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_TransparentMaterials : MyObjectBuilder_Base
    {
        [ProtoMember(13), XmlArrayItem("TransparentMaterial")]
        public MyObjectBuilder_TransparentMaterial[] Materials;
    }
}

