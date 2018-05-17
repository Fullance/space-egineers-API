namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Runtime.InteropServices;
    using VRage;
    using VRage.Game;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyProductionItem
    {
        public readonly MyFixedPoint Amount;
        public readonly MyDefinitionId BlueprintId;
        public readonly uint ItemId;
        public MyProductionItem(uint itemId, MyDefinitionId blueprintId, MyFixedPoint amount)
        {
            this = new MyProductionItem();
            this.ItemId = itemId;
            this.BlueprintId = blueprintId;
            this.Amount = amount;
        }
    }
}

