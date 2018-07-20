﻿namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CraftingComponentBase : MyObjectBuilder_ComponentBase
    {
        [ProtoMember(11)]
        public long LockedByEntityId = -1L;
    }
}

