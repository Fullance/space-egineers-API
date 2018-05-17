namespace VRage.Game.ModAPI
{
    using System;
    using System.Runtime.InteropServices;
    using VRage.Game;
    using VRage.ModAPI;

    public interface IMyCubeBuilder
    {
        void Activate(MyDefinitionId? blockDefinitionId = new MyDefinitionId?());
        bool AddConstruction(IMyEntity buildingEntity);
        void Deactivate();
        void DeactivateBlockCreation();
        IMyCubeGrid FindClosestGrid();
        void StartNewGridPlacement(MyCubeSize cubeSize, bool isStatic);

        bool BlockCreationIsActivated { get; }

        bool FreezeGizmo { get; set; }

        bool IsActivated { get; }

        bool ShowRemoveGizmo { get; set; }

        bool UseSymmetry { get; set; }

        bool UseTransparency { get; set; }
    }
}

