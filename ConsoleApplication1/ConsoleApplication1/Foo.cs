using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApplication1
{
    class Foo
    {
        public string MyProperty { get; set; }

        public void WriteSomething()
        {
            Console.WriteLine(MyProperty);

        }
    }
}
