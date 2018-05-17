namespace SpaceEngineers.Game.ModAPI.Ingame
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Collections.Generic;
    using VRage.Game.ModAPI.Ingame;

    public interface IMySoundBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void GetSounds(List<string> sounds);
        void Play();
        void Stop();

        bool IsSoundSelected { get; }

        float LoopPeriod { get; set; }

        float Range { get; set; }

        string SelectedSound { get; set; }

        float Volume { get; set; }
    }
}

