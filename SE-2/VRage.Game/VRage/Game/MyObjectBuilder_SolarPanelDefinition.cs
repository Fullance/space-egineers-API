namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_SolarPanelDefinition : MyObjectBuilder_PowerProducerDefinition
    {
        [ProtoMember(0x13)]
        public float PanelOffset = 1f;
        [ProtoMember(13)]
        public Vector3 PanelOrientation = new Vector3(0f, 0f, 0f);
        [ProtoMember(0x10)]
        public bool TwoSidedPanel = true;
    }
}

