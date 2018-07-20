namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct IdentifierList
    {
        public string OriginName;
        public string OriginType;
        public List<MyVariableIdentifier> Ids;
    }
}

