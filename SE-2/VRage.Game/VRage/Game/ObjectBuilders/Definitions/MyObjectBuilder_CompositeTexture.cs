namespace VRage.Game.ObjectBuilders.Definitions
{
    using System;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRage.Utils;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CompositeTexture : MyObjectBuilder_Base
    {
        public MyStringHash Center = MyStringHash.NullOrEmpty;
        public MyStringHash CenterBottom = MyStringHash.NullOrEmpty;
        public MyStringHash CenterTop = MyStringHash.NullOrEmpty;
        public MyStringHash LeftBottom = MyStringHash.NullOrEmpty;
        public MyStringHash LeftCenter = MyStringHash.NullOrEmpty;
        public MyStringHash LeftTop = MyStringHash.NullOrEmpty;
        public MyStringHash RightBottom = MyStringHash.NullOrEmpty;
        public MyStringHash RightCenter = MyStringHash.NullOrEmpty;
        public MyStringHash RightTop = MyStringHash.NullOrEmpty;

        public virtual bool IsValid()
        {
            if ((((!(this.LeftTop != MyStringHash.NullOrEmpty) && !(this.LeftTop != MyStringHash.NullOrEmpty)) && (!(this.LeftCenter != MyStringHash.NullOrEmpty) && !(this.LeftBottom != MyStringHash.NullOrEmpty))) && ((!(this.CenterTop != MyStringHash.NullOrEmpty) && !(this.Center != MyStringHash.NullOrEmpty)) && (!(this.CenterBottom != MyStringHash.NullOrEmpty) && !(this.RightTop != MyStringHash.NullOrEmpty)))) && !(this.RightCenter != MyStringHash.NullOrEmpty))
            {
                return (this.RightBottom != MyStringHash.NullOrEmpty);
            }
            return true;
        }
    }
}

