using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace ParallelDemo.Demo
{
    public class AwaitAsyncClass : AbstractClass
    {
        public AwaitAsyncClass(IView view) : base(view)
        {

        }

        /// <summary>
        /// 第一个简单demo
        /// </summary>
        /// <returns></returns>
        public async Task MethodAsync()
        {
            SetTip($"ManagedThreadId - 1 - :{Thread.CurrentThread.ManagedThreadId}");

            // 休眠
            await Task.Delay(TimeSpan.FromMilliseconds(100));

            SetTip($"ManagedThreadId - 2 - :{Thread.CurrentThread.ManagedThreadId}");
        }

        /// <summary>
        /// 在循环中使用await, 观察使用的线程数量
        /// </summary>
        /// <returns></returns>
        public async Task ForMethodAsync()
        {
            // 休眠
            // await Task.Delay(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            
            for (int i = 0; i < 10; i++)
            {
                //await MethodCallAsync(i.ToString(), 100);
                await Task.Delay(100);
                SetThreadTip("ForMethodAsync", i.ToString());
            }
        }


        private async Task MethodCallAsync(string args, int sleep)
        {
            SetThreadTip("MethodCallAsync - 1", args);

            // 休眠
            await Task.Delay(TimeSpan.FromMilliseconds(sleep));

            SetThreadTip("MethodCallAsync - 2", args);

            // 休眠
            await Task.Delay(TimeSpan.FromMilliseconds(sleep)); //.ConfigureAwait(false);

            SetThreadTip("MethodCallAsync - 3", args);
        }


        /// <summary>
        /// 死锁 Demo
        /// </summary>
        /// <returns></returns>
        public async Task DeadLockDemoAsync()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));// deadlock

            //await Task.Delay(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false);// un-deadlock

            DeadlockDemo.Test();
        }
        
    }

    /// <summary>
    /// MSDN Demo
    /// </summary>
    public static class DeadlockDemo
    {
        private static async Task DelayAsync()
        {
            await Task.Delay(1000);
        }
        // This method causes a deadlock when called in a GUI or ASP.NET context.
        public static void Test()
        {
            // Start the delay.
            var delayTask = DelayAsync();
            // Wait for the delay to complete.
            delayTask.Wait();
        }
    }
}
