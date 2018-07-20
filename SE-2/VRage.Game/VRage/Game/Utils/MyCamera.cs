namespace VRage.Game.Utils
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using VRage.ModAPI;
    using VRage.Utils;
    using VRageMath;
    using VRageRender;

    public class MyCamera : IMyCamera
    {
        public BoundingBoxD BoundingBox;
        public BoundingFrustumD BoundingFrustum = new BoundingFrustumD(MatrixD.Identity);
        public BoundingFrustumD BoundingFrustumFar = new BoundingFrustumD(MatrixD.Identity);
        public BoundingSphereD BoundingSphere;
        public readonly MyCameraShake CameraShake = new MyCameraShake();
        public readonly MyCameraSpring CameraSpring = new MyCameraSpring();
        public const float DefaultFarPlaneDistance = 20000f;
        public float FarFarPlaneDistance = 1000000f;
        public float FarPlaneDistance = 20000f;
        public float FieldOfView;
        private float m_fovSpring;
        private static float m_fovSpringDampening = 0.5f;
        public float NearPlaneDistance = 0.05f;
        public Vector3D PreviousPosition;
        public MatrixD ProjectionMatrix = MatrixD.Identity;
        public MatrixD ProjectionMatrixFar = MatrixD.Identity;
        public MatrixD ViewMatrix = MatrixD.Identity;
        public MyViewport Viewport;
        public MatrixD ViewProjectionMatrix = MatrixD.Identity;
        public MatrixD ViewProjectionMatrixFar = MatrixD.Identity;
        public MatrixD WorldMatrix = MatrixD.Identity;
        public MyCameraZoomProperties Zoom;

        public MyCamera(float fieldOfView, MyViewport currentScreenViewport)
        {
            this.FieldOfView = fieldOfView;
            this.Zoom = new MyCameraZoomProperties(this);
            this.UpdateScreenSize(currentScreenViewport);
        }

        public void AddFovSpring(float fovAddition = 0.01f)
        {
            this.m_fovSpring += fovAddition;
        }

        public double GetDistanceFromPoint(Vector3D position) => 
            Vector3D.Distance(this.Position, position);

        private float GetSafeNear() => 
            Math.Min(4f, this.NearPlaneDistance);

        public bool IsInFrustum(ref BoundingBoxD boundingBox)
        {
            ContainmentType type;
            this.BoundingFrustum.Contains(ref boundingBox, out type);
            return (type != ContainmentType.Disjoint);
        }

        public bool IsInFrustum(BoundingBoxD boundingBox) => 
            this.IsInFrustum(ref boundingBox);

        public bool IsInFrustum(ref BoundingSphereD boundingSphere)
        {
            ContainmentType type;
            this.BoundingFrustum.Contains(ref boundingSphere, out type);
            return (type != ContainmentType.Disjoint);
        }

        public Vector3D ScreenToWorld(ref Vector3D screenPos)
        {
            MatrixD matrix = MatrixD.Invert(MatrixD.Multiply(MatrixD.Multiply(this.WorldMatrix, this.ViewMatrix), this.ProjectionMatrix));
            return Vector3D.Transform(screenPos, matrix);
        }

        public void SetViewMatrix(MatrixD newViewMatrix)
        {
            this.PreviousPosition = this.Position;
            this.UpdatePropertiesInternal(newViewMatrix);
        }

        public void Update(float updateStepTime)
        {
            this.Zoom.Update(updateStepTime);
            Vector3 zero = Vector3.Zero;
            MatrixD viewMatrix = this.ViewMatrix;
            if (this.CameraSpring.Enabled)
            {
                this.CameraSpring.Update(updateStepTime, out zero);
            }
            if (this.CameraShake.ShakeEnabled)
            {
                Vector3 vector2;
                Vector3 vector3;
                this.CameraShake.UpdateShake(updateStepTime, out vector2, out vector3);
                zero += vector2;
            }
            if (zero != Vector3.Zero)
            {
                Vector3D vectord2;
                Vector3D vector = zero;
                Vector3D.Rotate(ref vector, ref viewMatrix, out vectord2);
                viewMatrix.Translation += vectord2;
                this.ViewMatrix = viewMatrix;
            }
            this.UpdatePropertiesInternal(this.ViewMatrix);
            this.m_fovSpring *= m_fovSpringDampening;
        }

        private void UpdateBoundingFrustum()
        {
            this.BoundingFrustum.Matrix = this.ViewProjectionMatrix;
            this.BoundingFrustumFar.Matrix = this.ViewProjectionMatrixFar;
            this.BoundingBox = BoundingBoxD.CreateInvalid();
            this.BoundingBox.Include(ref this.BoundingFrustum);
            this.BoundingSphere = MyUtils.GetBoundingSphereFromBoundingBox(ref this.BoundingBox);
        }

        private void UpdatePropertiesInternal(MatrixD newViewMatrix)
        {
            this.ViewMatrix = newViewMatrix;
            MatrixD.Invert(ref this.ViewMatrix, out this.WorldMatrix);
            this.ProjectionMatrix = MatrixD.CreatePerspectiveFieldOfView((double) this.FovWithZoom, (double) this.AspectRatio, (double) this.GetSafeNear(), (double) this.FarPlaneDistance);
            this.ProjectionMatrixFar = MatrixD.CreatePerspectiveFieldOfView((double) this.FovWithZoom, (double) this.AspectRatio, (double) this.GetSafeNear(), (double) this.FarFarPlaneDistance);
            this.ViewProjectionMatrix = this.ViewMatrix * this.ProjectionMatrix;
            this.ViewProjectionMatrixFar = this.ViewMatrix * this.ProjectionMatrixFar;
            this.UpdateBoundingFrustum();
        }

        public void UpdateScreenSize(MyViewport currentScreenViewport)
        {
            this.Viewport = currentScreenViewport;
            this.PreviousPosition = Vector3D.Zero;
            this.BoundingFrustum = new BoundingFrustumD(MatrixD.Identity);
            this.AspectRatio = this.Viewport.Width / this.Viewport.Height;
        }

        public void UploadViewMatrixToRender()
        {
            MyRenderProxy.SetCameraViewMatrix(this.ViewMatrix, (Matrix) this.ProjectionMatrix, (Matrix) this.ProjectionMatrixFar, this.Zoom.GetFOV() + this.m_fovSpring, this.Zoom.GetFOV() + this.m_fovSpring, this.NearPlaneDistance, this.FarPlaneDistance, this.FarFarPlaneDistance, this.Position, 0f, 0f, 1);
        }

        double IMyCamera.GetDistanceWithFOV(Vector3D position) => 
            this.GetDistanceFromPoint(position);

        bool IMyCamera.IsInFrustum(ref BoundingBoxD boundingBox) => 
            this.IsInFrustum(ref boundingBox);

        bool IMyCamera.IsInFrustum(ref BoundingSphereD boundingSphere) => 
            this.IsInFrustum(ref boundingSphere);

        bool IMyCamera.IsInFrustum(BoundingBoxD boundingBox) => 
            this.IsInFrustum(boundingBox);

        Vector3D IMyCamera.WorldToScreen(ref Vector3D worldPos) => 
            Vector3D.Transform(worldPos, this.ViewProjectionMatrix);

        public LineD WorldLineFromScreen(Vector2 screenCoords)
        {
            MatrixD matrix = MatrixD.Invert(this.ViewProjectionMatrix);
            Vector4D vector = new Vector4D((double) (((2f * screenCoords.X) / this.Viewport.Width) - 1f), (double) (1f - ((2f * screenCoords.Y) / this.Viewport.Height)), 0.0, 1.0);
            Vector4D vectord2 = new Vector4D((double) (((2f * screenCoords.X) / this.Viewport.Width) - 1f), (double) (1f - ((2f * screenCoords.Y) / this.Viewport.Height)), 1.0, 1.0);
            Vector4D xyz = Vector4D.Transform(vector, matrix);
            Vector4D vectord4 = Vector4D.Transform(vectord2, matrix);
            xyz = (Vector4D) (xyz / xyz.W);
            vectord4 = (Vector4D) (vectord4 / vectord4.W);
            return new LineD(new Vector3D(xyz), new Vector3D(vectord4));
        }

        public Vector3D WorldToScreen(ref Vector3D worldPos) => 
            Vector3D.Transform(worldPos, this.ViewProjectionMatrix);

        public float AspectRatio { get; private set; }

        public float FieldOfViewDegrees
        {
            get => 
                MathHelper.ToDegrees(this.FieldOfView);
            set
            {
                this.FieldOfView = MathHelper.ToRadians(value);
            }
        }

        public Vector3 ForwardVector =>
            ((Vector3) this.WorldMatrix.Forward);

        public float FovWithZoom =>
            (this.Zoom.GetFOV() + this.m_fovSpring);

        public Vector3 LeftVector =>
            ((Vector3) this.WorldMatrix.Left);

        public Vector3D Position =>
            this.WorldMatrix.Translation;

        public Vector3 UpVector =>
            ((Vector3) this.WorldMatrix.Up);

        public MatrixD ViewMatrixAtZero
        {
            get
            {
                MatrixD viewProjectionMatrix = this.ViewProjectionMatrix;
                viewProjectionMatrix.M14 = 0.0;
                viewProjectionMatrix.M24 = 0.0;
                viewProjectionMatrix.M34 = 0.0;
                viewProjectionMatrix.M41 = 0.0;
                viewProjectionMatrix.M42 = 0.0;
                viewProjectionMatrix.M43 = 0.0;
                viewProjectionMatrix.M44 = 1.0;
                return viewProjectionMatrix;
            }
        }

        float IMyCamera.FarPlaneDistance =>
            this.FarPlaneDistance;

        float IMyCamera.FieldOfViewAngle =>
            this.FieldOfViewDegrees;

        float IMyCamera.FieldOfViewAngleForNearObjects =>
            this.FieldOfViewDegrees;

        float IMyCamera.FovWithZoom =>
            this.FovWithZoom;

        float IMyCamera.FovWithZoomForNearObjects =>
            this.FovWithZoom;

        float IMyCamera.NearPlaneDistance =>
            this.NearPlaneDistance;

        Vector3D IMyCamera.Position =>
            this.Position;

        Vector3D IMyCamera.PreviousPosition =>
            this.PreviousPosition;

        MatrixD IMyCamera.ProjectionMatrix =>
            this.ProjectionMatrix;

        MatrixD IMyCamera.ProjectionMatrixForNearObjects =>
            this.ProjectionMatrix;

        MatrixD IMyCamera.ViewMatrix =>
            this.ViewMatrix;

        Vector2 IMyCamera.ViewportOffset =>
            new Vector2(this.Viewport.OffsetX, this.Viewport.OffsetY);

        Vector2 IMyCamera.ViewportSize =>
            new Vector2(this.Viewport.Width, this.Viewport.Height);

        MatrixD IMyCamera.WorldMatrix =>
            this.WorldMatrix;
    }
}

