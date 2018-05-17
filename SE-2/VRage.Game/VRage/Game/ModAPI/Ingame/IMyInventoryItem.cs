namespace VRage.Game.ModAPI.Ingame
{
    using System;
    using VRage;
    using VRage.ObjectBuilders;

    public interface IMyInventoryItem
    {
        MyFixedPoint Amount { get; set; }

        MyObjectBuilder_Base Content { get; set; }

        uint ItemId { get; set; }

        float Scale { get; set; }
    }
}

