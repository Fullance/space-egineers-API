namespace VRage.Game.ObjectBuilders.ComponentSystem
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_DurabilityComponentDefinition : MyObjectBuilder_ComponentDefinitionBase
    {
        [ProtoMember(0x24)]
        public float DamageOverTime;
        [ProtoMember(0x18)]
        public float DefaultHitDamage = 0.01f;
        [ProtoMember(0x1b), XmlArrayItem("Hit")]
        public HitDefinition[] DefinedHits;
        [ProtoMember(30)]
        public string ParticleEffect;
        [ProtoMember(0x21)]
        public string SoundCue;

        [ProtoContract]
        public class HitDefinition
        {
            [XmlAttribute, ProtoMember(0x10), DefaultValue((string) null)]
            public string Action;
            [XmlAttribute, ProtoMember(20)]
            public float Damage = 0.01f;
            [DefaultValue((string) null), XmlAttribute, ProtoMember(0x12)]
            public string Material;
        }
    }
}

