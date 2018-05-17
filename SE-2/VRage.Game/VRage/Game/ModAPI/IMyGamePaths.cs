namespace VRage.Game.ModAPI
{
    using System;

    public interface IMyGamePaths
    {
        string ContentPath { get; }

        string ModScopeName { get; }

        string ModsPath { get; }

        string SavesPath { get; }

        string UserDataPath { get; }
    }
}

