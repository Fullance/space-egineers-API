namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlType("StartingState"), MyObjectBuilderDefinition((Type) null, null)]
    public abstract class MyObjectBuilder_WorldGeneratorPlayerStartingState : MyObjectBuilder_Base
    {
        public string FactionTag;

        protected MyObjectBuilder_WorldGeneratorPlayerStartingState()
        {
        }
    }
}

