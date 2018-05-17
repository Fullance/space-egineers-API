namespace Sandbox.ModAPI
{
    using System;

    public interface IMyScriptBlacklistBatch : IDisposable
    {
        void AddMembers(Type type, params string[] memberNames);
        void AddNamespaceOfTypes(params Type[] types);
        void AddTypes(params Type[] types);
        void RemoveMembers(Type type, params string[] memberNames);
        void RemoveNamespaceOfTypes(params Type[] types);
        void RemoveTypes(params Type[] types);
    }
}

