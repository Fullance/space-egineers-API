namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.Components;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyCubeBlock : VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.ModAPI.IMyEntity, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action<VRage.Game.ModAPI.IMyCubeBlock> IsWorkingChanged;

        event Action OnUpgradeValuesChanged;

        void AddUpgradeValue(string upgrade, float defaultValue);
        void CalcLocalMatrix(out Matrix localMatrix, out string currModel);
        string CalculateCurrentModel(out Matrix orientation);
        bool DebugDraw();
        MyObjectBuilder_CubeBlock GetObjectBuilderCubeBlock(bool copy = false);
        MyRelationsBetweenPlayerAndBlock GetPlayerRelationToOwner();
        MyRelationsBetweenPlayerAndBlock GetUserRelationToOwner(long playerId);
        void Init();
        void Init(MyObjectBuilder_CubeBlock builder, VRage.Game.ModAPI.IMyCubeGrid cubeGrid);
        void OnBuildSuccess(long builtBy);
        void OnBuildSuccess(long builtBy, bool instantBuild);
        void OnDestroy();
        void OnModelChange();
        void OnRegisteredToGridSystems();
        void OnRemovedByCubeBuilder();
        void OnUnregisteredFromGridSystems();
        string RaycastDetectors(Vector3 worldFrom, Vector3 worldTo);
        void ReloadDetectors(bool refreshNetworks = true);
        int RemoveEffect(string effectName, int exception = -1);
        void SetDamageEffect(bool start);
        bool SetEffect(string effectName, bool stopPrevious = false);
        bool SetEffect(string effectName, float parameter, bool stopPrevious = false, bool ignoreParameter = false, bool removeSameNameEffects = false);
        void UpdateIsWorking();
        void UpdateVisual();

        bool CheckConnectionAllowed { get; set; }

        VRage.Game.ModAPI.IMyCubeGrid CubeGrid { get; }

        MyResourceSinkComponentBase ResourceSink { get; set; }

        VRage.Game.ModAPI.IMySlimBlock SlimBlock { get; }

        Dictionary<string, float> UpgradeValues { get; }
    }
}

