using System;
using System.Threading;

namespace crawlerStudy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var crawler =new  Crawler();
            crawler.Run();
            
            //testGIT
            
//            Thread t1 = new Thread(TestMethod);
//            Thread t2 = new Thread(TestMethod);
//            t1.IsBackground = true;
//            t2.IsBackground = true;
//            t1.Start("123");
//            t2.Start("hello");
//            Console.ReadKey();

        }
//        public static void TestMethod(object data)
//        {
//            string datastr = data as string;
//            Console.WriteLine("aaa:{0}", datastr);
//        }


    }
}