namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;

    public interface IMyHudObjectiveLine
    {
        void AdvanceObjective();
        void Hide();
        void Show();

        string CurrentObjective { get; }

        List<string> Objectives { get; set; }

        string Title { get; set; }

        bool Visible { get; }
    }
}

