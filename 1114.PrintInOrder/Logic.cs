using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1114.PrintInOrder
{
    public class Logic
    {
        private System.Threading.EventWaitHandle _firstHandle;
        private System.Threading.EventWaitHandle _SecondHandle;
        public Logic()
        {
            _firstHandle = new System.Threading.ManualResetEvent(false);
            _SecondHandle = new System.Threading.ManualResetEvent(false);
        }

        public void First(Action printFirst)
        {
            printFirst();
            _firstHandle.Set();
        }

        public void Second(Action printSecond)
        {
            _firstHandle.WaitOne();
            printSecond();
            _SecondHandle.Set();
        }

        public void Third(Action printThird)
        {
            _SecondHandle.WaitOne();
            printThird();
        }
    }
}
