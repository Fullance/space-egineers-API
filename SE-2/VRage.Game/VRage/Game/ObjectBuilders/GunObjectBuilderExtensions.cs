namespace VRage.Game.ObjectBuilders
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.Game;

    public static class GunObjectBuilderExtensions
    {
        public static T GetDevice<T>(this IMyObjectBuilder_GunObject<T> gunObjectBuilder) where T: MyObjectBuilder_DeviceBase => 
            (gunObjectBuilder.DeviceBase as T);

        public static void InitializeDeviceBase<T>(this IMyObjectBuilder_GunObject<T> gunObjectBuilder, MyObjectBuilder_DeviceBase newBuilder) where T: MyObjectBuilder_DeviceBase
        {
            if (newBuilder.TypeId == typeof(T))
            {
                gunObjectBuilder.DeviceBase = newBuilder;
            }
        }
    }
}

