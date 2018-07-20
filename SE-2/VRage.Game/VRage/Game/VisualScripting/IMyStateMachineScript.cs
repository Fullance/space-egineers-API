namespace VRage.Game.VisualScripting
{
    using System;
    using System.Runtime.InteropServices;

    public interface IMyStateMachineScript
    {
        [VisualScriptingMember(true, true)]
        void Complete(string transitionName = "Completed");
        [VisualScriptingMember(true, false)]
        void Deserialize();
        [VisualScriptingMember(true, false)]
        void Dispose();
        [VisualScriptingMember(false, true)]
        long GetOwnerId();
        [VisualScriptingMember(true, false)]
        void Init();
        [VisualScriptingMember(true, false)]
        void Update();

        long OwnerId { get; set; }

        string TransitionTo { get; set; }
    }
}

