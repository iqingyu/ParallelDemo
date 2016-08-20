using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ParallelDemo;

namespace ParallelDemo.Demo
{
    public abstract class AbstractClass
    {
        protected static string TXT_NAME = "txtTip";
        protected Control control;

        public AbstractClass(Control control)
        {
            this.control = control;
        }

        protected void SetTip(string tip)
        {
            this.control.Dispatcher.Invoke(() =>
            {
                TextBox txtTip = this.control.FindName(TXT_NAME) as TextBox;
                txtTip.SetTip(tip);
            });
        }
    }
}
