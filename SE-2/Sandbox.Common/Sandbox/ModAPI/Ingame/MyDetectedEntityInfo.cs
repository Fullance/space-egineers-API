namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRageMath;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyDetectedEntityInfo
    {
        public readonly long EntityId;
        public readonly string Name;
        public readonly MyDetectedEntityType Type;
        public readonly Vector3D? HitPosition;
        public readonly MatrixD Orientation;
        public readonly Vector3 Velocity;
        public readonly MyRelationsBetweenPlayerAndBlock Relationship;
        public readonly BoundingBoxD BoundingBox;
        public readonly long TimeStamp;
        public MyDetectedEntityInfo(long entityId, string name, MyDetectedEntityType type, Vector3D? hitPosition, MatrixD orientation, Vector3 velocity, MyRelationsBetweenPlayerAndBlock relationship, BoundingBoxD boundingBox, long timeStamp)
        {
            if (timeStamp <= 0L)
            {
                throw new ArgumentException("Invalid Timestamp", "timeStamp");
            }
            this.EntityId = entityId;
            this.Name = name;
            this.Type = type;
            this.HitPosition = hitPosition;
            this.Orientation = orientation;
            this.Velocity = velocity;
            this.Relationship = relationship;
            this.BoundingBox = boundingBox;
            this.TimeStamp = timeStamp;
        }

        public Vector3D Position =>
            this.BoundingBox.Center;
        public bool IsEmpty() => 
            (this.TimeStamp == 0L);
    }
}

