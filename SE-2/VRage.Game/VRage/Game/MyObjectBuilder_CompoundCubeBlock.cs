namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ModAPI;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers"), ProtoContract]
    public class MyObjectBuilder_CompoundCubeBlock : MyObjectBuilder_CubeBlock
    {
        [ProtoMember(20), Serialize(MyObjectFlags.DefaultZero)]
        public ushort[] BlockIds;
        [ProtoMember(15), DynamicItem(typeof(MyObjectBuilderDynamicSerializer), true), XmlArrayItem("MyObjectBuilder_CubeBlock", Type=typeof(MyAbstractXmlSerializer<MyObjectBuilder_CubeBlock>))]
        public MyObjectBuilder_CubeBlock[] Blocks;

        public override void Remap(IMyRemapHelper remapHelper)
        {
            base.Remap(remapHelper);
            foreach (MyObjectBuilder_CubeBlock block in this.Blocks)
            {
                block.Remap(remapHelper);
            }
        }
    }
}

