namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Library.Utils;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract, MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_Checkpoint : MyObjectBuilder_Base
    {
        public List<PlayerItem> AllPlayers;
        [ProtoMember(0xf3)]
        public SerializableDictionary<PlayerId, List<Vector3>> AllPlayersColors;
        [ProtoMember(240)]
        public SerializableDictionary<PlayerId, MyObjectBuilder_Player> AllPlayersData;
        [ProtoMember(0x70)]
        public int AppVersion;
        [ProtoMember(0x124)]
        public string Briefing;
        [ProtoMember(0x127)]
        public string BriefingVideo;
        [ProtoMember(0x4b), DefaultValue(0)]
        public MyCameraControllerEnum CameraController;
        [ProtoMember(0x4e)]
        public long CameraEntity;
        [ProtoMember(100)]
        public MyObjectBuilder_Toolbar CharacterToolbar;
        [ProtoMember(0xf7)]
        public List<MyObjectBuilder_ChatHistory> ChatHistory;
        [ProtoMember(0xe9)]
        public List<MyObjectBuilder_Client> Clients;
        [ProtoMember(0x162)]
        public SerializableDictionary<PlayerId, MyObjectBuilder_Player> ConnectedPlayers;
        [ProtoMember(0x67)]
        public SerializableDictionary<long, PlayerId> ControlledEntities;
        [ProtoMember(0x51), DefaultValue(-1)]
        public long ControlledObject = -1L;
        public HashSet<ulong> CreativeTools;
        [ProtoMember(0x36)]
        public SerializableVector3I CurrentSector;
        public string CustomLoadingScreenImage;
        public string CustomLoadingScreenText;
        [ProtoMember(0x12d)]
        public string CustomSkybox = "";
        public static DateTime DEFAULT_DATE = new DateTime(0x4bf, 7, 1, 12, 0, 0);
        private static SerializableDefinitionId DEFAULT_SCENARIO = new SerializableDefinitionId(typeof(MyObjectBuilder_ScenarioDefinition), "EmptyWorld");
        [ProtoMember(0x57)]
        public string Description;
        [ProtoMember(0x167)]
        public SerializableDictionary<PlayerId, long> DisconnectedPlayers;
        [ProtoMember(60)]
        public long ElapsedGameTime;
        [ProtoMember(250)]
        public List<MyObjectBuilder_FactionChatHistory> FactionChatHistory;
        [ProtoMember(0x73), DefaultValue((string) null)]
        public MyObjectBuilder_FactionCollection Factions;
        [ProtoMember(270)]
        public SerializableDefinitionId GameDefinition = ((SerializableDefinitionId) MyGameDefinition.Default);
        [ProtoMember(0x100)]
        public SerializableDictionary<long, MyObjectBuilder_Gps> Gps;
        [ProtoMember(230)]
        public List<MyObjectBuilder_Identity> Identities;
        [ProtoMember(0x11a)]
        public DateTime InGameTime = DEFAULT_DATE;
        [ProtoMember(90)]
        public DateTime LastSaveTime;
        [ProtoMember(0x121)]
        public MyObjectBuilder_SessionComponentMission MissionTriggers;
        [ProtoMember(200)]
        public List<ModItem> Mods;
        [ProtoMember(0xfd)]
        public List<long> NonPlayerIdentities;
        [ProtoMember(0x54)]
        public string Password;
        public SerializableDictionary<ulong, MyObjectBuilder_Player> Players;
        [ProtoMember(0xed)]
        public MyEnvironmentHostilityEnum? PreviousEnvironmentHostility = null;
        [ProtoMember(0xcb)]
        public SerializableDictionary<ulong, MyPromoteLevel> PromotedUsers;
        [DefaultValue(9), ProtoMember(0x130)]
        public int RequiresDX = 9;
        [ProtoMember(0xe3)]
        public List<RespawnCooldownItem> RespawnCooldowns;
        [ProtoMember(0xd0)]
        public SerializableDefinitionId Scenario = DEFAULT_SCENARIO;
        public MyObjectBuilder_ScriptManager ScriptManagerData;
        [ProtoMember(0x116)]
        public HashSet<string> SessionComponentDisabled = new HashSet<string>();
        [ProtoMember(0x113)]
        public HashSet<string> SessionComponentEnabled = new HashSet<string>();
        [XmlArrayItem("MyObjectBuilder_SessionComponent", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_SessionComponent>)), ProtoMember(0x10a)]
        public List<MyObjectBuilder_SessionComponent> SessionComponents;
        [ProtoMember(0x3f)]
        public string SessionName;
        [ProtoMember(0x6a), XmlElement("Settings", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_SessionSettings>))]
        public MyObjectBuilder_SessionSettings Settings = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_SessionSettings>();
        [ProtoMember(0x5d)]
        public float SpectatorDistance;
        [ProtoMember(0x45)]
        public bool SpectatorIsLightOn;
        [ProtoMember(0x42)]
        public MyPositionAndOrientation SpectatorPosition = new MyPositionAndOrientation(Matrix.Identity);
        [ProtoMember(310)]
        public List<string> VicinityModelsCache;
        [ProtoMember(0x133)]
        public List<string> VicinityTexturesCache;
        [DefaultValue((string) null), ProtoMember(0x60)]
        public ulong? WorkshopId = null;
        [ProtoMember(0x103)]
        public SerializableBoundingBoxD? WorldBoundaries;

        public bool ShouldSerializeAllPlayers() => 
            false;

        public bool ShouldSerializeAllPlayersColors() => 
            ((this.AllPlayersColors != null) && (this.AllPlayersColors.Dictionary.Count > 0));

        public bool ShouldSerializeAssemblerEfficiencyMultiplier() => 
            false;

        public bool ShouldSerializeAssemblerSpeedMultiplier() => 
            false;

        public bool ShouldSerializeAutoHealing() => 
            false;

        public bool ShouldSerializeAutoSave() => 
            false;

        public bool ShouldSerializeCargoShipsEnabled() => 
            false;

        public bool ShouldSerializeClients() => 
            ((this.Clients != null) && (this.Clients.Count != 0));

        public bool ShouldSerializeConnectedPlayers() => 
            false;

        public bool ShouldSerializeDisconnectedPlayers() => 
            false;

        public bool ShouldSerializeEnableCopyPaste() => 
            false;

        public bool ShouldSerializeGameMode() => 
            false;

        public bool ShouldSerializeGameTime() => 
            false;

        public bool ShouldSerializeInGameTime() => 
            (this.InGameTime != DEFAULT_DATE);

        public bool ShouldSerializeInventorySizeMultiplier() => 
            false;

        public bool ShouldSerializeMaxFloatingObjects() => 
            false;

        public bool ShouldSerializeMaxPlayers() => 
            false;

        public bool ShouldSerializeOnlineMode() => 
            false;

        public bool ShouldSerializeRefinerySpeedMultiplier() => 
            false;

        public bool ShouldSerializeShowPlayerNamesOnHud() => 
            false;

        public bool ShouldSerializeThrusterDamage() => 
            false;

        public bool ShouldSerializeWeaponsEnabled() => 
            false;

        public bool ShouldSerializeWorkshopId() => 
            this.WorkshopId.HasValue;

        public bool ShouldSerializeWorldBoundaries() => 
            this.WorldBoundaries.HasValue;

        public float AssemblerEfficiencyMultiplier
        {
            get => 
                this.Settings.AssemblerEfficiencyMultiplier;
            set
            {
                this.Settings.AssemblerEfficiencyMultiplier = value;
            }
        }

        public float AssemblerSpeedMultiplier
        {
            get => 
                this.Settings.AssemblerSpeedMultiplier;
            set
            {
                this.Settings.AssemblerSpeedMultiplier = value;
            }
        }

        public bool AutoHealing
        {
            get => 
                this.Settings.AutoHealing;
            set
            {
                this.Settings.AutoHealing = value;
            }
        }

        public bool AutoSave
        {
            get => 
                (this.Settings.AutoSaveInMinutes > 0);
            set
            {
                this.Settings.AutoSaveInMinutes = value ? 5 : 0;
            }
        }

        public bool CargoShipsEnabled
        {
            get => 
                this.Settings.CargoShipsEnabled;
            set
            {
                this.Settings.CargoShipsEnabled = value;
            }
        }

        public bool EnableCopyPaste
        {
            get => 
                this.Settings.EnableCopyPaste;
            set
            {
                this.Settings.EnableCopyPaste = value;
            }
        }

        public MyGameModeEnum GameMode
        {
            get => 
                this.Settings.GameMode;
            set
            {
                this.Settings.GameMode = value;
            }
        }

        public DateTime GameTime
        {
            get => 
                (new DateTime(0x821, 1, 1, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(this.ElapsedGameTime));
            set
            {
                TimeSpan span = (TimeSpan) (value - new DateTime(0x821, 1, 1));
                this.ElapsedGameTime = span.Ticks;
            }
        }

        public float InventorySizeMultiplier
        {
            get => 
                this.Settings.InventorySizeMultiplier;
            set
            {
                this.Settings.InventorySizeMultiplier = value;
            }
        }

        public short MaxFloatingObjects
        {
            get => 
                this.Settings.MaxFloatingObjects;
            set
            {
                this.Settings.MaxFloatingObjects = value;
            }
        }

        public short MaxPlayers
        {
            get => 
                this.Settings.MaxPlayers;
            set
            {
                this.Settings.MaxPlayers = value;
            }
        }

        public MyOnlineModeEnum OnlineMode
        {
            get => 
                this.Settings.OnlineMode;
            set
            {
                this.Settings.OnlineMode = value;
            }
        }

        public float RefinerySpeedMultiplier
        {
            get => 
                this.Settings.RefinerySpeedMultiplier;
            set
            {
                this.Settings.RefinerySpeedMultiplier = value;
            }
        }

        public bool ShowPlayerNamesOnHud
        {
            get => 
                this.Settings.ShowPlayerNamesOnHud;
            set
            {
                this.Settings.ShowPlayerNamesOnHud = value;
            }
        }

        public bool ThrusterDamage
        {
            get => 
                this.Settings.ThrusterDamage;
            set
            {
                this.Settings.ThrusterDamage = value;
            }
        }

        public bool WeaponsEnabled
        {
            get => 
                this.Settings.WeaponsEnabled;
            set
            {
                this.Settings.WeaponsEnabled = value;
            }
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct ModItem
        {
            [ProtoMember(0x91)]
            public string Name;
            [DefaultValue(0), ProtoMember(0x95)]
            public ulong PublishedFileId;
            [DefaultValue(false), ProtoMember(0x99)]
            public bool IsDependency;
            [ProtoMember(0x9d), XmlAttribute]
            public string FriendlyName;
            public bool ShouldSerializeName() => 
                (this.Name != null);

            public bool ShouldSerializePublishedFileId() => 
                (this.PublishedFileId != 0L);

            public bool ShouldSerializeIsDependency() => 
                true;

            public bool ShouldSerializeFriendlyName() => 
                !string.IsNullOrEmpty(this.FriendlyName);

            public ModItem(ulong publishedFileId)
            {
                this.Name = publishedFileId.ToString() + ".sbm";
                this.PublishedFileId = publishedFileId;
                this.FriendlyName = string.Empty;
                this.IsDependency = false;
            }

            public ModItem(ulong publishedFileId, bool isDependency)
            {
                this.Name = publishedFileId.ToString() + ".sbm";
                this.PublishedFileId = publishedFileId;
                this.FriendlyName = string.Empty;
                this.IsDependency = isDependency;
            }

            public ModItem(string name, ulong publishedFileId)
            {
                this.Name = name ?? (publishedFileId.ToString() + ".sbm");
                this.PublishedFileId = publishedFileId;
                this.FriendlyName = string.Empty;
                this.IsDependency = false;
            }

            public ModItem(string name, ulong publishedFileId, string friendlyName)
            {
                this.Name = name ?? (publishedFileId.ToString() + ".sbm");
                this.PublishedFileId = publishedFileId;
                this.FriendlyName = friendlyName;
                this.IsDependency = false;
            }

            public override string ToString() => 
                $"{this.FriendlyName} ({this.PublishedFileId})";
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PlayerId
        {
            public ulong ClientId;
            public int SerialId;
            public PlayerId(ulong steamId)
            {
                this.ClientId = steamId;
                this.SerialId = 0;
            }

            public void AssignFrom(ulong steamId)
            {
                this.ClientId = steamId;
                this.SerialId = 0;
            }
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct PlayerItem
        {
            [ProtoMember(0x79)]
            public long PlayerId;
            [ProtoMember(0x7b)]
            public bool IsDead;
            [ProtoMember(0x7d)]
            public string Name;
            [ProtoMember(0x7f)]
            public ulong SteamId;
            [ProtoMember(0x81)]
            public string Model;
            public PlayerItem(long id, string name, bool isDead, ulong steamId, string model)
            {
                this.PlayerId = id;
                this.IsDead = isDead;
                this.Name = name;
                this.SteamId = steamId;
                this.Model = model;
            }
        }

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct RespawnCooldownItem
        {
            [ProtoMember(0xd6)]
            public ulong PlayerSteamId;
            [ProtoMember(0xd9)]
            public int PlayerSerialId;
            [ProtoMember(220)]
            public string RespawnShipId;
            [ProtoMember(0xdf)]
            public int Cooldown;
        }
    }
}

