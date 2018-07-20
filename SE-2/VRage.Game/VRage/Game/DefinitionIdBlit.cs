namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Runtime.InteropServices;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRage.Utils;

    [StructLayout(LayoutKind.Sequential), ProtoContract]
    public struct DefinitionIdBlit
    {
        [ProtoMember(0xcf), NoSerialize]
        public MyRuntimeObjectBuilderId TypeId;
        [ProtoMember(0xda)]
        public MyStringHash SubtypeId;
        [Serialize]
        private ushort m_typeIdSerialized
        {
            get => 
                this.TypeId.Value;
            set
            {
                this.TypeId = new MyRuntimeObjectBuilderId(value);
            }
        }
        public DefinitionIdBlit(MyObjectBuilderType type, MyStringHash subtypeId)
        {
            this.TypeId = (MyRuntimeObjectBuilderId) type;
            this.SubtypeId = subtypeId;
        }

        public DefinitionIdBlit(MyRuntimeObjectBuilderId typeId, MyStringHash subtypeId)
        {
            this.TypeId = typeId;
            this.SubtypeId = subtypeId;
        }

        public bool IsValid =>
            (this.TypeId.Value != 0);
        public static implicit operator MyDefinitionId(DefinitionIdBlit id) => 
            new MyDefinitionId((MyObjectBuilderType) id.TypeId, id.SubtypeId);

        public static implicit operator DefinitionIdBlit(MyDefinitionId id) => 
            new DefinitionIdBlit(id.TypeId, id.SubtypeId);

        public override unsafe string ToString()
        {
            MyDefinitionId id = *((MyDefinitionId*) this);
            return id.ToString();
        }
    }
}

