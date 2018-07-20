namespace VRage.Game.VisualScripting.ScriptBuilder
{
    using System;
    using System.Collections.Generic;
    using VRage.Game;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.ScriptBuilder.Nodes;

    internal class MyVisualScriptNavigator
    {
        private readonly List<MyVisualSyntaxNode> m_freshNodes = new List<MyVisualSyntaxNode>();
        private readonly Dictionary<int, MyVisualSyntaxNode> m_idToNode = new Dictionary<int, MyVisualSyntaxNode>();
        private readonly Dictionary<Type, List<MyVisualSyntaxNode>> m_nodesByType = new Dictionary<Type, List<MyVisualSyntaxNode>>();
        private readonly Dictionary<string, MyVisualSyntaxVariableNode> m_variablesByName = new Dictionary<string, MyVisualSyntaxVariableNode>();

        public MyVisualScriptNavigator(MyObjectBuilder_VisualScript scriptOb)
        {
            Type baseClass = string.IsNullOrEmpty(scriptOb.Interface) ? null : MyVisualScriptingProxy.GetType(scriptOb.Interface);
            foreach (MyObjectBuilder_ScriptNode node in scriptOb.Nodes)
            {
                MyVisualSyntaxNode node2;
                if (node is MyObjectBuilder_NewListScriptNode)
                {
                    node2 = new MyVisualSyntaxNewListNode(node);
                }
                else if (node is MyObjectBuilder_SwitchScriptNode)
                {
                    node2 = new MyVisualSyntaxSwitchNode(node);
                }
                else if (node is MyObjectBuilder_LocalizationScriptNode)
                {
                    node2 = new MyVisualSyntaxLocalizationNode(node);
                }
                else if (node is MyObjectBuilder_LogicGateScriptNode)
                {
                    node2 = new MyVisualSyntaxLogicGateNode(node);
                }
                else if (node is MyObjectBuilder_ForLoopScriptNode)
                {
                    node2 = new MyVisualSyntaxForLoopNode(node);
                }
                else if (node is MyObjectBuilder_SequenceScriptNode)
                {
                    node2 = new MyVisualSyntaxSequenceNode(node);
                }
                else if (node is MyObjectBuilder_ArithmeticScriptNode)
                {
                    node2 = new MyVisualSyntaxArithmeticNode(node);
                }
                else if (node is MyObjectBuilder_InterfaceMethodNode)
                {
                    node2 = new MyVisualSyntaxInterfaceMethodNode(node, baseClass);
                }
                else if (node is MyObjectBuilder_KeyEventScriptNode)
                {
                    node2 = new MyVisualSyntaxKeyEventNode(node);
                }
                else if (node is MyObjectBuilder_BranchingScriptNode)
                {
                    node2 = new MyVisualSyntaxBranchingNode(node);
                }
                else if (node is MyObjectBuilder_InputScriptNode)
                {
                    node2 = new MyVisualSyntaxInputNode(node);
                }
                else if (node is MyObjectBuilder_CastScriptNode)
                {
                    node2 = new MyVisualSyntaxCastNode(node);
                }
                else if (node is MyObjectBuilder_EventScriptNode)
                {
                    node2 = new MyVisualSyntaxEventNode(node);
                }
                else if (node is MyObjectBuilder_FunctionScriptNode)
                {
                    node2 = new MyVisualSyntaxFunctionNode(node, baseClass);
                }
                else if (node is MyObjectBuilder_VariableSetterScriptNode)
                {
                    node2 = new MyVisualSyntaxSetterNode(node);
                }
                else if (node is MyObjectBuilder_TriggerScriptNode)
                {
                    node2 = new MyVisualSyntaxTriggerNode(node);
                }
                else if (node is MyObjectBuilder_VariableScriptNode)
                {
                    node2 = new MyVisualSyntaxVariableNode(node);
                }
                else if (node is MyObjectBuilder_ConstantScriptNode)
                {
                    node2 = new MyVisualSyntaxConstantNode(node);
                }
                else if (node is MyObjectBuilder_GetterScriptNode)
                {
                    node2 = new MyVisualSyntaxGetterNode(node);
                }
                else if (node is MyObjectBuilder_OutputScriptNode)
                {
                    node2 = new MyVisualSyntaxOutputNode(node);
                }
                else
                {
                    if (!(node is MyObjectBuilder_ScriptScriptNode))
                    {
                        continue;
                    }
                    node2 = new MyVisualSyntaxScriptNode(node);
                }
                node2.Navigator = this;
                this.m_idToNode.Add(node.ID, node2);
                Type type = node2.GetType();
                if (!this.m_nodesByType.ContainsKey(type))
                {
                    this.m_nodesByType.Add(type, new List<MyVisualSyntaxNode>());
                }
                this.m_nodesByType[type].Add(node2);
                if (type == typeof(MyVisualSyntaxVariableNode))
                {
                    this.m_variablesByName.Add(((MyObjectBuilder_VariableScriptNode) node).VariableName, (MyVisualSyntaxVariableNode) node2);
                }
            }
        }

        public MyVisualSyntaxNode GetNodeByID(int id)
        {
            MyVisualSyntaxNode node;
            this.m_idToNode.TryGetValue(id, out node);
            return node;
        }

        public MyVisualSyntaxVariableNode GetVariable(string name)
        {
            MyVisualSyntaxVariableNode node;
            this.m_variablesByName.TryGetValue(name, out node);
            return node;
        }

        public List<T> OfType<T>() where T: MyVisualSyntaxNode
        {
            List<MyVisualSyntaxNode> list = new List<MyVisualSyntaxNode>();
            foreach (KeyValuePair<Type, List<MyVisualSyntaxNode>> pair in this.m_nodesByType)
            {
                if (typeof(T) == pair.Key)
                {
                    list.AddRange(pair.Value);
                }
            }
            return list.ConvertAll<T>(node => (T) node);
        }

        public void ResetNodes()
        {
            foreach (KeyValuePair<int, MyVisualSyntaxNode> pair in this.m_idToNode)
            {
                pair.Value.Reset();
            }
        }

        public List<MyVisualSyntaxNode> FreshNodes =>
            this.m_freshNodes;
    }
}

