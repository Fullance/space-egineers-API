namespace VRage.Game.VisualScripting.ScriptBuilder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using VRage.FileSystem;
    using VRage.Game.ObjectBuilders.VisualScripting;
    using VRage.ObjectBuilders;
    using VRage.Utils;

    public class MyVSPreprocessor
    {
        private readonly HashSet<string> m_classNames = new HashSet<string>();
        private readonly HashSet<string> m_filePaths = new HashSet<string>();

        public void AddFile(string filePath)
        {
            if ((filePath != null) && this.m_filePaths.Add(filePath))
            {
                MyObjectBuilder_VSFiles objectBuilder = null;
                MyContentPath path = new MyContentPath(filePath, null);
                using (Stream stream = MyFileSystem.OpenRead(filePath))
                {
                    if (stream == null)
                    {
                        MyLog.Default.WriteLine("VisualScripting Preprocessor: " + filePath + " is Missing.");
                    }
                    if (!MyObjectBuilderSerializer.DeserializeXML<MyObjectBuilder_VSFiles>(stream, out objectBuilder))
                    {
                        this.m_filePaths.Remove(filePath);
                        return;
                    }
                }
                if (objectBuilder.VisualScript != null)
                {
                    if (this.m_classNames.Add(objectBuilder.VisualScript.Name))
                    {
                        foreach (string str in objectBuilder.VisualScript.DependencyFilePaths)
                        {
                            this.AddFile(new MyContentPath(str, path.ModFolder).GetExitingFilePath());
                        }
                    }
                    else
                    {
                        this.m_filePaths.Remove(filePath);
                    }
                }
                if (objectBuilder.StateMachine != null)
                {
                    foreach (MyObjectBuilder_ScriptSMNode node in objectBuilder.StateMachine.Nodes)
                    {
                        if ((!(node is MyObjectBuilder_ScriptSMSpreadNode) && !(node is MyObjectBuilder_ScriptSMBarrierNode)) && !string.IsNullOrEmpty(node.ScriptFilePath))
                        {
                            this.AddFile(new MyContentPath(node.ScriptFilePath, path.ModFolder).GetExitingFilePath());
                        }
                    }
                    this.m_filePaths.Remove(filePath);
                }
                if (objectBuilder.LevelScript != null)
                {
                    if (this.m_classNames.Add(objectBuilder.LevelScript.Name))
                    {
                        foreach (string str2 in objectBuilder.LevelScript.DependencyFilePaths)
                        {
                            this.AddFile(new MyContentPath(str2, path.ModFolder).GetExitingFilePath());
                        }
                    }
                    else
                    {
                        this.m_filePaths.Remove(filePath);
                    }
                }
            }
        }

        public void Clear()
        {
            this.m_filePaths.Clear();
            this.m_classNames.Clear();
        }

        public string[] FileSet
        {
            get
            {
                string[] strArray = new string[this.m_filePaths.Count];
                int num = 0;
                foreach (string str in this.m_filePaths)
                {
                    strArray[num++] = str;
                }
                return strArray;
            }
        }
    }
}

