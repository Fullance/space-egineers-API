namespace VRage.Game
{
    using System;

    public static class MyLightsConstants
    {
        public const int MAX_LIGHTS_COUNT = 0xfa0;
        public const int MAX_LIGHTS_COUNT_WHEN_DRAWING = 0x10;
        public const int MAX_LIGHTS_FOR_EFFECT = 8;
        public const int MAX_POINTLIGHT_RADIUS = 120;
        public static readonly float MAX_SPOTLIGHT_ANGLE = 80f;
        public static readonly float MAX_SPOTLIGHT_ANGLE_COS = (1f - ((float) Math.Cos((double) MathHelper.ToRadians(MAX_SPOTLIGHT_ANGLE))));
        public const float MAX_SPOTLIGHT_RANGE = 1200f;
    }
}

