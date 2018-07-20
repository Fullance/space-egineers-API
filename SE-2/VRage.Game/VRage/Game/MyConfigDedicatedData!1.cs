namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("MyConfigDedicated")]
    public class MyConfigDedicatedData<T> where T: MyObjectBuilder_SessionSettings, new()
    {
        [XmlArrayItem("unsignedLong")]
        public List<string> Administrators;
        public int AsteroidAmount;
        public bool AutoRestartEnabled;
        public bool AutoRestartSave;
        public int AutoRestatTimeInMin;
        public string AutoUpdateBranchPassword;
        public int AutoUpdateCheckIntervalInMin;
        public bool AutoUpdateEnabled;
        public int AutoUpdateRestartDelayInMin;
        public string AutoUpdateSteamBranch;
        public List<ulong> Banned;
        public ulong GroupID;
        public bool IgnoreLastSession;
        public string IP;
        public string LoadWorld;
        public string ManualActionChatMessage;
        public int ManualActionDelay;
        public string MessageOfTheDay;
        public string MessageOfTheDayUrl;
        public bool PauseGameWhenEmpty;
        public List<string> Plugins;
        public string PremadeCheckpointPath;
        public bool RemoteApiEnabled;
        public int RemoteApiPort;
        public string RemoteSecurityKey;
        public List<ulong> Reserved;
        public string ServerDescription;
        public string ServerName;
        public string ServerPasswordHash;
        public string ServerPasswordSalt;
        public int ServerPort;
        public T SessionSettings;
        public int SteamPort;
        public float WatcherInterval;
        public float WatcherSimulationSpeedMinimum;
        public string WorldName;

        public MyConfigDedicatedData()
        {
            this.SessionSettings = Activator.CreateInstance<T>();
            this.IP = "0.0.0.0";
            this.SteamPort = 0x223e;
            this.ServerPort = 0x6988;
            this.AsteroidAmount = 4;
            this.Administrators = new List<string>();
            this.Banned = new List<ulong>();
            this.ServerName = "";
            this.WorldName = "";
            this.MessageOfTheDay = string.Empty;
            this.MessageOfTheDayUrl = string.Empty;
            this.AutoRestartEnabled = true;
            this.AutoRestartSave = true;
            this.AutoUpdateCheckIntervalInMin = 10;
            this.AutoUpdateRestartDelayInMin = 15;
            this.PremadeCheckpointPath = "";
            this.Reserved = new List<ulong>();
            this.RemoteApiEnabled = true;
            this.RemoteApiPort = 0x1f90;
            this.Plugins = new List<string>();
            this.WatcherInterval = 30f;
            this.WatcherSimulationSpeedMinimum = 0.05f;
            this.ManualActionDelay = 5;
            this.ManualActionChatMessage = "Server will be shut down in {0} min(s).";
        }
    }
}

