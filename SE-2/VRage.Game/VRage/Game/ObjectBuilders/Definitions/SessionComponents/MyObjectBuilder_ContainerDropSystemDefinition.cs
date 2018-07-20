namespace VRage.Game.ObjectBuilders.Definitions.SessionComponents
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.Definitions;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_ContainerDropSystemDefinition : MyObjectBuilder_SessionComponentDefinition
    {
        public float CompetetiveContainerDistMax = 30f;
        public float CompetetiveContainerDistMin = 15f;
        public RGBColor CompetetiveContainerGPSColorClaimed;
        public RGBColor CompetetiveContainerGPSColorFree;
        public float CompetetiveContainerGPSTimeOut = 5f;
        public float CompetetiveContainerGridTimeOut = 60f;
        public string ContainerAudioCue = "BlockContainer";
        public float ContainerDropTime = 30f;
        public float PersonalContainerDistMax = 15f;
        public float PersonalContainerDistMin = 1f;
        public RGBColor PersonalContainerGPSColor;
        public float PersonalContainerGridTimeOut = 45f;
        public float PersonalContainerRatio = 0.95f;
    }
}

