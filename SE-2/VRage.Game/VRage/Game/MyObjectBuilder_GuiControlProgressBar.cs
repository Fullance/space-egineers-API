namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_GuiControlProgressBar : MyObjectBuilder_GuiControlBase
    {
        [ProtoMember(12)]
        public Vector4? ProgressColor;

        public bool ShouldSerializeProgressColor() => 
            this.ProgressColor.HasValue;
    }
}

