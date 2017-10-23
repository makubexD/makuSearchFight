using System;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new[] { ".net", "java" };
            args = demo;

            Console.WriteLine(new SearcherEngine().Execute(args));
            Console.ReadLine();
        }
    }
}
