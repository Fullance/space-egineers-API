namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Xml;
    using VRage.Collections;
    using VRage.FileSystem;
    using VRage.Utils;
    using VRage.Win32;
    using VRageMath;

    public class MyParticlesLibrary
    {
        public static string DefaultLibrary = @"Particles\MyParticlesLibrary.mwl";
        private static Dictionary<int, MyParticleEffect> m_libraryEffectsId = new Dictionary<int, MyParticleEffect>();
        private static Dictionary<string, MyParticleEffect> m_libraryEffectsString = new Dictionary<string, MyParticleEffect>();
        private static string m_loadedFile;
        public static int RedundancyDetected = 0;
        private static readonly int Version = 0;

        public static void AddParticleEffect(MyParticleEffect effect)
        {
            MyParticleEffect effect2;
            if (m_libraryEffectsString.TryGetValue(effect.Name, out effect2))
            {
                RemoveParticleEffect(effect2);
            }
            m_libraryEffectsString[effect.Name] = effect;
            m_libraryEffectsId[effect.ID] = effect;
        }

        public static void Close()
        {
            foreach (MyParticleEffect effect in m_libraryEffectsString.Values)
            {
                effect.Close(false, true);
                MyParticlesManager.EffectsPool.Deallocate(effect);
            }
            m_libraryEffectsString.Clear();
            m_libraryEffectsId.Clear();
        }

        public static MyParticleEffect CreateParticleEffect(string name, ref MatrixD effectMatrix, ref Vector3D worldPosition, uint parentID)
        {
            if (m_libraryEffectsString.ContainsKey(name))
            {
                return m_libraryEffectsString[name].CreateInstance(ref effectMatrix, ref worldPosition, parentID);
            }
            return null;
        }

        public static void DebugDraw()
        {
            foreach (MyParticleEffect effect in m_libraryEffectsString.Values)
            {
                MyConcurrentList<MyParticleEffect> instances = effect.GetInstances();
                if (instances != null)
                {
                    foreach (MyParticleEffect effect2 in instances)
                    {
                        effect2.DebugDraw();
                    }
                }
            }
        }

        public static void Deserialize(string file)
        {
            try
            {
                string path = Path.Combine(MyFileSystem.ContentPath, file);
                using (Stream stream = MyFileSystem.OpenRead(path))
                {
                    XmlReaderSettings settings = new XmlReaderSettings {
                        IgnoreWhitespace = true
                    };
                    using (XmlReader reader = XmlReader.Create(stream, settings))
                    {
                        Deserialize(reader);
                    }
                    m_loadedFile = path;
                }
            }
            catch (IOException exception)
            {
                MyLog.Default.WriteLine("ERROR: Failed to load particles library.");
                MyLog.Default.WriteLine(exception);
                WinApi.MessageBox(new IntPtr(), exception.Message, "Loading Error", 0);
                throw;
            }
        }

        public static void Deserialize(XmlReader reader)
        {
            Close();
            RedundancyDetected = 0;
            reader.ReadStartElement();
            reader.ReadElementContentAsInt();
            reader.ReadStartElement();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                MyParticleEffect effect = MyParticlesManager.EffectsPool.Allocate(false);
                effect.Deserialize(reader);
                AddParticleEffect(effect);
            }
            reader.ReadEndElement();
            reader.ReadEndElement();
        }

        public static bool EffectExists(string name)
        {
            if (LoadedFile == null)
            {
                InitDefault();
            }
            return m_libraryEffectsString.ContainsKey(name);
        }

        public static MyParticleEffect GetParticleEffect(string name)
        {
            if (LoadedFile == null)
            {
                InitDefault();
            }
            return m_libraryEffectsString[name];
        }

        public static IReadOnlyDictionary<int, MyParticleEffect> GetParticleEffectsById()
        {
            if (LoadedFile == null)
            {
                InitDefault();
            }
            return m_libraryEffectsId;
        }

        public static IReadOnlyDictionary<string, MyParticleEffect> GetParticleEffectsByName()
        {
            if (LoadedFile == null)
            {
                InitDefault();
            }
            return m_libraryEffectsString;
        }

        public static bool GetParticleEffectsID(int id, out string name)
        {
            MyParticleEffect effect;
            if (LoadedFile == null)
            {
                InitDefault();
            }
            if (m_libraryEffectsId.TryGetValue(id, out effect))
            {
                name = effect.Name;
                return true;
            }
            name = string.Empty;
            return false;
        }

        public static bool GetParticleEffectsID(string name, out int id)
        {
            MyParticleEffect effect;
            if (LoadedFile == null)
            {
                InitDefault();
            }
            if (m_libraryEffectsString.TryGetValue(name, out effect))
            {
                id = effect.GetID();
                return true;
            }
            id = -1;
            return false;
        }

        public static IEnumerable<int> GetParticleEffectsIDs()
        {
            if (LoadedFile == null)
            {
                InitDefault();
            }
            return m_libraryEffectsId.Keys;
        }

        public static IEnumerable<string> GetParticleEffectsNames()
        {
            if (LoadedFile == null)
            {
                InitDefault();
            }
            return m_libraryEffectsString.Keys;
        }

        public static void InitDefault()
        {
        }

        public static void RemoveParticleEffect(MyParticleEffect effect)
        {
            RemoveParticleEffect(effect.Name, true);
        }

        public static void RemoveParticleEffect(string name, bool instant = true)
        {
            MyParticleEffect effect;
            m_libraryEffectsString.TryGetValue(name, out effect);
            if (effect != null)
            {
                m_libraryEffectsString.Remove(effect.Name);
                m_libraryEffectsId.Remove(effect.ID);
                effect.Close(false, instant);
                MyParticlesManager.EffectsPool.Deallocate(effect);
            }
        }

        public static void RemoveParticleEffectInstance(MyParticleEffect effect)
        {
            effect.Close(true, false);
            if (m_libraryEffectsString.ContainsKey(effect.Name))
            {
                MyConcurrentList<MyParticleEffect> instances = m_libraryEffectsString[effect.Name].GetInstances();
                if ((instances != null) && instances.Contains(effect))
                {
                    MyParticlesManager.EffectsPool.Deallocate(effect);
                    m_libraryEffectsString[effect.Name].RemoveInstance(effect);
                }
            }
        }

        public static void Serialize(string file)
        {
            using (FileStream stream = File.Create(file))
            {
                XmlWriterSettings settings = new XmlWriterSettings {
                    Indent = true
                };
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    Serialize(writer);
                    writer.Flush();
                }
                m_loadedFile = file;
            }
        }

        public static void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement("Definitions");
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
            writer.WriteStartElement("ParticleEffects");
            foreach (KeyValuePair<string, MyParticleEffect> pair in m_libraryEffectsString)
            {
                pair.Value.Serialize(writer);
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public static void UpdateParticleEffectID(int id)
        {
            MyParticleEffect effect;
            if (LoadedFile == null)
            {
                InitDefault();
            }
            m_libraryEffectsId.TryGetValue(id, out effect);
            if (effect != null)
            {
                m_libraryEffectsId.Remove(id);
                m_libraryEffectsId.Add(effect.ID, effect);
            }
        }

        public static void UpdateParticleEffectName(string name)
        {
            MyParticleEffect effect;
            if (LoadedFile == null)
            {
                InitDefault();
            }
            m_libraryEffectsString.TryGetValue(name, out effect);
            if (effect != null)
            {
                m_libraryEffectsString.Remove(name);
                m_libraryEffectsString.Add(effect.Name, effect);
            }
        }

        public static string LoadedFile =>
            m_loadedFile;
    }
}

