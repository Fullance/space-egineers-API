namespace VRage.Game.Voxels
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct StoragePin : IDisposable
    {
        private readonly IMyStorage m_storage;
        public bool Valid =>
            (this.m_storage != null);
        public StoragePin(IMyStorage storage)
        {
            this.m_storage = storage;
        }

        public void Dispose()
        {
            if (this.m_storage != null)
            {
                this.m_storage.Unpin();
            }
        }
    }
}

