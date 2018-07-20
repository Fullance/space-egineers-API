namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_TriggerPositionReached : MyObjectBuilder_Trigger
    {
        [ProtoMember(14)]
        public double Distance2;
        [ProtoMember(12)]
        public Vector3D Pos;
    }
}

