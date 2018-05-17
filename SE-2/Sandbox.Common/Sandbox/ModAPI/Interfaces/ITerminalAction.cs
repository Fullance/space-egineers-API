namespace Sandbox.ModAPI.Interfaces
{
    using System;
    using System.Text;
    using VRage.Collections;
    using VRage.Game.ModAPI.Ingame;

    public interface ITerminalAction
    {
        void Apply(IMyCubeBlock block);
        void Apply(IMyCubeBlock block, ListReader<TerminalActionParameter> terminalActionParameters);
        bool IsEnabled(IMyCubeBlock block);
        void WriteValue(IMyCubeBlock block, StringBuilder appendTo);

        string Icon { get; }

        string Id { get; }

        StringBuilder Name { get; }
    }
}

