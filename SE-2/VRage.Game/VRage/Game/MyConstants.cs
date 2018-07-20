namespace VRage.Game
{
    using System;
    using VRageMath;

    public static class MyConstants
    {
        public static float DEFAULT_GROUND_SEARCH_DISTANCE = 2f;
        public static float DEFAULT_INTERACTIVE_DISTANCE = 5f;
        public const int FAREST_TIME_IN_PAST = -60000;
        public static readonly float FIELD_OF_VIEW_CONFIG_DEFAULT = MathHelper.ToRadians((float) 70f);
        public static readonly float FIELD_OF_VIEW_CONFIG_MAX = MathHelper.ToRadians((float) 140f);
        public static readonly float FIELD_OF_VIEW_CONFIG_MAX_DUAL_HEAD = MathHelper.ToRadians((float) 80f);
        public static readonly float FIELD_OF_VIEW_CONFIG_MAX_TRIPLE_HEAD = MathHelper.ToRadians((float) 70f);
        public static readonly float FIELD_OF_VIEW_CONFIG_MIN = MathHelper.ToRadians((float) 40f);
        public static float FLOATING_OBJ_INTERACTIVE_DISTANCE = 3f;
        public static readonly Vector3D GAME_PRUNING_STRUCTURE_AABB_EXTENSION = new Vector3D(3.0);
        public const float MAX_PARTICLE_DISTANCE_DEFAULT = 1f;
        public const float MAX_PARTICLE_DISTANCE_EXTENSION = 0.25f;
        public static float MAX_THRUST = 1.5f;
    }
}

