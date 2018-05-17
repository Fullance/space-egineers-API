namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;

    public interface IMyProjector : Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyProjector, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        void Build(VRage.Game.ModAPI.IMySlimBlock cubeBlock, long owner, long builder, bool requestInstant);
        BuildCheckResult CanBuild(VRage.Game.ModAPI.IMySlimBlock projectedBlock, bool checkHavokIntersections);
        void SetProjectedGrid(MyObjectBuilder_CubeGrid grid);

        VRage.Game.ModAPI.IMyCubeGrid ProjectedGrid { get; }
    }
}

