namespace VRage.Game
{
    using System;
    using System.Xml;
    using VRage;

    public class MyDefinitionXmlSerializer : MyAbstractXmlSerializer<MyObjectBuilder_DefinitionBase>
    {
        public const string DEFINITION_ELEMENT_NAME = "Definition";

        public MyDefinitionXmlSerializer()
        {
        }

        public MyDefinitionXmlSerializer(MyObjectBuilder_DefinitionBase data)
        {
            base.m_data = data;
        }

        protected override string GetTypeAttribute(XmlReader reader)
        {
            string str2;
            string typeAttribute = base.GetTypeAttribute(reader);
            if (typeAttribute == null)
            {
                return null;
            }
            MyXmlTextReader reader2 = reader as MyXmlTextReader;
            if (((reader2 != null) && (reader2.DefinitionTypeOverrideMap != null)) && reader2.DefinitionTypeOverrideMap.TryGetValue(typeAttribute, out str2))
            {
                return str2;
            }
            return typeAttribute;
        }

        public static implicit operator MyDefinitionXmlSerializer(MyObjectBuilder_DefinitionBase builder)
        {
            if (builder != null)
            {
                return new MyDefinitionXmlSerializer(builder);
            }
            return null;
        }
    }
}

