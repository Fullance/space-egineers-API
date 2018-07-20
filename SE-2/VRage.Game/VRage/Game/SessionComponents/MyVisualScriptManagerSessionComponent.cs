namespace VRage.Game.SessionComponents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using VRage.Collections;
    using VRage.FileSystem;
    using VRage.Game;
    using VRage.Game.Components;
    using VRage.Game.ObjectBuilders.Gui;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.Game.VisualScripting;
    using VRage.Game.VisualScripting.ScriptBuilder;
    using VRage.Utils;

    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation, 0x3e8, typeof(MyObjectBuilder_VisualScriptManagerSessionComponent), (Type) null)]
    public class MyVisualScriptManagerSessionComponent : MySessionComponentBase
    {
        private string[] m_failedLevelScriptExceptionTexts;
        private static bool m_firstUpdate = true;
        private CachingList<IMyLevelScript> m_levelScripts;
        private MyObjectBuilder_VisualScriptManagerSessionComponent m_objectBuilder;
        private readonly Dictionary<string, string> m_relativePathsToAbsolute = new Dictionary<string, string>();
        private string[] m_runningLevelScriptNames;
        private MyVSStateMachineManager m_smManager;
        private readonly List<string> m_stateMachineDefinitionFilePaths = new List<string>();

        public override void BeforeStart()
        {
            Action<IMyLevelScript> action = null;
            if (this.m_objectBuilder != null)
            {
                this.m_relativePathsToAbsolute.Clear();
                this.m_stateMachineDefinitionFilePaths.Clear();
                if (this.m_objectBuilder.LevelScriptFiles != null)
                {
                    foreach (string str in this.m_objectBuilder.LevelScriptFiles)
                    {
                        MyContentPath path = Path.Combine(this.CampaignModPath ?? MyFileSystem.ContentPath, str);
                        if (path.GetExitingFilePath() != null)
                        {
                            this.m_relativePathsToAbsolute.Add(str, path.GetExitingFilePath());
                        }
                        else
                        {
                            MyLog.Default.WriteLine(str + " Level Script was not found.");
                        }
                    }
                }
                if (this.m_objectBuilder.StateMachines != null)
                {
                    foreach (string str2 in this.m_objectBuilder.StateMachines)
                    {
                        MyContentPath path2 = Path.Combine(this.CampaignModPath ?? MyFileSystem.ContentPath, str2);
                        if (path2.GetExitingFilePath() != null)
                        {
                            if (!this.m_relativePathsToAbsolute.ContainsKey(str2))
                            {
                                this.m_stateMachineDefinitionFilePaths.Add(path2.GetExitingFilePath());
                            }
                            this.m_relativePathsToAbsolute.Add(str2, path2.GetExitingFilePath());
                        }
                        else
                        {
                            MyLog.Default.WriteLine(str2 + " Mission File was not found.");
                        }
                    }
                }
                if (base.Session.Mods != null)
                {
                    foreach (MyObjectBuilder_Checkpoint.ModItem item in base.Session.Mods)
                    {
                        string str3 = Path.Combine(MyFileSystem.ModsPath, item.PublishedFileId + ".sbm");
                        if (!MyFileSystem.DirectoryExists(str3))
                        {
                            str3 = Path.Combine(MyFileSystem.ModsPath, item.Name);
                            if (!MyFileSystem.DirectoryExists(str3))
                            {
                                str3 = null;
                            }
                        }
                        if (!string.IsNullOrEmpty(str3))
                        {
                            foreach (string str4 in MyFileSystem.GetFiles(str3, "*", MySearchOption.AllDirectories))
                            {
                                string extension = Path.GetExtension(str4);
                                string key = MyFileSystem.MakeRelativePath(Path.Combine(str3, "VisualScripts"), str4);
                                switch (extension)
                                {
                                    case ".vs":
                                    case ".vsc":
                                        if (this.m_relativePathsToAbsolute.ContainsKey(key))
                                        {
                                            this.m_relativePathsToAbsolute[key] = str4;
                                        }
                                        else
                                        {
                                            this.m_relativePathsToAbsolute.Add(key, str4);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                MyVSAssemblyProvider.Init(this.m_relativePathsToAbsolute.Values);
                this.m_levelScripts = new CachingList<IMyLevelScript>();
                List<IMyLevelScript> levelScriptInstances = MyVSAssemblyProvider.GetLevelScriptInstances();
                if (levelScriptInstances != null)
                {
                    if (action == null)
                    {
                        action = script => this.m_levelScripts.Add(script);
                    }
                    levelScriptInstances.ForEach(action);
                }
                this.m_levelScripts.ApplyAdditions();
                this.m_runningLevelScriptNames = (from x in this.m_levelScripts select x.GetType().Name).ToArray<string>();
                this.m_failedLevelScriptExceptionTexts = new string[this.m_runningLevelScriptNames.Length];
                this.m_smManager = new MyVSStateMachineManager();
                foreach (string str7 in this.m_stateMachineDefinitionFilePaths)
                {
                    this.m_smManager.AddMachine(str7);
                }
                if ((this.m_objectBuilder != null) && (this.m_objectBuilder.ScriptStateMachineManager != null))
                {
                    foreach (MyObjectBuilder_ScriptStateMachineManager.CursorStruct struct2 in this.m_objectBuilder.ScriptStateMachineManager.ActiveStateMachines)
                    {
                        this.m_smManager.Restore(struct2.StateMachineName, struct2.Cursors);
                    }
                }
            }
        }

        private void DisposeRunningScripts()
        {
            if (this.m_levelScripts != null)
            {
                foreach (IMyLevelScript script in this.m_levelScripts)
                {
                    script.GameFinished();
                    script.Dispose();
                }
                this.m_smManager.Dispose();
                this.m_smManager = null;
                this.m_levelScripts.Clear();
                this.m_levelScripts.ApplyRemovals();
            }
        }

        public override MyObjectBuilder_SessionComponent GetObjectBuilder()
        {
            if (!base.Session.IsServer)
            {
                return null;
            }
            this.m_objectBuilder.ScriptStateMachineManager = this.m_smManager.GetObjectBuilder();
            this.m_objectBuilder.FirstRun = m_firstUpdate;
            return this.m_objectBuilder;
        }

        public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
        {
            base.Init(sessionComponent);
            if (base.Session.IsServer)
            {
                MyObjectBuilder_VisualScriptManagerSessionComponent component = (MyObjectBuilder_VisualScriptManagerSessionComponent) sessionComponent;
                this.m_objectBuilder = component;
                m_firstUpdate = component.FirstRun;
            }
        }

        public void Reset()
        {
            if (this.m_smManager != null)
            {
                this.m_smManager.Dispose();
            }
            m_firstUpdate = true;
        }

        protected override void UnloadData()
        {
            base.UnloadData();
            this.DisposeRunningScripts();
        }

        public override void UpdateBeforeSimulation()
        {
            if (base.Session.IsServer)
            {
                if (this.m_smManager != null)
                {
                    this.m_smManager.Update();
                }
                if (this.m_levelScripts != null)
                {
                    foreach (IMyLevelScript script in this.m_levelScripts)
                    {
                        try
                        {
                            if (m_firstUpdate)
                            {
                                script.GameStarted();
                            }
                            else
                            {
                                script.Update();
                            }
                        }
                        catch (Exception exception)
                        {
                            string name = script.GetType().Name;
                            for (int i = 0; i < this.m_runningLevelScriptNames.Length; i++)
                            {
                                if (this.m_runningLevelScriptNames[i] == name)
                                {
                                    string[] strArray;
                                    IntPtr ptr;
                                    (strArray = this.m_runningLevelScriptNames)[(int) (ptr = (IntPtr) i)] = strArray[(int) ptr] + " - failed";
                                    this.m_failedLevelScriptExceptionTexts[i] = exception.ToString();
                                }
                            }
                            this.m_levelScripts.Remove(script, false);
                        }
                    }
                    this.m_levelScripts.ApplyRemovals();
                    m_firstUpdate = false;
                }
            }
        }

        public string CampaignModPath { get; set; }

        public string[] FailedLevelScriptExceptionTexts =>
            this.m_failedLevelScriptExceptionTexts;

        public MyObjectBuilder_Questlog QuestlogData
        {
            get
            {
                if (this.m_objectBuilder != null)
                {
                    return this.m_objectBuilder.Questlog;
                }
                return null;
            }
            set
            {
                if (this.m_objectBuilder != null)
                {
                    this.m_objectBuilder.Questlog = value;
                }
            }
        }

        public string[] RunningLevelScriptNames =>
            this.m_runningLevelScriptNames;

        public MyVSStateMachineManager SMManager =>
            this.m_smManager;
    }
}

