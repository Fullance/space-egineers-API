namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_DestructionDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x11), DefaultValue((float) 0.75f)]
        public float ConvertedFractureIntegrityRatio = 0.75f;
        [DefaultValue((float) 100f), ProtoMember(13)]
        public float DestructionDamage = 100f;
        [XmlArrayItem("FracturedPiece"), ProtoMember(0x1c)]
        public MyOBFracturedPieceDefinition[] FracturedPieceDefinitions;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct MyOBFracturedPieceDefinition
        {
            public SerializableDefinitionId Id;
            public int Age;
        }
    }
}

