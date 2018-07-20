namespace VRage.Game
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.FileSystem;
    using VRage.Game.ModAPI;

    public class MyModContext : IEquatable<MyModContext>, IMyModContext
    {
        public string CurrentFile;
        private static MyModContext m_baseContext;
        private static MyModContext m_unknownContext;

        public bool Equals(MyModContext other) => 
            ((this.ModName == other.ModName) && (this.ModPath == other.ModPath));

        public override int GetHashCode() => 
            (this.ModPath.GetHashCode() ^ ((this.ModName != null) ? this.ModName.GetHashCode() : 0));

        public void Init(MyModContext context)
        {
            this.ModName = context.ModName;
            this.ModPath = context.ModPath;
            this.ModId = context.ModId;
            this.ModPathData = context.ModPathData;
            this.CurrentFile = context.CurrentFile;
        }

        public void Init(MyObjectBuilder_Checkpoint.ModItem modItem)
        {
            this.ModName = modItem.FriendlyName;
            this.ModId = modItem.Name;
            this.ModPath = Path.Combine(MyFileSystem.ModsPath, modItem.Name);
            this.ModPathData = Path.Combine(this.ModPath, "Data");
        }

        public void Init(string modName, string fileName, string modPath = null)
        {
            this.ModName = modName;
            this.ModPath = modPath;
            this.ModPathData = (modPath != null) ? Path.Combine(modPath, "Data") : null;
            this.CurrentFile = fileName;
        }

        private static void InitBaseModContext()
        {
            m_baseContext = new MyModContext();
            m_baseContext.ModName = null;
            m_baseContext.ModPath = MyFileSystem.ContentPath;
            m_baseContext.ModPathData = Path.Combine(m_baseContext.ModPath, "Data");
        }

        private static void InitUnknownModContext()
        {
            m_unknownContext = new MyModContext();
            m_unknownContext.ModName = "Unknown MOD";
            m_unknownContext.ModPath = null;
            m_unknownContext.ModPathData = null;
        }

        public static MyModContext BaseGame
        {
            get
            {
                if (m_baseContext == null)
                {
                    InitBaseModContext();
                }
                return m_baseContext;
            }
        }

        public bool IsBaseGame =>
            ((((m_baseContext != null) && (this.ModName == m_baseContext.ModName)) && (this.ModPath == m_baseContext.ModPath)) && (this.ModPathData == m_baseContext.ModPathData));

        [XmlIgnore]
        public string ModId { get; private set; }

        [XmlIgnore]
        public string ModName { get; private set; }

        [XmlIgnore]
        public string ModPath { get; private set; }

        [XmlIgnore]
        public string ModPathData { get; private set; }

        public static MyModContext UnknownContext
        {
            get
            {
                if (m_unknownContext == null)
                {
                    InitUnknownModContext();
                }
                return m_unknownContext;
            }
        }
    }
}

