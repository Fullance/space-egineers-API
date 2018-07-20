namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_DecalGlobalsDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x29)]
        public int DecalQueueSize;
    }
}

