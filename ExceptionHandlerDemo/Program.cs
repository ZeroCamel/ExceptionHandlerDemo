using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlerDemo
{
    /// <summary>
    /// TODO:异常处理
    /// 1、同步编程
    /// 2、异步编程
    /// </summary>
    class Program
    {
        static Stopwatch _watch = new Stopwatch();

        static async Task ThrowAfter(int timeout,Exception ex)
        {
            await Task.Delay(timeout);
            throw ex;
        }

        static void PrintException(Exception ex)
        {
            Console.WriteLine("Time:{0}\n{1}\n===========",_watch.Elapsed,ex);
        }

        static async Task MissHandling()
        {
            var t1 = ThrowAfter(1000, new NotSupportedException("error1"));
            var t2 = ThrowAfter(2000,new NotImplementedException("error2"));

            try
            {
                await t1;
            }
            catch (NotSupportedException ex)
            {
                PrintException(ex);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
