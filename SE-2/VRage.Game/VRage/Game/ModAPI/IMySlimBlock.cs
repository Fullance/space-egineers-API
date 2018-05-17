namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.Game.ModAPI.Ingame;
    using VRage.Game.ModAPI.Interfaces;
    using VRageMath;

    public interface IMySlimBlock : VRage.Game.ModAPI.Ingame.IMySlimBlock, IMyDestroyableObject, IMyDecalProxy
    {
        void AddNeighbours();
        void ApplyAccumulatedDamage(bool addDirtyParts = true);
        string CalculateCurrentModel(out Matrix orientation);
        bool CanContinueBuild(VRage.Game.ModAPI.IMyInventory sourceInventory);
        void ClearConstructionStockpile(VRage.Game.ModAPI.IMyInventory outputInventory);
        void ComputeScaledCenter(out Vector3D scaledCenter);
        void ComputeScaledHalfExtents(out Vector3 scaledHalfExtents);
        void ComputeWorldCenter(out Vector3D worldCenter);
        void DecreaseMountLevel(float grinderAmount, VRage.Game.ModAPI.IMyInventory outputInventory, bool useDefaultDeconstructEfficiency = false);
        void FixBones(float oldDamage, float maxAllowedBoneMovement);
        void FullyDismount(VRage.Game.ModAPI.IMyInventory outputInventory);
        Vector3 GetColorMask();
        int GetConstructionStockpileItemAmount(MyDefinitionId id);
        [Obsolete("GetCopyObjectBuilder() is deprecated. Call GetObjectBuilder(bool) and pass 'true'.")]
        MyObjectBuilder_CubeBlock GetCopyObjectBuilder();
        MyObjectBuilder_CubeBlock GetObjectBuilder(bool copy = false);
        void GetWorldBoundingBox(out BoundingBoxD aabb, bool useAABBFromBlockCubes = false);
        void IncreaseMountLevel(float welderMountAmount, long welderOwnerPlayerId, VRage.Game.ModAPI.IMyInventory outputInventory = null, float maxAllowedBoneMovement = 0f, bool isHelping = false, MyOwnershipShareModeEnum share = 1);
        void InitOrientation(MyBlockOrientation orientation);
        void InitOrientation(ref Vector3I forward, ref Vector3I up);
        void InitOrientation(Base6Directions.Direction Forward, Base6Directions.Direction Up);
        void MoveItemsFromConstructionStockpile(VRage.Game.ModAPI.IMyInventory toInventory, MyItemFlags flags = 0);
        void MoveItemsToConstructionStockpile(VRage.Game.ModAPI.IMyInventory fromInventory);
        void PlayConstructionSound(MyIntegrityChangeEnum integrityChangeType, bool deconstruction = false);
        void RemoveNeighbours();
        void SetToConstructionSite();
        void SpawnConstructionStockpile();
        void SpawnFirstItemInConstructionStockpile();
        void UpdateVisual();

        MyDefinitionBase BlockDefinition { get; }

        VRage.Game.ModAPI.IMyCubeGrid CubeGrid { get; }

        float Dithering { get; set; }

        VRage.Game.ModAPI.IMyCubeBlock FatBlock { get; }

        Vector3I Max { get; }

        List<VRage.Game.ModAPI.IMySlimBlock> Neighbours { get; }

        MyBlockOrientation Orientation { get; }
    }
}

