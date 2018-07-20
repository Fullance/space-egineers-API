namespace VRage.Game
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class MyRagdollBoneSetDefinition : MyBoneSetDefinition
    {
        [ProtoMember(70)]
        public float CollisionRadius;
    }
}

