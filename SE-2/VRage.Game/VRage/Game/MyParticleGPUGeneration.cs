namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;
    using VRage.Utils;
    using VRageMath;
    using VRageRender;
    using VRageRender.Animations;
    using VRageRender.Messages;
    using VRageRender.Utils;

    public class MyParticleGPUGeneration : IComparable, IMyParticleGeneration
    {
        private static readonly MyStringId ID_WHITE_BLOCK = MyStringId.GetOrCompute("WhiteBlock");
        private bool m_animatedTimeValues;
        private bool m_animDirty;
        private bool m_dirty;
        private MyParticleEffect m_effect;
        private MyGPUEmitter m_emitter;
        private readonly MyAnimatedPropertyFloat m_floatTmp = new MyAnimatedPropertyFloat();
        private float m_lastFramePPS;
        private static readonly string[] m_myRotationReferenceStrings = new string[] { "Camera", "Local", "Local and camera" };
        private string m_name;
        private readonly IMyConstProperty[] m_properties = new IMyConstProperty[0x35];
        private uint m_renderId = uint.MaxValue;
        private static readonly List<string> m_rotationReferenceStrings = m_myRotationReferenceStrings.ToList<string>();
        private bool m_show = true;
        private readonly MyAnimatedPropertyVector4 m_vec4Tmp = new MyAnimatedPropertyVector4();
        private static readonly int m_version = 2;

        private T AddProperty<T>(MyGPUGenerationPropertiesEnum e, T property) where T: IMyConstProperty
        {
            this.m_properties[(int) e] = property;
            return property;
        }

        private MatrixD CalculateWorldMatrix() => 
            (MatrixD.CreateTranslation((Vector3) (this.Offset * this.m_effect.GetEmitterScale())) * this.GetEffect().WorldMatrix);

        public void Clear()
        {
        }

        public void Close()
        {
            this.Stop(false);
        }

        public int CompareTo(object compareToObject) => 
            0;

        private void ConvertAlphaColors()
        {
            MyAnimatedProperty2DVector4 color = this.Color;
            for (int i = 0; i < color.GetKeysCount(); i++)
            {
                MyAnimatedPropertyVector4 vector2;
                float num2;
                color.GetKey(i, out num2, out vector2);
                IMyAnimatedProperty property = vector2;
                for (int j = 0; j < vector2.GetKeysCount(); j++)
                {
                    Vector4 vector3;
                    vector2.GetKey(j, out num2, out vector3);
                    vector3 = vector3.UnmultiplyColor();
                    vector3.W = ColorExtensions.ToLinearRGBComponent(vector3.W);
                    vector3 = Vector4.Clamp(vector3.PremultiplyColor(), new Vector4(0f, 0f, 0f, 0f), new Vector4(1f, 1f, 1f, 1f));
                    property.SetKey(j, num2, vector3);
                }
            }
        }

        public IMyParticleGeneration CreateInstance(MyParticleEffect effect)
        {
            MyParticleGPUGeneration generation;
            MyParticlesManager.GPUGenerationsPool.AllocateOrCreate(out generation);
            generation.Start(effect);
            generation.Name = this.Name;
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                generation.m_properties[i] = this.m_properties[i];
            }
            return generation;
        }

        public void Deallocate()
        {
            MyParticlesManager.GPUGenerationsPool.Deallocate(this);
        }

        public void DebugDraw()
        {
        }

        public void Deserialize(XmlReader reader)
        {
            this.m_name = reader.GetAttribute("name");
            int num = Convert.ToInt32(reader.GetAttribute("version"), CultureInfo.InvariantCulture);
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                if (reader.GetAttribute("name") == null)
                {
                    break;
                }
                property.Deserialize(reader);
            }
            reader.ReadEndElement();
            if (num == 1)
            {
                this.ConvertAlphaColors();
            }
        }

        public void DeserializeFromObjectBuilder(ParticleGeneration generation)
        {
            this.m_name = generation.Name;
            foreach (GenerationProperty property in generation.Properties)
            {
                for (int i = 0; i < this.m_properties.Length; i++)
                {
                    if (this.m_properties[i].Name.Equals(property.Name))
                    {
                        this.m_properties[i].DeserializeFromObjectBuilder(property);
                    }
                }
            }
            this.Emissivity.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 1f, this.m_floatTmp);
            if (this.m_floatTmp.GetKeysCount() < 4)
            {
                MyAnimatedPropertyFloat val = new MyAnimatedPropertyFloat();
                val.AddKey<float>(0f, 0f);
                val.AddKey<float>(0.33f, 0f);
                val.AddKey<float>(0.66f, 0f);
                val.AddKey<float>(1f, 0f);
                this.Emissivity.AddKey<MyAnimatedPropertyFloat>(0f, val);
            }
        }

        public void Done()
        {
            this.Stop(true);
        }

        public void Draw(List<MyBillboard> collectedBillboards)
        {
            if (this.m_renderId == uint.MaxValue)
            {
                this.m_renderId = MyRenderProxy.CreateGPUEmitter(this.m_effect.Name + "_" + this.Name);
            }
            if (this.IsDirty)
            {
                this.m_emitter = new MyGPUEmitter();
                this.FillDataComplete(ref this.m_emitter);
                this.m_lastFramePPS = this.m_emitter.ParticlesPerSecond;
                MyParticlesManager.GPUEmitters.Add(this.m_emitter);
                this.m_dirty = this.m_animDirty = false;
            }
            else if (this.m_animatedTimeValues || this.m_animDirty)
            {
                this.FillData(ref this.m_emitter);
                this.m_lastFramePPS = this.m_emitter.ParticlesPerSecond;
                MyParticlesManager.GPUEmitters.Add(this.m_emitter);
                this.m_animDirty = false;
            }
            else if (this.m_effect.TransformDirty)
            {
                float particlesPerSecond = this.GetParticlesPerSecond();
                float particlesPerFrame = this.GetParticlesPerFrame();
                this.m_lastFramePPS = particlesPerSecond;
                MatrixD xd = this.CalculateWorldMatrix();
                MyGPUEmitterTransformUpdate item = new MyGPUEmitterTransformUpdate {
                    GID = this.m_renderId,
                    Rotation = xd.Rotation,
                    Position = xd.Translation,
                    Scale = this.m_effect.GetEmitterScale(),
                    ParticlesPerSecond = particlesPerSecond,
                    ParticlesPerFrame = particlesPerFrame
                };
                MyParticlesManager.GPUEmitterTransforms.Add(item);
            }
            else if ((this.ParticlesPerSecond.GetKeysCount() > 1) || (this.ParticlesPerFrame.GetKeysCount() > 0))
            {
                float num3 = this.GetParticlesPerSecond();
                float num4 = this.GetParticlesPerFrame();
                if ((Math.Abs((float) (this.m_lastFramePPS - num3)) > 0.5f) || (num4 > 0f))
                {
                    this.m_lastFramePPS = num3;
                    MyGPUEmitterLite lite = new MyGPUEmitterLite {
                        GID = this.m_renderId,
                        ParticlesPerSecond = num3,
                        ParticlesPerFrame = num4
                    };
                    MyParticlesManager.GPUEmittersLite.Add(lite);
                }
            }
        }

        public IMyParticleGeneration Duplicate(MyParticleEffect effect)
        {
            MyParticleGPUGeneration generation;
            MyParticlesManager.GPUGenerationsPool.AllocateOrCreate(out generation);
            generation.Start(effect);
            generation.Name = this.Name;
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                generation.m_properties[i] = this.m_properties[i].Duplicate();
            }
            return generation;
        }

        private void FillData(ref MyGPUEmitter emitter)
        {
            float num;
            float num2;
            MatrixD xd = this.CalculateWorldMatrix();
            emitter.ParentID = this.m_effect.ParentID;
            emitter.Data.Rotation = xd.Rotation;
            emitter.WorldPosition = xd.Translation;
            emitter.Data.Scale = this.m_effect.GetEmitterScale();
            emitter.ParticlesPerSecond = this.GetParticlesPerSecond();
            emitter.ParticlesPerFrame = this.GetParticlesPerFrame();
            emitter.CameraBias = ((float) this.CameraBias) * this.m_effect.GetEmitterScale();
            this.Velocity.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out emitter.Data.Velocity);
            this.VelocityVar.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out emitter.Data.VelocityVar);
            this.DirectionInnerCone.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out num);
            emitter.Data.DirectionInnerCone = num;
            this.DirectionConeVar.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out num);
            emitter.Data.DirectionConeVar = MathHelper.ToRadians(num);
            this.EmitterSize.GetInterpolatedValue<Vector3>(this.m_effect.GetElapsedTime(), out emitter.Data.EmitterSize);
            this.EmitterSizeMin.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out emitter.Data.EmitterSizeMin);
            this.Color.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 1f, this.m_vec4Tmp);
            this.m_vec4Tmp.GetKey(0, out num2, out emitter.Data.Color0);
            this.m_vec4Tmp.GetKey(1, out emitter.Data.ColorKey1, out emitter.Data.Color1);
            this.m_vec4Tmp.GetKey(2, out emitter.Data.ColorKey2, out emitter.Data.Color2);
            this.m_vec4Tmp.GetKey(3, out num2, out emitter.Data.Color3);
            emitter.Data.Color0 *= this.m_effect.UserColorMultiplier;
            emitter.Data.Color1 *= this.m_effect.UserColorMultiplier;
            emitter.Data.Color2 *= this.m_effect.UserColorMultiplier;
            emitter.Data.Color3 *= this.m_effect.UserColorMultiplier;
            this.ColorIntensity.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 1f, this.m_floatTmp);
            this.m_floatTmp.GetKey(0, out num2, out emitter.Data.Intensity0);
            this.m_floatTmp.GetKey(1, out emitter.Data.IntensityKey1, out emitter.Data.Intensity1);
            this.m_floatTmp.GetKey(2, out emitter.Data.IntensityKey2, out emitter.Data.Intensity2);
            this.m_floatTmp.GetKey(3, out num2, out emitter.Data.Intensity3);
            this.AccelerationFactor.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 1f, this.m_floatTmp);
            this.m_floatTmp.GetKey(0, out num2, out emitter.Data.Acceleration0);
            this.m_floatTmp.GetKey(1, out emitter.Data.AccelerationKey1, out emitter.Data.Acceleration1);
            this.m_floatTmp.GetKey(2, out emitter.Data.AccelerationKey2, out emitter.Data.Acceleration2);
            this.m_floatTmp.GetKey(3, out num2, out emitter.Data.Acceleration3);
            this.Radius.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 1f, this.m_floatTmp);
            this.m_floatTmp.GetKey(0, out num2, out emitter.Data.ParticleSize0);
            this.m_floatTmp.GetKey(1, out emitter.Data.ParticleSizeKeys1, out emitter.Data.ParticleSize1);
            this.m_floatTmp.GetKey(2, out emitter.Data.ParticleSizeKeys2, out emitter.Data.ParticleSize2);
            this.m_floatTmp.GetKey(3, out num2, out emitter.Data.ParticleSize3);
            emitter.Data.ParticleSize0 *= this.m_effect.UserRadiusMultiplier;
            emitter.Data.ParticleSize1 *= this.m_effect.UserRadiusMultiplier;
            emitter.Data.ParticleSize2 *= this.m_effect.UserRadiusMultiplier;
            emitter.Data.ParticleSize3 *= this.m_effect.UserRadiusMultiplier;
            this.Thickness.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 1f, this.m_floatTmp);
            this.m_floatTmp.GetKey(0, out num2, out emitter.Data.ParticleThickness0);
            this.m_floatTmp.GetKey(1, out emitter.Data.ParticleThicknessKeys1, out emitter.Data.ParticleThickness1);
            this.m_floatTmp.GetKey(2, out emitter.Data.ParticleThicknessKeys2, out emitter.Data.ParticleThickness2);
            this.m_floatTmp.GetKey(3, out num2, out emitter.Data.ParticleThickness3);
            this.Emissivity.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 1f, this.m_floatTmp);
            this.m_floatTmp.GetKey(0, out num2, out emitter.Data.Emissivity0);
            this.m_floatTmp.GetKey(1, out emitter.Data.EmissivityKeys1, out emitter.Data.Emissivity1);
            this.m_floatTmp.GetKey(2, out emitter.Data.EmissivityKeys2, out emitter.Data.Emissivity2);
            this.m_floatTmp.GetKey(3, out num2, out emitter.Data.Emissivity3);
        }

        private void FillDataComplete(ref MyGPUEmitter emitter)
        {
            this.m_animatedTimeValues = (((((this.Velocity.GetKeysCount() > 1) || (this.VelocityVar.GetKeysCount() > 1)) || ((this.DirectionInnerCone.GetKeysCount() > 1) || (this.DirectionConeVar.GetKeysCount() > 1))) || (((this.EmitterSize.GetKeysCount() > 1) || (this.EmitterSizeMin.GetKeysCount() > 1)) || ((this.Color.GetKeysCount() > 1) || (this.ColorIntensity.GetKeysCount() > 1)))) || (((this.AccelerationFactor.GetKeysCount() > 1) || (this.Radius.GetKeysCount() > 1)) || (this.Emissivity.GetKeysCount() > 1))) || (this.Thickness.GetKeysCount() > 1);
            emitter.Data.HueVar = (float) this.HueVar;
            if (emitter.Data.HueVar > 1f)
            {
                emitter.Data.HueVar = 1f;
            }
            else if (emitter.Data.HueVar < 0f)
            {
                emitter.Data.HueVar = 0f;
            }
            emitter.DistanceMaxSqr = MyParticlesManager.DISTANCE_CHECK_ENABLE ? (this.m_effect.DistanceMax * this.m_effect.DistanceMax) : float.MaxValue;
            emitter.Data.MotionInheritance = (float) this.MotionInheritance;
            emitter.Data.Bounciness = (float) this.Bounciness;
            emitter.Data.RotationVelocityCollisionMultiplier = (float) this.RotationVelocityCollisionMultiplier;
            emitter.Data.DistanceScalingFactor = (float) this.DistanceScalingFactor;
            emitter.Data.CollisionCountToKill = (uint) this.CollisionCountToKill;
            emitter.Data.ParticleLifeSpan = (float) this.Life;
            emitter.Data.ParticleLifeSpanVar = (float) this.LifeVar;
            emitter.Data.Direction = (Vector3) this.Direction;
            emitter.Data.RotationVelocity = (float) this.RotationVelocity;
            emitter.Data.RotationVelocityVar = (float) this.RotationVelocityVar;
            emitter.Data.AccelerationVector = (Vector3) this.Acceleration;
            emitter.Data.RadiusVar = (float) this.RadiusVar;
            emitter.Data.StreakMultiplier = (float) this.StreakMultiplier;
            emitter.Data.SoftParticleDistanceScale = (float) this.SoftParticleDistanceScale;
            emitter.Data.AnimationFrameTime = (float) this.AnimationFrameTime;
            emitter.Data.OITWeightFactor = (float) this.OITWeightFactor;
            emitter.Data.ShadowAlphaMultiplier = (float) this.ShadowAlphaMultiplier;
            emitter.Data.AmbientFactor = (float) this.AmbientFactor;
            emitter.AtlasTexture = this.Material.GetValue<MyTransparentMaterial>().Texture;
            emitter.AtlasDimension = new Vector2I((int) this.ArraySize.GetValue<Vector3>().X, (int) this.ArraySize.GetValue<Vector3>().Y);
            emitter.AtlasFrameOffset = (int) this.ArrayOffset;
            emitter.AtlasFrameModulo = (int) this.ArrayModulo;
            emitter.Data.Angle = MathHelper.ToRadians((Vector3) this.Angle);
            emitter.Data.AngleVar = MathHelper.ToRadians((Vector3) this.AngleVar);
            emitter.GravityFactor = (float) this.Gravity;
            GPUEmitterFlags flags = 0;
            switch (this.RotationReference)
            {
                case MyRotationReference.Local:
                    flags |= GPUEmitterFlags.LocalRotation;
                    break;

                case MyRotationReference.LocalAndCamera:
                    flags |= GPUEmitterFlags.LocalAndCameraRotation;
                    break;

                default:
                    flags |= (this.Streaks != null) ? GPUEmitterFlags.Streaks : 0;
                    break;
            }
            flags |= (this.Collide != null) ? GPUEmitterFlags.Collide : 0;
            flags |= (this.UseEmissivityChannel != null) ? GPUEmitterFlags.UseEmissivityChannel : 0;
            flags |= (this.UseAlphaAnisotropy != null) ? GPUEmitterFlags.UseAlphaAnisotropy : 0;
            flags |= (this.SleepState != null) ? GPUEmitterFlags.SleepState : 0;
            flags |= (this.Light != null) ? GPUEmitterFlags.Light : 0;
            flags |= (this.VolumetricLight != null) ? GPUEmitterFlags.VolumetricLight : 0;
            flags |= (this.m_effect.IsSimulationPaused || MyParticlesManager.Paused) ? GPUEmitterFlags.FreezeSimulate : 0;
            flags |= MyParticlesManager.Paused ? GPUEmitterFlags.FreezeEmit : 0;
            flags |= (this.RotationEnabled != null) ? GPUEmitterFlags.RandomRotationEnabled : 0;
            emitter.Data.Flags = flags;
            emitter.GID = this.m_renderId;
            this.FillData(ref emitter);
        }

        public float GetBirthRate() => 
            0f;

        public MyParticleEffect GetEffect() => 
            this.m_effect;

        public MyParticleEmitter GetEmitter() => 
            null;

        private float GetParticlesPerFrame()
        {
            if (((this.ParticlesPerFrame.GetKeysCount() > 0) && this.Enabled.GetValue<bool>()) && (this.m_show && !this.m_effect.IsEmittingStopped))
            {
                float num;
                float num2;
                float num3;
                this.ParticlesPerFrame.GetNextValue(this.m_effect.GetElapsedTime() - 0.01666667f, out num, out num2, out num3);
                if ((num2 < (this.m_effect.GetElapsedTime() - 0.01666667f)) || (num2 >= this.m_effect.GetElapsedTime()))
                {
                    return 0f;
                }
                return (num * this.m_effect.UserBirthMultiplier);
            }
            return 0f;
        }

        private float GetParticlesPerSecond()
        {
            if ((this.Enabled.GetValue<bool>() && this.m_show) && !this.m_effect.IsEmittingStopped)
            {
                float num;
                this.ParticlesPerSecond.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out num);
                return (num * this.m_effect.UserBirthMultiplier);
            }
            return 0f;
        }

        public IEnumerable<IMyConstProperty> GetProperties() => 
            this.m_properties;

        public void Init()
        {
            this.AddProperty<MyConstPropertyVector3>(MyGPUGenerationPropertiesEnum.ArraySize, new MyConstPropertyVector3("Array size"));
            this.AddProperty<MyConstPropertyInt>(MyGPUGenerationPropertiesEnum.ArrayOffset, new MyConstPropertyInt("Array offset"));
            this.AddProperty<MyConstPropertyInt>(MyGPUGenerationPropertiesEnum.ArrayModulo, new MyConstPropertyInt("Array modulo"));
            this.AddProperty<MyAnimatedProperty2DVector4>(MyGPUGenerationPropertiesEnum.Color, new MyAnimatedProperty2DVector4("Color"));
            this.AddProperty<MyAnimatedProperty2DFloat>(MyGPUGenerationPropertiesEnum.ColorIntensity, new MyAnimatedProperty2DFloat("Color intensity"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.HueVar, new MyConstPropertyFloat("Hue var"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.Bounciness, new MyConstPropertyFloat("Bounciness"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.RotationVelocityCollisionMultiplier, new MyConstPropertyFloat("Rotation velocity collision multiplier"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.DistanceScalingFactor, new MyConstPropertyFloat("Distance scaling factor"));
            this.AddProperty<MyConstPropertyInt>(MyGPUGenerationPropertiesEnum.CollisionCountToKill, new MyConstPropertyInt("Collision count to kill particle"));
            this.AddProperty<MyAnimatedPropertyVector3>(MyGPUGenerationPropertiesEnum.EmitterSize, new MyAnimatedPropertyVector3("Emitter size"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGPUGenerationPropertiesEnum.EmitterSizeMin, new MyAnimatedPropertyFloat("Emitter inner size"));
            this.AddProperty<MyConstPropertyVector3>(MyGPUGenerationPropertiesEnum.Offset, new MyConstPropertyVector3("Offset"));
            this.AddProperty<MyConstPropertyVector3>(MyGPUGenerationPropertiesEnum.Direction, new MyConstPropertyVector3("Direction"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGPUGenerationPropertiesEnum.Velocity, new MyAnimatedPropertyFloat("Velocity"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGPUGenerationPropertiesEnum.VelocityVar, new MyAnimatedPropertyFloat("Velocity var"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGPUGenerationPropertiesEnum.DirectionInnerCone, new MyAnimatedPropertyFloat("Direction inner cone"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGPUGenerationPropertiesEnum.DirectionConeVar, new MyAnimatedPropertyFloat("Direction cone"));
            this.AddProperty<MyConstPropertyVector3>(MyGPUGenerationPropertiesEnum.Acceleration, new MyConstPropertyVector3("Acceleration"));
            this.AddProperty<MyAnimatedProperty2DFloat>(MyGPUGenerationPropertiesEnum.AccelerationFactor, new MyAnimatedProperty2DFloat("Acceleration factor [m/s^2]"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.RotationVelocity, new MyConstPropertyFloat("Rotation velocity"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.RotationVelocityVar, new MyConstPropertyFloat("Rotation velocity var"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.RotationEnabled, new MyConstPropertyBool("Rotation enabled"));
            this.AddProperty<MyAnimatedProperty2DFloat>(MyGPUGenerationPropertiesEnum.Radius, new MyAnimatedProperty2DFloat("Radius"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.RadiusVar, new MyConstPropertyFloat("Radius var"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.Life, new MyConstPropertyFloat("Life"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.LifeVar, new MyConstPropertyFloat("Life var"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.SoftParticleDistanceScale, new MyConstPropertyFloat("Soft particle distance scale"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.StreakMultiplier, new MyConstPropertyFloat("Streak multiplier"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.AnimationFrameTime, new MyConstPropertyFloat("Animation frame time"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.Enabled, new MyConstPropertyBool("Enabled"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGPUGenerationPropertiesEnum.ParticlesPerSecond, new MyAnimatedPropertyFloat("Particles per second"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGPUGenerationPropertiesEnum.ParticlesPerFrame, new MyAnimatedPropertyFloat("Particles per frame"));
            this.AddProperty<MyConstPropertyTransparentMaterial>(MyGPUGenerationPropertiesEnum.Material, new MyConstPropertyTransparentMaterial("Material"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.OITWeightFactor, new MyConstPropertyFloat("OIT weight factor"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.TargetCoverage, new MyConstPropertyFloat("Target coverage"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.Streaks, new MyConstPropertyBool("Streaks"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.Collide, new MyConstPropertyBool("Collide"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.UseEmissivityChannel, new MyConstPropertyBool("Use Emissivity Channel"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.UseAlphaAnisotropy, new MyConstPropertyBool("Use Alpha Anisotropy"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.SleepState, new MyConstPropertyBool("SleepState"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.Light, new MyConstPropertyBool("Light"));
            this.AddProperty<MyConstPropertyBool>(MyGPUGenerationPropertiesEnum.VolumetricLight, new MyConstPropertyBool("VolumetricLight"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.Gravity, new MyConstPropertyFloat("Gravity"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.MotionInheritance, new MyConstPropertyFloat("Motion inheritance"));
            this.AddProperty<MyConstPropertyEnum>(MyGPUGenerationPropertiesEnum.RotationReference, new MyConstPropertyEnum("Rotation reference", typeof(MyRotationReference), m_rotationReferenceStrings));
            this.AddProperty<MyConstPropertyVector3>(MyGPUGenerationPropertiesEnum.Angle, new MyConstPropertyVector3("Angle"));
            this.AddProperty<MyConstPropertyVector3>(MyGPUGenerationPropertiesEnum.AngleVar, new MyConstPropertyVector3("Angle var"));
            this.AddProperty<MyAnimatedProperty2DFloat>(MyGPUGenerationPropertiesEnum.Thickness, new MyAnimatedProperty2DFloat("Thickness"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.CameraBias, new MyConstPropertyFloat("Camera bias"));
            this.AddProperty<MyAnimatedProperty2DFloat>(MyGPUGenerationPropertiesEnum.Emissivity, new MyAnimatedProperty2DFloat("Emissivity"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.ShadowAlphaMultiplier, new MyConstPropertyFloat("Shadow alpha multiplier"));
            this.AddProperty<MyConstPropertyFloat>(MyGPUGenerationPropertiesEnum.AmbientFactor, new MyConstPropertyFloat("Ambient light factor"));
            this.InitDefault();
        }

        public void InitDefault()
        {
            this.ArraySize.SetValue(Vector3.One);
            this.ArrayModulo.SetValue(1);
            MyAnimatedPropertyVector4 val = new MyAnimatedPropertyVector4();
            val.AddKey<Vector4>(0f, Vector4.One);
            val.AddKey<Vector4>(0.33f, Vector4.One);
            val.AddKey<Vector4>(0.66f, Vector4.One);
            val.AddKey<Vector4>(1f, Vector4.One);
            this.Color.AddKey<MyAnimatedPropertyVector4>(0f, val);
            MyAnimatedPropertyFloat num = new MyAnimatedPropertyFloat();
            num.AddKey<float>(0f, 1f);
            num.AddKey<float>(0.33f, 1f);
            num.AddKey<float>(0.66f, 1f);
            num.AddKey<float>(1f, 1f);
            this.ColorIntensity.AddKey<MyAnimatedPropertyFloat>(0f, num);
            MyAnimatedPropertyFloat num2 = new MyAnimatedPropertyFloat();
            num2.AddKey<float>(0f, 0f);
            num2.AddKey<float>(0.33f, 0f);
            num2.AddKey<float>(0.66f, 0f);
            num2.AddKey<float>(1f, 0f);
            this.AccelerationFactor.AddKey<MyAnimatedPropertyFloat>(0f, num2);
            this.Offset.SetValue(new Vector3(0f, 0f, 0f));
            this.Direction.SetValue(new Vector3(0f, 0f, -1f));
            MyAnimatedPropertyFloat num3 = new MyAnimatedPropertyFloat();
            num3.AddKey<float>(0f, 0.1f);
            num3.AddKey<float>(0.33f, 0.1f);
            num3.AddKey<float>(0.66f, 0.1f);
            num3.AddKey<float>(1f, 0.1f);
            this.Radius.AddKey<MyAnimatedPropertyFloat>(0f, num3);
            MyAnimatedPropertyFloat num4 = new MyAnimatedPropertyFloat();
            num4.AddKey<float>(0f, 1f);
            num4.AddKey<float>(0.33f, 1f);
            num4.AddKey<float>(0.66f, 1f);
            num4.AddKey<float>(1f, 1f);
            this.Thickness.AddKey<MyAnimatedPropertyFloat>(0f, num4);
            MyAnimatedPropertyFloat num5 = new MyAnimatedPropertyFloat();
            num5.AddKey<float>(0f, 0f);
            num5.AddKey<float>(0.33f, 0f);
            num5.AddKey<float>(0.66f, 0f);
            num5.AddKey<float>(1f, 0f);
            this.Emissivity.AddKey<MyAnimatedPropertyFloat>(0f, num5);
            this.Life.SetValue(1f);
            this.LifeVar.SetValue(0f);
            this.StreakMultiplier.SetValue(4f);
            this.AnimationFrameTime.SetValue(1f);
            this.Enabled.SetValue(true);
            this.EmitterSize.AddKey<Vector3>(0f, new Vector3(0f, 0f, 0f));
            this.EmitterSizeMin.AddKey<float>(0f, 0f);
            this.DirectionInnerCone.AddKey<float>(0f, 0f);
            this.DirectionConeVar.AddKey<float>(0f, 0f);
            this.Velocity.AddKey<float>(0f, 1f);
            this.VelocityVar.AddKey<float>(0f, 0f);
            this.ParticlesPerSecond.AddKey<float>(0f, 1000f);
            this.Material.SetValue(MyTransparentMaterials.GetMaterial(ID_WHITE_BLOCK));
            this.SoftParticleDistanceScale.SetValue(1f);
            this.Bounciness.SetValue(0.5f);
            this.RotationVelocityCollisionMultiplier.SetValue(1f);
            this.DistanceScalingFactor.SetValue(0f);
            this.CollisionCountToKill.SetValue(0);
            this.HueVar.SetValue(0f);
            this.RotationEnabled.SetValue(true);
            this.MotionInheritance.SetValue(0f);
            this.OITWeightFactor.SetValue(1f);
            this.TargetCoverage.SetValue(1f);
            this.CameraBias.SetValue(0f);
            this.ShadowAlphaMultiplier.SetValue(5f);
            this.AmbientFactor.SetValue(1f);
        }

        public void MergeAABB(ref BoundingBoxD aabb)
        {
        }

        public void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement("ParticleGeneration");
            writer.WriteAttributeString("Name", this.Name);
            writer.WriteAttributeString("Version", m_version.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("GenerationType", "GPU");
            writer.WriteStartElement("Properties");
            foreach (IMyConstProperty property in this.m_properties)
            {
                writer.WriteStartElement("Property");
                writer.WriteAttributeString("Name", property.Name);
                writer.WriteAttributeString("Type", property.BaseValueType);
                PropertyAnimationType @const = PropertyAnimationType.Const;
                if (property.Animated)
                {
                    @const = property.Is2D ? PropertyAnimationType.Animated2D : PropertyAnimationType.Animated;
                }
                writer.WriteAttributeString("AnimationType", @const.ToString());
                property.Serialize(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void SetAnimDirty()
        {
            this.m_animDirty = true;
        }

        public void SetDirty()
        {
            this.m_dirty = true;
        }

        public void Start(MyParticleEffect effect)
        {
            this.m_effect = effect;
            this.m_name = "ParticleGeneration GPU";
            this.m_dirty = true;
        }

        private void Stop(bool instant)
        {
            this.Clear();
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                this.m_properties[i] = null;
            }
            this.m_effect = null;
            if (this.m_renderId != uint.MaxValue)
            {
                MyRenderProxy.RemoveGPUEmitter(this.m_renderId, instant);
                this.m_renderId = uint.MaxValue;
            }
        }

        public void Update()
        {
        }

        public MyConstPropertyVector3 Acceleration
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[13]);
            private set
            {
                this.m_properties[13] = value;
            }
        }

        public MyAnimatedProperty2DFloat AccelerationFactor
        {
            get => 
                ((MyAnimatedProperty2DFloat) this.m_properties[14]);
            private set
            {
                this.m_properties[14] = value;
            }
        }

        public MyConstPropertyFloat AmbientFactor
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x30]);
            private set
            {
                this.m_properties[0x30] = value;
            }
        }

        public MyConstPropertyVector3 Angle
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[0x27]);
            private set
            {
                this.m_properties[0x27] = value;
            }
        }

        public MyConstPropertyVector3 AngleVar
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[40]);
            private set
            {
                this.m_properties[40] = value;
            }
        }

        public MyConstPropertyFloat AnimationFrameTime
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[20]);
            private set
            {
                this.m_properties[20] = value;
            }
        }

        public MyConstPropertyInt ArrayModulo
        {
            get => 
                ((MyConstPropertyInt) this.m_properties[2]);
            private set
            {
                this.m_properties[2] = value;
            }
        }

        public MyConstPropertyInt ArrayOffset
        {
            get => 
                ((MyConstPropertyInt) this.m_properties[1]);
            private set
            {
                this.m_properties[1] = value;
            }
        }

        public MyConstPropertyVector3 ArraySize
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[0]);
            private set
            {
                this.m_properties[0] = value;
            }
        }

        public MyConstPropertyFloat Bounciness
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[5]);
            private set
            {
                this.m_properties[5] = value;
            }
        }

        public MyConstPropertyFloat CameraBias
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x2b]);
            private set
            {
                this.m_properties[0x2b] = value;
            }
        }

        public MyConstPropertyBool Collide
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x19]);
            private set
            {
                this.m_properties[0x19] = value;
            }
        }

        public MyConstPropertyInt CollisionCountToKill
        {
            get => 
                ((MyConstPropertyInt) this.m_properties[0x33]);
            private set
            {
                this.m_properties[0x33] = value;
            }
        }

        public MyAnimatedProperty2DVector4 Color
        {
            get => 
                ((MyAnimatedProperty2DVector4) this.m_properties[3]);
            private set
            {
                this.m_properties[3] = value;
            }
        }

        public MyAnimatedProperty2DFloat ColorIntensity
        {
            get => 
                ((MyAnimatedProperty2DFloat) this.m_properties[4]);
            private set
            {
                this.m_properties[4] = value;
            }
        }

        public MyConstPropertyVector3 Direction
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[8]);
            private set
            {
                this.m_properties[8] = value;
            }
        }

        public MyAnimatedPropertyFloat DirectionConeVar
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[12]);
            private set
            {
                this.m_properties[12] = value;
            }
        }

        public MyAnimatedPropertyFloat DirectionInnerCone
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[11]);
            private set
            {
                this.m_properties[11] = value;
            }
        }

        public MyConstPropertyFloat DistanceScalingFactor
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x34]);
            private set
            {
                this.m_properties[0x34] = value;
            }
        }

        public MyAnimatedProperty2DFloat Emissivity
        {
            get => 
                ((MyAnimatedProperty2DFloat) this.m_properties[0x2c]);
            private set
            {
                this.m_properties[0x2c] = value;
            }
        }

        public MyAnimatedPropertyVector3 EmitterSize
        {
            get => 
                ((MyAnimatedPropertyVector3) this.m_properties[6]);
            private set
            {
                this.m_properties[6] = value;
            }
        }

        public MyAnimatedPropertyFloat EmitterSizeMin
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[7]);
            private set
            {
                this.m_properties[7] = value;
            }
        }

        public MyConstPropertyBool Enabled
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x15]);
            private set
            {
                this.m_properties[0x15] = value;
            }
        }

        public MyConstPropertyFloat Gravity
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[30]);
            private set
            {
                this.m_properties[30] = value;
            }
        }

        public MyConstPropertyFloat HueVar
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x21]);
            private set
            {
                this.m_properties[0x21] = value;
            }
        }

        private bool IsDirty =>
            this.m_dirty;

        public MyConstPropertyFloat Life
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x11]);
            private set
            {
                this.m_properties[0x11] = value;
            }
        }

        public MyConstPropertyFloat LifeVar
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x24]);
            private set
            {
                this.m_properties[0x24] = value;
            }
        }

        public MyConstPropertyBool Light
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x1b]);
            private set
            {
                this.m_properties[0x1b] = value;
            }
        }

        public MyConstPropertyTransparentMaterial Material
        {
            get => 
                ((MyConstPropertyTransparentMaterial) this.m_properties[0x17]);
            private set
            {
                this.m_properties[0x17] = value;
            }
        }

        public MyConstPropertyFloat MotionInheritance
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x23]);
            private set
            {
                this.m_properties[0x23] = value;
            }
        }

        public string Name
        {
            get => 
                this.m_name;
            set
            {
                this.m_name = value;
            }
        }

        public MyConstPropertyVector3 Offset
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[0x1f]);
            private set
            {
                this.m_properties[0x1f] = value;
            }
        }

        public MyConstPropertyFloat OITWeightFactor
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x18]);
            private set
            {
                this.m_properties[0x18] = value;
            }
        }

        public MyAnimatedPropertyFloat ParticlesPerFrame
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x2a]);
            private set
            {
                this.m_properties[0x2a] = value;
            }
        }

        public MyAnimatedPropertyFloat ParticlesPerSecond
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x16]);
            private set
            {
                this.m_properties[0x16] = value;
            }
        }

        public MyAnimatedProperty2DFloat Radius
        {
            get => 
                ((MyAnimatedProperty2DFloat) this.m_properties[0x10]);
            private set
            {
                this.m_properties[0x10] = value;
            }
        }

        public MyConstPropertyFloat RadiusVar
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x31]);
            private set
            {
                this.m_properties[0x31] = value;
            }
        }

        public MyConstPropertyBool RotationEnabled
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x22]);
            private set
            {
                this.m_properties[0x22] = value;
            }
        }

        private MyRotationReference RotationReference
        {
            get => 
                ((MyRotationReference) ((MyConstPropertyInt) this.m_properties[0x26]));
            set
            {
                this.m_properties[0x26].SetValue((int) value);
            }
        }

        public MyConstPropertyFloat RotationVelocity
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[15]);
            private set
            {
                this.m_properties[15] = value;
            }
        }

        public MyConstPropertyFloat RotationVelocityCollisionMultiplier
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[50]);
            private set
            {
                this.m_properties[50] = value;
            }
        }

        public MyConstPropertyFloat RotationVelocityVar
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x20]);
            private set
            {
                this.m_properties[0x20] = value;
            }
        }

        public MyConstPropertyFloat ShadowAlphaMultiplier
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x2d]);
            private set
            {
                this.m_properties[0x2d] = value;
            }
        }

        public bool Show
        {
            get => 
                this.m_show;
            set
            {
                this.m_show = value;
                this.SetDirty();
            }
        }

        public MyConstPropertyBool SleepState
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x1a]);
            private set
            {
                this.m_properties[0x1a] = value;
            }
        }

        public MyConstPropertyFloat SoftParticleDistanceScale
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x12]);
            private set
            {
                this.m_properties[0x12] = value;
            }
        }

        public MyConstPropertyFloat StreakMultiplier
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x13]);
            private set
            {
                this.m_properties[0x13] = value;
            }
        }

        public MyConstPropertyBool Streaks
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x25]);
            private set
            {
                this.m_properties[0x25] = value;
            }
        }

        public MyConstPropertyFloat TargetCoverage
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x1d]);
            private set
            {
                this.m_properties[0x1d] = value;
            }
        }

        public MyAnimatedProperty2DFloat Thickness
        {
            get => 
                ((MyAnimatedProperty2DFloat) this.m_properties[0x29]);
            private set
            {
                this.m_properties[0x29] = value;
            }
        }

        public MyConstPropertyBool UseAlphaAnisotropy
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x2f]);
            private set
            {
                this.m_properties[0x2f] = value;
            }
        }

        public MyConstPropertyBool UseEmissivityChannel
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x2e]);
            private set
            {
                this.m_properties[0x2e] = value;
            }
        }

        public MyAnimatedPropertyFloat Velocity
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[9]);
            private set
            {
                this.m_properties[9] = value;
            }
        }

        public MyAnimatedPropertyFloat VelocityVar
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[10]);
            private set
            {
                this.m_properties[10] = value;
            }
        }

        public MyConstPropertyBool VolumetricLight
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x1c]);
            private set
            {
                this.m_properties[0x1c] = value;
            }
        }

        private enum MyGPUGenerationPropertiesEnum
        {
            ArraySize,
            ArrayOffset,
            ArrayModulo,
            Color,
            ColorIntensity,
            Bounciness,
            EmitterSize,
            EmitterSizeMin,
            Direction,
            Velocity,
            VelocityVar,
            DirectionInnerCone,
            DirectionConeVar,
            Acceleration,
            AccelerationFactor,
            RotationVelocity,
            Radius,
            Life,
            SoftParticleDistanceScale,
            StreakMultiplier,
            AnimationFrameTime,
            Enabled,
            ParticlesPerSecond,
            Material,
            OITWeightFactor,
            Collide,
            SleepState,
            Light,
            VolumetricLight,
            TargetCoverage,
            Gravity,
            Offset,
            RotationVelocityVar,
            HueVar,
            RotationEnabled,
            MotionInheritance,
            LifeVar,
            Streaks,
            RotationReference,
            Angle,
            AngleVar,
            Thickness,
            ParticlesPerFrame,
            CameraBias,
            Emissivity,
            ShadowAlphaMultiplier,
            UseEmissivityChannel,
            UseAlphaAnisotropy,
            AmbientFactor,
            RadiusVar,
            RotationVelocityCollisionMultiplier,
            CollisionCountToKill,
            DistanceScalingFactor,
            NumMembers
        }

        private enum MyRotationReference
        {
            Camera,
            Local,
            LocalAndCamera
        }
    }
}

