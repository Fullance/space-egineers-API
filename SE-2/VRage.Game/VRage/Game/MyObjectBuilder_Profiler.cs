namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using VRage.FileSystem;
    using VRage.ObjectBuilders;
    using VRage.Profiler;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_Profiler : MyObjectBuilder_Base
    {
        public string AxisName = "";
        public long[] CommitTimes;
        public string CustomName = "";
        public List<MyObjectBuilder_ProfilerBlock> ProfilingBlocks;
        public List<MyProfilerBlockKey> RootBlocks;
        public bool ShallowProfile;
        public List<MyProfiler.TaskInfo> Tasks;
        public int[] TotalCalls;

        public static MyObjectBuilder_Profiler GetObjectBuilder(MyProfiler profiler)
        {
            MyProfiler.MyProfilerObjectBuilderInfo objectBuilderInfo = profiler.GetObjectBuilderInfo();
            MyObjectBuilder_Profiler profiler2 = new MyObjectBuilder_Profiler {
                ProfilingBlocks = new List<MyObjectBuilder_ProfilerBlock>()
            };
            foreach (KeyValuePair<MyProfilerBlockKey, MyProfilerBlock> pair in objectBuilderInfo.ProfilingBlocks)
            {
                profiler2.ProfilingBlocks.Add(MyObjectBuilder_ProfilerBlock.GetObjectBuilder(pair.Value, profiler.AllocationProfiling));
            }
            profiler2.RootBlocks = new List<MyProfilerBlockKey>();
            foreach (MyProfilerBlock block in objectBuilderInfo.RootBlocks)
            {
                profiler2.RootBlocks.Add(block.Key);
            }
            profiler2.Tasks = objectBuilderInfo.Tasks;
            profiler2.TotalCalls = objectBuilderInfo.TotalCalls;
            profiler2.CustomName = objectBuilderInfo.CustomName;
            profiler2.AxisName = objectBuilderInfo.AxisName;
            profiler2.ShallowProfile = objectBuilderInfo.ShallowProfile;
            profiler2.CommitTimes = objectBuilderInfo.CommitTimes;
            return profiler2;
        }

        public static MyProfiler Init(MyObjectBuilder_Profiler objectBuilder)
        {
            MyProfiler.MyProfilerObjectBuilderInfo info = new MyProfiler.MyProfilerObjectBuilderInfo {
                ProfilingBlocks = new Dictionary<MyProfilerBlockKey, MyProfilerBlock>()
            };
            foreach (MyObjectBuilder_ProfilerBlock block in objectBuilder.ProfilingBlocks)
            {
                info.ProfilingBlocks.Add(block.Key, new MyProfilerBlock());
            }
            foreach (MyObjectBuilder_ProfilerBlock block2 in objectBuilder.ProfilingBlocks)
            {
                MyObjectBuilder_ProfilerBlock.Init(block2, info);
            }
            info.RootBlocks = new List<MyProfilerBlock>();
            foreach (MyProfilerBlockKey key in objectBuilder.RootBlocks)
            {
                info.RootBlocks.Add(info.ProfilingBlocks[key]);
            }
            info.TotalCalls = objectBuilder.TotalCalls;
            info.CustomName = objectBuilder.CustomName;
            info.AxisName = objectBuilder.AxisName;
            info.ShallowProfile = objectBuilder.ShallowProfile;
            info.Tasks = objectBuilder.Tasks;
            info.CommitTimes = objectBuilder.CommitTimes;
            MyProfiler profiler = new MyProfiler(false, info.CustomName, info.AxisName, false);
            profiler.Init(info);
            return profiler;
        }

        public static void LoadFromFile(int index)
        {
            try
            {
                MyObjectBuilder_Profiler profiler;
                MyObjectBuilderSerializer.DeserializeXML<MyObjectBuilder_Profiler>(Path.Combine(MyFileSystem.UserDataPath, "Profiler-" + index), out profiler);
                MyRenderProfiler.SelectedProfiler = Init(profiler);
            }
            catch
            {
            }
        }

        public static void SaveToFile(int index)
        {
            try
            {
                MyObjectBuilder_Profiler objectBuilder = GetObjectBuilder(MyRenderProfiler.SelectedProfiler);
                MyObjectBuilderSerializer.SerializeXML(Path.Combine(MyFileSystem.UserDataPath, "Profiler-" + index), true, objectBuilder, null);
            }
            catch
            {
            }
        }
    }
}

