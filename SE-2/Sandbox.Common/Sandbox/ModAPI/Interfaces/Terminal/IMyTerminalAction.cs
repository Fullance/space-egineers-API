namespace Sandbox.ModAPI.Interfaces.Terminal
{
    using Sandbox.ModAPI.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMyTerminalAction : ITerminalAction
    {
        Action<IMyTerminalBlock> Action { get; set; }

        Func<IMyTerminalBlock, bool> Enabled { get; set; }

        string Icon { get; set; }

        List<MyToolbarType> InvalidToolbarTypes { get; set; }

        StringBuilder Name { get; set; }

        bool ValidForGroups { get; set; }

        Action<IMyTerminalBlock, StringBuilder> Writer { get; set; }
    }
}

