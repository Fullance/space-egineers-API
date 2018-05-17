namespace VRage.Game.ModAPI.Ingame
{
    using System;
    using System.Runtime.CompilerServices;
    using VRage.Game;

    public static class MyInventoryItemExtension
    {
        public static MyDefinitionId GetDefinitionId(this IMyInventoryItem self)
        {
            MyObjectBuilder_PhysicalObject content = self.Content as MyObjectBuilder_PhysicalObject;
            if (content != null)
            {
                return content.GetObjectId();
            }
            return new MyDefinitionId(self.Content.TypeId, self.Content.SubtypeId);
        }
    }
}

