using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParallelDemo.Demo
{
    /// <summary>
    /// Linq 的 并行版本
    /// </summary>
    public class PLinqClass : AbstractClass
    {
        public PLinqClass(IView view) : base(view)
        {

        }

        /// <summary>
        /// PLinq:Linq的并行版本
        /// </summary>
        public void Demo1()
        {
            Task.Run(() =>
            {
                var result = Enumerable.Range(1, 10).AsParallel().Where(e =>
                {
                    SetTip("开始                      " + e);

                    SetTip("休眠             " + e);
                    Thread.Sleep(1000);

                    SetTip("结束  " + e);
                    return e > 5;
                });

                SetTip("打印结果");

                foreach (var item in result)
                {
                    SetTip(item.ToString());
                }

                SetTip("并行查询执行完毕");
            });
        }


        /// <summary>
        /// PLinq:按顺序输出结果
        /// </summary>
        public void Demo2()
        {
            Task.Run(() =>
            {
                var result = Enumerable.Range(1, 10).AsParallel().AsOrdered().Where(e =>
                {
                    SetTip("开始                      " + e);

                    SetTip("休眠             " + e);
                    Thread.Sleep(1000);

                    SetTip("结束  " + e);
                    return e > 5;
                });

                SetTip("打印结果");

                foreach (var item in result)
                {
                    SetTip(item.ToString());
                }

                SetTip("并行查询执行完毕");
            });
        }


    }
}
