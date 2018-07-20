namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Xml;
    using VRage.Utils;
    using VRageMath;
    using VRageRender.Animations;

    public class MyParticleEmitter
    {
        [ThreadStatic]
        private IMyConstProperty[] m_propertiesInternal;
        private static string[] MyParticleEmitterTypeStrings = new string[] { "Point", "Line", "Box", "Sphere", "Hemisphere", "Circle" };
        private static List<string> s_emitterTypeStrings = MyParticleEmitterTypeStrings.ToList<string>();
        private static readonly int Version = 5;

        public MyParticleEmitter(MyParticleEmitterType type)
        {
        }

        private T AddProperty<T>(MyEmitterPropertiesEnum e, T property) where T: IMyConstProperty
        {
            this.m_properties[(int) e] = property;
            return property;
        }

        public void CalculateStartPosition(float elapsedTime, MatrixD worldMatrix, Vector3 userAxisScale, float userScale, out Vector3D startOffset, out Vector3D startPosition)
        {
            Vector3 vector;
            Vector3 vector2;
            float num;
            Vector3D vectord;
            Vector3D vectord2;
            this.Offset.GetInterpolatedValue<Vector3>(elapsedTime, out vector);
            this.Rotation.GetInterpolatedValue<Vector3>(elapsedTime, out vector2);
            this.Size.GetInterpolatedValue<float>(elapsedTime, out num);
            num *= MyUtils.GetRandomFloat((float) this.RadiusMin, (float) this.RadiusMax) * userScale;
            Vector3 vector3 = userAxisScale * this.AxisScale;
            Vector3 zero = Vector3.Zero;
            Vector3D.Transform(ref vector, ref worldMatrix, out vectord);
            switch (this.Type)
            {
                case MyParticleEmitterType.Point:
                    zero = Vector3.Zero;
                    break;

                case MyParticleEmitterType.Line:
                    zero = (Vector3) ((Vector3.Forward * MyUtils.GetRandomFloat(0f, num)) * vector3);
                    break;

                case MyParticleEmitterType.Box:
                {
                    float maxValue = num * 0.5f;
                    zero = new Vector3(MyUtils.GetRandomFloat(-maxValue, maxValue), MyUtils.GetRandomFloat(-maxValue, maxValue), MyUtils.GetRandomFloat(-maxValue, maxValue)) * vector3;
                    break;
                }
                case MyParticleEmitterType.Sphere:
                    float num2;
                    if (this.LimitAngle.GetKeysCount() <= 0)
                    {
                        zero = (Vector3) ((MyUtils.GetRandomVector3Normalized() * num) * vector3);
                        break;
                    }
                    this.LimitAngle.GetInterpolatedValue<float>(elapsedTime, out num2);
                    zero = (Vector3) ((MyUtils.GetRandomVector3MaxAngle(MathHelper.ToRadians(num2)) * num) * vector3);
                    break;

                case MyParticleEmitterType.Hemisphere:
                    zero = (Vector3) ((MyUtils.GetRandomVector3HemisphereNormalized(Vector3.Forward) * num) * vector3);
                    break;

                case MyParticleEmitterType.Circle:
                    zero = (Vector3) ((MyUtils.GetRandomVector3CircleNormalized() * num) * vector3);
                    break;
            }
            if (vector2.LengthSquared() > 0f)
            {
                Matrix introduced17 = Matrix.CreateRotationX(MathHelper.ToRadians(vector2.X));
                Matrix matrix = introduced17 * Matrix.CreateRotationY(MathHelper.ToRadians(vector2.Y));
                matrix *= Matrix.CreateRotationZ(MathHelper.ToRadians(vector2.Z));
                Vector3.TransformNormal(ref zero, ref matrix, out zero);
            }
            if (this.DirToCamera != null)
            {
                if (MyUtils.IsZero(MyTransparentGeometry.Camera.Forward, 1E-05f))
                {
                    startPosition = Vector3.Zero;
                    startOffset = Vector3.Zero;
                }
                else
                {
                    MatrixD xd = worldMatrix * MyTransparentGeometry.CameraView;
                    xd.Translation += vector;
                    MatrixD xd2 = xd * MatrixD.Invert(MyTransparentGeometry.CameraView);
                    Vector3D dir = MyTransparentGeometry.Camera.Translation - xd2.Translation;
                    dir.Normalize();
                    MatrixD xd3 = MatrixD.CreateFromDir(dir);
                    xd3.Translation = xd2.Translation;
                    Vector3D.Transform(ref zero, ref xd3, out vectord2);
                    startOffset = xd2.Translation;
                    startPosition = vectord2;
                }
            }
            else
            {
                Vector3D.TransformNormal(ref zero, ref worldMatrix, out vectord2);
                startOffset = vectord;
                startPosition = vectord + vectord2;
            }
        }

        public void Close()
        {
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                this.m_properties[i] = null;
            }
        }

        public void CreateInstance(MyParticleEmitter emitter)
        {
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                this.m_properties[i] = emitter.m_properties[i];
            }
        }

        public void DebugDraw(float elapsedTime, Matrix worldMatrix)
        {
        }

        public void Deserialize(XmlReader reader)
        {
            switch (Convert.ToInt32(reader.GetAttribute("version"), CultureInfo.InvariantCulture))
            {
                case 0:
                    this.DeserializeV0(reader);
                    return;

                case 1:
                    this.DeserializeV1(reader);
                    return;

                case 2:
                    this.DeserializeV2(reader);
                    return;

                case 3:
                    this.DeserializeV2(reader);
                    return;

                case 4:
                    this.DeserializeV4(reader);
                    return;
            }
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                property.Deserialize(reader);
            }
            reader.ReadEndElement();
        }

        public void DeserializeFromObjectBuilder(ParticleEmitter emitter)
        {
            foreach (GenerationProperty property in emitter.Properties)
            {
                for (int i = 0; i < this.m_properties.Length; i++)
                {
                    if (this.m_properties[i].Name.Equals(property.Name))
                    {
                        this.m_properties[i].DeserializeFromObjectBuilder(property);
                    }
                }
            }
        }

        private void DeserializeV0(XmlReader reader)
        {
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                if ((property.Name != "Rotation") && (property.Name != "AxisScale"))
                {
                    property.Deserialize(reader);
                }
            }
            reader.ReadEndElement();
        }

        private void DeserializeV1(XmlReader reader)
        {
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                if ((property.Name != "AxisScale") && (property.Name != "LimitAngle"))
                {
                    property.Deserialize(reader);
                }
            }
            reader.ReadEndElement();
        }

        private void DeserializeV2(XmlReader reader)
        {
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                if (property.Name != "LimitAngle")
                {
                    property.Deserialize(reader);
                }
            }
            if ((reader.AttributeCount > 0) && (reader.GetAttribute(0) == "LimitAngle"))
            {
                reader.Skip();
            }
            reader.ReadEndElement();
        }

        private void DeserializeV4(XmlReader reader)
        {
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                if (property.Name != "LimitAngle")
                {
                    property.Deserialize(reader);
                }
            }
            reader.ReadEndElement();
        }

        public void Done()
        {
            for (int i = 0; i < this.GetProperties().Length; i++)
            {
                if (this.m_properties[i] is IMyAnimatedProperty)
                {
                    (this.m_properties[i] as IMyAnimatedProperty).ClearKeys();
                }
            }
            this.Close();
        }

        public void Duplicate(MyParticleEmitter targetEmitter)
        {
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                targetEmitter.m_properties[i] = this.m_properties[i].Duplicate();
            }
        }

        public IMyConstProperty[] GetProperties() => 
            this.m_properties;

        public void Init()
        {
            this.AddProperty<MyConstPropertyEnum>(MyEmitterPropertiesEnum.Type, new MyConstPropertyEnum("Type", typeof(MyParticleEmitterType), s_emitterTypeStrings));
            this.AddProperty<MyAnimatedPropertyVector3>(MyEmitterPropertiesEnum.Offset, new MyAnimatedPropertyVector3("Offset"));
            this.AddProperty<MyAnimatedPropertyVector3>(MyEmitterPropertiesEnum.Rotation, new MyAnimatedPropertyVector3("Rotation", true, null));
            this.AddProperty<MyConstPropertyVector3>(MyEmitterPropertiesEnum.AxisScale, new MyConstPropertyVector3("AxisScale"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyEmitterPropertiesEnum.Size, new MyAnimatedPropertyFloat("Size"));
            this.AddProperty<MyConstPropertyFloat>(MyEmitterPropertiesEnum.RadiusMin, new MyConstPropertyFloat("RadiusMin"));
            this.AddProperty<MyConstPropertyFloat>(MyEmitterPropertiesEnum.RadiusMax, new MyConstPropertyFloat("RadiusMax"));
            this.AddProperty<MyConstPropertyBool>(MyEmitterPropertiesEnum.DirToCamera, new MyConstPropertyBool("DirToCamera"));
            this.AddProperty<MyAnimatedPropertyFloat>(MyEmitterPropertiesEnum.LimitAngle, new MyAnimatedPropertyFloat("LimitAngle"));
            this.Offset.AddKey<Vector3>(0f, new Vector3(0f, 0f, 0f));
            this.Rotation.AddKey<Vector3>(0f, new Vector3(0f, 0f, 0f));
            this.AxisScale.SetValue(Vector3.One);
            this.Size.AddKey<float>(0f, 1f);
            this.RadiusMin.SetValue(1f);
            this.RadiusMax.SetValue(1f);
            this.DirToCamera.SetValue(false);
        }

        public void Serialize(XmlWriter writer)
        {
            writer.WriteElementString("Version", Version.ToString(CultureInfo.InvariantCulture));
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
        }

        public void Start()
        {
        }

        public MyConstPropertyVector3 AxisScale
        {
            get => 
                (this.m_properties[3] as MyConstPropertyVector3);
            private set
            {
                this.m_properties[3] = value;
            }
        }

        public MyConstPropertyBool DirToCamera
        {
            get => 
                (this.m_properties[7] as MyConstPropertyBool);
            private set
            {
                this.m_properties[7] = value;
            }
        }

        public MyAnimatedPropertyFloat LimitAngle
        {
            get => 
                (this.m_properties[8] as MyAnimatedPropertyFloat);
            private set
            {
                this.m_properties[8] = value;
            }
        }

        private IMyConstProperty[] m_properties
        {
            get
            {
                if (this.m_propertiesInternal == null)
                {
                    this.m_propertiesInternal = new IMyConstProperty[Enum.GetValues(typeof(MyEmitterPropertiesEnum)).Length];
                }
                return this.m_propertiesInternal;
            }
        }

        public MyAnimatedPropertyVector3 Offset
        {
            get => 
                (this.m_properties[1] as MyAnimatedPropertyVector3);
            private set
            {
                this.m_properties[1] = value;
            }
        }

        public MyConstPropertyFloat RadiusMax
        {
            get => 
                (this.m_properties[6] as MyConstPropertyFloat);
            private set
            {
                this.m_properties[6] = value;
            }
        }

        public MyConstPropertyFloat RadiusMin
        {
            get => 
                (this.m_properties[5] as MyConstPropertyFloat);
            private set
            {
                this.m_properties[5] = value;
            }
        }

        public MyAnimatedPropertyVector3 Rotation
        {
            get => 
                (this.m_properties[2] as MyAnimatedPropertyVector3);
            private set
            {
                this.m_properties[2] = value;
            }
        }

        public MyAnimatedPropertyFloat Size
        {
            get => 
                (this.m_properties[4] as MyAnimatedPropertyFloat);
            private set
            {
                this.m_properties[4] = value;
            }
        }

        public MyParticleEmitterType Type
        {
            get => 
                ((MyParticleEmitterType) (this.m_properties[0] as MyConstPropertyEnum));
            private set
            {
                this.m_properties[0].SetValue((int) value);
            }
        }

        private enum MyEmitterPropertiesEnum
        {
            Type,
            Offset,
            Rotation,
            AxisScale,
            Size,
            RadiusMin,
            RadiusMax,
            DirToCamera,
            LimitAngle
        }
    }
}

