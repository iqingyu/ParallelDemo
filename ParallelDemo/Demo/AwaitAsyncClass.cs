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


        public async Task AsyncMethod()
        {
            SetTip($"ManagedThreadId - 1 - :{Thread.CurrentThread.ManagedThreadId}");

            // 休眠两秒
            await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);

            SetTip($"ManagedThreadId - 2 - :{Thread.CurrentThread.ManagedThreadId}");
        }



    }
}
