namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using VRage;
    using VRage.ObjectBuilders;
    using VRage.Serialization;

    [MyObjectBuilderDefinition((Type) null, null), XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ProxyAntenna : MyObjectBuilder_EntityBase
    {
        public long AntennaEntityId;
        public float BroadcastRadius;
        public bool HasReceiver;
        public bool HasRemote;
        public List<MyObjectBuilder_HudEntityParams> HudParams;
        public long InfoEntityId;
        [Serialize(MyObjectFlags.DefaultZero)]
        public string InfoName;
        public bool IsCharacter;
        public bool IsLaser;
        [Serialize(MyObjectFlags.DefaultZero)]
        public long? MainRemoteId;
        [Serialize(MyObjectFlags.DefaultZero)]
        public long? MainRemoteOwner;
        public MyOwnershipShareModeEnum MainRemoteSharing;
        public long Owner;
        public SerializableVector3D Position;
        public MyOwnershipShareModeEnum Share;
        [Serialize(MyObjectFlags.DefaultZero)]
        public string StateText;
        [Serialize(MyObjectFlags.DefaultZero)]
        public long? SuccessfullyContacting;
    }
}

