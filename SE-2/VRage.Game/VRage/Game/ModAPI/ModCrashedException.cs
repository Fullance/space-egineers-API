namespace VRage.Game.ModAPI
{
    using System;
    using System.Runtime.CompilerServices;

    public class ModCrashedException : Exception
    {
        public ModCrashedException(Exception innerException, IMyModContext modContext) : base("Mod crashed!", innerException)
        {
            this.ModContext = modContext;
        }

        public IMyModContext ModContext { get; private set; }
    }
}

