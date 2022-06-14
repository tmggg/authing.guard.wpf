using System;
using System.Threading;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Infrastructures
{
    internal class TaskExHelper
    {
        public static Task Run(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            new Thread(() =>
                {
                    try
                    {
                        action();
                        tcs.SetResult(null);
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                })
            { IsBackground = true }.Start();
            return tcs.Task;
        }

        public static Task<TResult> Run<TResult>(Func<TResult> function)
        {
            var tcs = new TaskCompletionSource<TResult>();
            new Thread(() =>
                {
                    try
                    {
                        tcs.SetResult(function());
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                })
            { IsBackground = true }.Start();
            return tcs.Task;
        }

        public static Task Delay(uint time)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new System.Timers.Timer(time) { AutoReset = false };
            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(null); };
            timer.Start();
            return tcs.Task;
        }
    }
}