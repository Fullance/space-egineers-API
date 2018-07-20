namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Utils;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_BlockItem : MyObjectBuilder_PhysicalObject
    {
        [ProtoMember(13)]
        public SerializableDefinitionId BlockDefId;

        public override bool CanStack(MyObjectBuilder_PhysicalObject a)
        {
            MyObjectBuilder_BlockItem item = a as MyObjectBuilder_BlockItem;
            if (item == null)
            {
                return false;
            }
            return (((item.BlockDefId.TypeId == this.BlockDefId.TypeId) && (item.BlockDefId.SubtypeId == this.BlockDefId.SubtypeId)) && (a.Flags == base.Flags));
        }

        public override bool CanStack(MyObjectBuilderType typeId, MyStringHash subtypeId, MyItemFlags flags)
        {
            MyDefinitionId id = new MyDefinitionId(typeId, subtypeId);
            return ((id == this.BlockDefId) && (flags == base.Flags));
        }

        public override MyDefinitionId GetObjectId() => 
            this.BlockDefId;
    }
}

