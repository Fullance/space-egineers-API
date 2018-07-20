namespace VRage.Game.ObjectBuilders.Components
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.ComponentSystem;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_EntityOwnershipComponent : MyObjectBuilder_ComponentBase
    {
        public long OwnerId;
        public MyOwnershipShareModeEnum ShareMode;
    }
}

