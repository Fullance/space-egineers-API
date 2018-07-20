namespace VRage.Game
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using VRage.FileSystem;
    using VRage.ObjectBuilders;
    using VRage.Profiler;
    using VRageRender;

    [XmlSerializerAssembly("VRage.Game.XmlSerializers")]
    public class MyObjectBuilder_ProfilerSnapshot : MyObjectBuilder_Base
    {
        public List<MyObjectBuilder_Profiler> Profilers;
        public List<MyRenderProfiler.FrameInfo> SimulationFrames;

        public static MyObjectBuilder_ProfilerSnapshot GetObjectBuilder(MyRenderProfiler profiler)
        {
            MyObjectBuilder_ProfilerSnapshot snapshot = new MyObjectBuilder_ProfilerSnapshot();
            List<MyProfiler> threadProfilers = MyRenderProfiler.ThreadProfilers;
            lock (threadProfilers)
            {
                snapshot.Profilers = new List<MyObjectBuilder_Profiler>(threadProfilers.Count);
                snapshot.Profilers.AddRange(threadProfilers.Select<MyProfiler, MyObjectBuilder_Profiler>(new Func<MyProfiler, MyObjectBuilder_Profiler>(MyObjectBuilder_Profiler.GetObjectBuilder)));
            }
            snapshot.SimulationFrames = MyRenderProfiler.FrameTimestamps.ToList<MyRenderProfiler.FrameInfo>();
            return snapshot;
        }

        public void Init(MyRenderProfiler profiler, SnapshotType type, bool subtract)
        {
            List<MyProfiler> threadProfilers = this.Profilers.Select<MyObjectBuilder_Profiler, MyProfiler>(new Func<MyObjectBuilder_Profiler, MyProfiler>(MyObjectBuilder_Profiler.Init)).ToList<MyProfiler>();
            ConcurrentQueue<MyRenderProfiler.FrameInfo> frameTimestamps = new ConcurrentQueue<MyRenderProfiler.FrameInfo>(this.SimulationFrames);
            if (subtract)
            {
                MyRenderProfiler.SubtractOnlineSnapshot(type, threadProfilers, frameTimestamps);
            }
            else
            {
                MyRenderProfiler.PushOnlineSnapshot(type, threadProfilers, frameTimestamps);
            }
            MyRenderProfiler.SelectedProfiler = (threadProfilers.Count > 0) ? threadProfilers[0] : null;
        }

        private static void LoadFromFile(int index, bool subtract)
        {
            try
            {
                MyObjectBuilder_ProfilerSnapshot snapshot;
                MyObjectBuilderSerializer.DeserializeXML<MyObjectBuilder_ProfilerSnapshot>(Path.Combine(MyFileSystem.UserDataPath, "FullProfiler-" + index), out snapshot);
                snapshot.Init(MyRenderProxy.GetRenderProfiler(), SnapshotType.Snapshot, subtract);
            }
            catch
            {
            }
        }

        private static void SaveToFile(int index)
        {
            try
            {
                MyObjectBuilder_ProfilerSnapshot objectBuilder = GetObjectBuilder(MyRenderProxy.GetRenderProfiler());
                MyObjectBuilderSerializer.SerializeXML(Path.Combine(MyFileSystem.UserDataPath, "FullProfiler-" + index), true, objectBuilder, null);
            }
            catch
            {
            }
        }

        public static void SetDelegates()
        {
            MyRenderProfiler.SaveProfilerToFile = new Action<int>(MyObjectBuilder_ProfilerSnapshot.SaveToFile);
            MyRenderProfiler.LoadProfilerFromFile = new Action<int, bool>(MyObjectBuilder_ProfilerSnapshot.LoadFromFile);
        }
    }
}

