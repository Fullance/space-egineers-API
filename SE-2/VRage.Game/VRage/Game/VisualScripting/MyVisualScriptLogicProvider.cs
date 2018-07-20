namespace VRage.Game.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.Components.Session;
    using VRage.Game.VisualScripting.Utils;
    using VRage.Input;
    using VRage.Utils;
    using VRageMath;

    public static class MyVisualScriptLogicProvider
    {
        public static SingleKeyMissionEvent MissionFinished;
        public static SingleKeyMissionEvent MissionStarted;

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Math", null)]
        public static float Abs(float value) => 
            Math.Abs(value);

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Math", null)]
        public static int Ceil(float value) => 
            ((int) Math.Ceiling((double) value));

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static float Clamp(float value, float min, float max) => 
            MathHelper.Clamp(value, min, max);

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static Vector3D CreateVector3D(float x = 0f, float y = 0f, float z = 0f) => 
            new Vector3D((double) x, (double) y, (double) z);

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Math", null)]
        public static Vector3D DirectionVector(Vector3D speed)
        {
            if (speed == Vector3D.Zero)
            {
                return Vector3D.Forward;
            }
            return Vector3D.Normalize(speed);
        }

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static float DistanceVector3(Vector3 posA, Vector3 posB) => 
            Vector3.Distance(posA, posB);

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static float DistanceVector3D(Vector3D posA, Vector3D posB) => 
            ((float) Vector3D.Distance(posA, posB));

        [VisualScriptingMember(false, false), VisualScriptingMiscData("String", null)]
        public static string FloatToString(float value) => 
            value.ToString();

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static int Floor(float value) => 
            ((int) Math.Floor((double) value));

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static void GetVector3DComponents(Vector3D vector, out float x, out float y, out float z)
        {
            x = (float) vector.X;
            y = (float) vector.Y;
            z = (float) vector.Z;
        }

        public static void Init()
        {
            MyVisualScriptingProxy.WhitelistExtensions(typeof(MyVSCollectionExtensions));
            Type type = typeof(List<>);
            MyVisualScriptingProxy.WhitelistMethod(type.GetMethod("Insert"), true);
            MyVisualScriptingProxy.WhitelistMethod(type.GetMethod("RemoveAt"), true);
            MyVisualScriptingProxy.WhitelistMethod(type.GetMethod("Clear"), true);
            MyVisualScriptingProxy.WhitelistMethod(type.GetMethod("Add"), true);
            MyVisualScriptingProxy.WhitelistMethod(type.GetMethod("Remove"), true);
            MyVisualScriptingProxy.WhitelistMethod(type.GetMethod("Contains"), false);
            Type type2 = typeof(string);
            MyVisualScriptingProxy.WhitelistMethod(type2.GetMethod("Substring", new Type[] { typeof(int), typeof(int) }), true);
        }

        [VisualScriptingMember(false, false), VisualScriptingMiscData("String", null)]
        public static string IntToString(int value) => 
            value.ToString();

        [VisualScriptingMiscData("Input", null), VisualScriptingMember(false, false)]
        public static bool IsLocalInputBlacklisted(string controlStringId) => 
            MyInput.Static.IsControlBlocked(MyStringId.GetOrCompute(controlStringId));

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Shared Storage", null)]
        public static bool LoadBool(string key) => 
            ((MySessionComponentScriptSharedStorage.Instance != null) && MySessionComponentScriptSharedStorage.Instance.ReadBool(key));

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Shared Storage", null)]
        public static float LoadFloat(string key)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                return MySessionComponentScriptSharedStorage.Instance.ReadFloat(key);
            }
            return 0f;
        }

        [VisualScriptingMiscData("Shared Storage", null), VisualScriptingMember(false, false)]
        public static int LoadInteger(string key)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                return MySessionComponentScriptSharedStorage.Instance.ReadInt(key);
            }
            return 0;
        }

        [VisualScriptingMiscData("Shared Storage", null), VisualScriptingMember(false, false)]
        public static long LoadLong(string key)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                return MySessionComponentScriptSharedStorage.Instance.ReadLong(key);
            }
            return 0L;
        }

        [VisualScriptingMiscData("Shared Storage", null), VisualScriptingMember(false, false)]
        public static string LoadString(string key)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                return MySessionComponentScriptSharedStorage.Instance.ReadString(key);
            }
            return null;
        }

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Shared Storage", null)]
        public static Vector3D LoadVector(string key)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                return MySessionComponentScriptSharedStorage.Instance.ReadVector3D(key);
            }
            return Vector3D.Zero;
        }

        [VisualScriptingMiscData("String", null), VisualScriptingMember(false, false)]
        public static string LongToString(long value) => 
            value.ToString();

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static float Max(float value1, float value2) => 
            Math.Max(value1, value2);

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Math", null)]
        public static float Min(float value1, float value2) => 
            Math.Min(value1, value2);

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static int Modulo(int number, int mod) => 
            (number % mod);

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Math", null)]
        public static float RandomFloat(float min, float max) => 
            MyUtils.GetRandomFloat(min, max);

        [VisualScriptingMember(false, false), VisualScriptingMiscData("Math", null)]
        public static int RandomInt(int min, int max) => 
            MyUtils.GetRandomInt(min, max);

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static int Round(float value) => 
            ((int) Math.Round((double) value));

        [VisualScriptingMember(true, false), VisualScriptingMiscData("Input", null)]
        public static void SetLocalInputBlacklistState(string controlStringId, bool enabled = false)
        {
            MyInput.Static.SetControlBlock(MyStringId.GetOrCompute(controlStringId), !enabled);
        }

        [VisualScriptingMember(true, false), VisualScriptingMiscData("Shared Storage", null)]
        public static void StoreBool(string key, bool value)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                MySessionComponentScriptSharedStorage.Instance.Write(key, value, false);
            }
        }

        [VisualScriptingMember(true, false), VisualScriptingMiscData("Shared Storage", null)]
        public static void StoreFloat(string key, float value)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                MySessionComponentScriptSharedStorage.Instance.Write(key, value, false);
            }
        }

        [VisualScriptingMember(true, false), VisualScriptingMiscData("Shared Storage", null)]
        public static void StoreInteger(string key, int value)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                MySessionComponentScriptSharedStorage.Instance.Write(key, value, false);
            }
        }

        [VisualScriptingMember(true, false), VisualScriptingMiscData("Shared Storage", null)]
        public static void StoreLong(string key, long value)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                MySessionComponentScriptSharedStorage.Instance.Write(key, value, false);
            }
        }

        [VisualScriptingMiscData("Shared Storage", null), VisualScriptingMember(true, false)]
        public static void StoreString(string key, string value)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                MySessionComponentScriptSharedStorage.Instance.Write(key, value, false);
            }
        }

        [VisualScriptingMember(true, false), VisualScriptingMiscData("Shared Storage", null)]
        public static void StoreVector(string key, Vector3D value)
        {
            if (MySessionComponentScriptSharedStorage.Instance != null)
            {
                MySessionComponentScriptSharedStorage.Instance.Write(key, value, false);
            }
        }

        [VisualScriptingMiscData("String", null), VisualScriptingMember(false, false)]
        public static bool StringIsNullOrEmpty(string value)
        {
            if (value != null)
            {
                return (value.Length == 0);
            }
            return true;
        }

        [VisualScriptingMiscData("String", null), VisualScriptingMember(false, false)]
        public static int StringLength(string value)
        {
            if (value != null)
            {
                return value.Length;
            }
            return 0;
        }

        [VisualScriptingMiscData("String", null), VisualScriptingMember(false, false)]
        public static string StringReplace(string value, string oldValue, string newValue) => 
            value?.Replace(oldValue, newValue);

        [VisualScriptingMember(false, false), VisualScriptingMiscData("String", null)]
        public static string SubString(string value, int startIndex = 0, int length = 0)
        {
            if (value == null)
            {
                return null;
            }
            if (length > 0)
            {
                return value.Substring(startIndex, length);
            }
            return value.Substring(startIndex);
        }

        [VisualScriptingMember(false, false), VisualScriptingMiscData("String", null)]
        public static string Vector3DToString(Vector3D value) => 
            value.ToString();

        [VisualScriptingMiscData("Math", null), VisualScriptingMember(false, false)]
        public static float VectorLength(Vector3D speed) => 
            ((float) speed.Length());
    }
}

