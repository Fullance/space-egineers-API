namespace VRage.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyCamera
    {
        double GetDistanceWithFOV(Vector3D position);
        bool IsInFrustum(ref BoundingBoxD boundingBox);
        bool IsInFrustum(ref BoundingSphereD boundingSphere);
        bool IsInFrustum(BoundingBoxD boundingBox);
        LineD WorldLineFromScreen(Vector2 screenCoords);
        Vector3D WorldToScreen(ref Vector3D worldPos);

        float FarPlaneDistance { get; }

        float FieldOfViewAngle { get; }

        [Obsolete]
        float FieldOfViewAngleForNearObjects { get; }

        float FovWithZoom { get; }

        [Obsolete]
        float FovWithZoomForNearObjects { get; }

        float NearPlaneDistance { get; }

        Vector3D Position { get; }

        Vector3D PreviousPosition { get; }

        MatrixD ProjectionMatrix { get; }

        [Obsolete]
        MatrixD ProjectionMatrixForNearObjects { get; }

        MatrixD ViewMatrix { get; }

        Vector2 ViewportOffset { get; }

        Vector2 ViewportSize { get; }

        MatrixD WorldMatrix { get; }
    }
}

