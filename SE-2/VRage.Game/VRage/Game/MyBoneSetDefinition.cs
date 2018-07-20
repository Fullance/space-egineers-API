namespace VRage.Game
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyBoneSetDefinition
    {
        [ProtoMember(0x3f)]
        public string Bones;
        [ProtoMember(60)]
        public string Name;
    }
}

