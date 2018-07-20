namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_WeaponDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x44), XmlArrayItem("AmmoMagazine")]
        public WeaponAmmoMagazine[] AmmoMagazines;
        [ProtoMember(0x61), DefaultValue(1)]
        public float DamageMultiplier = 1f;
        [ProtoMember(0x37)]
        public float DeviateShotAngle;
        [ProtoMember(0x48), XmlArrayItem("Effect")]
        public WeaponEffect[] Effects;
        [ProtoMember(40)]
        public WeaponAmmoData MissileAmmoData;
        [ProtoMember(0x3d)]
        public int MuzzleFlashLifeSpan;
        [ProtoMember(0x2b)]
        public string NoAmmoSoundName;
        [ProtoMember(0x34)]
        public string PhysicalMaterial = "Metal";
        [ProtoMember(0x25)]
        public WeaponAmmoData ProjectileAmmoData;
        [ProtoMember(0x3a)]
        public float ReleaseTimeAfterFire;
        [ProtoMember(0x2e)]
        public string ReloadSoundName;
        [ProtoMember(0x40)]
        public int ReloadTime = 0x7d0;
        [ProtoMember(0x31)]
        public string SecondarySoundName;
        [ProtoMember(0x4b)]
        public bool UseDefaultMuzzleFlash = true;

        [ProtoContract]
        public class WeaponAmmoData
        {
            [XmlAttribute]
            public int RateOfFire;
            [XmlAttribute]
            public string ShootSoundName;
            [XmlAttribute]
            public int ShotsInBurst;
        }

        [ProtoContract]
        public class WeaponAmmoMagazine
        {
            [XmlAttribute, ProtoMember(0x21)]
            public string Subtype;
            [XmlIgnore]
            public MyObjectBuilderType Type = typeof(MyObjectBuilder_AmmoMagazine);
        }

        [ProtoContract]
        public class WeaponEffect
        {
            [XmlAttribute, ProtoMember(0x51)]
            public string Action = "";
            [ProtoMember(0x54), XmlAttribute]
            public string Dummy = "";
            [XmlAttribute, ProtoMember(0x5d, IsRequired=false)]
            public bool InstantStop = true;
            [XmlAttribute, ProtoMember(90)]
            public bool Loop;
            [ProtoMember(0x57), XmlAttribute]
            public string Particle = "";
        }
    }
}

