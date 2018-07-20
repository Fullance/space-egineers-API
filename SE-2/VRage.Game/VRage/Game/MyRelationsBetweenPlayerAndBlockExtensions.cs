namespace VRage.Game
{
    using System;
    using System.Runtime.CompilerServices;

    public static class MyRelationsBetweenPlayerAndBlockExtensions
    {
        public static bool IsFriendly(this MyRelationsBetweenPlayerAndBlock relations)
        {
            if ((relations != MyRelationsBetweenPlayerAndBlock.NoOwnership) && (relations != MyRelationsBetweenPlayerAndBlock.Owner))
            {
                return (relations == MyRelationsBetweenPlayerAndBlock.FactionShare);
            }
            return true;
        }
    }
}

