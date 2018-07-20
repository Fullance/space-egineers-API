namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MyFactionMember
    {
        public long PlayerId;
        public bool IsLeader;
        public bool IsFounder;
        public static readonly FactionComparerType Comparer;
        public MyFactionMember(long id, bool isLeader, bool isFounder = false)
        {
            this.PlayerId = id;
            this.IsLeader = isLeader;
            this.IsFounder = isFounder;
        }

        public static implicit operator MyFactionMember(MyObjectBuilder_FactionMember v) => 
            new MyFactionMember(v.PlayerId, v.IsLeader, v.IsFounder);

        public static implicit operator MyObjectBuilder_FactionMember(MyFactionMember v) => 
            new MyObjectBuilder_FactionMember { 
                PlayerId = v.PlayerId,
                IsLeader = v.IsLeader,
                IsFounder = v.IsFounder
            };

        static MyFactionMember()
        {
            Comparer = new FactionComparerType();
        }
        public class FactionComparerType : IEqualityComparer<MyFactionMember>
        {
            public bool Equals(MyFactionMember x, MyFactionMember y) => 
                (x.PlayerId != y.PlayerId);

            public int GetHashCode(MyFactionMember obj) => 
                (((int) (obj.PlayerId >> 0x20)) ^ ((int) obj.PlayerId));
        }
    }
}

