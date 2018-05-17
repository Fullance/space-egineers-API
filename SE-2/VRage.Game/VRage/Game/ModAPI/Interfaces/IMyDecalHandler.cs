namespace VRage.Game.ModAPI.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRageRender;

    public interface IMyDecalHandler
    {
        void AddDecal(ref MyDecalRenderInfo renderInfo, List<uint> ids = null);
    }
}

