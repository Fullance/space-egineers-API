namespace VRage.Game
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using VRage.ObjectBuilders;
    using VRageMath;

    [MyObjectBuilderDefinition((Type) null, null), ProtoContract, XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_HandItemDefinition : MyObjectBuilder_DefinitionBase
    {
        [ProtoMember(0x65)]
        public float AmplitudeMultiplier3rd;
        [ProtoMember(0x4e)]
        public float BlendTime;
        [ProtoMember(0x76)]
        public string FingersAnimation;
        [ProtoMember(0x39)]
        public Quaternion ItemIronsightOrientation = Quaternion.Identity;
        [ProtoMember(0x3b)]
        public Vector3 ItemIronsightPosition;
        [ProtoMember(0x2a)]
        public Quaternion ItemOrientation = Quaternion.Identity;
        [ProtoMember(0x3e)]
        public Quaternion ItemOrientation3rd = Quaternion.Identity;
        [ProtoMember(0x2c)]
        public Vector3 ItemPosition;
        [ProtoMember(0x40)]
        public Vector3 ItemPosition3rd;
        [ProtoMember(0x9f)]
        public MyItemPositioningEnum ItemPositioning;
        [ProtoMember(0xa1)]
        public MyItemPositioningEnum ItemPositioning3rd;
        [ProtoMember(0xab)]
        public MyItemPositioningEnum ItemPositioningIronsight;
        [ProtoMember(0xad)]
        public MyItemPositioningEnum ItemPositioningIronsight3rd;
        [ProtoMember(0xa7)]
        public MyItemPositioningEnum ItemPositioningShoot;
        [ProtoMember(0xa9)]
        public MyItemPositioningEnum ItemPositioningShoot3rd;
        [ProtoMember(0xa3)]
        public MyItemPositioningEnum ItemPositioningWalk;
        [ProtoMember(0xa5)]
        public MyItemPositioningEnum ItemPositioningWalk3rd;
        [ProtoMember(0x34)]
        public Quaternion ItemShootOrientation = Quaternion.Identity;
        [ProtoMember(0x48)]
        public Quaternion ItemShootOrientation3rd = Quaternion.Identity;
        [ProtoMember(0x36)]
        public Vector3 ItemShootPosition;
        [ProtoMember(0x4a)]
        public Vector3 ItemShootPosition3rd;
        [ProtoMember(0x2f)]
        public Quaternion ItemWalkingOrientation = Quaternion.Identity;
        [ProtoMember(0x43)]
        public Quaternion ItemWalkingOrientation3rd = Quaternion.Identity;
        [ProtoMember(0x31)]
        public Vector3 ItemWalkingPosition;
        [ProtoMember(0x45)]
        public Vector3 ItemWalkingPosition3rd;
        [ProtoMember(0x20)]
        public Quaternion LeftHandOrientation = Quaternion.Identity;
        [ProtoMember(0x22)]
        public Vector3 LeftHandPosition;
        [ProtoMember(0x84)]
        public Vector4 LightColor;
        [ProtoMember(0x86)]
        public float LightFalloff;
        [ProtoMember(140)]
        public float LightGlareIntensity = 1f;
        [ProtoMember(0x8a)]
        public float LightGlareSize;
        [ProtoMember(0x8e)]
        public float LightIntensityLower;
        [ProtoMember(0x90)]
        public float LightIntensityUpper;
        [ProtoMember(0x88)]
        public float LightRadius;
        [ProtoMember(0x79)]
        public Vector3 MuzzlePosition;
        [ProtoMember(0x81)]
        public SerializableDefinitionId PhysicalItemId;
        [ProtoMember(0x24)]
        public Quaternion RightHandOrientation = Quaternion.Identity;
        [ProtoMember(0x26)]
        public Vector3 RightHandPosition;
        [ProtoMember(0x62)]
        public float RunMultiplier;
        [ProtoMember(0x7e)]
        public float ScatterSpeed;
        [ProtoMember(0x95)]
        public float ShakeAmountNoTarget;
        [ProtoMember(0x93)]
        public float ShakeAmountTarget;
        [ProtoMember(0x51)]
        public float ShootBlend;
        [ProtoMember(0x7c)]
        public Vector3 ShootScatter;
        [ProtoMember(0x69), DefaultValue(true)]
        public bool SimulateLeftHand = true;
        [ProtoMember(0x6f)]
        public bool? SimulateLeftHandFps = null;
        [DefaultValue(true), ProtoMember(0x6c)]
        public bool SimulateRightHand = true;
        [ProtoMember(0x71)]
        public bool? SimulateRightHandFps = null;
        [ProtoMember(0x9b)]
        public string ToolMaterial = "Grinder";
        [ProtoMember(0x98)]
        public List<ToolSound> ToolSounds;
        [ProtoMember(0x55)]
        public float XAmplitudeOffset;
        [ProtoMember(0x5b)]
        public float XAmplitudeScale;
        [ProtoMember(0x57)]
        public float YAmplitudeOffset;
        [ProtoMember(0x5d)]
        public float YAmplitudeScale;
        [ProtoMember(0x59)]
        public float ZAmplitudeOffset;
        [ProtoMember(0x5f)]
        public float ZAmplitudeScale;
    }
}

