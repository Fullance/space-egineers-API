namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Xml;
    using VRage.Utils;
    using VRageMath;
    using VRageRender;
    using VRageRender.Animations;
    using VRageRender.Utils;

    public class MyParticleGeneration : IMyParticleGeneration
    {
        private BoundingBoxD m_AABB = new BoundingBoxD();
        private readonly List<MyBillboard> m_billboards = new List<MyBillboard>();
        private float m_birthPerFrame;
        private float m_birthRate;
        private MyParticleEffect m_effect;
        private readonly MyParticleEmitter m_emitter = new MyParticleEmitter(MyParticleEmitterType.Point);
        private Vector3D? m_lastEffectPosition;
        private string m_name;
        private readonly List<MyAnimatedParticle> m_particles = new List<MyAnimatedParticle>(0x40);
        private float m_particlesToCreate;
        private readonly IMyConstProperty[] m_properties = new IMyConstProperty[Enum.GetValues(typeof(MyGenerationPropertiesEnum)).Length];
        private bool m_show = true;
        private static readonly MyStringId m_smokeStringId = MyStringId.GetOrCompute("Smoke");
        private static readonly string[] MyAccelerationReferenceStrings = new string[] { "Local", "Camera", "Velocity", "Gravity" };
        private static readonly string[] MyBlendTypeStrings = new string[] { MyBillboard.BlendTypeEnum.Standard.ToString(), MyBillboard.BlendTypeEnum.AdditiveBottom.ToString(), MyBillboard.BlendTypeEnum.AdditiveTop.ToString() };
        private static readonly string[] MyParticleTypeStrings = new string[] { "Point", "Line", "Trail" };
        private static readonly string[] MyRotationReferenceStrings = new string[] { "Camera", "Local", "Velocity", "Velocity and camera", "Local and camera" };
        private static readonly string[] MyVelocityDirStrings = new string[] { "Default", "FromEmitterCenter" };
        private static readonly List<string> s_accelerationReferenceStrings = MyAccelerationReferenceStrings.ToList<string>();
        private static readonly List<string> s_blendTypeStrings = MyBlendTypeStrings.ToList<string>();
        private static readonly List<string> s_particleTypeStrings = MyParticleTypeStrings.ToList<string>();
        private static readonly List<string> s_rotationReferenceStrings = MyRotationReferenceStrings.ToList<string>();
        private static readonly List<string> s_velocityDirStrings = MyVelocityDirStrings.ToList<string>();
        private static readonly int Version = 4;

        private T AddProperty<T>(MyGenerationPropertiesEnum e, T property) where T: IMyConstProperty
        {
            this.m_properties[(int) e] = property;
            return property;
        }

        public void Clear()
        {
            int num = 0;
            while (num < this.m_particles.Count)
            {
                MyAnimatedParticle item = this.m_particles[num];
                this.m_particles.Remove(item);
                MyTransparentGeometry.DeallocateAnimatedParticle(item);
            }
            this.m_particlesToCreate = 0f;
            this.m_lastEffectPosition = new Vector3D?(this.m_effect.WorldMatrix.Translation);
        }

        public void Close()
        {
            this.Clear();
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                this.m_properties[i] = null;
            }
            this.m_emitter.Close();
            this.m_effect = null;
        }

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

        private void ConvertSRGBColors()
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
                    vector3 = Vector4.Clamp(vector3.UnmultiplyColor().ToLinearRGB().PremultiplyColor(), new Vector4(0f, 0f, 0f, 0f), new Vector4(1f, 1f, 1f, 1f));
                    property.SetKey(j, num2, vector3);
                }
            }
        }

        public IMyParticleGeneration CreateInstance(MyParticleEffect effect)
        {
            MyParticleGeneration generation;
            MyParticlesManager.GenerationsPool.AllocateOrCreate(out generation);
            generation.Start(effect);
            generation.Name = this.Name;
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                generation.m_properties[i] = this.m_properties[i];
            }
            generation.m_emitter.CreateInstance(this.m_emitter);
            return generation;
        }

        private void CreateParticle(Vector3D interpolatedEffectPosition)
        {
            MyAnimatedParticle item = MyTransparentGeometry.AddAnimatedParticle();
            if (item != null)
            {
                Vector3D vectord;
                Vector3 vector;
                float num6;
                float num8;
                item.Type = (MyParticleTypeEnum) ((byte) this.ParticleType.GetValue<int>());
                item.BlendType = this.BlendType.GetValue<int>();
                this.m_emitter.CalculateStartPosition(this.m_effect.GetElapsedTime(), MatrixD.CreateWorld(interpolatedEffectPosition, this.m_effect.WorldMatrix.Forward, this.m_effect.WorldMatrix.Up), this.m_effect.GetEmitterAxisScale(), this.m_effect.GetEmitterScale(), out vectord, out item.StartPosition);
                Vector3D startPosition = item.StartPosition;
                this.m_AABB = this.m_AABB.Include(ref startPosition);
                this.Life.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out item.Life);
                float lifeVar = (float) this.LifeVar;
                if (lifeVar > 0f)
                {
                    item.Life = MathHelper.Max(MyUtils.GetRandomFloat(item.Life - lifeVar, item.Life + lifeVar), 0.1f);
                }
                this.Velocity.GetInterpolatedValue<Vector3>(this.m_effect.GetElapsedTime(), out vector);
                if (this.VelocityVar.GetKeysCount() > 0)
                {
                    float randomFloat;
                    this.VelocityVar.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out randomFloat);
                    if (randomFloat != 0f)
                    {
                        float minValue = 1f / randomFloat;
                        float maxValue = randomFloat;
                        randomFloat = MyUtils.GetRandomFloat(minValue, maxValue);
                        vector = (Vector3) (vector * (this.m_effect.GetScale() * randomFloat));
                    }
                    else
                    {
                        vector = (Vector3) (vector * this.m_effect.GetScale());
                    }
                }
                else
                {
                    vector = (Vector3) (vector * this.m_effect.GetScale());
                }
                item.Velocity = vector;
                item.Velocity = (Vector3) Vector3D.TransformNormal(item.Velocity, this.GetEffect().WorldMatrix);
                if ((this.VelocityDir == MyVelocityDirEnum.FromEmitterCenter) && !MyUtils.IsZero(vectord - item.StartPosition, 1E-05f))
                {
                    float num5 = item.Velocity.Length();
                    item.Velocity = (Vector3) (MyUtils.Normalize(item.StartPosition - vectord) * num5);
                }
                this.Angle.GetInterpolatedValue<Vector3>(this.m_effect.GetElapsedTime(), out item.Angle);
                Vector3 angleVar = (Vector3) this.AngleVar;
                if (angleVar.LengthSquared() > 0f)
                {
                    float x = MyUtils.GetRandomFloat(item.Angle.X - angleVar.X, item.Angle.X + angleVar.X);
                    float y = MyUtils.GetRandomFloat(item.Angle.Y - angleVar.Y, item.Angle.Y + angleVar.Y);
                    item.Angle = new Vector3(x, y, MyUtils.GetRandomFloat(item.Angle.Z - angleVar.Z, item.Angle.Z + angleVar.Z));
                }
                if (this.RotationSpeed.GetKeysCount() > 0)
                {
                    item.RotationSpeed = new MyAnimatedPropertyVector3(this.RotationSpeed.Name);
                    Vector3 rotationSpeedVar = (Vector3) this.RotationSpeedVar;
                    this.RotationSpeed.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), rotationSpeedVar, 1f, item.RotationSpeed);
                }
                else
                {
                    item.RotationSpeed = null;
                }
                this.RadiusVar.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out num6);
                float num7 = 1f;
                if (this.GetEffect().EnableLods)
                {
                    this.LODRadius.GetInterpolatedValue<float>(this.GetEffect().Distance, out num7);
                }
                this.Radius.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), num6, ((this.EnableCustomRadius.GetValue<bool>() ? this.m_effect.UserRadiusMultiplier : 1f) * num7) * this.m_effect.GetScale(), item.Radius);
                this.Thickness.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out item.Thickness);
                item.Thickness *= num7;
                this.ColorVar.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out num8);
                this.Color.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), num8, 1f, item.Color);
                this.ColorIntensity.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out item.ColorIntensity);
                item.SoftParticleDistanceScale = (float) this.SoftParticleDistanceScale;
                this.Material.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 0, 1f, item.Material);
                if (this.Pivot.GetKeysCount() > 0)
                {
                    item.Pivot = new MyAnimatedPropertyVector3(this.Pivot.Name);
                    this.Pivot.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), (Vector3) this.PivotVar, 1f, item.Pivot);
                }
                else
                {
                    item.Pivot = null;
                }
                if (this.PivotRotation.GetKeysCount() > 0)
                {
                    item.PivotRotation = new MyAnimatedPropertyVector3(this.PivotRotation.Name);
                    this.PivotRotation.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), (Vector3) this.PivotRotationVar, 1f, item.PivotRotation);
                }
                else
                {
                    item.PivotRotation = null;
                }
                if (this.Acceleration.GetKeysCount() > 0)
                {
                    item.Acceleration = new MyAnimatedPropertyVector3(this.Acceleration.Name);
                    float multiplier = MyUtils.GetRandomFloat(1f - ((float) this.AccelerationVar), 1f + ((float) this.AccelerationVar));
                    this.Acceleration.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), multiplier, item.Acceleration);
                }
                else
                {
                    item.Acceleration = null;
                }
                if (this.AlphaCutout.GetKeysCount() > 0)
                {
                    item.AlphaCutout = new MyAnimatedPropertyFloat(this.AlphaCutout.Name);
                    this.AlphaCutout.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 0f, 1f, item.AlphaCutout);
                }
                else
                {
                    item.AlphaCutout = null;
                }
                if (this.ArrayIndex.GetKeysCount() > 0)
                {
                    item.ArrayIndex = new MyAnimatedPropertyInt(this.ArrayIndex.Name);
                    this.ArrayIndex.GetInterpolatedKeys(this.m_effect.GetElapsedTime(), 0, 1f, item.ArrayIndex);
                }
                else
                {
                    item.ArrayIndex = null;
                }
                item.Start(this);
                this.m_particles.Add(item);
            }
        }

        public void Deallocate()
        {
            MyParticlesManager.GenerationsPool.Deallocate(this);
        }

        public void DebugDraw()
        {
            this.m_emitter.DebugDraw(this.m_effect.GetElapsedTime(), (Matrix) this.m_effect.WorldMatrix);
        }

        public void Deserialize(XmlReader reader)
        {
            this.m_name = reader.GetAttribute("name");
            int num = Convert.ToInt32(reader.GetAttribute("version"), CultureInfo.InvariantCulture);
            switch (num)
            {
                case 0:
                    this.DeserializeV0(reader);
                    this.ConvertSRGBColors();
                    return;

                case 1:
                    this.DeserializeV1(reader);
                    this.ConvertSRGBColors();
                    return;

                default:
                    reader.ReadStartElement();
                    foreach (IMyConstProperty property in this.m_properties)
                    {
                        if (reader.Name == "Emitter")
                        {
                            break;
                        }
                        property.Deserialize(reader);
                        if (property.Name == "Target coverage")
                        {
                            property.Name = "Soft particle distance scale";
                        }
                    }
                    break;
            }
            reader.ReadStartElement();
            this.m_emitter.Deserialize(reader);
            reader.ReadEndElement();
            reader.ReadEndElement();
            if (this.LODBirth.GetKeysCount() > 0)
            {
                float num2;
                float num3;
                this.LODBirth.GetKey(this.LODBirth.GetKeysCount() - 1, out num2, out num3);
                if (num3 > 0f)
                {
                    this.LODBirth.AddKey<float>(Math.Max((float) (num2 + 0.25f), (float) 1f), 0f);
                }
            }
            switch (num)
            {
                case 2:
                    this.ConvertSRGBColors();
                    break;

                case 3:
                    this.ConvertAlphaColors();
                    break;
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
            this.m_emitter.DeserializeFromObjectBuilder(generation.Emitter);
            if (this.LODBirth.GetKeysCount() > 0)
            {
                float num2;
                float num3;
                this.LODBirth.GetKey(this.LODBirth.GetKeysCount() - 1, out num2, out num3);
                if (num3 > 0f)
                {
                    this.LODBirth.AddKey<float>(Math.Max((float) (num2 + 0.25f), (float) 1f), 0f);
                }
            }
        }

        public void DeserializeV0(XmlReader reader)
        {
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                if (reader.Name == "Emitter")
                {
                    break;
                }
                IMyConstProperty property2 = property;
                if ((property2.Name == "Angle") || (property2.Name == "Rotation speed"))
                {
                    property2 = new MyAnimatedPropertyFloat();
                }
                if ((property2.Name == "Angle var") || (property2.Name == "Rotation speed var"))
                {
                    property2 = new MyConstPropertyFloat();
                }
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "PivotDistance"))
                {
                    new MyAnimatedProperty2DFloat("temp").Deserialize(reader);
                }
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "PivotDistVar"))
                {
                    new MyConstPropertyFloat().Deserialize(reader);
                }
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "Pivot distance"))
                {
                    new MyAnimatedProperty2DFloat("temp").Deserialize(reader);
                }
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "Pivot distance var"))
                {
                    new MyConstPropertyFloat().Deserialize(reader);
                }
                property2.Deserialize(reader);
            }
            reader.ReadStartElement();
            this.m_emitter.Deserialize(reader);
            reader.ReadEndElement();
            reader.ReadEndElement();
            if (this.LODBirth.GetKeysCount() > 0)
            {
                float num5;
                float num6;
                this.LODBirth.GetKey(this.LODBirth.GetKeysCount() - 1, out num5, out num6);
                if (num6 > 0f)
                {
                    this.LODBirth.AddKey<float>(Math.Max((float) (num5 + 0.25f), (float) 1f), 0f);
                }
            }
            if (this.ParticleType != 1)
            {
                this.Thickness.ClearKeys();
            }
        }

        public void DeserializeV1(XmlReader reader)
        {
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                if (reader.Name == "Emitter")
                {
                    break;
                }
                IMyConstProperty property2 = property;
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "PivotDistance"))
                {
                    new MyAnimatedProperty2DFloat("temp").Deserialize(reader);
                }
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "PivotDistVar"))
                {
                    new MyConstPropertyFloat().Deserialize(reader);
                }
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "Pivot distance"))
                {
                    new MyAnimatedProperty2DFloat("temp").Deserialize(reader);
                }
                if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "Pivot distance var"))
                {
                    new MyConstPropertyFloat().Deserialize(reader);
                }
                property2.Deserialize(reader);
            }
            reader.ReadStartElement();
            this.m_emitter.Deserialize(reader);
            reader.ReadEndElement();
            reader.ReadEndElement();
            if (this.LODBirth.GetKeysCount() > 0)
            {
                float num5;
                float num6;
                this.LODBirth.GetKey(this.LODBirth.GetKeysCount() - 1, out num5, out num6);
                if (num6 > 0f)
                {
                    this.LODBirth.AddKey<float>(Math.Max((float) (num5 + 0.25f), (float) 1f), 0f);
                }
            }
            if (this.ParticleType != 1)
            {
                this.Thickness.ClearKeys();
            }
        }

        public void Done()
        {
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                if (this.m_properties[i] is IMyAnimatedProperty)
                {
                    (this.m_properties[i] as IMyAnimatedProperty).ClearKeys();
                }
            }
            this.m_emitter.Done();
            this.Close();
        }

        public void Draw(List<MyBillboard> collectedBillboards)
        {
            this.PrepareForDraw();
            foreach (MyBillboard billboard in this.m_billboards)
            {
                collectedBillboards.Add(billboard);
            }
            this.m_billboards.Clear();
        }

        public IMyParticleGeneration Duplicate(MyParticleEffect effect)
        {
            MyParticleGeneration generation;
            MyParticlesManager.GenerationsPool.AllocateOrCreate(out generation);
            generation.Start(effect);
            generation.Name = this.Name;
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                generation.m_properties[i] = this.m_properties[i].Duplicate();
            }
            this.m_emitter.Duplicate(generation.m_emitter);
            return generation;
        }

        public float GetBirthRate() => 
            this.m_birthRate;

        public MyParticleEffect GetEffect() => 
            this.m_effect;

        public MyParticleEmitter GetEmitter() => 
            this.m_emitter;

        private IMyParticleGeneration GetInheritedGeneration(int generationIndex)
        {
            if ((generationIndex < this.m_effect.GetGenerations().Count) && (generationIndex != this.m_effect.GetGenerations().IndexOf(this)))
            {
                return this.m_effect.GetGenerations()[generationIndex];
            }
            return null;
        }

        public IEnumerable<IMyConstProperty> GetProperties() => 
            this.m_properties;

        public void Init()
        {
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.Birth, new MyAnimatedPropertyFloat("Birth"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.Life, new MyAnimatedPropertyFloat("Life"));
            this.AddProperty<MyConstPropertyFloat>(MyGenerationPropertiesEnum.LifeVar, new MyConstPropertyFloat("Life var"));
            this.AddProperty<MyAnimatedPropertyVector3>(MyGenerationPropertiesEnum.Velocity, new MyAnimatedPropertyVector3("Velocity"));
            this.AddProperty<MyConstPropertyEnum>(MyGenerationPropertiesEnum.VelocityDir, new MyConstPropertyEnum("Velocity dir", typeof(MyVelocityDirEnum), s_velocityDirStrings));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.VelocityVar, new MyAnimatedPropertyFloat("Velocity var"));
            this.AddProperty<MyAnimatedPropertyVector3>(MyGenerationPropertiesEnum.Angle, new MyAnimatedPropertyVector3("Angle"));
            this.AddProperty<MyConstPropertyVector3>(MyGenerationPropertiesEnum.AngleVar, new MyConstPropertyVector3("Angle var"));
            this.AddProperty<MyAnimatedProperty2DVector3>(MyGenerationPropertiesEnum.RotationSpeed, new MyAnimatedProperty2DVector3("Rotation speed"));
            this.AddProperty<MyConstPropertyVector3>(MyGenerationPropertiesEnum.RotationSpeedVar, new MyConstPropertyVector3("Rotation speed var"));
            this.AddProperty<MyAnimatedProperty2DFloat>(MyGenerationPropertiesEnum.Radius, new MyAnimatedProperty2DFloat("Radius"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.RadiusVar, new MyAnimatedPropertyFloat("Radius var"));
            this.AddProperty<MyAnimatedProperty2DVector4>(MyGenerationPropertiesEnum.Color, new MyAnimatedProperty2DVector4("Color"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.ColorVar, new MyAnimatedPropertyFloat("Color var"));
            this.AddProperty<MyAnimatedProperty2DTransparentMaterial>(MyGenerationPropertiesEnum.Material, new MyAnimatedProperty2DTransparentMaterial("Material", new MyAnimatedProperty<MyTransparentMaterial>.InterpolatorDelegate(MyTransparentMaterialInterpolator.Switch)));
            this.AddProperty<MyConstPropertyEnum>(MyGenerationPropertiesEnum.ParticleType, new MyConstPropertyEnum("Particle type", typeof(MyParticleTypeEnum), s_particleTypeStrings));
            this.AddProperty<MyConstPropertyEnum>(MyGenerationPropertiesEnum.BlendType, new MyConstPropertyEnum("Blend type", typeof(MyBillboard.BlendTypeEnum), s_blendTypeStrings));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.Thickness, new MyAnimatedPropertyFloat("Thickness"));
            this.AddProperty<MyConstPropertyBool>(MyGenerationPropertiesEnum.Enabled, new MyConstPropertyBool("Enabled"));
            this.Enabled.SetValue(true);
            this.AddProperty<MyConstPropertyBool>(MyGenerationPropertiesEnum.EnableCustomRadius, new MyConstPropertyBool("Enable custom radius"));
            this.AddProperty<MyConstPropertyBool>(MyGenerationPropertiesEnum.EnableCustomVelocity, new MyConstPropertyBool("Enable custom velocity"));
            this.AddProperty<MyConstPropertyBool>(MyGenerationPropertiesEnum.EnableCustomBirth, new MyConstPropertyBool("Enable custom birth"));
            this.AddProperty<MyConstPropertyGenerationIndex>(MyGenerationPropertiesEnum.OnDie, new MyConstPropertyGenerationIndex("OnDie"));
            this.OnDie.SetValue(-1);
            this.AddProperty<MyConstPropertyGenerationIndex>(MyGenerationPropertiesEnum.OnLife, new MyConstPropertyGenerationIndex("OnLife"));
            this.OnLife.SetValue(-1);
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.LODBirth, new MyAnimatedPropertyFloat("LODBirth"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.LODRadius, new MyAnimatedPropertyFloat("LODRadius"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.MotionInheritance, new MyAnimatedPropertyFloat("Motion inheritance"));
            this.AddProperty<MyConstPropertyBool>(MyGenerationPropertiesEnum.AlphaAnisotropic, new MyConstPropertyBool("Alpha anisotropic"));
            this.AddProperty<MyConstPropertyFloat>(MyGenerationPropertiesEnum.Gravity, new MyConstPropertyFloat("Gravity"));
            this.AddProperty<MyAnimatedProperty2DVector3>(MyGenerationPropertiesEnum.PivotRotation, new MyAnimatedProperty2DVector3("Pivot rotation"));
            this.AddProperty<MyAnimatedProperty2DVector3>(MyGenerationPropertiesEnum.Acceleration, new MyAnimatedProperty2DVector3("Acceleration"));
            this.AddProperty<MyConstPropertyFloat>(MyGenerationPropertiesEnum.AccelerationVar, new MyConstPropertyFloat("Acceleration var"));
            this.AddProperty<MyAnimatedProperty2DFloat>(MyGenerationPropertiesEnum.AlphaCutout, new MyAnimatedProperty2DFloat("Alpha cutout"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.BirthPerFrame, new MyAnimatedPropertyFloat("Birth per frame"));
            this.AddProperty<MyConstPropertyFloat>(MyGenerationPropertiesEnum.RadiusBySpeed, new MyConstPropertyFloat("Radius by speed"));
            this.AddProperty<MyConstPropertyFloat>(MyGenerationPropertiesEnum.SoftParticleDistanceScale, new MyConstPropertyFloat("Soft particle distance scale"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyGenerationPropertiesEnum.ColorIntensity, new MyAnimatedPropertyFloat("Color intensity"));
            this.AddProperty<MyAnimatedProperty2DVector3>(MyGenerationPropertiesEnum.Pivot, new MyAnimatedProperty2DVector3("Pivot"));
            this.AddProperty<MyConstPropertyVector3>(MyGenerationPropertiesEnum.PivotVar, new MyConstPropertyVector3("Pivot var"));
            this.AddProperty<MyConstPropertyVector3>(MyGenerationPropertiesEnum.PivotRotationVar, new MyConstPropertyVector3("Pivot rotation var"));
            this.AddProperty<MyConstPropertyEnum>(MyGenerationPropertiesEnum.RotationReference, new MyConstPropertyEnum("Rotation reference", typeof(VRage.Game.MyRotationReference), s_rotationReferenceStrings));
            this.AddProperty<MyConstPropertyVector3>(MyGenerationPropertiesEnum.ArraySize, new MyConstPropertyVector3("Array size"));
            this.AddProperty<MyAnimatedProperty2DInt>(MyGenerationPropertiesEnum.ArrayIndex, new MyAnimatedProperty2DInt("Array index"));
            this.AddProperty<MyConstPropertyInt>(MyGenerationPropertiesEnum.ArrayOffset, new MyConstPropertyInt("Array offset"));
            this.AddProperty<MyConstPropertyInt>(MyGenerationPropertiesEnum.ArrayModulo, new MyConstPropertyInt("Array modulo"));
            this.AddProperty<MyConstPropertyEnum>(MyGenerationPropertiesEnum.AccelerationReference, new MyConstPropertyEnum("Acceleration reference", typeof(MyAccelerationReference), s_accelerationReferenceStrings));
            this.LODBirth.AddKey<float>(0f, 1f);
            this.LODRadius.AddKey<float>(0f, 1f);
            MyAnimatedPropertyVector3 val = new MyAnimatedPropertyVector3(this.Pivot.Name);
            val.AddKey<Vector3>(0f, new Vector3(0f, 0f, 0f));
            this.Pivot.AddKey<MyAnimatedPropertyVector3>(0f, val);
            this.AccelerationVar.SetValue(0f);
            this.ColorIntensity.AddKey<float>(0f, 1f);
            this.SoftParticleDistanceScale.SetValue(1f);
            this.m_emitter.Init();
        }

        public void InitDefault()
        {
            this.Birth.AddKey<float>(0f, 1f);
            this.Life.AddKey<float>(0f, 10f);
            this.Velocity.AddKey<Vector3>(0f, new Vector3(0f, 1f, 0f));
            MyAnimatedPropertyVector4 val = new MyAnimatedPropertyVector4(this.Color.Name);
            val.AddKey<Vector4>(0f, new Vector4(1f, 0f, 0f, 1f));
            val.AddKey<Vector4>(1f, new Vector4(0f, 0f, 1f, 1f));
            this.Color.AddKey<MyAnimatedPropertyVector4>(0f, val);
            MyAnimatedPropertyFloat num = new MyAnimatedPropertyFloat(this.Radius.Name);
            num.AddKey<float>(0f, 1f);
            this.Radius.AddKey<MyAnimatedPropertyFloat>(0f, num);
            MyAnimatedPropertyTransparentMaterial material = new MyAnimatedPropertyTransparentMaterial(this.Material.Name);
            material.AddKey<MyTransparentMaterial>(0f, MyTransparentMaterials.GetMaterial(m_smokeStringId));
            this.Material.AddKey<MyAnimatedPropertyTransparentMaterial>(0f, material);
            this.LODBirth.AddKey<float>(0f, 1f);
            this.LODBirth.AddKey<float>(0.5f, 1f);
            this.LODBirth.AddKey<float>(1f, 0f);
            this.LODRadius.AddKey<float>(0f, 1f);
            MyAnimatedPropertyVector3 vector2 = new MyAnimatedPropertyVector3(this.Pivot.Name);
            vector2.AddKey<Vector3>(0f, new Vector3(0f, 0f, 0f));
            this.Pivot.AddKey<MyAnimatedPropertyVector3>(0f, vector2);
            this.AccelerationVar.SetValue(0f);
            this.SoftParticleDistanceScale.SetValue(1f);
            this.BlendType.SetValue(MyBillboard.BlendTypeEnum.Standard);
        }

        public void MergeAABB(ref BoundingBoxD aabb)
        {
            aabb.Include(ref this.m_AABB);
        }

        private void PrepareForDraw()
        {
            this.m_billboards.Clear();
            if (this.m_particles.Count != 0)
            {
                foreach (MyAnimatedParticle particle in this.m_particles)
                {
                    MyBillboard item = MyTransparentGeometry.AddBillboardParticle(particle);
                    if (item != null)
                    {
                        this.m_billboards.Add(item);
                    }
                }
            }
        }

        public void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement("ParticleGeneration");
            writer.WriteAttributeString("Name", this.Name);
            writer.WriteAttributeString("Version", Version.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("GenerationType", "CPU");
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
            writer.WriteStartElement("Emitter");
            this.m_emitter.Serialize(writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void SetAnimDirty()
        {
        }

        public void SetDirty()
        {
        }

        public void SetVelocityDir(MyVelocityDirEnum val)
        {
            this.VelocityDir = val;
        }

        public void Start(MyParticleEffect effect)
        {
            this.m_effect = effect;
            this.m_name = "ParticleGeneration";
            this.m_emitter.Start();
            this.m_lastEffectPosition = null;
            this.IsInherited = false;
            this.m_birthRate = 0f;
            this.m_particlesToCreate = 0f;
            this.m_AABB = BoundingBoxD.CreateInvalid();
        }

        public void Update()
        {
            this.EffectMatrix = this.m_effect.WorldMatrix;
            this.m_birthRate = 0f;
            this.UpdateParticlesLife();
            if (!this.IsInherited)
            {
                this.UpdateParticlesCreation();
            }
            this.m_effect.ParticlesCount += this.m_particles.Count;
        }

        private void UpdateParticlesCreation()
        {
            if (this.Enabled.GetValue<bool>() && this.m_show)
            {
                if (!this.m_effect.CalculateDeltaMatrix)
                {
                    float num;
                    this.MotionInheritance.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out num);
                    if (num > 0f)
                    {
                        this.m_effect.CalculateDeltaMatrix = true;
                    }
                }
                if (!this.m_effect.IsEmittingStopped)
                {
                    float num2 = 1f;
                    if (this.GetEffect().EnableLods && (this.LODBirth.GetKeysCount() > 0))
                    {
                        this.LODBirth.GetInterpolatedValue<float>(this.GetEffect().Distance, out num2);
                    }
                    this.Birth.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out this.m_birthRate);
                    this.m_birthRate *= (0.01666667f * ((this.EnableCustomBirth != null) ? this.m_effect.UserBirthMultiplier : 1f)) * num2;
                    if (this.BirthPerFrame.GetKeysCount() > 0)
                    {
                        float num3;
                        float num4;
                        this.BirthPerFrame.GetNextValue(this.m_effect.GetElapsedTime() - 0.01666667f, out this.m_birthPerFrame, out num3, out num4);
                        if ((num3 >= (this.m_effect.GetElapsedTime() - 0.01666667f)) && (num3 < this.m_effect.GetElapsedTime()))
                        {
                            this.m_birthPerFrame *= ((this.EnableCustomBirth != null) ? this.m_effect.UserBirthMultiplier : 1f) * num2;
                        }
                        else
                        {
                            this.m_birthPerFrame = 0f;
                        }
                    }
                    this.m_particlesToCreate += this.m_birthRate;
                }
                Vector3 zero = Vector3.Zero;
                if (!this.m_lastEffectPosition.HasValue)
                {
                    this.m_lastEffectPosition = new Vector3D?(this.EffectMatrix.Translation);
                }
                if ((this.m_particlesToCreate > 1f) && !this.m_effect.CalculateDeltaMatrix)
                {
                    zero = (Vector3) ((this.EffectMatrix.Translation - this.m_lastEffectPosition.Value) / ((double) ((int) this.m_particlesToCreate)));
                }
                int num5 = 40;
                while ((this.m_particlesToCreate >= 1f) && (num5-- > 0))
                {
                    if (this.m_effect.CalculateDeltaMatrix)
                    {
                        this.CreateParticle(this.EffectMatrix.Translation);
                    }
                    else
                    {
                        this.CreateParticle(this.m_lastEffectPosition.Value + (zero * ((int) this.m_particlesToCreate)));
                    }
                    this.m_particlesToCreate--;
                }
                while ((this.m_birthPerFrame >= 1f) && (num5-- > 0))
                {
                    if (this.m_effect.CalculateDeltaMatrix)
                    {
                        this.CreateParticle(this.EffectMatrix.Translation);
                    }
                    else
                    {
                        this.CreateParticle(this.m_lastEffectPosition.Value + (zero * ((int) this.m_birthPerFrame)));
                    }
                    this.m_birthPerFrame--;
                }
                if (this.OnLife.GetValue<int>() != -1)
                {
                    MyParticleGeneration inheritedGeneration = this.GetInheritedGeneration(this.OnLife.GetValue<int>()) as MyParticleGeneration;
                    if (inheritedGeneration == null)
                    {
                        this.OnLife.SetValue(-1);
                    }
                    else
                    {
                        inheritedGeneration.IsInherited = true;
                        float particlesToCreate = inheritedGeneration.m_particlesToCreate;
                        foreach (MyAnimatedParticle particle in this.m_particles)
                        {
                            inheritedGeneration.m_particlesToCreate = particlesToCreate;
                            inheritedGeneration.EffectMatrix = MatrixD.CreateWorld(particle.ActualPosition, particle.Velocity, Vector3D.Cross(Vector3D.Left, particle.Velocity));
                            inheritedGeneration.UpdateParticlesCreation();
                        }
                    }
                }
                this.m_lastEffectPosition = new Vector3D?(this.EffectMatrix.Translation);
            }
        }

        private void UpdateParticlesLife()
        {
            int num = 0;
            MyParticleGeneration inheritedGeneration = null;
            Vector3D translation = this.m_effect.WorldMatrix.Translation;
            float particlesToCreate = 0f;
            this.m_AABB = BoundingBoxD.CreateInvalid();
            this.m_AABB = this.m_AABB.Include(ref translation);
            if (this.OnDie.GetValue<int>() != -1)
            {
                inheritedGeneration = this.GetInheritedGeneration(this.OnDie.GetValue<int>()) as MyParticleGeneration;
                if (inheritedGeneration == null)
                {
                    this.OnDie.SetValue(-1);
                }
                else
                {
                    inheritedGeneration.IsInherited = true;
                    particlesToCreate = inheritedGeneration.m_particlesToCreate;
                }
            }
            Vector3D vectord2 = translation;
            Vector3D vectord3 = translation;
            while (num < this.m_particles.Count)
            {
                float num3;
                this.MotionInheritance.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime(), out num3);
                MyAnimatedParticle item = this.m_particles[num];
                if (item.Update())
                {
                    if (num3 > 0f)
                    {
                        MatrixD deltaMatrix = this.m_effect.GetDeltaMatrix();
                        item.AddMotionInheritance(ref num3, ref deltaMatrix);
                    }
                    if (num == 0)
                    {
                        translation = item.ActualPosition;
                        vectord2 = item.Quad.Point1;
                        vectord3 = item.Quad.Point2;
                        item.Quad.Point0 = item.ActualPosition;
                        item.Quad.Point2 = item.ActualPosition;
                    }
                    num++;
                    if (item.Type == MyParticleTypeEnum.Trail)
                    {
                        if (item.ActualPosition == translation)
                        {
                            item.Quad.Point0 = item.ActualPosition;
                            item.Quad.Point1 = item.ActualPosition;
                            item.Quad.Point2 = item.ActualPosition;
                            item.Quad.Point3 = item.ActualPosition;
                        }
                        else
                        {
                            float num4;
                            MyPolyLineD polyLine = new MyPolyLineD();
                            item.Radius.GetInterpolatedValue<float>(item.NormalizedTime, out num4);
                            polyLine.Thickness = num4;
                            polyLine.Point0 = item.ActualPosition;
                            polyLine.Point1 = translation;
                            Vector3D vectord1 = polyLine.Point1 - polyLine.Point0;
                            Vector3D vectord4 = MyUtils.Normalize(polyLine.Point1 - polyLine.Point0);
                            polyLine.LineDirectionNormalized = (Vector3) vectord4;
                            Vector3D cameraPosition = MyTransparentGeometry.Camera.Translation;
                            MyUtils.GetPolyLineQuad(out item.Quad, ref polyLine, cameraPosition);
                            item.Quad.Point0 = vectord2;
                            item.Quad.Point3 = vectord3;
                            vectord2 = item.Quad.Point1;
                            vectord3 = item.Quad.Point2;
                        }
                    }
                    translation = item.ActualPosition;
                    this.m_AABB = this.m_AABB.Include(ref translation);
                }
                else
                {
                    if (inheritedGeneration != null)
                    {
                        inheritedGeneration.m_particlesToCreate = particlesToCreate;
                        inheritedGeneration.EffectMatrix = MatrixD.CreateWorld(item.ActualPosition, Vector3D.Normalize(item.Velocity), Vector3D.Cross(Vector3D.Left, item.Velocity));
                        inheritedGeneration.UpdateParticlesCreation();
                    }
                    this.m_particles.Remove(item);
                    MyTransparentGeometry.DeallocateAnimatedParticle(item);
                }
            }
        }

        public MyAnimatedProperty2DVector3 Acceleration
        {
            get => 
                ((MyAnimatedProperty2DVector3) this.m_properties[0x1c]);
            private set
            {
                this.m_properties[0x1c] = value;
            }
        }

        public MyAccelerationReference AccelerationReference
        {
            get => 
                ((MyAccelerationReference) ((MyConstPropertyInt) this.m_properties[0x2a]));
            set
            {
                this.m_properties[0x2a].SetValue((int) value);
            }
        }

        public MyConstPropertyFloat AccelerationVar
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x1d]);
            private set
            {
                this.m_properties[0x1d] = value;
            }
        }

        public MyConstPropertyBool AlphaAnisotropic
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x19]);
            private set
            {
                this.m_properties[0x19] = value;
            }
        }

        public MyAnimatedProperty2DFloat AlphaCutout
        {
            get => 
                ((MyAnimatedProperty2DFloat) this.m_properties[30]);
            private set
            {
                this.m_properties[30] = value;
            }
        }

        public MyAnimatedPropertyVector3 Angle
        {
            get => 
                ((MyAnimatedPropertyVector3) this.m_properties[5]);
            private set
            {
                this.m_properties[5] = value;
            }
        }

        public MyConstPropertyVector3 AngleVar
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[6]);
            private set
            {
                this.m_properties[6] = value;
            }
        }

        public MyAnimatedProperty2DInt ArrayIndex
        {
            get => 
                ((MyAnimatedProperty2DInt) this.m_properties[0x27]);
            private set
            {
                this.m_properties[0x27] = value;
            }
        }

        public MyConstPropertyInt ArrayModulo
        {
            get => 
                ((MyConstPropertyInt) this.m_properties[0x29]);
            private set
            {
                this.m_properties[0x29] = value;
            }
        }

        public MyConstPropertyInt ArrayOffset
        {
            get => 
                ((MyConstPropertyInt) this.m_properties[40]);
            private set
            {
                this.m_properties[40] = value;
            }
        }

        public MyConstPropertyVector3 ArraySize
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[0x26]);
            private set
            {
                this.m_properties[0x26] = value;
            }
        }

        public MyAnimatedPropertyFloat Birth
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0]);
            private set
            {
                this.m_properties[0] = value;
            }
        }

        public MyAnimatedPropertyFloat BirthPerFrame
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x1f]);
            private set
            {
                this.m_properties[0x1f] = value;
            }
        }

        public MyConstPropertyEnum BlendType
        {
            get => 
                ((MyConstPropertyEnum) this.m_properties[0x2c]);
            private set
            {
                this.m_properties[0x2c] = value;
            }
        }

        public MyAnimatedProperty2DVector4 Color
        {
            get => 
                ((MyAnimatedProperty2DVector4) this.m_properties[11]);
            private set
            {
                this.m_properties[11] = value;
            }
        }

        public MyAnimatedPropertyFloat ColorIntensity
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x21]);
            private set
            {
                this.m_properties[0x21] = value;
            }
        }

        public MyAnimatedPropertyFloat ColorVar
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[12]);
            private set
            {
                this.m_properties[12] = value;
            }
        }

        public MatrixD EffectMatrix { get; set; }

        public MyConstPropertyBool EnableCustomBirth
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x13]);
            private set
            {
                this.m_properties[0x13] = value;
            }
        }

        public MyConstPropertyBool EnableCustomRadius
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x11]);
            private set
            {
                this.m_properties[0x11] = value;
            }
        }

        public MyConstPropertyBool Enabled
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[0x10]);
            private set
            {
                this.m_properties[0x10] = value;
            }
        }

        public MyConstPropertyFloat Gravity
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x1a]);
            private set
            {
                this.m_properties[0x1a] = value;
            }
        }

        private bool IsDirty =>
            true;

        public bool IsInherited { get; set; }

        public MyAnimatedPropertyFloat Life
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[1]);
            private set
            {
                this.m_properties[1] = value;
            }
        }

        public MyConstPropertyFloat LifeVar
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[2]);
            private set
            {
                this.m_properties[2] = value;
            }
        }

        public MyAnimatedPropertyFloat LODBirth
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x16]);
            private set
            {
                this.m_properties[0x16] = value;
            }
        }

        public MyAnimatedPropertyFloat LODRadius
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x17]);
            private set
            {
                this.m_properties[0x17] = value;
            }
        }

        public MyAnimatedProperty2DTransparentMaterial Material
        {
            get => 
                ((MyAnimatedProperty2DTransparentMaterial) this.m_properties[13]);
            private set
            {
                this.m_properties[13] = value;
            }
        }

        public MyAnimatedPropertyFloat MotionInheritance
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x18]);
            private set
            {
                this.m_properties[0x18] = value;
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

        public MyConstPropertyGenerationIndex OnDie
        {
            get => 
                ((MyConstPropertyGenerationIndex) this.m_properties[20]);
            private set
            {
                this.m_properties[20] = value;
            }
        }

        public MyConstPropertyGenerationIndex OnLife
        {
            get => 
                ((MyConstPropertyGenerationIndex) this.m_properties[0x15]);
            private set
            {
                this.m_properties[0x15] = value;
            }
        }

        public MyConstPropertyEnum ParticleType
        {
            get => 
                ((MyConstPropertyEnum) this.m_properties[14]);
            private set
            {
                this.m_properties[14] = value;
            }
        }

        public MyAnimatedProperty2DVector3 Pivot
        {
            get => 
                ((MyAnimatedProperty2DVector3) this.m_properties[0x22]);
            private set
            {
                this.m_properties[0x22] = value;
            }
        }

        public MyAnimatedProperty2DVector3 PivotRotation
        {
            get => 
                ((MyAnimatedProperty2DVector3) this.m_properties[0x1b]);
            private set
            {
                this.m_properties[0x1b] = value;
            }
        }

        public MyConstPropertyVector3 PivotRotationVar
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[0x24]);
            private set
            {
                this.m_properties[0x24] = value;
            }
        }

        public MyConstPropertyVector3 PivotVar
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[0x23]);
            private set
            {
                this.m_properties[0x23] = value;
            }
        }

        public MyAnimatedProperty2DFloat Radius
        {
            get => 
                ((MyAnimatedProperty2DFloat) this.m_properties[9]);
            private set
            {
                this.m_properties[9] = value;
            }
        }

        public MyConstPropertyFloat RadiusBySpeed
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x20]);
            private set
            {
                this.m_properties[0x20] = value;
            }
        }

        public MyAnimatedPropertyFloat RadiusVar
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[10]);
            private set
            {
                this.m_properties[10] = value;
            }
        }

        public VRage.Game.MyRotationReference RotationReference
        {
            get => 
                ((VRage.Game.MyRotationReference) ((MyConstPropertyInt) this.m_properties[0x25]));
            set
            {
                this.m_properties[0x25].SetValue((int) value);
            }
        }

        public MyAnimatedProperty2DVector3 RotationSpeed
        {
            get => 
                ((MyAnimatedProperty2DVector3) this.m_properties[7]);
            private set
            {
                this.m_properties[7] = value;
            }
        }

        public MyConstPropertyVector3 RotationSpeedVar
        {
            get => 
                ((MyConstPropertyVector3) this.m_properties[8]);
            private set
            {
                this.m_properties[8] = value;
            }
        }

        public bool Show
        {
            get => 
                this.m_show;
            set
            {
                this.m_show = value;
            }
        }

        public MyConstPropertyFloat SoftParticleDistanceScale
        {
            get => 
                ((MyConstPropertyFloat) this.m_properties[0x2b]);
            private set
            {
                this.m_properties[0x2b] = value;
            }
        }

        public MyAnimatedPropertyFloat Thickness
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[15]);
            private set
            {
                this.m_properties[15] = value;
            }
        }

        public MyAnimatedPropertyVector3 Velocity
        {
            get => 
                ((MyAnimatedPropertyVector3) this.m_properties[3]);
            private set
            {
                this.m_properties[3] = value;
            }
        }

        public MyVelocityDirEnum VelocityDir
        {
            get => 
                ((MyVelocityDirEnum) ((MyConstPropertyInt) this.m_properties[4]));
            private set
            {
                this.m_properties[4].SetValue((int) value);
            }
        }

        public MyAnimatedPropertyFloat VelocityVar
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0x2d]);
            private set
            {
                this.m_properties[0x2d] = value;
            }
        }
    }
}

