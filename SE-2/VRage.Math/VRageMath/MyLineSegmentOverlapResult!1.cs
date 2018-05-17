namespace VRageMath
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyLineSegmentOverlapResult<T>
    {
        public static MyLineSegmentOverlapResultComparer<T> DistanceComparer;
        public double Distance;
        public T Element;
        static MyLineSegmentOverlapResult()
        {
            MyLineSegmentOverlapResult<T>.DistanceComparer = new MyLineSegmentOverlapResultComparer<T>();
        }
        public class MyLineSegmentOverlapResultComparer : IComparer<MyLineSegmentOverlapResult<T>>
        {
            public int Compare(MyLineSegmentOverlapResult<T> x, MyLineSegmentOverlapResult<T> y) => 
                x.Distance.CompareTo(y.Distance);
        }
    }
}

