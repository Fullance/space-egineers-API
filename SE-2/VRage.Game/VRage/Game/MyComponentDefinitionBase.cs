namespace VRage.Game
{
    using System;
    using System.Xml.Serialization;
    using VRage.Game.Definitions;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers"), MyDefinitionType(typeof(MyObjectBuilder_ComponentDefinitionBase), (Type) null)]
    public class MyComponentDefinitionBase : MyDefinitionBase
    {
        public override MyObjectBuilder_DefinitionBase GetObjectBuilder() => 
            base.GetObjectBuilder();

        protected override void Init(MyObjectBuilder_DefinitionBase builder)
        {
            base.Init(builder);
        }

        public override string ToString() => 
            $"ComponentDefinitionId={base.Id.TypeId}";
    }
}

