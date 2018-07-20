namespace VRageMath
{
    using System;
    using System.Collections.Generic;

    public class Vector3LNormalEqualityComparer : IEqualityComparer<Vector3L>
    {
        public bool Equals(Vector3L x, Vector3L y) => 
            ((((x.X + 1L) + ((x.Y + 1L) * 3L)) + ((x.Z + 1L) * 9L)) == (((y.X + 1L) + ((y.Y + 1L) * 3L)) + ((y.Z + 1L) * 9L)));

        public int GetHashCode(Vector3L x) => 
            ((int) (((x.X + 1L) + ((x.Y + 1L) * 3L)) + ((x.Z + 1L) * 9L)));
    }
}

