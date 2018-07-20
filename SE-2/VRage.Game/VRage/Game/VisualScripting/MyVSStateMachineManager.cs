namespace VRage.Game.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;
    using VRage.Collections;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting.Missions;
    using VRage.ObjectBuilders;

    public class MyVSStateMachineManager
    {
        private readonly Dictionary<string, MyObjectBuilder_ScriptSM> m_machineDefinitions = new Dictionary<string, MyObjectBuilder_ScriptSM>();
        private readonly CachingList<MyVSStateMachine> m_runningMachines = new CachingList<MyVSStateMachine>();

        public event Action<MyVSStateMachine> StateMachineStarted;

        public string AddMachine(string filePath)
        {
            MyObjectBuilder_VSFiles files;
            if (!MyObjectBuilderSerializer.DeserializeXML<MyObjectBuilder_VSFiles>(filePath, out files) || (files.StateMachine == null))
            {
                return null;
            }
            if (this.m_machineDefinitions.ContainsKey(files.StateMachine.Name))
            {
                return null;
            }
            this.m_machineDefinitions.Add(files.StateMachine.Name, files.StateMachine);
            return files.StateMachine.Name;
        }

        public void Dispose()
        {
            foreach (MyVSStateMachine machine in this.m_runningMachines)
            {
                machine.Dispose();
            }
            this.m_runningMachines.Clear();
        }

        public MyObjectBuilder_ScriptStateMachineManager GetObjectBuilder()
        {
            MyObjectBuilder_ScriptStateMachineManager manager = new MyObjectBuilder_ScriptStateMachineManager {
                ActiveStateMachines = new List<MyObjectBuilder_ScriptStateMachineManager.CursorStruct>()
            };
            foreach (MyVSStateMachine machine in this.m_runningMachines)
            {
                List<MyStateMachineCursor> activeCursors = machine.ActiveCursors;
                MyObjectBuilder_ScriptSMCursor[] cursorArray = new MyObjectBuilder_ScriptSMCursor[activeCursors.Count];
                for (int i = 0; i < activeCursors.Count; i++)
                {
                    cursorArray[i] = new MyObjectBuilder_ScriptSMCursor { NodeName = activeCursors[i].Node.Name };
                }
                MyObjectBuilder_ScriptStateMachineManager.CursorStruct item = new MyObjectBuilder_ScriptStateMachineManager.CursorStruct {
                    Cursors = cursorArray,
                    StateMachineName = machine.Name
                };
                manager.ActiveStateMachines.Add(item);
            }
            return manager;
        }

        public bool Restore(string machineName, IEnumerable<MyObjectBuilder_ScriptSMCursor> cursors)
        {
            MyObjectBuilder_ScriptSM tsm;
            if (!this.m_machineDefinitions.TryGetValue(machineName, out tsm))
            {
                return false;
            }
            MyObjectBuilder_ScriptSM ob = new MyObjectBuilder_ScriptSM {
                Name = tsm.Name,
                Nodes = tsm.Nodes,
                Transitions = tsm.Transitions
            };
            MyVSStateMachine entity = new MyVSStateMachine();
            entity.Init(ob, null);
            foreach (MyObjectBuilder_ScriptSMCursor cursor in cursors)
            {
                if (entity.RestoreCursor(cursor.NodeName) == null)
                {
                    return false;
                }
            }
            this.m_runningMachines.Add(entity);
            if (this.StateMachineStarted != null)
            {
                this.StateMachineStarted(entity);
            }
            return true;
        }

        public bool Run(string machineName, long ownerId = 0L)
        {
            MyObjectBuilder_ScriptSM tsm;
            if (!this.m_machineDefinitions.TryGetValue(machineName, out tsm))
            {
                return false;
            }
            MyVSStateMachine entity = new MyVSStateMachine();
            entity.Init(tsm, new long?(ownerId));
            this.m_runningMachines.Add(entity);
            if (MyVisualScriptLogicProvider.MissionStarted != null)
            {
                MyVisualScriptLogicProvider.MissionStarted(entity.Name);
            }
            if (this.StateMachineStarted != null)
            {
                this.StateMachineStarted(entity);
            }
            return true;
        }

        public void Update()
        {
            this.m_runningMachines.ApplyChanges();
            foreach (MyVSStateMachine machine in this.m_runningMachines)
            {
                machine.Update();
                if (machine.ActiveCursorCount == 0)
                {
                    this.m_runningMachines.Remove(machine, false);
                    if (MyVisualScriptLogicProvider.MissionFinished != null)
                    {
                        MyVisualScriptLogicProvider.MissionFinished(machine.Name);
                    }
                }
            }
        }

        public Dictionary<string, MyObjectBuilder_ScriptSM> MachineDefinitions =>
            this.m_machineDefinitions;

        public IEnumerable<MyVSStateMachine> RunningMachines =>
            this.m_runningMachines;
    }
}

