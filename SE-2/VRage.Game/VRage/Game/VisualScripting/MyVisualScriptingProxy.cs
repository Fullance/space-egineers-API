namespace VRage.Game.VisualScripting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using VRage.Game.Entity;
    using VRageMath;

    public static class MyVisualScriptingProxy
    {
        private static bool m_initialized = false;
        private static readonly Dictionary<string, Type> m_registeredTypes = new Dictionary<string, Type>();
        private static readonly List<Type> m_supportedTypes = new List<Type>();
        private static readonly Dictionary<string, FieldInfo> m_visualScriptingEventFields = new Dictionary<string, FieldInfo>();
        private static readonly Dictionary<string, MethodInfo> m_visualScriptingMethodsBySignature = new Dictionary<string, MethodInfo>();
        private static readonly Dictionary<Type, HashSet<MethodInfo>> m_whitelistedMethods = new Dictionary<Type, HashSet<MethodInfo>>();
        private static readonly Dictionary<MethodInfo, bool> m_whitelistedMethodsSequenceDependency = new Dictionary<MethodInfo, bool>();

        public static FieldInfo GetField(string signature)
        {
            FieldInfo info;
            m_visualScriptingEventFields.TryGetValue(signature, out info);
            return info;
        }

        public static MethodInfo GetMethod(string signature)
        {
            MethodInfo info;
            m_visualScriptingMethodsBySignature.TryGetValue(signature, out info);
            return info;
        }

        public static MethodInfo GetMethod(Type type, string signature)
        {
            if (!m_whitelistedMethods.ContainsKey(type))
            {
                GetWhitelistedMethods(type);
            }
            return GetMethod(signature);
        }

        public static List<MethodInfo> GetMethods()
        {
            List<MethodInfo> list = new List<MethodInfo>();
            foreach (KeyValuePair<string, MethodInfo> pair in m_visualScriptingMethodsBySignature)
            {
                list.Add(pair.Value);
            }
            return list;
        }

        public static Type GetType(string typeFullName)
        {
            Type type;
            if ((typeFullName == null) || (typeFullName.Length == 0))
            {
                Debugger.Break();
            }
            if (m_registeredTypes.TryGetValue(typeFullName, out type))
            {
                return type;
            }
            type = Type.GetType(typeFullName);
            if (type != null)
            {
                return type;
            }
            return typeof(Vector3D).Assembly.GetType(typeFullName);
        }

        public static IEnumerable<MethodInfo> GetWhitelistedMethods(Type type)
        {
            if (type != null)
            {
                HashSet<MethodInfo> set;
                if (m_whitelistedMethods.TryGetValue(type, out set))
                {
                    return set;
                }
                if (type.IsGenericType)
                {
                    Type genericTypeDefinition = type.GetGenericTypeDefinition();
                    Type[] genericArguments = type.GetGenericArguments();
                    if (m_whitelistedMethods.TryGetValue(genericTypeDefinition, out set))
                    {
                        HashSet<MethodInfo> set2 = new HashSet<MethodInfo>();
                        m_whitelistedMethods[type] = set2;
                        foreach (MethodInfo info in set)
                        {
                            MethodInfo item = null;
                            if (info.IsDefined(typeof(ExtensionAttribute)))
                            {
                                item = info.MakeGenericMethod(genericArguments);
                            }
                            else
                            {
                                item = type.GetMethod(info.Name);
                            }
                            set2.Add(item);
                            bool flag = m_whitelistedMethodsSequenceDependency[info];
                            m_whitelistedMethodsSequenceDependency[item] = flag;
                            m_visualScriptingMethodsBySignature[item.Signature()] = item;
                        }
                        return set2;
                    }
                }
            }
            return null;
        }

        public static void Init()
        {
            if (!m_initialized)
            {
                m_supportedTypes.Add(typeof(int));
                m_supportedTypes.Add(typeof(float));
                m_supportedTypes.Add(typeof(string));
                m_supportedTypes.Add(typeof(Vector3D));
                m_supportedTypes.Add(typeof(bool));
                m_supportedTypes.Add(typeof(long));
                m_supportedTypes.Add(typeof(List<bool>));
                m_supportedTypes.Add(typeof(List<int>));
                m_supportedTypes.Add(typeof(List<float>));
                m_supportedTypes.Add(typeof(List<string>));
                m_supportedTypes.Add(typeof(List<long>));
                m_supportedTypes.Add(typeof(List<MyEntity>));
                m_supportedTypes.Add(typeof(MyEntity));
                MyVisualScriptLogicProvider.Init();
                m_initialized = true;
            }
        }

        public static bool IsSequenceDependent(this MethodInfo method)
        {
            VisualScriptingMember customAttribute = method.GetCustomAttribute<VisualScriptingMember>();
            if ((customAttribute == null) && !method.IsStatic)
            {
                bool flag = true;
                if (m_whitelistedMethodsSequenceDependency.TryGetValue(method, out flag))
                {
                    return flag;
                }
                return true;
            }
            if (customAttribute != null)
            {
                return customAttribute.Sequential;
            }
            return true;
        }

        public static string MethodGroup(this MethodInfo info)
        {
            VisualScriptingMiscData customAttribute = info.GetCustomAttribute<VisualScriptingMiscData>();
            if (customAttribute != null)
            {
                return customAttribute.Group;
            }
            return null;
        }

        public static string ReadableName(this Type type)
        {
            if (type == null)
            {
                Debugger.Break();
                return null;
            }
            if (type == typeof(bool))
            {
                return "Bool";
            }
            if (type == typeof(int))
            {
                return "Int";
            }
            if (type == typeof(string))
            {
                return "String";
            }
            if (type == typeof(float))
            {
                return "Float";
            }
            if (type == typeof(long))
            {
                return "Long";
            }
            if (!type.IsGenericType)
            {
                return type.Name;
            }
            StringBuilder builder = new StringBuilder(type.Name.Remove(type.Name.IndexOf('`')));
            Type[] genericArguments = type.GetGenericArguments();
            builder.Append(" - ");
            foreach (Type type2 in genericArguments)
            {
                builder.Append(type2.ReadableName());
                builder.Append(",");
            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        public static void RegisterLogicProvider(Type type)
        {
            foreach (MethodInfo info in type.GetMethods())
            {
                if (info.GetCustomAttribute<VisualScriptingMember>() != null)
                {
                    string key = info.Signature();
                    if (!m_visualScriptingMethodsBySignature.ContainsKey(key))
                    {
                        m_visualScriptingMethodsBySignature.Add(key, info);
                    }
                }
            }
            foreach (FieldInfo info2 in type.GetFields())
            {
                if (((info2.FieldType.GetCustomAttribute<VisualScriptingEvent>() != null) && info2.FieldType.IsSubclassOf(typeof(MulticastDelegate))) && !m_visualScriptingEventFields.ContainsKey(info2.Signature()))
                {
                    m_visualScriptingEventFields.Add(info2.Signature(), info2);
                }
            }
        }

        private static void RegisterMethod(Type declaringType, MethodInfo method, VisualScriptingMember attribute, bool? overrideSequenceDependency = new bool?())
        {
            if (declaringType.IsGenericType)
            {
                declaringType = declaringType.GetGenericTypeDefinition();
            }
            if (!m_whitelistedMethods.ContainsKey(declaringType))
            {
                m_whitelistedMethods[declaringType] = new HashSet<MethodInfo>();
            }
            m_whitelistedMethods[declaringType].Add(method);
            bool? nullable = overrideSequenceDependency;
            m_whitelistedMethodsSequenceDependency[method] = nullable.HasValue ? nullable.GetValueOrDefault() : attribute.Sequential;
            foreach (KeyValuePair<Type, HashSet<MethodInfo>> pair in m_whitelistedMethods)
            {
                if (pair.Key.IsAssignableFrom(declaringType))
                {
                    pair.Value.Add(method);
                }
                else if (declaringType.IsAssignableFrom(pair.Key))
                {
                    HashSet<MethodInfo> set = m_whitelistedMethods[declaringType];
                    foreach (MethodInfo info in pair.Value)
                    {
                        set.Add(info);
                    }
                }
            }
        }

        public static void RegisterType(Type type)
        {
            string key = type.Signature();
            if (!m_registeredTypes.ContainsKey(key))
            {
                m_registeredTypes.Add(key, type);
            }
        }

        public static string Signature(this FieldInfo info) => 
            (info.DeclaringType.Namespace + "." + info.DeclaringType.Name + "." + info.Name);

        public static string Signature(this MethodInfo info)
        {
            StringBuilder builder = new StringBuilder(info.DeclaringType.Signature());
            ParameterInfo[] parameters = info.GetParameters();
            builder.Append('.').Append(info.Name).Append('(');
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType.IsGenericType)
                {
                    builder.Append(parameters[i].ParameterType.Signature());
                }
                else
                {
                    builder.Append(parameters[i].ParameterType.Name);
                }
                builder.Append(' ').Append(parameters[i].Name);
                if (i < (parameters.Length - 1))
                {
                    builder.Append(", ");
                }
            }
            builder.Append(')');
            return builder.ToString();
        }

        public static string Signature(this Type type)
        {
            if (type.IsEnum)
            {
                return type.FullName.Replace("+", ".");
            }
            return type.FullName;
        }

        public static bool TryToRecoverMethodInfo(ref string oldSignature, Type declaringType, Type extensionType, out MethodInfo info)
        {
            info = null;
            int num = 0;
            while (((num < oldSignature.Length) && (num < declaringType.FullName.Length)) && (oldSignature[num] == declaringType.FullName[num]))
            {
                num++;
            }
            oldSignature = oldSignature.Remove(0, num + 1);
            oldSignature = oldSignature.Remove(oldSignature.IndexOf('('));
            if ((extensionType != null) && extensionType.IsGenericType)
            {
                Type[] genericArguments = extensionType.GetGenericArguments();
                MethodInfo method = declaringType.GetMethod(oldSignature);
                if (method != null)
                {
                    info = method.MakeGenericMethod(genericArguments);
                }
            }
            else
            {
                info = declaringType.GetMethod(oldSignature);
            }
            if (info != null)
            {
                oldSignature = info.Signature();
            }
            return (info != null);
        }

        public static void WhitelistExtensions(Type type)
        {
            foreach (MethodInfo info in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                VisualScriptingMember customAttribute = info.GetCustomAttribute<VisualScriptingMember>();
                if ((customAttribute != null) && info.IsDefined(typeof(ExtensionAttribute), false))
                {
                    bool? overrideSequenceDependency = null;
                    RegisterMethod(info.GetParameters()[0].ParameterType, info, customAttribute, overrideSequenceDependency);
                }
            }
            m_registeredTypes[type.Signature()] = type;
        }

        public static void WhitelistMethod(MethodInfo method, bool sequenceDependent)
        {
            Type declaringType = method.DeclaringType;
            if (declaringType != null)
            {
                RegisterMethod(declaringType, method, null, new bool?(sequenceDependent));
            }
        }

        public static List<FieldInfo> EventFields =>
            m_visualScriptingEventFields.Values.ToList<FieldInfo>();

        public static List<Type> SupportedTypes =>
            m_supportedTypes;
    }
}

