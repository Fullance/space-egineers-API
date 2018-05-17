namespace VRage.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.ObjectBuilders;
    using VRageMath;

    public interface IMyEntities
    {
        event Action OnCloseAll;

        event Action<IMyEntity> OnEntityAdd;

        event Action<IMyEntity, string, string> OnEntityNameSet;

        event Action<IMyEntity> OnEntityRemove;

        void AddEntity(IMyEntity entity, bool insertIntoScene = true);
        IMyEntity CreateFromObjectBuilder(MyObjectBuilder_EntityBase objectBuilder);
        IMyEntity CreateFromObjectBuilderAndAdd(MyObjectBuilder_EntityBase objectBuilder);
        IMyEntity CreateFromObjectBuilderNoinit(MyObjectBuilder_EntityBase objectBuilder);
        IMyEntity CreateFromObjectBuilderParallel(MyObjectBuilder_EntityBase objectBuilder, bool addToScene = false, Action completionCallback = null);
        void EnableEntityBoundingBoxDraw(IMyEntity entity, bool enable, Vector4? color = new Vector4?(), float lineWidth = 0.01f, Vector3? inflateAmount = new Vector3?());
        bool EntityExists(long entityId);
        bool EntityExists(long? entityId);
        bool EntityExists(string name);
        bool Exist(IMyEntity entity);
        Vector3D? FindFreePlace(Vector3D basePos, float radius, int maxTestCount = 20, int testsPerDistance = 5, float stepSize = 1f);
        List<IMyEntity> GetElementsInBox(ref BoundingBoxD boundingBox);
        void GetEntities(HashSet<IMyEntity> entities, Func<IMyEntity, bool> collect = null);
        List<IMyEntity> GetEntitiesInAABB(ref BoundingBoxD boundingBox);
        List<IMyEntity> GetEntitiesInSphere(ref BoundingSphereD boundingSphere);
        IMyEntity GetEntity(Func<IMyEntity, bool> match);
        IMyEntity GetEntityById(long entityId);
        IMyEntity GetEntityById(long? entityId);
        IMyEntity GetEntityByName(string name);
        void GetInflatedPlayerBoundingBox(ref BoundingBox playerBox, float inflation);
        IMyEntity GetIntersectionWithSphere(ref BoundingSphereD sphere);
        IMyEntity GetIntersectionWithSphere(ref BoundingSphereD sphere, IMyEntity ignoreEntity0, IMyEntity ignoreEntity1);
        List<IMyEntity> GetIntersectionWithSphere(ref BoundingSphereD sphere, IMyEntity ignoreEntity0, IMyEntity ignoreEntity1, bool ignoreVoxelMaps, bool volumetricTest);
        IMyEntity GetIntersectionWithSphere(ref BoundingSphereD sphere, IMyEntity ignoreEntity0, IMyEntity ignoreEntity1, bool ignoreVoxelMaps, bool volumetricTest, bool excludeEntitiesWithDisabledPhysics = false, bool ignoreFloatingObjects = true, bool ignoreHandWeapons = true);
        List<IMyEntity> GetTopMostEntitiesInBox(ref BoundingBoxD boundingBox);
        List<IMyEntity> GetTopMostEntitiesInSphere(ref BoundingSphereD boundingSphere);
        bool IsInsideVoxel(Vector3 pos, Vector3 hintPosition, out Vector3 lastOutsidePos);
        bool IsInsideWorld(Vector3D pos);
        bool IsNameExists(IMyEntity entity, string name);
        bool IsRaycastBlocked(Vector3D pos, Vector3D target);
        bool IsSpherePenetrating(ref BoundingSphereD bs);
        bool IsTypeHidden(Type type);
        bool IsVisible(IMyEntity entity);
        bool IsWorldLimited();
        void MarkForClose(IMyEntity entity);
        void RegisterForDraw(IMyEntity entity);
        void RegisterForUpdate(IMyEntity entity);
        void RemapObjectBuilder(MyObjectBuilder_EntityBase objectBuilder);
        void RemapObjectBuilderCollection(IEnumerable<MyObjectBuilder_EntityBase> objectBuilders);
        void RemoveEntity(IMyEntity entity);
        void RemoveFromClosedEntities(IMyEntity entity);
        void RemoveName(IMyEntity entity);
        void SetEntityName(IMyEntity IMyEntity, bool possibleRename = true);
        void SetTypeHidden(Type type, bool hidden);
        bool TryGetEntityById(long id, out IMyEntity entity);
        bool TryGetEntityById(long? id, out IMyEntity entity);
        bool TryGetEntityByName(string name, out IMyEntity entity);
        void UnhideAllTypes();
        void UnregisterForDraw(IMyEntity entity);
        void UnregisterForUpdate(IMyEntity entity, bool immediate = false);
        float WorldHalfExtent();
        float WorldSafeHalfExtent();
    }
}

