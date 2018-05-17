namespace Sandbox.ModAPI
{
    using System;

    public interface IMyIngameScripting
    {
        void Clean();

        IMyScriptBlacklist ScriptBlacklist { get; }
    }
}

