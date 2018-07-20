namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using VRage.Profiler;

    public class MyObjectBuilder_ProfilerBlock
    {
        public float[] Allocations;
        public string CallFormat;
        public List<MyProfilerBlockKey> Children;
        public float[] CustomValues;
        public int Id;
        public MyProfilerBlockKey Key;
        public long[] ManagedMemoryBytes;
        public float[] Milliseconds;
        public int[] NumCallsArray;
        public MyProfilerBlockKey Parent;
        public float[] ProcessMemory;
        public string TimeFormat;
        public string ValueFormat;

        public static MyObjectBuilder_ProfilerBlock GetObjectBuilder(MyProfilerBlock profilerBlock, bool serializeAllocations)
        {
            MyProfilerBlock.MyProfilerBlockObjectBuilderInfo objectBuilderInfo = profilerBlock.GetObjectBuilderInfo(serializeAllocations);
            MyObjectBuilder_ProfilerBlock block = new MyObjectBuilder_ProfilerBlock {
                Id = objectBuilderInfo.Id,
                Key = objectBuilderInfo.Key,
                TimeFormat = objectBuilderInfo.TimeFormat,
                ValueFormat = objectBuilderInfo.ValueFormat,
                CallFormat = objectBuilderInfo.CallFormat,
                Allocations = objectBuilderInfo.Allocations,
                Milliseconds = objectBuilderInfo.Milliseconds,
                CustomValues = objectBuilderInfo.CustomValues,
                NumCallsArray = objectBuilderInfo.NumCallsArray,
                Children = new List<MyProfilerBlockKey>()
            };
            foreach (MyProfilerBlock block2 in objectBuilderInfo.Children)
            {
                block.Children.Add(block2.Key);
            }
            if (objectBuilderInfo.Parent != null)
            {
                block.Parent = objectBuilderInfo.Parent.Key;
            }
            return block;
        }

        public static MyProfilerBlock Init(MyObjectBuilder_ProfilerBlock objectBuilder, MyProfiler.MyProfilerObjectBuilderInfo profiler)
        {
            MyProfilerBlock.MyProfilerBlockObjectBuilderInfo data = new MyProfilerBlock.MyProfilerBlockObjectBuilderInfo {
                Id = objectBuilder.Id,
                Key = objectBuilder.Key,
                TimeFormat = objectBuilder.TimeFormat,
                ValueFormat = objectBuilder.ValueFormat,
                CallFormat = objectBuilder.CallFormat,
                Allocations = objectBuilder.Allocations,
                Milliseconds = objectBuilder.Milliseconds,
                CustomValues = objectBuilder.CustomValues,
                NumCallsArray = objectBuilder.NumCallsArray,
                Children = new List<MyProfilerBlock>()
            };
            foreach (MyProfilerBlockKey key in objectBuilder.Children)
            {
                data.Children.Add(profiler.ProfilingBlocks[key]);
            }
            if (objectBuilder.Parent.File != null)
            {
                data.Parent = profiler.ProfilingBlocks[objectBuilder.Parent];
            }
            MyProfilerBlock block = profiler.ProfilingBlocks[data.Key];
            block.Init(data);
            return block;
        }
    }
}

