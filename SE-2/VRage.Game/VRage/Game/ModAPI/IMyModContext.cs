namespace VRage.Game.ModAPI
{
    using System;

    public interface IMyModContext
    {
        bool IsBaseGame { get; }

        string ModId { get; }

        string ModName { get; }

        string ModPath { get; }

        string ModPathData { get; }
    }
}

