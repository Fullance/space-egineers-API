namespace VRage.Game.VisualScripting.Missions
{
    using System;
    using VRage.Collections;
    using VRage.Generics;

    public class MyVSStateMachineSpreadNode : MyStateMachineNode
    {
        public MyVSStateMachineSpreadNode(string nodeName) : base(nodeName)
        {
        }

        protected override void ExpandInternal(MyStateMachineCursor cursor, MyConcurrentHashSet<MyStringId> enquedActions, int passThrough)
        {
            if (base.OutTransitions.Count != 0)
            {
                MyStateMachine stateMachine = cursor.StateMachine;
                stateMachine.DeleteCursor(cursor.Id);
                for (int i = 0; i < base.OutTransitions.Count; i++)
                {
                    stateMachine.CreateCursor(base.OutTransitions[i].TargetNode.Name);
                }
            }
        }
    }
}

