namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders.ComponentSystem;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_CargoContainer : MyObjectBuilder_TerminalBlock
    {
        [DefaultValue((string) null), ProtoMember(0x11), Serialize(MyObjectFlags.DefaultZero)]
        public string ContainerType;
        [DefaultValue((string) null), Serialize(MyObjectFlags.DefaultZero), ProtoMember(13)]
        public MyObjectBuilder_Inventory Inventory;

        public override void SetupForProjector()
        {
            base.SetupForProjector();
            if (this.Inventory != null)
            {
                this.Inventory.Clear();
            }
            if (base.ComponentContainer != null)
            {
                MyObjectBuilder_ComponentContainer.ComponentData data = base.ComponentContainer.Components.Find(s => s.Component.TypeId == typeof(MyObjectBuilder_Inventory));
                if (data != null)
                {
                    (data.Component as MyObjectBuilder_Inventory).Clear();
                }
            }
        }

        public bool ShouldSerializeContainerType() => 
            (this.ContainerType != null);
    }
}

