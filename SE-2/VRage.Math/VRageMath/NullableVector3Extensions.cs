namespace VRageMath
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public static class NullableVector3Extensions
    {
        [Conditional("DEBUG")]
        public static void AssertIsValid(this Vector3? value)
        {
        }

        public static bool IsValid(this Vector3? value)
        {
            if (value.HasValue)
            {
                return value.Value.IsValid();
            }
            return true;
        }
    }
}

