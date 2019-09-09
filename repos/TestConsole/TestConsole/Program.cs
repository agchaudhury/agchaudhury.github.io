using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test obj1 = new Test();
            obj1.TestMethod();
            Test1 obj = new Test1();
            obj.TestMethod1();
        }
    }

    public sealed class Test
    {
        public void TestMethod()
        { }
    }

    public class Test1
    {
        public void TestMethod1()
        { }
    }
}
