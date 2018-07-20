namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game.Gui;
    using VRage.ObjectBuilders;
    using VRageMath;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_HudEntityParams : MyObjectBuilder_Base
    {
        public float BlinkingTime;
        public long EntityId;
        public MyHudIndicatorFlagsEnum FlagsEnum;
        public long Owner;
        public Vector3D Position;
        public MyOwnershipShareModeEnum Share;
        public string Text;
    }
}

