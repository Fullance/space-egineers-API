namespace Sandbox.ModAPI.Ingame
{
    using System;
    using System.Collections.Generic;
    using VRage.Game.ModAPI.Ingame;

    public interface IMySensorBlock : IMyFunctionalBlock, IMyTerminalBlock, IMyCubeBlock, IMyEntity
    {
        void DetectedEntities(List<MyDetectedEntityInfo> entities);

        float BackExtend { get; set; }

        float BottomExtend { get; set; }

        bool DetectAsteroids { get; set; }

        bool DetectEnemy { get; set; }

        bool DetectFloatingObjects { get; set; }

        bool DetectFriendly { get; set; }

        bool DetectLargeShips { get; set; }

        bool DetectNeutral { get; set; }

        bool DetectOwner { get; set; }

        bool DetectPlayers { get; set; }

        bool DetectSmallShips { get; set; }

        bool DetectStations { get; set; }

        bool DetectSubgrids { get; set; }

        float FrontExtend { get; set; }

        bool IsActive { get; }

        MyDetectedEntityInfo LastDetectedEntity { get; }

        float LeftExtend { get; set; }

        float MaxRange { get; }

        bool PlayProximitySound { get; set; }

        float RightExtend { get; set; }

        float TopExtend { get; set; }
    }
}

