namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using VRage.Game.ModAPI.Ingame;
    using VRageMath;

    public interface IMyProjector : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool LoadBlueprint(string name);
        bool LoadRandomBlueprint(string searchPattern);
        void UpdateOffsetAndRotation();

        int BuildableBlocksCount { get; }

        bool IsProjecting { get; }

        Vector3I ProjectionOffset { get; set; }

        [Obsolete("Use ProjectionOffset vector instead.")]
        int ProjectionOffsetX { get; }

        [Obsolete("Use ProjectionOffset vector instead.")]
        int ProjectionOffsetY { get; }

        [Obsolete("Use ProjectionOffset vector instead.")]
        int ProjectionOffsetZ { get; }

        Vector3I ProjectionRotation { get; set; }

        [Obsolete("Use ProjectionRotation vector instead.")]
        int ProjectionRotX { get; }

        [Obsolete("Use ProjectionRotation vector instead.")]
        int ProjectionRotY { get; }

        [Obsolete("Use ProjectionRotation vector instead.")]
        int ProjectionRotZ { get; }

        int RemainingArmorBlocks { get; }

        int RemainingBlocks { get; }

        Dictionary<MyDefinitionBase, int> RemainingBlocksPerType { get; }

        bool ShowOnlyBuildable { get; set; }

        int TotalBlocks { get; }
    }
}

