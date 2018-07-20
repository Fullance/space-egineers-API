namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Xml;
    using VRageMath;
    using VRageRender.Animations;

    public class MyParticleSound
    {
        private MyParticleEffect m_effect;
        private string m_name;
        private bool m_newLoop;
        private uint m_particleSoundId;
        private static uint m_particleSoundIdGlobal = 1;
        private Vector3 m_position = Vector3.Zero;
        private IMyConstProperty[] m_properties = new IMyConstProperty[Enum.GetValues(typeof(MySoundPropertiesEnum)).Length];
        private float m_range;
        private float m_volume;
        private static readonly int Version = 0;

        private T AddProperty<T>(MySoundPropertiesEnum e, T property) where T: IMyConstProperty
        {
            this.m_properties[(int) e] = property;
            return property;
        }

        public void Close()
        {
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                this.m_properties[i] = null;
            }
            this.m_effect = null;
            this.CloseSound();
        }

        private void CloseSound()
        {
        }

        public MyParticleSound CreateInstance(MyParticleEffect effect)
        {
            MyParticleSound sound;
            MyParticlesManager.SoundsPool.AllocateOrCreate(out sound);
            sound.Start(effect);
            sound.Name = this.Name;
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                sound.m_properties[i] = this.m_properties[i].Duplicate();
            }
            return sound;
        }

        public void DebugDraw()
        {
        }

        public void Deserialize(XmlReader reader)
        {
            this.m_name = reader.GetAttribute("name");
            Convert.ToInt32(reader.GetAttribute("version"), CultureInfo.InvariantCulture);
            reader.ReadStartElement();
            foreach (IMyConstProperty property in this.m_properties)
            {
                property.Deserialize(reader);
            }
            reader.ReadEndElement();
        }

        public void DeserializeFromObjectBuilder(ParticleSound sound)
        {
            this.m_name = sound.Name;
            foreach (GenerationProperty property in sound.Properties)
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

        public void Done()
        {
            for (int i = 0; i < this.m_properties.Length; i++)
            {
                if (this.m_properties[i] is IMyAnimatedProperty)
                {
                    (this.m_properties[i] as IMyAnimatedProperty).ClearKeys();
                }
            }
            this.Close();
        }

        public MyParticleSound Duplicate(MyParticleEffect effect) => 
            this.CreateInstance(effect);

        public MyParticleEffect GetEffect() => 
            this.m_effect;

        public IEnumerable<IMyConstProperty> GetProperties() => 
            this.m_properties;

        public void Init()
        {
            this.AddProperty<MyAnimatedPropertyFloat>(MySoundPropertiesEnum.Range, new MyAnimatedPropertyFloat("Range"));
            this.AddProperty<MyAnimatedPropertyFloat>(MySoundPropertiesEnum.RangeVar, new MyAnimatedPropertyFloat("Range var"));
            this.AddProperty<MyAnimatedPropertyFloat>(MySoundPropertiesEnum.Volume, new MyAnimatedPropertyFloat("Volume"));
            this.AddProperty<MyAnimatedPropertyFloat>(MySoundPropertiesEnum.VolumeVar, new MyAnimatedPropertyFloat("Volume var"));
            this.AddProperty<MyConstPropertyString>(MySoundPropertiesEnum.SoundName, new MyConstPropertyString("Sound name"));
            this.AddProperty<MyConstPropertyBool>(MySoundPropertiesEnum.Enabled, new MyConstPropertyBool("Enabled"));
            this.Enabled.SetValue(true);
        }

        public void InitDefault()
        {
            this.Range.AddKey<float>(0f, 30f);
            this.Volume.AddKey<float>(0f, 1f);
        }

        private void InitSound()
        {
        }

        public void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement("ParticleSound");
            writer.WriteAttributeString("Name", this.Name);
            writer.WriteAttributeString("Version", Version.ToString(CultureInfo.InvariantCulture));
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

        public void Start(MyParticleEffect effect)
        {
            this.m_effect = effect;
            this.m_name = "ParticleSound";
            this.m_particleSoundId = m_particleSoundIdGlobal++;
        }

        public void Update(bool newLoop = false)
        {
            this.m_newLoop |= newLoop;
            if (this.Enabled != null)
            {
                this.Range.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime() / this.m_effect.Duration, out this.m_range);
                this.Volume.GetInterpolatedValue<float>(this.m_effect.GetElapsedTime() / this.m_effect.Duration, out this.m_volume);
                this.m_position = (Vector3) this.m_effect.WorldMatrix.Translation;
            }
            MyConstPropertyBool enabled = this.Enabled;
        }

        public float CurrentRange =>
            this.m_range;

        public float CurrentVolume =>
            this.m_volume;

        public MyConstPropertyBool Enabled
        {
            get => 
                ((MyConstPropertyBool) this.m_properties[5]);
            private set
            {
                this.m_properties[5] = value;
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

        public bool NewLoop
        {
            get => 
                this.m_newLoop;
            set
            {
                this.m_newLoop = value;
            }
        }

        public uint ParticleSoundId =>
            this.m_particleSoundId;

        public Vector3 Position =>
            this.m_position;

        public MyAnimatedPropertyFloat Range
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[2]);
            private set
            {
                this.m_properties[2] = value;
            }
        }

        public MyAnimatedPropertyFloat RangeVar
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[3]);
            private set
            {
                this.m_properties[3] = value;
            }
        }

        public MyConstPropertyString SoundName
        {
            get => 
                ((MyConstPropertyString) this.m_properties[4]);
            private set
            {
                this.m_properties[4] = value;
            }
        }

        public MyAnimatedPropertyFloat Volume
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[0]);
            private set
            {
                this.m_properties[0] = value;
            }
        }

        public MyAnimatedPropertyFloat VolumeVar
        {
            get => 
                ((MyAnimatedPropertyFloat) this.m_properties[1]);
            private set
            {
                this.m_properties[1] = value;
            }
        }

        private enum MySoundPropertiesEnum
        {
            Volume,
            VolumeVar,
            Range,
            RangeVar,
            SoundName,
            Enabled
        }
    }
}

