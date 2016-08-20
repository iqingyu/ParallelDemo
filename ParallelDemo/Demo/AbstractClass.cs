﻿using System;
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
        protected IView view;

        public AbstractClass(IView view)
        {
            this.view = view;
        }

        protected void SetTip(string tip)
        {
            this.view.DispatcherAction(() =>
            {
                TextBox txtTip = this.view.GetObjectByName(TXT_NAME) as TextBox;
                txtTip.SetTip(tip);
            });
        }
    }
}
