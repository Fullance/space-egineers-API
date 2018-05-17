namespace VRage.Game.ModAPI
{
    using System;

    public interface IMyHudNotification
    {
        void Hide();
        void ResetAliveTime();
        void Show();

        int AliveTime { get; set; }

        string Font { get; set; }

        string Text { get; set; }
    }
}

