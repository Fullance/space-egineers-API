namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Ore : MyObjectBuilder_PhysicalObject
    {
        [NoSerialize, XmlIgnore]
        private string m_materialName;
        [Nullable, XmlIgnore]
        public MyStringHash? MaterialTypeName;

        public override MyObjectBuilder_Base Clone()
        {
            MyObjectBuilder_Ore ore = MyObjectBuilderSerializer.Clone(this) as MyObjectBuilder_Ore;
            ore.MaterialTypeName = this.MaterialTypeName;
            return ore;
        }

        public string GetMaterialName()
        {
            if (!string.IsNullOrEmpty(this.m_materialName))
            {
                return this.m_materialName;
            }
            if (this.MaterialTypeName.HasValue)
            {
                return this.MaterialTypeName.Value.String;
            }
            return string.Empty;
        }

        public bool HasMaterialName() => 
            (!string.IsNullOrEmpty(this.m_materialName) || (this.MaterialTypeName.HasValue && (this.MaterialTypeName.Value.GetHashCode() != 0)));

        [ProtoMember(20, IsRequired=false), NoSerialize]
        public string MaterialNameString
        {
            get
            {
                if (this.MaterialTypeName.HasValue && (this.MaterialTypeName.Value.GetHashCode() != 0))
                {
                    return this.MaterialTypeName.Value.String;
                }
                return this.m_materialName;
            }
            set
            {
                this.m_materialName = value;
            }
        }
    }
}

