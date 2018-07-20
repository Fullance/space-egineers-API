namespace VRage.Game.VisualScripting
{
    using System;
    using System.Runtime.CompilerServices;

    [VisualScriptingEvent(new bool[] { true })]
    public delegate void SingleKeyTriggerEvent(string triggerName, long playerId);
}

