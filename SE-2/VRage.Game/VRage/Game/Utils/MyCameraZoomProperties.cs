namespace VRage.Game.Utils
{
    using System;
    using System.Runtime.CompilerServices;
    using VRageMath;

    public class MyCameraZoomProperties
    {
        private static readonly float FIELD_OF_VIEW_MIN = MathHelper.ToRadians((float) 40f);
        private MyCamera m_camera;
        private float m_currentZoomTime;
        private float m_FOV;
        private float m_zoomLevel;
        private MyCameraZoomOperationType m_zoomType;
        private float ZoomTime = 0.075f;

        public MyCameraZoomProperties(MyCamera camera)
        {
            this.m_camera = camera;
            this.Update(0f);
        }

        public float GetFOV() => 
            MyMath.Clamp(this.m_FOV, 1E-05f, 3.141583f);

        public float GetZoomLevel() => 
            this.m_zoomLevel;

        public bool IsZooming() => 
            (this.m_zoomType != MyCameraZoomOperationType.NoZoom);

        public void ResetZoom()
        {
            this.m_zoomType = MyCameraZoomOperationType.NoZoom;
            this.m_currentZoomTime = 0f;
        }

        public void SetZoom(MyCameraZoomOperationType inZoomType)
        {
            this.m_zoomType = inZoomType;
        }

        public void Update(float updateStepSize)
        {
            switch (this.m_zoomType)
            {
                case MyCameraZoomOperationType.ZoomingIn:
                    if (this.m_currentZoomTime <= this.ZoomTime)
                    {
                        this.m_currentZoomTime += updateStepSize;
                        if (this.m_currentZoomTime >= this.ZoomTime)
                        {
                            this.m_currentZoomTime = this.ZoomTime;
                            this.m_zoomType = MyCameraZoomOperationType.Zoomed;
                        }
                    }
                    break;

                case MyCameraZoomOperationType.ZoomingOut:
                    if (this.m_currentZoomTime >= 0f)
                    {
                        this.m_currentZoomTime -= updateStepSize;
                        if (this.m_currentZoomTime <= 0f)
                        {
                            this.m_currentZoomTime = 0f;
                            this.m_zoomType = MyCameraZoomOperationType.NoZoom;
                        }
                    }
                    break;
            }
            this.m_zoomLevel = 1f - (this.m_currentZoomTime / this.ZoomTime);
            this.m_FOV = this.ApplyToFov ? MathHelper.Lerp(FIELD_OF_VIEW_MIN, this.m_camera.FieldOfView, this.m_zoomLevel) : this.m_camera.FieldOfView;
        }

        public bool ApplyToFov { get; set; }
    }
}

