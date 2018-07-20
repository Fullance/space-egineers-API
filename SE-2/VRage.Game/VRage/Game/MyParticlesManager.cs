namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Game.Components;
    using VRage.Generics;
    using VRageMath;
    using VRageRender;

    [MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
    public class MyParticlesManager : MySessionComponentBase
    {
        public static Func<Vector3D, Vector3> CalculateGravityInPoint;
        public static readonly bool DISTANCE_CHECK_ENABLE = true;
        public static MyObjectsPool<MyParticleEffect> EffectsPool = new MyObjectsPool<MyParticleEffect>(0x800, null);
        public static bool EnableCPUGenerations = true;
        public static bool Enabled = true;
        public static MyObjectsPool<MyParticleGeneration> GenerationsPool = new MyObjectsPool<MyParticleGeneration>(0x1000, null);
        public static List<MyGPUEmitter> GPUEmitters = new List<MyGPUEmitter>();
        public static List<MyGPUEmitterLite> GPUEmittersLite = new List<MyGPUEmitterLite>();
        public static List<MyGPUEmitterTransformUpdate> GPUEmitterTransforms = new List<MyGPUEmitterTransformUpdate>();
        public static MyObjectsPool<MyParticleGPUGeneration> GPUGenerationsPool = new MyObjectsPool<MyParticleGPUGeneration>(0x1000, null);
        public static MyObjectsPool<MyParticleLight> LightsPool = new MyObjectsPool<MyParticleLight>(0x20, null);
        private static List<MyBillboard> m_collectedBillboards = new List<MyBillboard>(0x4000);
        private static List<MyParticleEffect> m_effectsToDelete = new List<MyParticleEffect>();
        private static List<MyParticleEffect> m_particleEffectsAll = new List<MyParticleEffect>();
        private static List<MyParticleEffect> m_particleEffectsForUpdate = new List<MyParticleEffect>();
        private static FastResourceLock m_particlesLock = new FastResourceLock();
        private static bool m_paused = false;
        public static MyObjectsPool<MyParticleSound> SoundsPool = new MyObjectsPool<MyParticleSound>(0x200, null);

        private static MyParticleEffect CreateParticleEffect(string name, ref MatrixD effectMatrix, ref Vector3D worldPosition, uint parentID, bool userDraw = false)
        {
            MyParticleEffect item = MyParticlesLibrary.CreateParticleEffect(name, ref effectMatrix, ref worldPosition, parentID);
            userDraw = false;
            if (item != null)
            {
                if (!userDraw)
                {
                    m_particleEffectsForUpdate.Add(item);
                }
                item.UserDraw = userDraw;
                m_particleEffectsAll.Add(item);
            }
            return item;
        }

        public override void Draw()
        {
            if (Enabled)
            {
                m_collectedBillboards.Clear();
                DrawStart();
                using (m_particlesLock.AcquireExclusiveUsing())
                {
                    foreach (MyParticleEffect effect in m_particleEffectsForUpdate)
                    {
                        effect.Draw(m_collectedBillboards);
                    }
                }
                DrawEnd();
                if (m_collectedBillboards.Count > 0)
                {
                    MyRenderProxy.AddBillboards(m_collectedBillboards);
                }
            }
        }

        public static void DrawEnd()
        {
            if (GPUEmitters.Count > 0)
            {
                MyRenderProxy.UpdateGPUEmitters(ref GPUEmitters);
                GPUEmitters.AssertEmpty<MyGPUEmitter>();
            }
            if (GPUEmitterTransforms.Count > 0)
            {
                MyRenderProxy.UpdateGPUEmittersTransform(ref GPUEmitterTransforms);
                GPUEmitterTransforms.AssertEmpty<MyGPUEmitterTransformUpdate>();
            }
            if (GPUEmittersLite.Count > 0)
            {
                MyRenderProxy.UpdateGPUEmittersLite(ref GPUEmittersLite);
                GPUEmittersLite.AssertEmpty<MyGPUEmitterLite>();
            }
        }

        public static void DrawStart()
        {
            GPUEmitters.Clear();
            GPUEmittersLite.Clear();
            GPUEmitterTransforms.Clear();
        }

        public override void LoadData()
        {
            base.LoadData();
            if (Enabled)
            {
                MyTransparentGeometry.LoadData();
            }
        }

        public static void RemoveParticleEffect(MyParticleEffect effect, bool fromBackground = false)
        {
            if (effect != null)
            {
                if (!effect.UserDraw)
                {
                    using (m_particlesLock.AcquireExclusiveUsing())
                    {
                        m_particleEffectsForUpdate.Remove(effect);
                    }
                }
                m_particleEffectsAll.Remove(effect);
                MyParticlesLibrary.RemoveParticleEffectInstance(effect);
            }
        }

        [Obsolete("Use TryCreateParticleEffect with parenting instead")]
        public static bool TryCreateParticleEffect(string effectName, out MyParticleEffect effect) => 
            TryCreateParticleEffect(effectName, ref MatrixD.Identity, ref Vector3D.Zero, uint.MaxValue, out effect);

        [Obsolete("Use TryCreateParticleEffect with parenting instead")]
        public static bool TryCreateParticleEffect(int id, out MyParticleEffect effect, bool userDraw = false) => 
            TryCreateParticleEffect(id, out effect, ref MatrixD.Identity, ref Vector3D.Zero, uint.MaxValue, userDraw);

        [Obsolete("Use TryCreateParticleEffect with parenting instead")]
        public static bool TryCreateParticleEffect(string effectName, MatrixD worldMatrix, out MyParticleEffect effect)
        {
            Vector3D translation = worldMatrix.Translation;
            return TryCreateParticleEffect(effectName, ref worldMatrix, ref translation, uint.MaxValue, out effect);
        }

        public static bool TryCreateParticleEffect(string effectName, ref MatrixD effectMatrix, ref Vector3D worldPosition, uint parentID, out MyParticleEffect effect)
        {
            using (m_particlesLock.AcquireExclusiveUsing())
            {
                if ((string.IsNullOrEmpty(effectName) || !Enabled) || !MyParticlesLibrary.EffectExists(effectName))
                {
                    effect = null;
                    return false;
                }
                effect = CreateParticleEffect(effectName, ref effectMatrix, ref worldPosition, parentID, false);
                return (effect != null);
            }
        }

        public static bool TryCreateParticleEffect(int id, out MyParticleEffect effect, ref MatrixD effectMatrix, ref Vector3D worldPosition, uint parentID, bool userDraw = false)
        {
            effect = null;
            using (m_particlesLock.AcquireExclusiveUsing())
            {
                string str;
                if (MyParticlesLibrary.GetParticleEffectsID(id, out str))
                {
                    effect = CreateParticleEffect(str, ref effectMatrix, ref worldPosition, parentID, userDraw);
                }
                return (effect != null);
            }
        }

        protected override void UnloadData()
        {
            foreach (MyParticleEffect effect in m_particleEffectsForUpdate)
            {
                m_effectsToDelete.Add(effect);
            }
            foreach (MyParticleEffect effect2 in m_effectsToDelete)
            {
                RemoveParticleEffect(effect2, false);
            }
            m_effectsToDelete.Clear();
        }

        public override void UpdateAfterSimulation()
        {
            if (Enabled)
            {
                UpdateEffects();
            }
        }

        private static void UpdateEffects()
        {
            using (m_particlesLock.AcquireExclusiveUsing())
            {
                foreach (MyParticleEffect effect in m_particleEffectsForUpdate)
                {
                    if (effect.Update())
                    {
                        m_effectsToDelete.Add(effect);
                    }
                }
            }
            foreach (MyParticleEffect effect2 in m_effectsToDelete)
            {
                RemoveParticleEffect(effect2, true);
            }
            m_effectsToDelete.Clear();
        }

        public static List<MyParticleEffect> ParticleEffectsForUpdate =>
            m_particleEffectsForUpdate;

        public static bool Paused
        {
            get => 
                m_paused;
            set
            {
                if (m_paused != value)
                {
                    m_paused = value;
                    using (m_particlesLock.AcquireExclusiveUsing())
                    {
                        foreach (MyParticleEffect effect in m_particleEffectsForUpdate)
                        {
                            effect.SetDirty();
                        }
                    }
                }
            }
        }
    }
}

