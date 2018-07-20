namespace VRage.Game.VisualScripting.Missions
{
    using System;
    using System.Collections.Generic;
    using VRage.Collections;
    using VRage.Generics;

    public class MyVSStateMachineBarrierNode : MyStateMachineNode
    {
        private readonly List<bool> m_cursorsFromInEdgesReceived;

        public MyVSStateMachineBarrierNode(string name) : base(name)
        {
            this.m_cursorsFromInEdgesReceived = new List<bool>();
        }

        protected override void ExpandInternal(MyStateMachineCursor cursor, MyConcurrentHashSet<MyStringId> enquedActions, int passThrough)
        {
            MyStateMachine stateMachine = cursor.StateMachine;
            int num = 0;
            while (num < base.InTransitions.Count)
            {
                if (base.InTransitions[num].Id == cursor.LastTransitionTakenId)
                {
                    break;
                }
                num++;
            }
            this.m_cursorsFromInEdgesReceived[num] = true;
            stateMachine.DeleteCursor(cursor.Id);
            using (List<bool>.Enumerator enumerator = this.m_cursorsFromInEdgesReceived.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (!enumerator.Current)
                    {
                        return;
                    }
                }
            }
            if (base.OutTransitions.Count > 0)
            {
                stateMachine.CreateCursor(base.OutTransitions[0].TargetNode.Name);
            }
        }

        protected override void TransitionAddedInternal(MyStateMachineTransition transition)
        {
            if (transition.TargetNode == this)
            {
                this.m_cursorsFromInEdgesReceived.Add(false);
            }
        }

        protected override void TransitionRemovedInternal(MyStateMachineTransition transition)
        {
            if (transition.TargetNode == this)
            {
                int index = base.InTransitions.IndexOf(transition);
                this.m_cursorsFromInEdgesReceived.RemoveAt(index);
            }
        }
    }
}

