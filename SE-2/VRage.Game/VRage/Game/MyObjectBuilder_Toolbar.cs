namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ModAPI;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Toolbar : MyObjectBuilder_Base
    {
        [DefaultValue((string) null), NoSerialize, ProtoMember(0x3d)]
        public List<Vector3> ColorMaskHSVList;
        [Serialize(MyObjectFlags.DefaultZero), ProtoMember(0x33), DefaultValue((string) null)]
        public int? SelectedSlot = null;
        [ProtoMember(0x37), Serialize(MyObjectFlags.DefaultZero)]
        public List<Slot> Slots = new List<Slot>();
        [ProtoMember(0x30)]
        public MyToolbarType ToolbarType;

        public void Remap(IMyRemapHelper remapHelper)
        {
            if (this.Slots != null)
            {
                foreach (Slot slot in this.Slots)
                {
                    slot.Data.Remap(remapHelper);
                }
            }
        }

        public bool ShouldSerializeColorMaskHSVList() => 
            false;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct Slot
        {
            [ProtoMember(0x24)]
            public int Index;
            [ProtoMember(0x27)]
            public string Item;
            [DynamicObjectBuilder(false), ProtoMember(0x2a), XmlElement(Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_ToolbarItem>))]
            public MyObjectBuilder_ToolbarItem Data;
        }
    }
}

