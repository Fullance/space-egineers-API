namespace VRage.Game.Systems
{
    using System;
    using VRage.Collections;

    public abstract class MyGroupScriptBase
    {
        public abstract void ProcessObjects(ListReader<MyDefinitionId> objects);
    }
}

