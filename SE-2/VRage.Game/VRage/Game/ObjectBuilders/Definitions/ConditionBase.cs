namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public abstract class ConditionBase : MyObjectBuilder_Base
    {
        protected ConditionBase()
        {
        }

        public abstract bool Eval();
    }
}

