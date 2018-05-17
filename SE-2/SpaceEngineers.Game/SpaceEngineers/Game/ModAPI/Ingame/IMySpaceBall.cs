namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using VRage.Game.ModAPI.Ingame;

    public interface IMySpaceBall : IMyVirtualMass, IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        bool Broadcasting { get; set; }

        float Friction { get; set; }

        [Obsolete("Use IMySpaceBall.Broadcasting")]
        bool IsBroadcasting { get; }

        float Restitution { get; set; }

        float VirtualMass { get; set; }
    }
}

