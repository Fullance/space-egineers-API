namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlType("AddShipPrefab")]
    public class MyObjectBuilder_WorldGeneratorOperation_AddShipPrefab : MyObjectBuilder_WorldGeneratorOperation
    {
        [ProtoMember(0xe3), XmlAttribute]
        public string PrefabFile;
        [ProtoMember(0xec), XmlAttribute]
        public float RandomRadius;
        [ProtoMember(230)]
        public MyPositionAndOrientation Transform;
        [ProtoMember(0xe9)]
        public bool UseFirstGridOrigin;

        public bool ShouldSerializeRandomRadius() => 
            !(this.RandomRadius == 0f);
    }
}

