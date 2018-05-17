namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game.ModAPI;
    using VRage.Game.ModAPI.Ingame;
    using VRage.ModAPI;
    using VRageMath;

    public interface IMyMotorBase : Sandbox.ModAPI.IMyMechanicalConnectionBlock, Sandbox.ModAPI.IMyFunctionalBlock, Sandbox.ModAPI.IMyTerminalBlock, VRage.Game.ModAPI.IMyCubeBlock, VRage.ModAPI.IMyEntity, Sandbox.ModAPI.Ingame.IMyMotorBase, Sandbox.ModAPI.Ingame.IMyMechanicalConnectionBlock, Sandbox.ModAPI.Ingame.IMyFunctionalBlock, Sandbox.ModAPI.Ingame.IMyTerminalBlock, VRage.Game.ModAPI.Ingame.IMyCubeBlock, VRage.Game.ModAPI.Ingame.IMyEntity
    {
        event Action<Sandbox.ModAPI.IMyMotorBase> AttachedEntityChanged;

        void Attach(Sandbox.ModAPI.IMyMotorRotor rotor, bool updateGroup = true);

        Vector3 DummyPosition { get; }

        float MaxRotorAngularVelocity { get; }

        [Obsolete("Use IMyMechanicalConnectionBlock.Top")]
        VRage.Game.ModAPI.IMyCubeBlock Rotor { get; }

        Vector3 RotorAngularVelocity { get; }

        [Obsolete("Use IMyMechanicalConnectionBlock.TopGrid")]
        VRage.Game.ModAPI.IMyCubeGrid RotorGrid { get; }
    }
}

