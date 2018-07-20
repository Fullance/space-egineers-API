namespace VRage.Game.VisualScripting
{
    using System;

    public interface IMyLevelScript
    {
        [VisualScriptingMember(true, false)]
        void Dispose();
        [VisualScriptingMember(true, false)]
        void GameFinished();
        [VisualScriptingMember(true, false)]
        void GameStarted();
        [VisualScriptingMember(true, false)]
        void Update();
    }
}

