﻿namespace VRage.Game.ObjectBuilders.Definitions
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_RepairBlueprintDefinition : MyObjectBuilder_BlueprintDefinition
    {
        [ProtoMember(11)]
        public float RepairAmount;
    }
}
