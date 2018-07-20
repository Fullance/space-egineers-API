namespace VRage.Game.VisualScripting.ScriptBuilder.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using VRage.Collections;
    using VRage.Game;
    using VRage.Game.VisualScripting.ScriptBuilder;

    public class MyVisualSyntaxNode
    {
        internal int Depth = 0x7fffffff;
        private static readonly MyBinaryStructHeap<int, HeapNodeWrapper> m_activeHeap = new MyBinaryStructHeap<int, HeapNodeWrapper>(0x80, null);
        private static readonly HashSet<MyVisualSyntaxNode> m_commonParentSet = new HashSet<MyVisualSyntaxNode>();
        protected MyObjectBuilder_ScriptNode m_objectBuilder;
        private static readonly HashSet<MyVisualSyntaxNode> m_sequenceHelper = new HashSet<MyVisualSyntaxNode>();
        internal HashSet<MyVisualSyntaxNode> SubTreeNodes = new HashSet<MyVisualSyntaxNode>();

        internal MyVisualSyntaxNode(MyObjectBuilder_ScriptNode ob)
        {
            this.m_objectBuilder = ob;
            this.Inputs = new List<MyVisualSyntaxNode>();
            this.Outputs = new List<MyVisualSyntaxNode>();
            this.SequenceInputs = new List<MyVisualSyntaxNode>();
            this.SequenceOutputs = new List<MyVisualSyntaxNode>();
        }

        internal virtual void CollectInputExpressions(List<StatementSyntax> expressions)
        {
            this.Collected = true;
            foreach (MyVisualSyntaxNode node in this.SubTreeNodes)
            {
                if (!node.Collected)
                {
                    node.CollectInputExpressions(expressions);
                }
            }
        }

        internal virtual void CollectSequenceExpressions(List<StatementSyntax> expressions)
        {
            this.CollectInputExpressions(expressions);
            foreach (MyVisualSyntaxNode node in this.SequenceOutputs)
            {
                node.CollectSequenceExpressions(expressions);
            }
        }

        protected static MyVisualSyntaxNode CommonParent(IEnumerable<MyVisualSyntaxNode> nodes)
        {
            Action<MyVisualSyntaxNode> action = null;
            HeapNodeWrapper current;
            m_commonParentSet.Clear();
            m_activeHeap.Clear();
            foreach (MyVisualSyntaxNode node in nodes)
            {
                if (m_commonParentSet.Add(node))
                {
                    HeapNodeWrapper wrapper = new HeapNodeWrapper {
                        Node = node
                    };
                    m_activeHeap.Insert(wrapper, -node.Depth);
                }
            }
        Label_0075:
            current = m_activeHeap.RemoveMin();
            if (m_activeHeap.Count != 0)
            {
                if (current.Node.SequenceInputs.Count == 0)
                {
                    if (m_activeHeap.Count > 0)
                    {
                        return null;
                    }
                }
                else
                {
                    if (action == null)
                    {
                        action = delegate (MyVisualSyntaxNode node) {
                            if ((m_activeHeap.Count > 0) && m_commonParentSet.Add(node))
                            {
                                current.Node = node;
                                m_activeHeap.Insert(current, -current.Node.Depth);
                            }
                        };
                    }
                    current.Node.SequenceInputs.ForEach(action);
                }
                goto Label_0075;
            }
            if (current.Node is MyVisualSyntaxForLoopNode)
            {
                return current.Node.SequenceInputs.FirstOrDefault<MyVisualSyntaxNode>();
            }
            return current.Node;
        }

        public override int GetHashCode()
        {
            if (this.ObjectBuilder == null)
            {
                return base.GetType().GetHashCode();
            }
            return this.ObjectBuilder.ID;
        }

        public IEnumerable<MyVisualSyntaxNode> GetSequenceDependentOutputs()
        {
            m_sequenceHelper.Clear();
            this.SequenceDependentChildren(m_sequenceHelper);
            return m_sequenceHelper;
        }

        protected internal virtual void Preprocess(int currentDepth)
        {
            if (currentDepth < this.Depth)
            {
                this.Depth = currentDepth;
            }
            if (!this.Preprocessed)
            {
                foreach (MyVisualSyntaxNode node in this.SequenceOutputs)
                {
                    node.Preprocess(this.Depth + 1);
                }
            }
            foreach (MyVisualSyntaxNode node2 in this.Inputs)
            {
                if (!node2.SequenceDependent)
                {
                    node2.Preprocess(this.Depth);
                }
            }
            if (!this.SequenceDependent && !this.Preprocessed)
            {
                if ((this.Outputs.Count == 1) && !this.Outputs[0].SequenceDependent)
                {
                    this.Outputs[0].SubTreeNodes.Add(this);
                }
                else if (this.Outputs.Count > 0)
                {
                    this.Navigator.FreshNodes.Add(this);
                }
            }
            this.Preprocessed = true;
        }

        internal virtual void Reset()
        {
            this.Depth = 0x7fffffff;
            this.SubTreeNodes.Clear();
            this.Inputs.Clear();
            this.Outputs.Clear();
            this.SequenceOutputs.Clear();
            this.SequenceInputs.Clear();
            this.Collected = false;
            this.Preprocessed = false;
        }

        private void SequenceDependentChildren(HashSet<MyVisualSyntaxNode> results)
        {
            if ((this.Outputs.Count != 0) && (this.Depth != 0x7fffffff))
            {
                foreach (MyVisualSyntaxNode node in this.Outputs)
                {
                    if (node.Depth != 0x7fffffff)
                    {
                        if (node.SequenceDependent)
                        {
                            results.Add(node);
                        }
                        else
                        {
                            node.SequenceDependentChildren(results);
                        }
                    }
                }
            }
        }

        protected MyVisualSyntaxNode TryRegisterNode(int nodeID, List<MyVisualSyntaxNode> collection)
        {
            if (nodeID == -1)
            {
                return null;
            }
            MyVisualSyntaxNode nodeByID = this.Navigator.GetNodeByID(nodeID);
            if (nodeByID != null)
            {
                collection.Add(nodeByID);
            }
            return nodeByID;
        }

        protected internal virtual string VariableSyntaxName(string variableIdentifier = null)
        {
            throw new NotImplementedException();
        }

        internal bool Collected { get; private set; }

        internal List<MyVisualSyntaxNode> Inputs { virtual get; private set; }

        internal MyVisualScriptNavigator Navigator { get; set; }

        public MyObjectBuilder_ScriptNode ObjectBuilder =>
            this.m_objectBuilder;

        internal List<MyVisualSyntaxNode> Outputs { virtual get; private set; }

        protected bool Preprocessed { get; set; }

        internal virtual bool SequenceDependent =>
            true;

        internal List<MyVisualSyntaxNode> SequenceInputs { virtual get; private set; }

        internal List<MyVisualSyntaxNode> SequenceOutputs { virtual get; private set; }

        [StructLayout(LayoutKind.Sequential)]
        protected struct HeapNodeWrapper
        {
            public MyVisualSyntaxNode Node;
        }
    }
}

