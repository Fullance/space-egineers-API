namespace VRage.Game.ObjectBuilders.Definitions.SessionComponents
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game.ObjectBuilders.Definitions;
    using VRage.ObjectBuilders;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_CoordinateSystemDefinition : MyObjectBuilder_SessionComponentDefinition
    {
        public double AngleTolerance = 0.0001;
        public int CoordSystemSize = 0x3e8;
        public double PositionTolerance = 0.001;
    }
}

