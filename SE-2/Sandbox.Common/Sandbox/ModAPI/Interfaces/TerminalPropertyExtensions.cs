namespace Sandbox.ModAPI.Interfaces
{
    using Sandbox.ModAPI.Ingame;
    using System;
    using System.Runtime.CompilerServices;
    using VRageMath;

    public static class TerminalPropertyExtensions
    {
        public static ITerminalProperty<TValue> As<TValue>(this ITerminalProperty property) => 
            (property as ITerminalProperty<TValue>);

        public static ITerminalProperty<bool> AsBool(this ITerminalProperty property) => 
            property.As<bool>();

        public static ITerminalProperty<Color> AsColor(this ITerminalProperty property) => 
            property.As<Color>();

        public static ITerminalProperty<float> AsFloat(this ITerminalProperty property) => 
            property.As<float>();

        public static ITerminalProperty<TValue> Cast<TValue>(this ITerminalProperty property)
        {
            if (property == null)
            {
                throw new InvalidOperationException("Invalid property");
            }
            ITerminalProperty<TValue> property2 = property.As<TValue>();
            if (property2 == null)
            {
                throw new InvalidOperationException($"Property {property.Id} is not of type {typeof(TValue).Name}, correct type is {property.TypeName}");
            }
            return property2;
        }

        public static T GetDefaultValue<T>(this IMyTerminalBlock block, string propertyId) => 
            block.GetProperty(propertyId).Cast<T>().GetDefaultValue(block);

        public static T GetMaximum<T>(this IMyTerminalBlock block, string propertyId) => 
            block.GetProperty(propertyId).Cast<T>().GetMaximum(block);

        public static T GetMinimum<T>(this IMyTerminalBlock block, string propertyId) => 
            block.GetProperty(propertyId).Cast<T>().GetMinimum(block);

        [Obsolete("Use GetMinimum instead")]
        public static T GetMininum<T>(this IMyTerminalBlock block, string propertyId) => 
            block.GetProperty(propertyId).Cast<T>().GetMinimum(block);

        public static T GetValue<T>(this IMyTerminalBlock block, string propertyId) => 
            block.GetProperty(propertyId).Cast<T>().GetValue(block);

        public static bool GetValueBool(this IMyTerminalBlock block, string propertyId) => 
            block.GetValue<bool>(propertyId);

        public static Color GetValueColor(this IMyTerminalBlock block, string propertyId) => 
            block.GetValue<Color>(propertyId);

        public static float GetValueFloat(this IMyTerminalBlock block, string propertyId) => 
            block.GetValue<float>(propertyId);

        public static bool Is<TValue>(this ITerminalProperty property) => 
            (property is ITerminalProperty<TValue>);

        public static void SetValue<T>(this IMyTerminalBlock block, string propertyId, T value)
        {
            block.GetProperty(propertyId).Cast<T>().SetValue(block, value);
        }

        public static void SetValueBool(this IMyTerminalBlock block, string propertyId, bool value)
        {
            block.SetValue<bool>(propertyId, value);
        }

        public static void SetValueColor(this IMyTerminalBlock block, string propertyId, Color value)
        {
            block.SetValue<Color>(propertyId, value);
        }

        public static void SetValueFloat(this IMyTerminalBlock block, string propertyId, float value)
        {
            block.SetValue<float>(propertyId, value);
        }
    }
}

