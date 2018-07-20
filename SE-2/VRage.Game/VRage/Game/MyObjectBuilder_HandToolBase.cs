namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_HandToolBase : MyObjectBuilder_EntityBase, IMyObjectBuilder_GunObject<MyObjectBuilder_ToolBase>
    {
        [Serialize(MyObjectFlags.DefaultZero)]
        public MyObjectBuilder_ToolBase DeviceBase;

        public bool ShouldSerializeDeviceBase() => 
            (this.DeviceBase != null);

        MyObjectBuilder_DeviceBase IMyObjectBuilder_GunObject<MyObjectBuilder_ToolBase>.DeviceBase
        {
            get => 
                this.DeviceBase;
            set
            {
                this.DeviceBase = value as MyObjectBuilder_ToolBase;
            }
        }
    }
}

