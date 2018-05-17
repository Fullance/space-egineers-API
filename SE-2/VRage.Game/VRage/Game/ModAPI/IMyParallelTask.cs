namespace VRage.Game.ModAPI
{
    using ParallelTasks;
    using System;
    using System.Collections.Generic;

    public interface IMyParallelTask
    {
        void Do(params IWork[] work);
        void Do(params Action[] actions);
        void Do(IWork a, IWork b);
        void Do(Action action1, Action action2);
        void For(int startInclusive, int endExclusive, Action<int> body);
        void For(int startInclusive, int endExclusive, Action<int> body, int stride);
        void ForEach<T>(IEnumerable<T> collection, Action<T> action);
        void Sleep(int millisecondsTimeout);
        void Sleep(TimeSpan timeout);
        Task Start(IWork work);
        Task Start(Action action);
        Task Start(IWork work, Action completionCallback);
        Task Start(Action action, WorkOptions options);
        Task Start(Action action, Action completionCallback);
        Task Start(Action action, WorkOptions options, Action completionCallback);
        Task Start(Action<WorkData> action, Action<WorkData> completionCallback, WorkData workData);
        Task StartBackground(IWork work);
        Task StartBackground(Action action);
        Task StartBackground(IWork work, Action completionCallback);
        Task StartBackground(Action action, Action completionCallback);
        Task StartBackground(Action<WorkData> action, Action<WorkData> completionCallback, WorkData workData);

        WorkOptions DefaultOptions { get; }
    }
}

