namespace VRage.Game
{
    using System;
    using VRageMath;

    public static class MySunWindConstants
    {
        public static readonly float FORCE_ANGLE_RANDOM_VARIATION_IN_RADIANS = MathHelper.ToRadians((float) 70f);
        public const float FORCE_IMPULSE_POSITION_DISTANCE = 1000f;
        public const float FORCE_IMPULSE_RANDOM_MAX = 500000f;
        public const float HEALTH_DAMAGE = 80f;
        public const float LARGE_BILLBOARD_DISAPEAR_DISTANCE = 27000f;
        public const float LARGE_BILLBOARD_DISTANCE = 7500f;
        public const float LARGE_BILLBOARD_POSITION_DELTA_MAX = 50f;
        public const float LARGE_BILLBOARD_POSITION_DELTA_MIN = -50f;
        public const float LARGE_BILLBOARD_RADIUS_MAX = 35000f;
        public const float LARGE_BILLBOARD_RADIUS_MIN = 20000f;
        public const float LARGE_BILLBOARD_ROTATION_SPEED_MAX = 1.2f;
        public const float LARGE_BILLBOARD_ROTATION_SPEED_MIN = 0.5f;
        public static readonly Vector2I LARGE_BILLBOARDS_SIZE = new Vector2I(10, 10);
        public static readonly Vector2I LARGE_BILLBOARDS_SIZE_HALF = new Vector2I(LARGE_BILLBOARDS_SIZE.X / 2, LARGE_BILLBOARDS_SIZE.Y / 2);
        public const float PARTICLE_DUST_DECREAS_DISTANCE = 27000f;
        public const float RAY_CAST_DISTANCE = 30000f;
        public const float SECONDS_FOR_SMALL_BILLBOARDS_INITIALIZATION = 1f;
        public const float SHIP_DAMAGE = 50f;
        public const float SMALL_BILLBOARD_DISTANCE = 350f;
        public const float SMALL_BILLBOARD_POSITION_DELTA_MAX = 300f;
        public const float SMALL_BILLBOARD_POSITION_DELTA_MIN = -300f;
        public const float SMALL_BILLBOARD_RADIUS_MAX = 500f;
        public const float SMALL_BILLBOARD_RADIUS_MIN = 250f;
        public const float SMALL_BILLBOARD_ROTATION_SPEED_MAX = 3.5f;
        public const float SMALL_BILLBOARD_ROTATION_SPEED_MIN = 1.4f;
        public const int SMALL_BILLBOARD_TAIL_COUNT_MAX = 14;
        public const int SMALL_BILLBOARD_TAIL_COUNT_MIN = 8;
        public const float SMALL_BILLBOARD_TAIL_DISTANCE_MAX = 450f;
        public const float SMALL_BILLBOARD_TAIL_DISTANCE_MIN = 300f;
        public static readonly Vector2I SMALL_BILLBOARDS_SIZE = new Vector2I(20, 20);
        public static readonly Vector2I SMALL_BILLBOARDS_SIZE_HALF = new Vector2I(SMALL_BILLBOARDS_SIZE.X / 2, SMALL_BILLBOARDS_SIZE.Y / 2);
        public const float SPEED_MAX = 1500f;
        public const float SPEED_MIN = 1300f;
        public const float SUN_COLOR_INCREASE_DISTANCE = 10000f;
        public const float SUN_COLOR_INCREASE_STRENGTH_MAX = 4f;
        public const float SUN_COLOR_INCREASE_STRENGTH_MIN = 3f;
        public const float SUN_WIND_LENGTH_HALF = 30000f;
        public const float SUN_WIND_LENGTH_TOTAL = 60000f;
        public const float SWITCH_LARGE_AND_SMALL_BILLBOARD_DISTANCE = 10000f;
        public const float SWITCH_LARGE_AND_SMALL_BILLBOARD_DISTANCE_HALF = 3333.333f;
        public const float SWITCH_LARGE_AND_SMALL_BILLBOARD_RADIUS = 7000f;
    }
}

