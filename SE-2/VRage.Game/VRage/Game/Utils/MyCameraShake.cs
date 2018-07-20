namespace VRage.Game.Utils
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Utils;
    using VRageMath;

    public class MyCameraShake
    {
        public float Dampening = 0.8f;
        public float DirReduction = 0.35f;
        private float m_currentShakeDirPower = 0f;
        private float m_currentShakePosPower = 0f;
        private Vector3 m_shakeDir;
        private bool m_shakeEnabled = false;
        private Vector3 m_shakePos;
        public float MaxShake = 15f;
        public float MaxShakeDir = 0.2f;
        public float MaxShakePosX = 0.8f;
        public float MaxShakePosY = 0.2f;
        public float MaxShakePosZ = 0.8f;
        public float OffConstant = 0.01f;
        public float Reduction = 0.6f;

        public void AddShake(float shakePower)
        {
            if (!MyUtils.IsZero(shakePower, 1E-05f) && !MyUtils.IsZero(this.MaxShake, 1E-05f))
            {
                float num = MathHelper.Clamp((float) (shakePower / this.MaxShake), (float) 0f, (float) 1f);
                if (this.m_currentShakePosPower < num)
                {
                    this.m_currentShakePosPower = num;
                }
                if (this.m_currentShakeDirPower < (num * this.DirReduction))
                {
                    this.m_currentShakeDirPower = num * this.DirReduction;
                }
                this.m_shakePos = new Vector3(this.m_currentShakePosPower * this.MaxShakePosX, this.m_currentShakePosPower * this.MaxShakePosY, this.m_currentShakePosPower * this.MaxShakePosZ);
                this.m_shakeDir = new Vector3(this.m_currentShakeDirPower * this.MaxShakeDir, this.m_currentShakeDirPower * this.MaxShakeDir, 0f);
                this.m_shakeEnabled = true;
            }
        }

        public bool ShakeActive() => 
            this.m_shakeEnabled;

        public void UpdateShake(float timeStep, out Vector3 outPos, out Vector3 outDir)
        {
            if (!this.m_shakeEnabled)
            {
                outPos = Vector3.Zero;
                outDir = Vector3.Zero;
            }
            else
            {
                this.m_shakePos.X *= MyUtils.GetRandomSign();
                this.m_shakePos.Y *= MyUtils.GetRandomSign();
                this.m_shakePos.Z *= MyUtils.GetRandomSign();
                outPos.X = (this.m_shakePos.X * Math.Abs(this.m_shakePos.X)) * this.Reduction;
                outPos.Y = (this.m_shakePos.Y * Math.Abs(this.m_shakePos.Y)) * this.Reduction;
                outPos.Z = (this.m_shakePos.Z * Math.Abs(this.m_shakePos.Z)) * this.Reduction;
                this.m_shakeDir.X *= MyUtils.GetRandomSign();
                this.m_shakeDir.Y *= MyUtils.GetRandomSign();
                this.m_shakeDir.Z *= MyUtils.GetRandomSign();
                outDir.X = (this.m_shakeDir.X * Math.Abs(this.m_shakeDir.X)) * 100f;
                outDir.Y = (this.m_shakeDir.Y * Math.Abs(this.m_shakeDir.Y)) * 100f;
                outDir.Z = (this.m_shakeDir.Z * Math.Abs(this.m_shakeDir.Z)) * 100f;
                outDir = (Vector3) (outDir * this.DirReduction);
                this.m_currentShakePosPower *= (float) Math.Pow((double) this.Dampening, (double) (timeStep * 60f));
                this.m_currentShakeDirPower *= (float) Math.Pow((double) this.Dampening, (double) (timeStep * 60f));
                if (this.m_currentShakeDirPower < 0f)
                {
                    this.m_currentShakeDirPower = 0f;
                }
                if (this.m_currentShakePosPower < 0f)
                {
                    this.m_currentShakePosPower = 0f;
                }
                this.m_shakePos = new Vector3(this.m_currentShakePosPower * this.MaxShakePosX, this.m_currentShakePosPower * this.MaxShakePosY, this.m_currentShakePosPower * this.MaxShakePosZ);
                this.m_shakeDir = new Vector3(this.m_currentShakeDirPower * this.MaxShakeDir, this.m_currentShakeDirPower * this.MaxShakeDir, 0f);
                if ((this.m_currentShakeDirPower < this.OffConstant) && (this.m_currentShakePosPower < this.OffConstant))
                {
                    this.m_currentShakeDirPower = 0f;
                    this.m_currentShakePosPower = 0f;
                    this.m_shakeEnabled = false;
                }
            }
        }

        public Vector3 ShakeDir =>
            this.m_shakeDir;

        public bool ShakeEnabled
        {
            get => 
                this.m_shakeEnabled;
            set
            {
                this.m_shakeEnabled = value;
            }
        }

        public Vector3 ShakePos =>
            this.m_shakePos;
    }
}

