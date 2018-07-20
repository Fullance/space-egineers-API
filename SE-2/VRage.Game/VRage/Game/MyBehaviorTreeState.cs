namespace VRage.Game
{
    using System;

    public enum MyBehaviorTreeState : sbyte
    {
        ERROR = -1,
        FAILURE = 2,
        NOT_TICKED = 0,
        RUNNING = 3,
        SUCCESS = 1
    }
}

