using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 闭包测试
{
    delegate void Func();
    class Program
    {
        static Func F()
        {
            int e = 1;
            return () => {   
                e++;
                Console.WriteLine($"e={e}"); 
            };
        }

        static void Main(string[] args)
        {
            Func G = F();
            G();
            G();
            G();
            G();

            Console.ReadKey();
        }
    }
}
