namespace Sandbox.ModAPI.Ingame
{
    using System;

    public interface IMyGridProgramRuntimeInfo
    {
        int CurrentCallChainDepth { get; }

        int CurrentInstructionCount { get; }

        double LastRunTimeMs { get; }

        int MaxCallChainDepth { get; }

        int MaxInstructionCount { get; }

        TimeSpan TimeSinceLastRun { get; }

        Sandbox.ModAPI.Ingame.UpdateFrequency UpdateFrequency { get; set; }
    }
}

