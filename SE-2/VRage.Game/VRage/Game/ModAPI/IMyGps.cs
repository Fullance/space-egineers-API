namespace VRage.Game.ModAPI
{
    using System;
    using VRageMath;

    public interface IMyGps
    {
        string ToString();
        void UpdateHash();

        string ContainerRemainingTime { get; set; }

        Vector3D Coords { get; set; }

        string Description { get; set; }

        TimeSpan? DiscardAt { get; set; }

        int Hash { get; }

        string Name { get; set; }

        bool ShowOnHud { get; set; }
    }
}

