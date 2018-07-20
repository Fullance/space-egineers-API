namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Data;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PrefabDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x13)]
        public MyObjectBuilder_CubeGrid CubeGrid;
        [XmlArrayItem("CubeGrid"), ProtoMember(0x17)]
        public MyObjectBuilder_CubeGrid[] CubeGrids;
        [ProtoMember(0x1b), ModdableContentFile("sbc")]
        public string PrefabPath;
        [ProtoMember(14)]
        public bool RespawnShip;

        public bool ShouldSerializeCubeGrid() => 
            false;

        public bool ShouldSerializeRespawnShip() => 
            false;
    }
}

