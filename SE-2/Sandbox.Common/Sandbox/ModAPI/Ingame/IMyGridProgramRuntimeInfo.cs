namespace Sandbox.ModAPI.Ingame
{
    using System;

    public interface IMyGridProgramRuntimeInfo
    {
        int CurrentInstructionCount { get; }

        [Obsolete("This property no longer holds any meaning.")]
        int CurrentMethodCallCount { get; }

        double LastRunTimeMs { get; }

        int MaxInstructionCount { get; }

        [Obsolete("This property no longer holds any meaning.")]
        int MaxMethodCallCount { get; }

        TimeSpan TimeSinceLastRun { get; }

        Sandbox.ModAPI.Ingame.UpdateFrequency UpdateFrequency { get; set; }
    }
}

