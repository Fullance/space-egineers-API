namespace VRage.Game.ObjectBuilders
{
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_SectorWeatherComponent : MyObjectBuilder_SessionComponent
    {
        public SerializableVector3 BaseSunDirection;
    }
}

