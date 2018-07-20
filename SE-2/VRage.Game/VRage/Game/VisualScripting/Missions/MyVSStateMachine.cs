namespace VRage.Game.VisualScripting.Missions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;
    using VRage.Collections;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting.ScriptBuilder;
    using VRage.Generics;
    using VRage.Utils;

    public class MyVSStateMachine : MyStateMachine
    {
        private readonly MyConcurrentHashSet<MyStringId> m_cachedActions = new MyConcurrentHashSet<MyStringId>();
        private readonly List<MyStateMachineCursor> m_cursorsToDeserialize = new List<MyStateMachineCursor>();
        private readonly List<MyStateMachineCursor> m_cursorsToInit = new List<MyStateMachineCursor>();
        private MyObjectBuilder_ScriptSM m_objectBuilder;
        private long m_ownerId;

        public event Action<MyVSStateMachineNode, MyVSStateMachineNode> CursorStateChanged;

        public override MyStateMachineCursor CreateCursor(string nodeName)
        {
            foreach (MyStateMachineCursor cursor in base.m_activeCursorsById.Values)
            {
                if (cursor.Node.Name == nodeName)
                {
                    return null;
                }
            }
            MyStateMachineCursor item = base.CreateCursor(nodeName);
            if (item != null)
            {
                item.OnCursorStateChanged += new VRage.Generics.MyStateMachineCursor.CursorStateChanged(this.OnCursorStateChanged);
                if (item.Node is MyVSStateMachineNode)
                {
                    this.m_cursorsToInit.Add(item);
                }
            }
            return item;
        }

        public void Dispose()
        {
            base.m_activeCursors.ApplyChanges();
            for (int i = 0; i < base.m_activeCursors.Count; i++)
            {
                MyVSStateMachineNode node = base.m_activeCursors[i].Node as MyVSStateMachineNode;
                if (node != null)
                {
                    node.DisposeScript();
                }
                this.DeleteCursor(base.m_activeCursors[i].Id);
            }
            base.m_activeCursors.ApplyChanges();
            base.m_activeCursors.Clear();
        }

        public MyObjectBuilder_ScriptSM GetObjectBuilder()
        {
            this.m_objectBuilder.Cursors = new MyObjectBuilder_ScriptSMCursor[base.m_activeCursors.Count];
            this.m_objectBuilder.OwnerId = this.m_ownerId;
            for (int i = 0; i < base.m_activeCursors.Count; i++)
            {
                this.m_objectBuilder.Cursors[i] = new MyObjectBuilder_ScriptSMCursor { NodeName = base.m_activeCursors[i].Node.Name };
            }
            return this.m_objectBuilder;
        }

        public void Init(MyObjectBuilder_ScriptSM ob, long? ownerId = new long?())
        {
            this.m_objectBuilder = ob;
            base.Name = ob.Name;
            if (ob.Nodes != null)
            {
                foreach (MyObjectBuilder_ScriptSMNode node in ob.Nodes)
                {
                    MyStateMachineNode node2;
                    if (node is MyObjectBuilder_ScriptSMFinalNode)
                    {
                        node2 = new MyVSStateMachineFinalNode(node.Name);
                    }
                    else if (node is MyObjectBuilder_ScriptSMSpreadNode)
                    {
                        node2 = new MyVSStateMachineSpreadNode(node.Name);
                    }
                    else if (node is MyObjectBuilder_ScriptSMBarrierNode)
                    {
                        node2 = new MyVSStateMachineBarrierNode(node.Name);
                    }
                    else
                    {
                        Type script = MyVSAssemblyProvider.GetType("VisualScripting.CustomScripts." + node.ScriptClassName);
                        MyVSStateMachineNode node3 = new MyVSStateMachineNode(node.Name, script);
                        if (node3.ScriptInstance != null)
                        {
                            if (!ownerId.HasValue)
                            {
                                node3.ScriptInstance.OwnerId = ob.OwnerId;
                            }
                            else
                            {
                                node3.ScriptInstance.OwnerId = ownerId.Value;
                            }
                        }
                        node2 = node3;
                    }
                    this.AddNode(node2);
                }
            }
            if (ob.Transitions != null)
            {
                foreach (MyObjectBuilder_ScriptSMTransition transition in ob.Transitions)
                {
                    this.AddTransition(transition.From, transition.To, null, transition.Name);
                }
            }
            if (ob.Cursors != null)
            {
                foreach (MyObjectBuilder_ScriptSMCursor cursor in ob.Cursors)
                {
                    this.CreateCursor(cursor.NodeName);
                }
            }
        }

        private void NotifyStateChanged(MyVSStateMachineNode from, MyVSStateMachineNode to)
        {
            if (this.CursorStateChanged != null)
            {
                this.CursorStateChanged(from, to);
            }
        }

        private void OnCursorStateChanged(int transitionId, MyStringId action, MyStateMachineNode node, MyStateMachine stateMachine)
        {
            MyVSStateMachineNode startNode = base.FindTransitionWithStart(transitionId).StartNode as MyVSStateMachineNode;
            if (startNode != null)
            {
                startNode.DisposeScript();
            }
            MyVSStateMachineNode to = node as MyVSStateMachineNode;
            if (to != null)
            {
                to.ActivateScript(false);
            }
            this.NotifyStateChanged(startNode, to);
        }

        public MyStateMachineCursor RestoreCursor(string nodeName)
        {
            foreach (MyStateMachineCursor cursor in base.m_activeCursorsById.Values)
            {
                if (cursor.Node.Name == nodeName)
                {
                    return null;
                }
            }
            MyStateMachineCursor item = base.CreateCursor(nodeName);
            if (item != null)
            {
                item.OnCursorStateChanged += new VRage.Generics.MyStateMachineCursor.CursorStateChanged(this.OnCursorStateChanged);
                if (item.Node is MyVSStateMachineNode)
                {
                    this.m_cursorsToDeserialize.Add(item);
                }
            }
            return item;
        }

        public void TriggerCachedAction(MyStringId actionName)
        {
            this.m_cachedActions.Add(actionName);
        }

        public override void Update()
        {
            base.m_activeCursors.ApplyChanges();
            foreach (MyStateMachineCursor cursor in this.m_cursorsToDeserialize)
            {
                MyVSStateMachineNode node = cursor.Node as MyVSStateMachineNode;
                if (node != null)
                {
                    node.ActivateScript(true);
                }
            }
            this.m_cursorsToDeserialize.Clear();
            foreach (MyStateMachineCursor cursor2 in this.m_cursorsToInit)
            {
                MyVSStateMachineNode node2 = cursor2.Node as MyVSStateMachineNode;
                if (node2 != null)
                {
                    node2.ActivateScript(false);
                }
            }
            this.m_cursorsToInit.Clear();
            foreach (MyStringId id in this.m_cachedActions)
            {
                base.m_enqueuedActions.Add(id);
            }
            this.m_cachedActions.Clear();
            base.Update();
        }

        public int ActiveCursorCount =>
            base.m_activeCursors.Count;

        public long OwnerId
        {
            get => 
                this.m_ownerId;
            set
            {
                foreach (MyStateMachineNode node in base.m_nodes.Values)
                {
                    MyVSStateMachineNode node2 = node as MyVSStateMachineNode;
                    if ((node2 != null) && (node2.ScriptInstance != null))
                    {
                        node2.ScriptInstance.OwnerId = value;
                    }
                }
                this.m_ownerId = value;
            }
        }
    }
}

