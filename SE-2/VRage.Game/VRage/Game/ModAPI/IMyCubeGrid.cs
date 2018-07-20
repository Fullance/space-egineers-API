namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyCubeGrid : VRage.ModAPI.IMyEntity, VRage.Game.ModAPI.Ingame.IMyCubeGrid, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action<VRage.Game.ModAPI.IMySlimBlock> OnBlockAdded;

        event Action<VRage.Game.ModAPI.IMySlimBlock> OnBlockIntegrityChanged;

        event Action<VRage.Game.ModAPI.IMyCubeGrid> OnBlockOwnershipChanged;

        event Action<VRage.Game.ModAPI.IMySlimBlock> OnBlockRemoved;

        event Action<VRage.Game.ModAPI.IMyCubeGrid> OnGridChanged;

        event Action<VRage.Game.ModAPI.IMyCubeGrid, VRage.Game.ModAPI.IMyCubeGrid> OnGridSplit;

        event Action<VRage.Game.ModAPI.IMyCubeGrid, bool> OnIsStaticChanged;

        VRage.Game.ModAPI.IMySlimBlock AddBlock(MyObjectBuilder_CubeBlock objectBuilder, bool testMerge);
        void ApplyDestructionDeformation(VRage.Game.ModAPI.IMySlimBlock block);
        MatrixI CalculateMergeTransform(VRage.Game.ModAPI.IMyCubeGrid gridToMerge, Vector3I gridOffset);
        bool CanAddCube(Vector3I pos);
        bool CanAddCubes(Vector3I min, Vector3I max);
        bool CanMergeCubes(VRage.Game.ModAPI.IMyCubeGrid gridToMerge, Vector3I gridOffset);
        void ChangeGridOwnership(long playerId, MyOwnershipShareModeEnum shareMode);
        void ClearSymmetries();
        void ColorBlocks(Vector3I min, Vector3I max, Vector3 newHSV);
        void FixTargetCube(out Vector3I cube, Vector3 fractionalGridPosition);
        void GetBlocks(List<VRage.Game.ModAPI.IMySlimBlock> blocks, Func<VRage.Game.ModAPI.IMySlimBlock, bool> collect = null);
        List<VRage.Game.ModAPI.IMySlimBlock> GetBlocksInsideSphere(ref BoundingSphereD sphere);
        Vector3 GetClosestCorner(Vector3I gridPos, Vector3 position);
        VRage.Game.ModAPI.IMySlimBlock GetCubeBlock(Vector3I pos);
        Vector3D? GetLineIntersectionExactAll(ref LineD line, out double distance, out VRage.Game.ModAPI.IMySlimBlock intersectedBlock);
        bool GetLineIntersectionExactGrid(ref LineD line, ref Vector3I position, ref double distanceSquared);
        bool IsTouchingAnyNeighbor(Vector3I min, Vector3I max);
        VRage.Game.ModAPI.IMyCubeGrid MergeGrid_MergeBlock(VRage.Game.ModAPI.IMyCubeGrid gridToMerge, Vector3I gridOffset);
        [Obsolete("Use IMyCubeGrid.Static instead.")]
        void OnConvertToDynamic();
        Vector3I? RayCastBlocks(Vector3D worldStart, Vector3D worldEnd);
        void RayCastCells(Vector3D worldStart, Vector3D worldEnd, List<Vector3I> outHitPositions, Vector3I? gridSizeInflate = new Vector3I?(), bool havokWorld = false);
        void RazeBlock(Vector3I position);
        void RazeBlocks(List<Vector3I> locations);
        void RazeBlocks(ref Vector3I pos, ref Vector3UByte size);
        void RemoveBlock(VRage.Game.ModAPI.IMySlimBlock block, bool updatePhysics = false);
        void RemoveDestroyedBlock(VRage.Game.ModAPI.IMySlimBlock block);
        VRage.Game.ModAPI.IMyCubeGrid Split(List<VRage.Game.ModAPI.IMySlimBlock> blocks, bool sync = true);
        VRage.Game.ModAPI.IMyCubeGrid SplitByPlane(PlaneD plane);
        void UpdateBlockNeighbours(VRage.Game.ModAPI.IMySlimBlock block);
        void UpdateOwnership(long ownerId, bool isFunctional);
        bool WillRemoveBlockSplitGrid(VRage.Game.ModAPI.IMySlimBlock testBlock);
        Vector3I WorldToGridInteger(Vector3 coords);

        List<long> BigOwners { get; }

        string CustomName { get; set; }

        bool IsRespawnGrid { get; set; }

        bool IsStatic { get; set; }

        List<long> SmallOwners { get; }

        bool XSymmetryOdd { get; set; }

        Vector3I? XSymmetryPlane { get; set; }

        bool YSymmetryOdd { get; set; }

        Vector3I? YSymmetryPlane { get; set; }

        bool ZSymmetryOdd { get; set; }

        Vector3I? ZSymmetryPlane { get; set; }
    }
}

