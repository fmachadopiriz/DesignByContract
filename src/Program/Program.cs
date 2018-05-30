using System;

namespace DesignByContract
{
    class Program
    {
        static void Main(string[] args)
        {
            TVSamsung tv = new TVSamsung();

            Console.WriteLine(tv.IsOn);
            tv.NextChannel();
            Console.WriteLine(tv.Channel);
        }
    }
}
