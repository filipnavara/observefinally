using System;
using System.Runtime.InteropServices;

namespace nativecrash
{
    class Program
    {
        [DllImport("nativelib.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static unsafe int crash(int *n);

        static int a = 42;

        static bool Filter()
        {
            Console.WriteLine("Filter");
            a = 11;
            return false;
        }

        static unsafe void Main(string[] args)
        {
	    try
            {
                try
                {
                    fixed (int *pa = &a)
                    {
                       Console.WriteLine("Start");
                       crash(pa);
                    }
                }
                catch (Exception) when (Filter())
                {
                    Console.WriteLine("Catch");
                }
            }
            catch
            {
                Console.WriteLine("Catch 2");
            }
        }
    }
}
