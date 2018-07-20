namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Utils;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_PhysicalObject : MyObjectBuilder_Base
    {
        [ProtoMember(0x15), DefaultValue((string) null)]
        public float? DurabilityHP;
        [ProtoMember(15), DefaultValue(0)]
        public MyItemFlags Flags;

        public MyObjectBuilder_PhysicalObject() : this(MyItemFlags.None)
        {
        }

        public MyObjectBuilder_PhysicalObject(MyItemFlags flags)
        {
            this.DurabilityHP = null;
            this.Flags = flags;
        }

        public virtual bool CanStack(MyObjectBuilder_PhysicalObject a)
        {
            if (a == null)
            {
                return false;
            }
            return this.CanStack(a.TypeId, a.SubtypeId, a.Flags);
        }

        public virtual bool CanStack(MyObjectBuilderType typeId, MyStringHash subtypeId, MyItemFlags flags) => 
            (((flags == this.Flags) && (typeId == base.TypeId)) && (subtypeId == base.SubtypeId));

        public virtual MyDefinitionId GetObjectId() => 
            this.GetId();

        public bool ShouldSerializeDurabilityHP() => 
            this.DurabilityHP.HasValue;
    }
}

