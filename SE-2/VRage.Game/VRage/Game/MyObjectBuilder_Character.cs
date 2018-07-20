namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Character : MyObjectBuilder_EntityBase
    {
        [ProtoMember(0xb9), DefaultValue(false)]
        public bool AIMode;
        [ProtoMember(0xae)]
        public float AutoenableJetpackDelay;
        [ProtoMember(0x99)]
        public MyObjectBuilder_Battery Battery;
        [DefaultValue((float) 1f), ProtoMember(0xa2)]
        public float CharacterGeneralDamageModifier = 1f;
        [ProtoMember(0x8d)]
        public string CharacterModel;
        public static Dictionary<string, SerializableVector3> CharacterModels;
        [ProtoMember(0xbc)]
        public SerializableVector3 ColorMaskHSV;
        [DefaultValue(true), ProtoMember(0x9f)]
        public bool DampenersEnabled = true;
        [ProtoMember(0xc2)]
        public string DisplayName;
        [ProtoMember(200)]
        public bool EnableBroadcasting = true;
        [ProtoMember(0xd9), Nullable]
        public List<string> EnabledComponents = new List<string>();
        [ProtoMember(0xce)]
        public float EnvironmentOxygenLevel = 1f;
        [ProtoMember(0x94), DynamicObjectBuilder(false), Nullable, XmlElement("HandWeapon", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_EntityBase>))]
        public MyObjectBuilder_EntityBase HandWeapon;
        [ProtoMember(0xa8)]
        public SerializableVector2 HeadAngle;
        [NoSerialize, ProtoMember(180)]
        public float? Health;
        [DefaultValue((string) null), ProtoMember(0x90), Serialize(MyObjectFlags.DefaultZero)]
        public MyObjectBuilder_Inventory Inventory;
        [ProtoMember(0xc5)]
        public bool IsInFirstPersonView = true;
        [ProtoMember(0xe8, IsRequired=false)]
        public bool IsPersistenceCharacter;
        [ProtoMember(0xb1)]
        public bool JetpackEnabled;
        [ProtoMember(0x9c)]
        public bool LightEnabled;
        [ProtoMember(0xab)]
        public SerializableVector3 LinearVelocity;
        [ProtoMember(0xbf)]
        public float LootingCounter;
        [ProtoMember(0xd5)]
        public MyCharacterMovementEnum MovementState;
        [ProtoMember(0xe2)]
        public bool NeedsOxygenFromSuit;
        [ProtoMember(0xe5, IsRequired=false)]
        public long? OwningPlayerIdentityId = null;
        [ProtoMember(0xcb)]
        public float OxygenLevel = 1f;
        [ProtoMember(0xdf)]
        public int PlayerSerialId;
        [ProtoMember(0xdd)]
        public ulong PlayerSteamId;
        [ProtoMember(0xd1), Nullable]
        public List<StoredGas> StoredGases = new List<StoredGas>();
        [ProtoMember(0xa5)]
        public long? UsingLadder;

        static MyObjectBuilder_Character()
        {
            Dictionary<string, SerializableVector3> dictionary = new Dictionary<string, SerializableVector3> {
                { 
                    "Soldier",
                    new SerializableVector3(0f, 0f, 0.05f)
                },
                { 
                    "Astronaut",
                    new SerializableVector3(0f, -1f, 0f)
                },
                { 
                    "Astronaut_Black",
                    new SerializableVector3(0f, -0.96f, -0.5f)
                },
                { 
                    "Astronaut_Blue",
                    new SerializableVector3(0.575f, 0.15f, 0.2f)
                },
                { 
                    "Astronaut_Green",
                    new SerializableVector3(0.333f, -0.33f, -0.05f)
                },
                { 
                    "Astronaut_Red",
                    new SerializableVector3(0f, 0f, 0.05f)
                },
                { 
                    "Astronaut_White",
                    new SerializableVector3(0f, -0.8f, 0.6f)
                },
                { 
                    "Astronaut_Yellow",
                    new SerializableVector3(0.122f, 0.05f, 0.46f)
                },
                { 
                    "Engineer_suit_no_helmet",
                    new SerializableVector3(-100f, -100f, -100f)
                }
            };
            CharacterModels = dictionary;
        }

        public bool ShouldSerializeHealth() => 
            false;

        public bool ShouldSerializeMovementState() => 
            (this.MovementState != MyCharacterMovementEnum.Standing);

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct StoredGas
        {
            [ProtoMember(0x7a)]
            public SerializableDefinitionId Id;
            [ProtoMember(0x7d)]
            public float FillLevel;
        }
    }
}

