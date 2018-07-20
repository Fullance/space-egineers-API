namespace VRage.Game.ObjectBuilders.VisualScripting
{
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.Game;
    using VRage.ObjectBuilders;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyObjectBuilderDefinition((Type) null, null)]
    public class MyObjectBuilder_CommentScriptNode : MyObjectBuilder_ScriptNode
    {
        public SerializableVector2 CommentSize = new SerializableVector2(50f, 20f);
        public string CommentText = "Insert Comment...";
    }
}

