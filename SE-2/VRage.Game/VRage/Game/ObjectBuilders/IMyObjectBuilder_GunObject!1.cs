namespace VRage.Game.ObjectBuilders
{
    using System;
    using VRage.Game;

    public interface IMyObjectBuilder_GunObject<out T> where T: MyObjectBuilder_DeviceBase
    {
        MyObjectBuilder_DeviceBase DeviceBase { get; set; }
    }
}

