namespace VRage.Game.ModAPI
{
    using System;
    using VRage.ModAPI;

    public interface IMyGui
    {
        event Action<object> GuiControlCreated;

        event Action<object> GuiControlRemoved;

        string ActiveGamePlayScreen { get; }

        bool ChatEntryVisible { get; }

        MyTerminalPageEnum GetCurrentScreen { get; }

        IMyEntity InteractedEntity { get; }

        bool IsCursorVisible { get; }
    }
}

