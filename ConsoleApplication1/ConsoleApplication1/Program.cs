using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo();
            foo.MyProperty = "Whats up my!";
            foo.WriteSomething();
            Console.ReadLine();
        }
    }
}
