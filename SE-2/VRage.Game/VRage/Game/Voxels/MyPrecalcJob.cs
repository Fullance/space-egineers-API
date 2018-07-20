namespace VRage.Game.Voxels
{
    using ParallelTasks;
    using System;
    using VRageMath;

    public abstract class MyPrecalcJob
    {
        public bool IsValid;
        public readonly Action OnCompleteDelegate;

        protected MyPrecalcJob(bool enableCompletionCallback)
        {
            if (enableCompletionCallback)
            {
                this.OnCompleteDelegate = new Action(this.OnComplete);
            }
        }

        public abstract void Cancel();
        public virtual void DebugDraw(Color c)
        {
        }

        public abstract void DoWork();
        protected virtual void OnComplete()
        {
        }

        public virtual bool IsCanceled =>
            false;

        public WorkOptions Options =>
            Parallel.DefaultOptions;

        public virtual int Priority =>
            0;
    }
}

