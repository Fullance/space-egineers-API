namespace VRage.Game.VisualScripting
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class MyObjectiveLogicScript : IMyStateMachineScript
    {
        public void Complete(string transitionName = "Completed")
        {
            this.TransitionTo = transitionName;
        }

        public virtual void Deserialize()
        {
        }

        public virtual void Dispose()
        {
        }

        public long GetOwnerId() => 
            this.OwnerId;

        public virtual void Init()
        {
        }

        public virtual void Update()
        {
        }

        public long OwnerId { get; set; }

        public string TransitionTo { get; set; }
    }
}

