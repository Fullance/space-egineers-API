namespace VRage.Game.VisualScripting.Missions
{
    using System;
    using VRage.Collections;
    using VRage.Generics;

    public class MyVSStateMachineFinalNode : MyStateMachineNode
    {
        public MyVSStateMachineFinalNode(string name) : base(name)
        {
        }

        protected override void ExpandInternal(MyStateMachineCursor cursor, MyConcurrentHashSet<MyStringId> enquedActions, int passThrough)
        {
            foreach (MyStateMachineCursor cursor2 in cursor.StateMachine.ActiveCursors)
            {
                cursor.StateMachine.DeleteCursor(cursor2.Id);
            }
        }
    }
}

