namespace VRageMath
{
    using System;
    using System.Collections.Generic;

    public class Vector3INormalEqualityComparer : IEqualityComparer<Vector3I>
    {
        public bool Equals(Vector3I x, Vector3I y) => 
            ((((x.X + 1) + ((x.Y + 1) * 3)) + ((x.Z + 1) * 9)) == (((y.X + 1) + ((y.Y + 1) * 3)) + ((y.Z + 1) * 9)));

        public int GetHashCode(Vector3I x) => 
            (((x.X + 1) + ((x.Y + 1) * 3)) + ((x.Z + 1) * 9));
    }
}

