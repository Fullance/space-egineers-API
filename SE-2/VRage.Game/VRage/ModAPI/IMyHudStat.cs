﻿namespace VRage.ModAPI
{
    using System;
    using VRage.Utils;

    public interface IMyHudStat
    {
        string GetValueString();
        void Update();

        float CurrentValue { get; }

        MyStringHash Id { get; }

        float MaxValue { get; }

        float MinValue { get; }
    }
}

