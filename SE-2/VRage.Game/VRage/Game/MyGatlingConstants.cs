namespace VRage.Game
{
    using System;

    public static class MyGatlingConstants
    {
        public static readonly float COCKPIT_GLASS_PROJECTILE_DEBRIS_MAX_DEVIATION_ANGLE = MathHelper.ToRadians((float) 10f);
        public const int MIN_TIME_RELEASE_INTERVAL_IN_MILISECONDS = 0xcc;
        public const int REAL_SHOTS_PER_SECOND = 0x2d;
        public const float ROTATION_SPEED_PER_SECOND = 12.56637f;
        public const int ROTATION_TIMEOUT = 0x7d0;
        public const int SHOT_INTERVAL_IN_MILISECONDS = 0x5f;
        public static readonly float SHOT_PROJECTILE_DEBRIS_MAX_DEVIATION_ANGLE = MathHelper.ToRadians((float) 30f);
        public const int SMOKE_DECREASE = 1;
        public const int SMOKE_INCREASE_PER_SHOT = 0x13;
        public const int SMOKES_INTERVAL_IN_MILISECONDS = 10;
        public const int SMOKES_MAX = 50;
        public const int SMOKES_MIN = 40;
    }
}

