namespace VRage.Game
{
    using System;
    using VRageMath;

    public static class MyMissileConstants
    {
        public const int DISTANCE_TO_CHECK_MISSILE_CORRECTION = 10;
        public const float GENERATE_SMOKE_TRAIL_PARTICLE_DENSITY_PER_METER = 4f;
        public const int MAX_MISSILES_COUNT = 0x200;
        public static readonly Vector3 MISSILE_INIT_DIR = MyUtils.Normalize(new Vector3(0f, 0f, -1f));
        public const int MISSILE_INIT_TIME = 10;
        public static readonly Vector4 MISSILE_LIGHT_COLOR = new Vector4(1.5f, 1.5f, 1f, 1f);
        public const float MISSILE_LIGHT_RANGE = 70f;
    }
}

