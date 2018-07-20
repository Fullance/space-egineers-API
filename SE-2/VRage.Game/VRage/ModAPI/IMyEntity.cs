namespace VRage.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.Components;
    using VRage.Game.Entity;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ObjectBuilders;
    using VRageMath;

    public interface IMyEntity : VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action<VRage.ModAPI.IMyEntity> OnClose;

        event Action<VRage.ModAPI.IMyEntity> OnClosing;

        event Action<VRage.ModAPI.IMyEntity> OnMarkForClose;

        event Action<VRage.ModAPI.IMyEntity> OnPhysicsChanged;

        [Obsolete("Only used during Sandbox removal.")]
        void AddToGamePruningStructure();
        void BeforeSave();
        void Close();
        void DebugDraw();
        void DebugDrawInvalidTriangles();
        void Delete();
        bool DoOverlapSphereTest(float sphereRadius, Vector3D spherePos);
        void EnableColorMaskForSubparts(bool enable);
        void GetChildren(List<VRage.ModAPI.IMyEntity> children, Func<VRage.ModAPI.IMyEntity, bool> collect = null);
        Vector3 GetDiffuseColor();
        float GetDistanceBetweenCameraAndBoundingSphere();
        float GetDistanceBetweenCameraAndPosition();
        string GetFriendlyName();
        bool GetIntersectionWithAABB(ref BoundingBoxD aabb);
        bool GetIntersectionWithLine(ref LineD line, out MyIntersectionResultLineTriangleEx? tri, IntersectionFlags flags);
        Vector3? GetIntersectionWithLineAndBoundingSphere(ref LineD line, float boundingSphereRadiusMultiplier);
        bool GetIntersectionWithSphere(ref BoundingSphereD sphere);
        VRage.Game.ModAPI.IMyInventory GetInventory();
        VRage.Game.ModAPI.IMyInventory GetInventory(int index);
        float GetLargestDistanceBetweenCameraAndBoundingSphere();
        MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false);
        float GetSmallestDistanceBetweenCameraAndBoundingSphere();
        MyEntitySubpart GetSubpart(string name);
        VRage.ModAPI.IMyEntity GetTopMostParent(Type type = null);
        void GetTrianglesIntersectingSphere(ref BoundingSphere sphere, Vector3? referenceNormalVector, float? maxAngle, List<MyTriangle_Vertex_Normals> retTriangles, int maxNeighbourTriangles);
        MatrixD GetViewMatrix();
        MatrixD GetWorldMatrixNormalizedInv();
        bool IsVisible();
        void OnAddedToScene(object source);
        void OnRemovedFromScene(object source);
        [Obsolete("Only used during Sandbox removal.")]
        void RemoveFromGamePruningStructure();
        void SetColorMaskForSubparts(Vector3 colorMaskHsv);
        void SetEmissiveParts(string emissiveName, Color emissivePartColor, float emissivity);
        void SetEmissivePartsForSubparts(string emissiveName, Color emissivePartColor, float emissivity);
        void SetLocalMatrix(Matrix localMatrix, object source = null);
        void SetPosition(Vector3D pos);
        void SetWorldMatrix(MatrixD worldMatrix, object source = null);
        void Teleport(MatrixD pos, object source = null, bool ignoreAssert = false);
        bool TryGetSubpart(string name, out MyEntitySubpart subpart);
        [Obsolete("Only used during Sandbox removal.")]
        void UpdateGamePruningStructure();

        bool CastShadows { get; set; }

        bool Closed { get; }

        MyEntityComponentContainer Components { get; }

        bool DebugAsyncLoading { get; }

        string DisplayName { get; set; }

        long EntityId { get; set; }

        bool FastCastShadowResolve { get; set; }

        EntityFlags Flags { get; set; }

        MyEntityComponentBase GameLogic { get; set; }

        MyHierarchyComponentBase Hierarchy { get; set; }

        bool InScene { get; set; }

        bool InvalidateOnMove { get; }

        [Obsolete]
        bool IsCCDForProjectiles { get; }

        bool IsVolumetric { get; }

        BoundingBox LocalAABB { get; set; }

        BoundingBox LocalAABBHr { get; }

        Matrix LocalMatrix { get; set; }

        BoundingSphere LocalVolume { get; set; }

        Vector3 LocalVolumeOffset { get; set; }

        [Obsolete]
        Vector3 LocationForHudMarker { get; }

        bool MarkedForClose { get; }

        float MaxGlassDistSq { get; }

        IMyModel Model { get; }

        string Name { get; set; }

        bool NearFlag { get; set; }

        bool NeedsDraw { get; set; }

        bool NeedsDrawFromParent { get; set; }

        bool NeedsResolveCastShadow { get; set; }

        MyEntityUpdateEnum NeedsUpdate { get; set; }

        bool NeedsWorldMatrix { get; set; }

        VRage.ModAPI.IMyEntity Parent { get; }

        MyPersistentEntityFlags2 PersistentFlags { get; set; }

        MyPhysicsComponentBase Physics { get; set; }

        MyPositionComponentBase PositionComp { get; set; }

        MyRenderComponentBase Render { get; set; }

        bool Save { get; set; }

        bool ShadowBoxLod { get; set; }

        bool SkipIfTooSmall { get; set; }

        MyModStorageComponentBase Storage { get; set; }

        bool Synchronized { get; set; }

        MySyncComponentBase SyncObject { get; }

        bool Transparent { get; set; }

        bool Visible { get; set; }

        MatrixD WorldMatrix { get; set; }

        MatrixD WorldMatrixInvScaled { get; }

        MatrixD WorldMatrixNormalizedInv { get; }
    }
}

