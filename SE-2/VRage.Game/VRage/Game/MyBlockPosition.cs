namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRageMath;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyBlockPosition
    {
        [ProtoMember(10)]
        public string Name;
        [ProtoMember(13)]
        public Vector2I Position;
    }
}

