namespace Sandbox.ModAPI
{
    using System;

    public enum BuildCheckResult
    {
        OK,
        NotConnected,
        IntersectedWithGrid,
        IntersectedWithSomethingElse,
        AlreadyBuilt,
        NotFound
    }
}

