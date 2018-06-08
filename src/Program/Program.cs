using System;

namespace DesignByContract
{
    class Program
    {
        static void Main(string[] args)
        {
            AcmeTV tv = new AcmeTV();

            Console.WriteLine(tv.IsOn);
            tv.NextChannel();
            Console.WriteLine(tv.Channel);
        }
    }
}
