namespace VRage.Game.VisualScripting.Campaign
{
    using System;
    using VRage.Game.ObjectBuilders.Campaign;
    using VRage.Generics;

    public class MyCampaignStateMachine : MySingleStateMachine
    {
        private MyObjectBuilder_CampaignSM m_objectBuilder;

        public void Deserialize(MyObjectBuilder_CampaignSM ob)
        {
            if (this.m_objectBuilder == null)
            {
                this.m_objectBuilder = ob;
                foreach (MyObjectBuilder_CampaignSMNode node in this.m_objectBuilder.Nodes)
                {
                    MyCampaignStateMachineNode newNode = new MyCampaignStateMachineNode(node.Name) {
                        SavePath = node.SaveFilePath
                    };
                    this.AddNode(newNode);
                }
                foreach (MyObjectBuilder_CampaignSMTransition transition in this.m_objectBuilder.Transitions)
                {
                    this.AddTransition(transition.From, transition.To, null, transition.Name);
                }
            }
        }

        public void ResetToStart()
        {
            foreach (MyStateMachineNode node in base.m_nodes.Values)
            {
                MyCampaignStateMachineNode node2 = node as MyCampaignStateMachineNode;
                if ((node2 != null) && (node2.InTransitionCount == 0))
                {
                    base.SetState(node2.Name);
                    break;
                }
            }
        }

        public bool Finished =>
            ((MyCampaignStateMachineNode) base.CurrentNode).Finished;

        public bool Initialized =>
            (this.m_objectBuilder != null);
    }
}

