namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageRender.Messages;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_AssetModifierDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x24, IsRequired=false), XmlArrayItem("Texture")]
        public List<MyAssetTexture> Textures;

        [StructLayout(LayoutKind.Sequential), ProtoContract]
        public struct MyAssetTexture
        {
            [ProtoMember(0x13, IsRequired=false)]
            public string Location;
            [ProtoMember(0x16, IsRequired=false)]
            public MyTextureType Type;
            [ProtoMember(0x19, IsRequired=false)]
            public string Filepath;
            public MyAssetTexture(string location, MyTextureType type, string filepath)
            {
                this.Location = location;
                this.Type = type;
                this.Filepath = filepath;
            }
        }
    }
}

