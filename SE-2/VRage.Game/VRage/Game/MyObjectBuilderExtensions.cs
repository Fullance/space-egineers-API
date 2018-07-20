namespace VRage.Game
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.ObjectBuilders;

    public static class MyObjectBuilderExtensions
    {
        public static MyDefinitionId GetId(this MyObjectBuilder_Base self) => 
            new MyDefinitionId(self.TypeId, self.SubtypeId);
    }
}

