namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;
    using VRageMath;

    [ProtoContract, MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_VoxelMap : MyObjectBuilder_EntityBase
    {
        [Serialize(MyObjectFlags.DefaultZero)]
        public bool? ContentChanged;
        [ProtoMember(0x1c), Nullable]
        public string Filename;
        private string m_storageName;
        public bool MutableStorage;

        public MyObjectBuilder_VoxelMap()
        {
            this.MutableStorage = true;
            base.PositionAndOrientation = new MyPositionAndOrientation(Vector3.Zero, Vector3.Forward, Vector3.Up);
            this.ContentChanged = false;
        }

        public MyObjectBuilder_VoxelMap(Vector3 position, string storageName)
        {
            this.MutableStorage = true;
            base.PositionAndOrientation = new MyPositionAndOrientation(position, Vector3.Forward, Vector3.Up);
            this.ContentChanged = false;
            this.StorageName = storageName;
        }

        public bool ShouldSerializeMutableStorage() => 
            !this.MutableStorage;

        [Nullable, ProtoMember(13)]
        public string StorageName
        {
            get => 
                (this.m_storageName ?? (base.Name ?? this.Filename));
            set
            {
                this.m_storageName = value;
            }
        }
    }
}

