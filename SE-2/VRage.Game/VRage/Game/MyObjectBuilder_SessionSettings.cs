namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.Library.Utils;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRage.Utils;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract(SkipConstructor=true), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_SessionSettings : MyObjectBuilder_Base
    {
        [GameRelation(VRage.Game.Game.SpaceEngineers), Category("Others"), Display(Name="Adaptive Simulation Quality", Description="Enables adaptive simulation quality system. This system is useful if you have a lot of voxel deformations in the world and low simulation speed."), ProtoMember(0x22d, IsRequired=false)]
        public bool AdaptiveSimulationQuality;
        [Category("Multipliers"), ProtoMember(0x2b), Display(Name="Assembler Efficiency", Description="The multiplier for assembler efficiency."), GameRelation(VRage.Game.Game.SpaceEngineers), Range(1, 100)]
        public float AssemblerEfficiencyMultiplier = 3f;
        [ProtoMember(0x24), Range(1, 100), Display(Name="Assembler Speed", Description="The multiplier for assembler speed."), Category("Multipliers"), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public float AssemblerSpeedMultiplier = 3f;
        [GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x80), Display(Name="Auto Healing", Description="Enables auto healing of the character."), Category("Players")]
        public bool AutoHealing = true;
        [Range((double) 0.0, (double) 4294967295), ProtoMember(0xf2), Display(Name="Autosave Interval [mins]", Description="Defines autosave interval."), GameRelation(VRage.Game.Game.Shared), Category("Others")]
        public uint AutoSaveInMinutes = 5;
        [ProtoMember(600, IsRequired=false), Category("Trash Removal"), Display(Name="Block Count Threshold", Description="Defines block count threshold for trash removal system."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public int BlockCountThreshold;
        [ProtoMember(0x6d), Category("Block Limits"), Display(Name="Block Limits Mode", Description="Defines block limits mode."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public MyBlockLimitsEnabledEnum BlockLimitsEnabled;
        [ProtoMember(0x1eb), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Block Limits"), Display(Name="Block Type World Limits")]
        public SerializableDictionary<string, short> BlockTypeLimits;
        [ProtoMember(0x195), Display(Name=""), Browsable(false), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool CanJoinRunning;
        [GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0xa6), Display(Name="Enable Cargo Ships", Description="Enables spawning of cargo ships."), Category("NPCs")]
        public bool CargoShipsEnabled = true;
        [XmlIgnore]
        public const uint DEFAULT_AUTOSAVE_IN_MINUTES = 5;
        [ProtoMember(0x128), Category("Environment"), Display(Name="Enable Destructible Blocks", Description="Enables destruction feature for the blocks."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool DestructibleBlocks = true;
        [GameRelation(VRage.Game.Game.SpaceEngineers), Category("Players"), ProtoMember(0x15f), Display(Name="Enable 3rd Person Camera", Description="Enables 3rd person camera.")]
        public bool Enable3rdPersonView = true;
        [ProtoMember(0x10b), Category("Others"), Display(Name="Enable Drop Containers", Description="Enables drop containers (unknown signals)."), GameRelation(VRage.Game.Game.Shared)]
        public bool EnableContainerDrops = true;
        [Display(Name="Enable Convert to Station", Description="Enables possibility of converting grid to station."), ProtoMember(0x171), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Others")]
        public bool EnableConvertToStation = true;
        [Display(Name="Enable Copy & Paste", Description="Enables copy and paste feature."), Category("Players"), ProtoMember(0x86), GameRelation(VRage.Game.Game.Shared)]
        public bool EnableCopyPaste = true;
        [GameRelation(VRage.Game.Game.SpaceEngineers), Display(Name="Enable Drones", Description="Enables spawning of drones in the world."), ProtoMember(0x1c6), Category("NPCs")]
        public bool EnableDrones = true;
        [Display(Name="Enable Encounters", Description="Enables random encounters in the world."), ProtoMember(0x165), GameRelation(VRage.Game.Game.SpaceEngineers), Category("NPCs")]
        public bool EnableEncounters = true;
        [Category("Environment"), Display(Name="Enable Flora", Description=""), GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x16b)]
        public bool EnableFlora = true;
        [Category("Others"), ProtoMember(0x12e), Display(Name="Enable Ingame Scripts", Description="Enables in game scripts."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool EnableIngameScripts = true;
        [Display(Name="Enable Jetpack", Description="Enables jetpack."), ProtoMember(0x1a8), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Players")]
        public bool EnableJetpack = true;
        [Display(Name="Enable Oxygen", Description="Enables oxygen in the world."), Category("Environment"), GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x153)]
        public bool EnableOxygen;
        [ProtoMember(0x159), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment"), Display(Name="Enable Airtightness", Description="Enables airtightness in the world.")]
        public bool EnableOxygenPressurization;
        [GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x73), Display(Name="Enable Remote Grid Removal", Description="Enables possibility to remove grid remotely from the world by an author."), Category("Others")]
        public bool EnableRemoteBlockRemoval = true;
        [Display(Name="Enable Respawn Screen in the Game", Description="Enables respawn screen."), ProtoMember(0xff), Category("Players"), GameRelation(VRage.Game.Game.Shared)]
        public bool EnableRespawnScreen = true;
        [GameRelation(VRage.Game.Game.Shared), Display(Name="Enable Respawn Ships", Description="Enables respawn ships."), Category("Others"), ProtoMember(0x183)]
        public bool EnableRespawnShips = true;
        [ProtoMember(0xf9), Category("Others"), Display(Name="Enable Saving from Menu", Description="Enables saving from the menu."), GameRelation(VRage.Game.Game.Shared)]
        public bool EnableSaving = true;
        [ProtoMember(0x200), Display(Name="Enable Scripter Role", Description="Enables scripter role for administration."), Category("Others"), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool EnableScripterRole;
        [Category("Others"), ProtoMember(0xac), Display(Name="Enable Spectator Camera", Description="Enables spectator camera."), GameRelation(VRage.Game.Game.Shared)]
        public bool EnableSpectator;
        [Display(Name="Enable Spiders", Description="Enables spawning of spiders in the world."), GameRelation(VRage.Game.Game.SpaceEngineers), Category("NPCs"), ProtoMember(0x1d2)]
        public bool EnableSpiders;
        [GameRelation(VRage.Game.Game.MedievalEngineers), Display(Name="Enable Structural Simulation"), ProtoMember(480)]
        public bool EnableStructuralSimulation;
        [GameRelation(VRage.Game.Game.SpaceEngineers), Display(Name="Enable Sub-Grid Damage", Description="Enables sub-grid damage."), Category("Environment"), ProtoMember(0x21a, IsRequired=false)]
        public bool EnableSubgridDamage;
        [Category("Environment"), Display(Name="Enable Sun Rotation", Description="Enables sun rotation."), ProtoMember(0x17d), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool EnableSunRotation = true;
        [Display(Name="Enable Tool Shake", Description="Enables tool shake feature."), Category("Players"), ProtoMember(0x144), DefaultValue(false), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool EnableToolShake;
        [GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x214, IsRequired=false), Category("Environment"), Display(Name="Enable Turrets Friendly Fire", Description="Enables friendly fire for turrets.")]
        public bool EnableTurretsFriendlyFire;
        [Display(Name="Enable Voxel Destruction", Description="Enables voxel destructions."), Category("Environment"), GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x1ba)]
        public bool EnableVoxelDestruction = true;
        [GameRelation(VRage.Game.Game.SpaceEngineers), Category("Others"), ProtoMember(0x233, IsRequired=false), Display(Name="Enable voxel hand", Description="Enables voxel hand.")]
        public bool EnableVoxelHand;
        [Category("NPCs"), Display(Name="Enable Wolves", Description="Enables spawning of wolves in the world."), GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(460)]
        public bool EnableWolfs = true;
        [GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment"), ProtoMember(0x79), Display(Name="Environment Hostility", Description="Defines hostility of the environment.")]
        public MyEnvironmentHostilityEnum EnvironmentHostility = MyEnvironmentHostilityEnum.NORMAL;
        [Category("Others"), GameRelation(VRage.Game.Game.SpaceEngineers), Display(Name="Experimental Mode", Description="Enables experimental mode."), ProtoMember(0x227, IsRequired=false)]
        public bool ExperimentalMode;
        [Range(0, 40), Category("Environment"), ProtoMember(0x13d), Display(Name="Flora Density", Description=""), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public int FloraDensity = 20;
        [Browsable(false), GameRelation(VRage.Game.Game.Shared), ProtoMember(0x1d8), Display(Name="Flora Density Multiplier", Description=""), Category("Environment"), Range(0, 100)]
        public float FloraDensityMultiplier = 1f;
        [Display(Name="Game Mode", Description="The type of the game mode."), ProtoMember(0x17), GameRelation(VRage.Game.Game.Shared), Category("Others")]
        public MyGameModeEnum GameMode;
        [ProtoMember(0xd1), Display(Name="Grinder Speed", Description="The multiplier for grinder speed."), Category("Multipliers"), GameRelation(VRage.Game.Game.SpaceEngineers), Range(0, 100)]
        public float GrinderSpeedMultiplier = 2f;
        [Range(0, 100), ProtoMember(0xe5), Display(Name="Hacking Speed", Description="The multiplier for hacking speed."), Category("Multipliers"), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public float HackSpeedMultiplier = 0.33f;
        [ProtoMember(0x105), Category("Others"), Display(Name="Enable Infinite Ammunition in Survival", Description="Enables infinite ammunition in survival game mode."), GameRelation(VRage.Game.Game.Shared)]
        public bool InfiniteAmmo;
        [Range(1, 100), ProtoMember(0x1d), Display(Name="Inventory Size", Description="The multiplier for inventory size."), Category("Multipliers"), GameRelation(VRage.Game.Game.Shared)]
        public float InventorySizeMultiplier = 10f;
        private ExperimentalReason m_experimentalReason;
        private bool m_experimentalReasonInited;
        [GameRelation(VRage.Game.Game.MedievalEngineers), Range(0, 0x7fffffff), ProtoMember(0x1e5), Display(Name="Max Active Fracture Pieces")]
        public int MaxActiveFracturePieces = 50;
        [Category("Others"), ProtoMember(0x4a), Display(Name="Max Backup Saves", Description="The maximum number of backup saves."), GameRelation(VRage.Game.Game.SpaceEngineers), Range(0, 0x3e8)]
        public short MaxBackupSaves = 5;
        [Display(Name="Max Blocks per Player", Description="The maximum number of blocks per player."), ProtoMember(0x58), Category("Block Limits"), GameRelation(VRage.Game.Game.SpaceEngineers), Range(0, 0x7fffffff)]
        public int MaxBlocksPerPlayer = 0x186a0;
        [ProtoMember(0x1c0), Browsable(false), Display(Name=""), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public int MaxDrones = 5;
        [GameRelation(VRage.Game.Game.Shared), Category("Others"), Range(0, 100), Display(Name="Max Drop Container Respawn Time", Description="Defines maximum respawn time for drop containers."), ProtoMember(0x20d, IsRequired=false)]
        public int MaxDropContainerRespawnTime;
        [ProtoMember(0x66), Category("Block Limits"), Display(Name="Max Factions Count", Description="The maximum number of existing factions in the world."), GameRelation(VRage.Game.Game.SpaceEngineers), Range(0, 0x7fffffff)]
        public int MaxFactionsCount;
        [Category("Environment"), ProtoMember(0x43), Display(Name="Max Floating Objects", Description="The maximum number of existing floating objects."), GameRelation(VRage.Game.Game.SpaceEngineers), Range(2, 0x400)]
        public short MaxFloatingObjects = 0x38;
        [Category("Block Limits"), ProtoMember(0x51), Display(Name="Max Grid Blocks", Description="The maximum number of blocks in one grid."), GameRelation(VRage.Game.Game.SpaceEngineers), Range(0, 0x7fffffff)]
        public int MaxGridSize = 0xc350;
        [Display(Name="Max Players", Description="The maximum number of connected players."), Range(2, 0x40), ProtoMember(60), GameRelation(VRage.Game.Game.Shared), Category("Players")]
        public short MaxPlayers = 4;
        [Category("Others"), Display(Name="Min Drop Container Respawn Time", Description="Defines minimum respawn time for drop containers."), GameRelation(VRage.Game.Game.Shared), Range(0, 100), ProtoMember(0x206, IsRequired=false)]
        public int MinDropContainerRespawnTime;
        [ProtoMember(0x39)]
        public MyOnlineModeEnum OnlineMode;
        [GameRelation(VRage.Game.Game.SpaceEngineers), Category("Trash Removal"), Display(Name="Optimal Grid Count", Description="By setting this, server will keep number of grids around this value. \n !WARNING! It ignores Powered and Fixed flags, Block Count and lowers Distance from player.\n Set to 0 to disable."), ProtoMember(0x264, IsRequired=false)]
        public int OptimalGridCount;
        [Display(Name="Permanent Death", Description="Enables permanent death."), ProtoMember(0xec), Category("Players"), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool? PermanentDeath = false;
        [Category("Environment"), Display(Name="Physics Iterations", Description=""), ProtoMember(0x19b), Range(2, 0x20)]
        public int PhysicsIterations = 8;
        [Display(Name="Character Removal Threshold [mins]", Description="Defines character removal threshold for trash removal system. If player disconnects it will remove his character after this time.\n Set to 0 to disable."), Category("Trash Removal"), ProtoMember(0x270, IsRequired=false), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public int PlayerCharacterRemovalThreshold;
        [Category("Trash Removal"), ProtoMember(0x25e, IsRequired=false), Display(Name="Player Distance Threshold [m]", Description="Defines player distance threshold for trash removal system."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public float PlayerDistanceThreshold;
        [ProtoMember(0x26a, IsRequired=false), Category("Trash Removal"), Display(Name="Player Inactivity Threshold [hours]", Description="Defines player inactivity threshold for trash removal system. \n !WARNING! This will remove all grids of the player.\n Set to 0 to disable."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public float PlayerInactivityThreshold;
        [Range(0, 1), ProtoMember(280), Display(Name="Procedural Density", Description="Defines density of the procedurally generated content."), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment")]
        public float ProceduralDensity;
        [Range(-2147483648, 0x7fffffff), Category("Environment"), ProtoMember(0x120), Display(Name="Procedural Seed", Description="Defines unique starting seed for the procedurally generated content."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public int ProceduralSeed;
        [Display(Name="Enable Realistic Sound", Description="Enables realistic sounds."), ProtoMember(0xd8), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment")]
        public bool RealisticSound;
        [ProtoMember(50), Category("Multipliers"), Range(1, 100), Display(Name="Refinery Speed", Description="The multiplier for refinery speed."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public float RefinerySpeedMultiplier = 3f;
        [Display(Name="Reset Ownership", Description=""), ProtoMember(0xc4), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Players")]
        public bool ResetOwnership;
        [Category("Others"), ProtoMember(190), Display(Name="Remove Respawn Ships on Logoff", Description="When enabled respawn ship is removed after player logout."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool RespawnShipDelete = true;
        [Display(Name=""), ProtoMember(0x18f), Browsable(false), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool Scenario;
        [Browsable(false), ProtoMember(0x189), Display(Name=""), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool ScenarioEditMode;
        [Display(Name="Show Player Names on HUD", Description=""), ProtoMember(0x9a), Category("Players"), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool ShowPlayerNamesOnHud = true;
        [GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x111), Display(Name="Respawn Ship Time Multiplier", Description="The multiplier for respawn ship timer."), Range(0, 100), Category("Players")]
        public float SpawnShipTimeMultiplier = 0.5f;
        [ProtoMember(430), Display(Name="Spawn with Tools", Description="Enables spawning with tools in the inventory."), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Players")]
        public bool SpawnWithTools = true;
        [Display(Name=""), Browsable(false), ProtoMember(0x1b4), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool StartInRespawnScreen;
        [Display(Name="Enable Station Grid with Voxel", Description="Enables possibility of station grid inside voxel."), ProtoMember(0x177), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment")]
        public bool StationVoxelSupport;
        [Range(0, 0x5a0), Display(Name="Sun Rotation Interval", Description="Defines interval of one rotation of the sun."), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment"), ProtoMember(0x1a1)]
        public float SunRotationIntervalMinutes = 120f;
        [Range(0x3e8, 0x4e20), Category("Environment"), ProtoMember(0x220, IsRequired=false), Display(Name="Sync Distance", Description="Defines synchronization distance in multiplayer. High distance can slow down server drastically. Use with caution."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public int SyncDistance;
        [ProtoMember(160), Category("Others"), Display(Name="Enable Thruster Damage", Description="Enables thruster damage."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool ThrusterDamage = true;
        [ProtoMember(0x5f), Category("Block Limits"), Display(Name="World PCU", Description="The total number of Performance Cost Units in the world."), GameRelation(VRage.Game.Game.SpaceEngineers), Range(0, 0x7fffffff)]
        public int TotalPCU = 0x186a0;
        [ProtoMember(0x23f, IsRequired=false), Category("Trash Removal"), Display(Name="Trash Removal Flags", Description="Defines flags for trash removal system."), GameRelation(VRage.Game.Game.SpaceEngineers), MyFlagEnum(typeof(MyTrashRemovalFlags))]
        public int TrashFlagsValue;
        [Category("Trash Removal"), ProtoMember(0x239, IsRequired=false), Display(Name="Trash Removal Enabled", Description="Enables trash removal system."), GameRelation(VRage.Game.Game.SpaceEngineers)]
        public bool TrashRemovalEnabled;
        [Range(5, 0xc350), Browsable(false), ProtoMember(0x134), Display(Name="View Distance"), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment")]
        public int ViewDistance = 0x3a98;
        [ProtoMember(0x14c), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment"), Range(0, 100), Display(Name="Voxel Generator Version", Description="")]
        public int VoxelGeneratorVersion;
        [Display(Name="Enable Weapons", Description="Enables weapons."), Category("Others"), GameRelation(VRage.Game.Game.SpaceEngineers), ProtoMember(0x94)]
        public bool WeaponsEnabled = true;
        [GameRelation(VRage.Game.Game.SpaceEngineers), Display(Name="Welder Speed", Description="The multiplier for welder speed."), Category("Multipliers"), ProtoMember(0xca), Range(0, 100)]
        public float WelderSpeedMultiplier = 2f;
        [Display(Name="World Size [km]", Description="Defines the size of the world."), ProtoMember(0xb7), Range(0, 0x7fffffff), GameRelation(VRage.Game.Game.SpaceEngineers), Category("Environment")]
        public int WorldSizeKm;

        public MyObjectBuilder_SessionSettings()
        {
            Dictionary<string, short> dict = new Dictionary<string, short> {
                { 
                    "Assembler",
                    0x18
                },
                { 
                    "Refinery",
                    0x18
                },
                { 
                    "Blast Furnace",
                    0x18
                },
                { 
                    "Antenna",
                    30
                },
                { 
                    "Drill",
                    30
                },
                { 
                    "InteriorTurret",
                    50
                },
                { 
                    "GatlingTurret",
                    50
                },
                { 
                    "MissileTurret",
                    50
                },
                { 
                    "ExtendedPistonBase",
                    50
                },
                { 
                    "MotorStator",
                    50
                },
                { 
                    "MotorAdvancedStator",
                    50
                },
                { 
                    "ShipWelder",
                    100
                },
                { 
                    "ShipGrinder",
                    150
                }
            };
            this.BlockTypeLimits = new SerializableDictionary<string, short>(dict);
            this.MinDropContainerRespawnTime = 5;
            this.MaxDropContainerRespawnTime = 20;
            this.SyncDistance = 0xbb8;
            this.AdaptiveSimulationQuality = true;
            this.TrashRemovalEnabled = true;
            this.TrashFlagsValue = 0x61a;
            this.BlockCountThreshold = 20;
            this.PlayerDistanceThreshold = 500f;
            this.PlayerCharacterRemovalThreshold = 15;
        }

        public ExperimentalReason GetExperimentalReason(bool update = true)
        {
            if (update || !this.m_experimentalReasonInited)
            {
                this.UpdateExperimentalReason();
            }
            return this.m_experimentalReason;
        }

        public bool IsSettingsExperimental()
        {
            if (!this.m_experimentalReasonInited)
            {
                this.UpdateExperimentalReason();
            }
            return (this.m_experimentalReason != 0L);
        }

        public void LogMembers(MyLog log, LoggingOptions options)
        {
            log.WriteLine("Settings:");
            using (log.IndentUsing(options))
            {
                log.WriteLine("GameMode = " + this.GameMode);
                log.WriteLine("MaxPlayers = " + this.MaxPlayers);
                log.WriteLine("OnlineMode = " + this.OnlineMode);
                log.WriteLine("AutoHealing = " + this.AutoHealing);
                log.WriteLine("WeaponsEnabled = " + this.WeaponsEnabled);
                log.WriteLine("ThrusterDamage = " + this.ThrusterDamage);
                log.WriteLine("EnableSpectator = " + this.EnableSpectator);
                log.WriteLine("EnableCopyPaste = " + this.EnableCopyPaste);
                log.WriteLine("MaxFloatingObjects = " + this.MaxFloatingObjects);
                log.WriteLine("MaxGridSize = " + this.MaxGridSize);
                log.WriteLine("MaxBlocksPerPlayer = " + this.MaxBlocksPerPlayer);
                log.WriteLine("CargoShipsEnabled = " + this.CargoShipsEnabled);
                log.WriteLine("EnvironmentHostility = " + this.EnvironmentHostility);
                log.WriteLine("ShowPlayerNamesOnHud = " + this.ShowPlayerNamesOnHud);
                log.WriteLine("InventorySizeMultiplier = " + this.InventorySizeMultiplier);
                log.WriteLine("RefinerySpeedMultiplier = " + this.RefinerySpeedMultiplier);
                log.WriteLine("AssemblerSpeedMultiplier = " + this.AssemblerSpeedMultiplier);
                log.WriteLine("AssemblerEfficiencyMultiplier = " + this.AssemblerEfficiencyMultiplier);
                log.WriteLine("WelderSpeedMultiplier = " + this.WelderSpeedMultiplier);
                log.WriteLine("GrinderSpeedMultiplier = " + this.GrinderSpeedMultiplier);
                log.WriteLine("ClientCanSave = " + this.ClientCanSave);
                log.WriteLine("HackSpeedMultiplier = " + this.HackSpeedMultiplier);
                log.WriteLine("PermanentDeath = " + this.PermanentDeath);
                log.WriteLine("DestructibleBlocks =  " + this.DestructibleBlocks);
                log.WriteLine("EnableScripts =  " + this.EnableIngameScripts);
                log.WriteLine("AutoSaveInMinutes = " + this.AutoSaveInMinutes);
                log.WriteLine("SpawnShipTimeMultiplier = " + this.SpawnShipTimeMultiplier);
                log.WriteLine("ProceduralDensity = " + this.ProceduralDensity);
                log.WriteLine("ProceduralSeed = " + this.ProceduralSeed);
                log.WriteLine("DestructibleBlocks = " + this.DestructibleBlocks);
                log.WriteLine("EnableIngameScripts = " + this.EnableIngameScripts);
                log.WriteLine("ViewDistance = " + this.ViewDistance);
                log.WriteLine("Voxel destruction = " + this.EnableVoxelDestruction);
                log.WriteLine("EnableStructuralSimulation = " + this.EnableStructuralSimulation);
                log.WriteLine("MaxActiveFracturePieces = " + this.MaxActiveFracturePieces);
                log.WriteLine("EnableContainerDrops = " + this.EnableContainerDrops);
                log.WriteLine("MinDropContainerRespawnTime = " + this.MinDropContainerRespawnTime);
                log.WriteLine("MaxDropContainerRespawnTime = " + this.MaxDropContainerRespawnTime);
                log.WriteLine("EnableTurretsFriendlyFire = " + this.EnableTurretsFriendlyFire);
                log.WriteLine("EnableSubgridDamage = " + this.EnableSubgridDamage);
                log.WriteLine("SyncDistance = " + this.SyncDistance);
                log.WriteLine("BlockLimitsEnabled = " + this.BlockLimitsEnabled);
                log.WriteLine("ExperimentalMode = " + this.ExperimentalMode);
                log.WriteLine("ExperimentalModeReason = " + this.GetExperimentalReason(true));
            }
        }

        public bool ShouldSerializeAutoSave() => 
            false;

        public bool ShouldSerializeProceduralDensity() => 
            (this.ProceduralDensity > 0f);

        public bool ShouldSerializeProceduralSeed() => 
            (this.ProceduralDensity > 0f);

        public bool ShouldSerializeTrashFlags() => 
            false;

        public void UpdateExperimentalReason()
        {
            this.m_experimentalReasonInited = true;
            this.m_experimentalReason = 0L;
            if (this.ExperimentalMode)
            {
                this.m_experimentalReason |= ExperimentalReason.ExperimentalMode;
            }
            if ((this.MaxPlayers > 0x10) || (this.MaxPlayers == 0))
            {
                this.m_experimentalReason |= ExperimentalReason.MaxPlayers;
            }
            if ((this.EnvironmentHostility == MyEnvironmentHostilityEnum.CATACLYSM) || (this.EnvironmentHostility == MyEnvironmentHostilityEnum.CATACLYSM_UNREAL))
            {
                this.m_experimentalReason |= ExperimentalReason.EnvironmentHostility;
            }
            if (this.ProceduralDensity > 0.25f)
            {
                this.m_experimentalReason |= ExperimentalReason.ProceduralDensity;
            }
            if (this.FloraDensity > 20)
            {
                this.m_experimentalReason |= ExperimentalReason.FloraDensity;
            }
            if (this.WorldSizeKm != 0)
            {
                this.m_experimentalReason |= ExperimentalReason.WorldSizeKm;
            }
            if (this.SpawnShipTimeMultiplier != 0.5f)
            {
                this.m_experimentalReason |= ExperimentalReason.SpawnShipTimeMultiplier;
            }
            if (this.SunRotationIntervalMinutes <= 30f)
            {
                this.m_experimentalReason |= ExperimentalReason.SunRotationIntervalMinutes;
            }
            if (this.MaxFloatingObjects > 0x38)
            {
                this.m_experimentalReason |= ExperimentalReason.MaxFloatingObjects;
            }
            if (this.PhysicsIterations != 8)
            {
                this.m_experimentalReason |= ExperimentalReason.PhysicsIterations;
            }
            if (this.SyncDistance != 0xbb8)
            {
                this.m_experimentalReason |= ExperimentalReason.SyncDistance;
            }
            if (this.ViewDistance != 0x3a98)
            {
                this.m_experimentalReason |= ExperimentalReason.ViewDistance;
            }
            if (this.VoxelGeneratorVersion != 2)
            {
                this.m_experimentalReason |= ExperimentalReason.VoxelGeneratorVersion;
            }
            if (this.BlockLimitsEnabled == MyBlockLimitsEnabledEnum.NONE)
            {
                this.m_experimentalReason |= ExperimentalReason.BlockLimitsEnabled;
            }
            if (this.TotalPCU > 0x186a0)
            {
                this.m_experimentalReason |= ExperimentalReason.TotalPCU;
            }
            if (!this.RespawnShipDelete)
            {
                this.m_experimentalReason |= ExperimentalReason.RespawnShipDelete;
            }
            if (this.EnableSpectator)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableSpectator;
            }
            if ((!this.EnableCopyPaste && (this.GameMode == MyGameModeEnum.Creative)) || (this.EnableCopyPaste && (this.GameMode == MyGameModeEnum.Survival)))
            {
                this.m_experimentalReason |= ExperimentalReason.EnableCopyPaste;
            }
            if (this.ResetOwnership)
            {
                this.m_experimentalReason |= ExperimentalReason.ResetOwnership;
            }
            if (!this.ThrusterDamage)
            {
                this.m_experimentalReason |= ExperimentalReason.ThrusterDamage;
            }
            if (this.PermanentDeath == true)
            {
                this.m_experimentalReason |= ExperimentalReason.PermanentDeath;
            }
            if (!this.WeaponsEnabled)
            {
                this.m_experimentalReason |= ExperimentalReason.WeaponsEnabled;
            }
            if (this.CargoShipsEnabled)
            {
                this.m_experimentalReason |= ExperimentalReason.CargoShipsEnabled;
            }
            if (!this.DestructibleBlocks)
            {
                this.m_experimentalReason |= ExperimentalReason.DestructibleBlocks;
            }
            if (this.EnableIngameScripts)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableIngameScripts;
            }
            if (!this.EnableToolShake)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableToolShake;
            }
            if (this.EnableEncounters)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableEncounters;
            }
            if (!this.Enable3rdPersonView)
            {
                this.m_experimentalReason |= ExperimentalReason.Enable3rdPersonView;
            }
            if (!this.EnableOxygen)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableOxygen;
            }
            if (this.EnableOxygenPressurization)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableOxygenPressurization;
            }
            if (!this.EnableConvertToStation)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableConvertToStation;
            }
            if (this.StationVoxelSupport)
            {
                this.m_experimentalReason |= ExperimentalReason.StationVoxelSupport;
            }
            if (!this.EnableJetpack)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableJetpack;
            }
            if (!this.SpawnWithTools)
            {
                this.m_experimentalReason |= ExperimentalReason.SpawnWithTools;
            }
            if (this.StartInRespawnScreen)
            {
                this.m_experimentalReason |= ExperimentalReason.StartInRespawnScreen;
            }
            if (!this.EnableVoxelDestruction)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableVoxelDestruction;
            }
            if (this.EnableDrones)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableDrones;
            }
            if (this.EnableWolfs)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableWolfs;
            }
            if (this.EnableSpiders)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableSpiders;
            }
            if (!this.EnableRemoteBlockRemoval)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableRemoteBlockRemoval;
            }
            if (this.EnableSubgridDamage)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableSubgridDamage;
            }
            if (this.EnableTurretsFriendlyFire)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableTurretsFriendlyFire;
            }
            if (!this.EnableRespawnShips)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableRespawnShips;
            }
            if (!this.AdaptiveSimulationQuality)
            {
                this.m_experimentalReason |= ExperimentalReason.AdaptiveSimulationQuality;
            }
            if (this.EnableVoxelHand)
            {
                this.m_experimentalReason |= ExperimentalReason.EnableVoxelHand;
            }
        }

        public bool AutoSave
        {
            get => 
                (this.AutoSaveInMinutes > 0);
            set
            {
                this.AutoSaveInMinutes = value ? 5 : 0;
            }
        }

        [XmlIgnore, NoSerialize, Display(Name="Client can save"), GameRelation(VRage.Game.Game.Shared), Browsable(false)]
        public bool ClientCanSave
        {
            get => 
                false;
            set
            {
            }
        }

        [XmlIgnore, ProtoIgnore, Browsable(false)]
        public MyTrashRemovalFlags TrashFlags
        {
            get => 
                ((MyTrashRemovalFlags) this.TrashFlagsValue);
            set
            {
                this.TrashFlagsValue = (int) value;
            }
        }

        [Flags]
        public enum ExperimentalReason : long
        {
            AdaptiveSimulationQuality = 0x800000000000L,
            AutoHealing = 0x8000L,
            BlockLimitsEnabled = 0x2000L,
            CargoShipsEnabled = 0x1000000L,
            DestructibleBlocks = 0x2000000L,
            Enable3rdPersonView = 0x20000000L,
            EnableContainerDrops = 0x200000000000L,
            EnableConvertToStation = 0x200000000L,
            EnableCopyPaste = 0x40000L,
            EnableDrones = 0x8000000000L,
            EnableEncounters = 0x10000000L,
            EnableIngameScripts = 0x4000000L,
            EnableJetpack = 0x800000000L,
            EnableOxygen = 0x40000000L,
            EnableOxygenPressurization = 0x80000000L,
            EnableRemoteBlockRemoval = 0x40000000000L,
            EnableRespawnShips = 0x400000000000L,
            EnableSpectator = 0x20000L,
            EnableSpiders = 0x20000000000L,
            EnableSubgridDamage = 0x80000000000L,
            EnableSunRotation = 0x100000000L,
            EnableToolShake = 0x8000000L,
            EnableTurretsFriendlyFire = 0x100000000000L,
            EnableVoxelDestruction = 0x4000000000L,
            EnableVoxelHand = 0x1000000000000L,
            EnableWolfs = 0x10000000000L,
            EnvironmentHostility = 4L,
            ExperimentalMode = 1L,
            ExperimentalTurnedOnInConfiguration = 0x2000000000000L,
            FloraDensity = 0x10L,
            InsufficientHardware = 0x4000000000000L,
            MaxFloatingObjects = 0x100L,
            MaxPlayers = 2L,
            Mods = 0x8000000000000L,
            PermanentDeath = 0x400000L,
            PhysicsIterations = 0x200L,
            Plugins = 0x10000000000000L,
            ProceduralDensity = 8L,
            ResetOwnership = 0x100000L,
            RespawnShipDelete = 0x10000L,
            ShowPlayerNamesOnHud = 0x80000L,
            SpawnShipTimeMultiplier = 0x40L,
            SpawnWithTools = 0x1000000000L,
            StartInRespawnScreen = 0x2000000000L,
            StationVoxelSupport = 0x400000000L,
            SunRotationIntervalMinutes = 0x80L,
            SyncDistance = 0x400L,
            ThrusterDamage = 0x200000L,
            TotalPCU = 0x4000L,
            ViewDistance = 0x800L,
            VoxelGeneratorVersion = 0x1000L,
            WeaponsEnabled = 0x800000L,
            WorldSizeKm = 0x20L
        }
    }
}

