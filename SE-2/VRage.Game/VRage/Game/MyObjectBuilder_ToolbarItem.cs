namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ModAPI;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public abstract class MyObjectBuilder_ToolbarItem : MyObjectBuilder_Base
    {
        protected MyObjectBuilder_ToolbarItem()
        {
        }

        public virtual void Remap(IMyRemapHelper remapHelper)
        {
        }
    }
}

