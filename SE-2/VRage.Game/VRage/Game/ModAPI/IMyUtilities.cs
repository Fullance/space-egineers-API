namespace VRage.Game.ModAPI
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public interface IMyUtilities
    {
        event MessageEnteredDel MessageEntered;

        event Action<ulong, string> MessageRecieved;

        IMyHudNotification CreateNotification(string message, int disappearTimeMs = 0x7d0, string font = "White");
        void DeleteFileInGlobalStorage(string file);
        void DeleteFileInLocalStorage(string file, Type callingType);
        void DeleteFileInWorldStorage(string file, Type callingType);
        bool FileExistsInGlobalStorage(string file);
        bool FileExistsInLocalStorage(string file, Type callingType);
        bool FileExistsInWorldStorage(string file, Type callingType);
        IMyHudObjectiveLine GetObjectiveLine();
        string GetTypeName(Type type);
        bool GetVariable<T>(string name, out T value);
        void InvokeOnGameThread(Action action, string invokerName = "ModAPI");
        BinaryReader ReadBinaryFileInGlobalStorage(string file);
        BinaryReader ReadBinaryFileInLocalStorage(string file, Type callingType);
        BinaryReader ReadBinaryFileInWorldStorage(string file, Type callingType);
        TextReader ReadFileInGlobalStorage(string file);
        TextReader ReadFileInLocalStorage(string file, Type callingType);
        TextReader ReadFileInWorldStorage(string file, Type callingType);
        void RegisterMessageHandler(long id, Action<object> messageHandler);
        bool RemoveVariable(string name);
        void SendMessage(string messageText);
        void SendModMessage(long id, object payload);
        T SerializeFromBinary<T>(byte[] data);
        T SerializeFromXML<T>(string buffer);
        byte[] SerializeToBinary<T>(T obj);
        string SerializeToXML<T>(T objToSerialize);
        void SetVariable<T>(string name, T value);
        void ShowMessage(string sender, string messageText);
        void ShowMissionScreen(string screenTitle = null, string currentObjectivePrefix = null, string currentObjective = null, string screenDescription = null, Action<ResultEnum> callback = null, string okButtonCaption = null);
        void ShowNotification(string message, int disappearTimeMs = 0x7d0, string font = "White");
        void UnregisterMessageHandler(long id, Action<object> messageHandler);
        BinaryWriter WriteBinaryFileInGlobalStorage(string file);
        BinaryWriter WriteBinaryFileInLocalStorage(string file, Type callingType);
        BinaryWriter WriteBinaryFileInWorldStorage(string file, Type callingType);
        TextWriter WriteFileInGlobalStorage(string file);
        TextWriter WriteFileInLocalStorage(string file, Type callingType);
        TextWriter WriteFileInWorldStorage(string file, Type callingType);

        IMyConfigDedicated ConfigDedicated { get; }

        IMyGamePaths GamePaths { get; }

        bool IsDedicated { get; }
    }
}

