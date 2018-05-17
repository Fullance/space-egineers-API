namespace VRage.ModAPI
{
    using System;

    public interface IMyRemapHelper
    {
        void Clear();
        long RemapEntityId(long oldEntityId);
        int RemapGroupId(string group, int oldValue);
    }
}

