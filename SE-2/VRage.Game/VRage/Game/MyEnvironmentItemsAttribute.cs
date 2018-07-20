namespace VRage.Game
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited=false)]
    public class MyEnvironmentItemsAttribute : Attribute
    {
        public readonly Type ItemDefinitionType;

        public MyEnvironmentItemsAttribute(Type itemDefinitionType)
        {
            this.ItemDefinitionType = itemDefinitionType;
        }
    }
}

