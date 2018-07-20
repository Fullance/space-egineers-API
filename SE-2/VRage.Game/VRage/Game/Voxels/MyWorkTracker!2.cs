namespace VRage.Game.Voxels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Collections;

    public class MyWorkTracker<TWorkId, TWork> : IEnumerable<KeyValuePair<TWorkId, TWork>>, IEnumerable where TWork: MyPrecalcJob
    {
        private readonly MyConcurrentDictionary<TWorkId, TWork> m_worksById;

        public MyWorkTracker(IEqualityComparer<TWorkId> comparer = null)
        {
            this.m_worksById = new MyConcurrentDictionary<TWorkId, TWork>(comparer ?? EqualityComparer<TWorkId>.Default);
        }

        public void Add(TWorkId id, TWork work)
        {
            work.IsValid = true;
            this.m_worksById.Add(id, work);
        }

        public void Cancel(TWorkId id)
        {
            TWork local;
            if (this.m_worksById.TryGetValue(id, out local))
            {
                local.Cancel();
                this.m_worksById.Remove(id);
            }
        }

        public void CancelAll()
        {
            foreach (TWork local in this.m_worksById.Values)
            {
                local.Cancel();
            }
            this.m_worksById.Clear();
        }

        public void Complete(TWorkId id)
        {
            this.m_worksById.Remove(id);
        }

        public bool Exists(TWorkId id) => 
            this.m_worksById.ContainsKey(id);

        public IEnumerator<KeyValuePair<TWorkId, TWork>> GetEnumerator() => 
            this.m_worksById.GetEnumerator();

        public bool Invalidate(TWorkId id)
        {
            TWork local;
            if (this.m_worksById.TryGetValue(id, out local))
            {
                local.IsValid = false;
                return true;
            }
            return false;
        }

        public void InvalidateAll()
        {
            foreach (TWork local in this.m_worksById.Values)
            {
                local.IsValid = false;
            }
        }

        IEnumerator<KeyValuePair<TWorkId, TWork>> IEnumerable<KeyValuePair<TWorkId, TWork>>.GetEnumerator() => 
            this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            this.GetEnumerator();

        public bool TryGet(TWorkId id, out TWork work) => 
            this.m_worksById.TryGetValue(id, out work);

        public bool HasAny =>
            (this.m_worksById.Count > 0);
    }
}

