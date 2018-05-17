namespace Sandbox.ModAPI
{
    using Sandbox.ModAPI.Interfaces.Terminal;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface IMyTerminalControls
    {
        event CustomActionGetDelegate CustomActionGetter;

        event CustomControlGetDelegate CustomControlGetter;

        void AddAction<TBlock>(IMyTerminalAction action);
        void AddControl<TBlock>(IMyTerminalControl item);
        IMyTerminalAction CreateAction<TBlock>(string id);
        TControl CreateControl<TControl, TBlock>(string id);
        IMyTerminalControlProperty<TValue> CreateProperty<TValue, TBlock>(string id);
        void GetActions<TBlock>(out List<IMyTerminalAction> items);
        void GetControls<TBlock>(out List<IMyTerminalControl> items);
        void RemoveAction<TBlock>(IMyTerminalAction action);
        void RemoveControl<TBlock>(IMyTerminalControl item);
    }
}

