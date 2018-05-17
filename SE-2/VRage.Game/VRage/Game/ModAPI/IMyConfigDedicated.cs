namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game;

    public interface IMyConfigDedicated
    {
        string GetFilePath();
        void Load(string path = null);
        void Save(string path = null);

        List<string> Administrators { get; set; }

        int AsteroidAmount { get; set; }

        List<ulong> Banned { get; set; }

        ulong GroupID { get; set; }

        bool IgnoreLastSession { get; set; }

        string IP { get; set; }

        string LoadWorld { get; }

        List<ulong> Mods { get; }

        bool PauseGameWhenEmpty { get; set; }

        string PremadeCheckpointPath { get; set; }

        string ServerDescription { get; set; }

        string ServerName { get; set; }

        int ServerPort { get; set; }

        MyObjectBuilder_SessionSettings SessionSettings { get; set; }

        int SteamPort { get; set; }

        string WorldName { get; set; }
    }
}

