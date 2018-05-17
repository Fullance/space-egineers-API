namespace VRage.Game.ModAPI
{
    using System;
    using System.Collections.Generic;

    public interface IMyGridGroups
    {
        List<IMyCubeGrid> GetGroup(IMyCubeGrid node, GridLinkTypeEnum type);
        bool HasConnection(IMyCubeGrid grid1, IMyCubeGrid grid2, GridLinkTypeEnum type);
    }
}

