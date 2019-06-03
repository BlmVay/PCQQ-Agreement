using System;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //int r = 1;
            //string str = "<Packet><Len>170</Len><No>20190528140417</No><FunCode>11</FunCode><Room></Room><NRoom></NRoom><Status>99</Status><Response>0</Response><CheckCode>043</CheckCode></Packet>";
            //for (int i = 0 ; i < str.Length; i++)
            //{
            //    r ^= str[i];
            //}
            //Console.WriteLine(r);
            int x = 126;
            Console.WriteLine(x&1);
            Console.ReadKey();
        }
    }
}
