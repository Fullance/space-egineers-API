namespace VRage.Game.VisualScripting.Campaign
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.Generics;

    public class MyCampaignStateMachineNode : MyStateMachineNode
    {
        public MyCampaignStateMachineNode(string name) : base(name)
        {
        }

        public override void OnUpdate(MyStateMachine stateMachine)
        {
            if (base.OutTransitions.Count == 0)
            {
                this.Finished = true;
            }
        }

        public bool Finished { get; private set; }

        public int InTransitionCount =>
            base.InTransitions.Count;

        public string SavePath { get; set; }
    }
}

