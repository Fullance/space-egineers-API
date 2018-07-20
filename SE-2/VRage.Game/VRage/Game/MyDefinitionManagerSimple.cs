namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;
    using VRage.FileSystem;
    using VRage.Game.Definitions;
    using VRage.ObjectBuilders;

    public class MyDefinitionManagerSimple : MyDefinitionManagerBase
    {
        private Dictionary<string, string> m_overrideMap = new Dictionary<string, string>();

        public void AddDefinitionOverride(Type overridingType, string typeOverride)
        {
            string name;
            MyDefinitionTypeAttribute attribute = overridingType.GetCustomAttribute(typeof(MyDefinitionTypeAttribute), false) as MyDefinitionTypeAttribute;
            if (attribute == null)
            {
                throw new Exception("Missing type attribute in definition");
            }
            XmlTypeAttribute attribute2 = attribute.ObjectBuilderType.GetCustomAttribute(typeof(XmlTypeAttribute), false) as XmlTypeAttribute;
            if (attribute2 == null)
            {
                name = attribute.ObjectBuilderType.Name;
            }
            else
            {
                name = attribute2.TypeName;
            }
            this.m_overrideMap[typeOverride] = name;
        }

        public override MyDefinitionSet GetLoadingSet()
        {
            throw new NotImplementedException();
        }

        public void LoadDefinitions(string path)
        {
            bool flag = false;
            MyObjectBuilder_Definitions definitions = null;
            using (Stream stream = MyFileSystem.OpenRead(path))
            {
                if (stream != null)
                {
                    using (Stream stream2 = stream.UnwrapGZip())
                    {
                        if (stream2 != null)
                        {
                            MyObjectBuilder_Base base2;
                            flag = MyObjectBuilderSerializer.DeserializeXML(stream2, out base2, typeof(MyObjectBuilder_Definitions), this.m_overrideMap);
                            definitions = base2 as MyObjectBuilder_Definitions;
                        }
                    }
                }
            }
            if (!flag)
            {
                throw new Exception("Error while reading \"" + path + "\"");
            }
            if (definitions.Definitions != null)
            {
                foreach (MyObjectBuilder_DefinitionBase base3 in definitions.Definitions)
                {
                    MyObjectBuilderType.RemapType(ref base3.Id, this.m_overrideMap);
                    MyDefinitionBase def = MyDefinitionManagerBase.GetObjectFactory().CreateInstance(base3.TypeId);
                    def.Init(definitions.Definitions[0], new MyModContext());
                    base.m_definitions.AddDefinition(def);
                }
            }
        }
    }
}

