namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;

    [ProtoContract]
    public class MyPlanetMaterialDefinition : ICloneable
    {
        [ProtoMember(0x2d), XmlArrayItem("Layer")]
        public MyPlanetMaterialLayer[] Layers;
        [XmlAttribute(AttributeName="Material"), ProtoMember(0x21)]
        public string Material;
        [XmlAttribute(AttributeName="MaxDepth"), ProtoMember(0x29)]
        public float MaxDepth = 1f;
        [XmlAttribute(AttributeName="Value"), ProtoMember(0x25)]
        public byte Value;

        public object Clone()
        {
            MyPlanetMaterialDefinition definition = new MyPlanetMaterialDefinition {
                Material = this.Material,
                Value = this.Value,
                MaxDepth = this.MaxDepth
            };
            if (this.Layers != null)
            {
                definition.Layers = this.Layers.Clone() as MyPlanetMaterialLayer[];
                return definition;
            }
            definition.Layers = null;
            return definition;
        }

        public string FirstOrDefault
        {
            get
            {
                if (this.Material != null)
                {
                    return this.Material;
                }
                if (this.HasLayers)
                {
                    return this.Layers[0].Material;
                }
                return null;
            }
        }

        public bool HasLayers =>
            ((this.Layers != null) && (this.Layers.Length > 0));

        public virtual bool IsRule =>
            false;
    }
}

