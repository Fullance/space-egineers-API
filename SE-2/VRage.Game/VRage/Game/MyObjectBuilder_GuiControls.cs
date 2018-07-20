namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null), ProtoContract]
    public class MyObjectBuilder_GuiControls : MyObjectBuilder_Base
    {
        [ProtoMember(12)]
        public List<MyObjectBuilder_GuiControlBase> Controls;
    }
}

