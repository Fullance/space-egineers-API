namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;

    public interface IMyConfigDedicated
    {
        void GenerateRemoteSecurityKey();
        string GetFilePath();
        void Load(string path = null);
        void Save(string path = null);
        void SetPassword(string password);

        List<string> Administrators { get; set; }

        int AsteroidAmount { get; set; }

        bool AutoRestartEnabled { get; set; }

        bool AutoRestartSave { get; set; }

        int AutoRestatTimeInMin { get; set; }

        string AutoUpdateBranchPassword { get; set; }

        int AutoUpdateCheckIntervalInMin { get; set; }

        bool AutoUpdateEnabled { get; set; }

        int AutoUpdateRestartDelayInMin { get; set; }

        string AutoUpdateSteamBranch { get; set; }

        List<ulong> Banned { get; set; }

        ulong GroupID { get; set; }

        bool IgnoreLastSession { get; set; }

        string IP { get; set; }

        string LoadWorld { get; set; }

        string ManualActionChatMessage { get; set; }

        int ManualActionDelay { get; set; }

        string MessageOfTheDay { get; set; }

        string MessageOfTheDayUrl { get; set; }

        bool PauseGameWhenEmpty { get; set; }

        List<string> Plugins { get; set; }

        string PremadeCheckpointPath { get; set; }

        bool RemoteApiEnabled { get; set; }

        int RemoteApiPort { get; set; }

        string RemoteSecurityKey { get; set; }

        List<ulong> Reserved { get; set; }

        string ServerDescription { get; set; }

        string ServerName { get; set; }

        string ServerPasswordHash { get; set; }

        string ServerPasswordSalt { get; set; }

        int ServerPort { get; set; }

        MyObjectBuilder_SessionSettings SessionSettings { get; set; }

        int SteamPort { get; set; }

        float WatcherInterval { get; set; }

        float WatcherSimulationSpeedMinimum { get; set; }

        string WorldName { get; set; }
    }
}

