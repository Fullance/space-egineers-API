namespace Sandbox.ModAPI
{
    using System;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Game;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyProductionQueueItem
    {
        public MyFixedPoint Amount;
        public MyDefinitionBase Blueprint;
        public uint ItemId;
    }
}

