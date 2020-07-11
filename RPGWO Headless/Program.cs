using System;

namespace RPGWO_Headless
{
    class Program
    {
        static void Main(string[] args)
        {
            new HeadlessClient("127.0.0.1", 4502).Start().GetAwaiter().GetResult();
        }
    }
}
