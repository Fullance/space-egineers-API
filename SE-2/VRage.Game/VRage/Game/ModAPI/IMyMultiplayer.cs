namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface IMyMultiplayer
    {
        bool IsServerPlayer(IMyNetworkClient player);
        void JoinServer(string address);
        void RegisterMessageHandler(ushort id, Action<byte[]> messageHandler);
        void ReplicateEntityForClient(long entityId, ulong steamId);
        void SendEntitiesCreated(List<MyObjectBuilder_EntityBase> objectBuilders);
        bool SendMessageTo(ushort id, byte[] message, ulong recipient, bool reliable = true);
        bool SendMessageToOthers(ushort id, byte[] message, bool reliable = true);
        bool SendMessageToServer(ushort id, byte[] message, bool reliable = true);
        void UnregisterMessageHandler(ushort id, Action<byte[]> messageHandler);

        bool IsServer { get; }

        bool MultiplayerActive { get; }

        ulong MyId { get; }

        string MyName { get; }

        IMyPlayerCollection Players { get; }

        ulong ServerId { get; }
    }
}

