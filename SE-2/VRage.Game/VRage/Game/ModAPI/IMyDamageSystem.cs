namespace VRage.Game.ModAPI
{
    using System;

    public interface IMyDamageSystem
    {
        void RegisterAfterDamageHandler(int priority, Action<object, MyDamageInformation> handler);
        void RegisterBeforeDamageHandler(int priority, BeforeDamageApplied handler);
        void RegisterDestroyHandler(int priority, Action<object, MyDamageInformation> handler);
    }
}

