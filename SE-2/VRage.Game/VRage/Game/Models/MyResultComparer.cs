namespace VRage.Game.Models
{
    using System;
    using System.Collections.Generic;

    internal class MyResultComparer : IComparer<MyIntersectionResultLineTriangle>
    {
        public int Compare(MyIntersectionResultLineTriangle x, MyIntersectionResultLineTriangle y) => 
            x.Distance.CompareTo(y.Distance);
    }
}

