namespace VRage.Game.Models
{
    using BulletXNA.LinearMath;
    using System;
    using System.Runtime.CompilerServices;
    using VRageMath;

    public static class BulletXnaExtensions
    {
        public static IndexedVector3 ToBullet(this Vector3 v) => 
            new IndexedVector3(v.X, v.Y, v.Z);

        public static IndexedVector3 ToBullet(this Vector3D v) => 
            new IndexedVector3((float) v.X, (float) v.Y, (float) v.Z);
    }
}

