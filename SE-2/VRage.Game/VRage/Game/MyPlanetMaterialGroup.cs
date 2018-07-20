namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [XmlType("MaterialGroup"), ProtoContract]
    public class MyPlanetMaterialGroup : ICloneable
    {
        [ProtoMember(0xc9), XmlElement("Rule")]
        public MyPlanetMaterialPlacementRule[] MaterialRules;
        [XmlAttribute(AttributeName="Name"), ProtoMember(0xc5)]
        public string Name = "Default";
        [XmlAttribute(AttributeName="Value"), ProtoMember(0xc1)]
        public byte Value;

        public object Clone()
        {
            MyPlanetMaterialGroup group = new MyPlanetMaterialGroup {
                Value = this.Value,
                Name = this.Name,
                MaterialRules = new MyPlanetMaterialPlacementRule[this.MaterialRules.Length]
            };
            for (int i = 0; i < this.MaterialRules.Length; i++)
            {
                group.MaterialRules[i] = this.MaterialRules[i].Clone() as MyPlanetMaterialPlacementRule;
            }
            return group;
        }
    }
}

