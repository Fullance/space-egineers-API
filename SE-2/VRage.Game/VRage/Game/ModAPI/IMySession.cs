namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.Components;
    using VRage.Game.ModAPI.Interfaces;
    using VRage.Library.Utils;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMySession
    {
        event Action OnSessionLoading;

        event Action OnSessionReady;

        void BeforeStartComponents();
        void Draw();
        void GameOver();
        void GameOver(MyStringId? customMessage);
        MyObjectBuilder_Checkpoint GetCheckpoint(string saveName);
        MyObjectBuilder_Sector GetSector();
        MyPromoteLevel GetUserPromoteLevel(ulong steamId);
        Dictionary<string, byte[]> GetVoxelMapsArray();
        MyObjectBuilder_World GetWorld();
        bool IsPausable();
        bool IsUserAdmin(ulong steamId);
        [Obsolete("Use GetUserPromoteLevel")]
        bool IsUserPromoted(ulong steamId);
        void RegisterComponent(MySessionComponentBase component, MyUpdateOrder updateOrder, int priority);
        bool Save(string customSaveName = null);
        void SetAsNotReady();
        void SetCameraController(MyCameraControllerEnum cameraControllerEnum, IMyEntity cameraEntity = null, Vector3D? position = new Vector3D?());
        void SetComponentUpdateOrder(MySessionComponentBase component, MyUpdateOrder order);
        void Unload();
        void UnloadDataComponents();
        void UnloadMultiplayer();
        void UnregisterComponent(MySessionComponentBase component);
        void Update(MyTimeSpan time);
        void UpdateComponents();

        float AssemblerEfficiencyMultiplier { get; }

        float AssemblerSpeedMultiplier { get; }

        bool AutoHealing { get; }

        uint AutoSaveInMinutes { get; }

        IMyCamera Camera { get; }

        IMyCameraController CameraController { get; }

        double CameraTargetDistance { get; set; }

        bool CargoShipsEnabled { get; }

        [Obsolete("Client saving not supported anymore")]
        bool ClientCanSave { get; }

        IMyConfig Config { get; }

        IMyControllableEntity ControlledObject { get; }

        bool CreativeMode { get; }

        string CurrentPath { get; }

        IMyDamageSystem DamageSystem { get; }

        string Description { get; set; }

        TimeSpan ElapsedPlayTime { get; }

        bool EnableCopyPaste { get; }

        MyEnvironmentHostilityEnum EnvironmentHostility { get; }

        IMyFactionCollection Factions { get; }

        DateTime GameDateTime { get; set; }

        IMyGpsCollection GPS { get; }

        float GrinderSpeedMultiplier { get; }

        float HackSpeedMultiplier { get; }

        [Obsolete("Use HasCreativeRights")]
        bool HasAdminPrivileges { get; }

        bool HasCreativeRights { get; }

        float InventoryMultiplier { get; }

        bool IsCameraAwaitingEntity { get; set; }

        bool IsCameraControlledObject { get; }

        bool IsCameraUserControlledSpectator { get; }

        bool IsServer { get; }

        IMyPlayer LocalHumanPlayer { get; }

        short MaxBackupSaves { get; }

        short MaxFloatingObjects { get; }

        short MaxPlayers { get; }

        List<MyObjectBuilder_Checkpoint.ModItem> Mods { get; set; }

        bool MultiplayerAlive { get; set; }

        bool MultiplayerDirect { get; set; }

        double MultiplayerLastMsg { get; set; }

        string Name { get; set; }

        float NegativeIntegrityTotal { get; set; }

        MyOnlineModeEnum OnlineMode { get; }

        IMyOxygenProviderSystem OxygenProviderSystem { get; }

        string Password { get; set; }

        IMyPlayer Player { get; }

        float PositiveIntegrityTotal { get; set; }

        MyPromoteLevel PromoteLevel { get; }

        float RefinerySpeedMultiplier { get; }

        MyObjectBuilder_SessionSettings SessionSettings { get; }

        bool ShowPlayerNamesOnHud { get; }

        bool SurvivalMode { get; }

        bool ThrusterDamage { get; }

        string ThumbPath { get; }

        TimeSpan TimeOnBigShip { get; }

        TimeSpan TimeOnFoot { get; }

        TimeSpan TimeOnJetpack { get; }

        TimeSpan TimeOnSmallShip { get; }

        System.Version Version { get; }

        IMyVoxelMaps VoxelMaps { get; }

        bool WeaponsEnabled { get; }

        float WelderSpeedMultiplier { get; }

        ulong? WorkshopId { get; }

        BoundingBoxD WorldBoundaries { get; }
    }
}

