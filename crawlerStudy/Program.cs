using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Threading;
using Microsoft.SqlServer.Server;

namespace crawlerStudy
{
    internal class Program
    {
       
        public static void Main(string[] args)
        {
            var crawler =new  Crawler();
            crawler.Run();



            



//            var downloaders = new DownLoader("123");
//            var downloaders2 = new DownLoader("123");
//            downloaders = null;
//            Console.WriteLine(downloaders == null);





//            var list = new List<DownLoader>();
//            list.Add(new DownLoader("123"));
//            
//            list.Add(new DownLoader("456"));
//            Console.WriteLine(list.Count);
//            list.RemoveAt(0);
//            Console.WriteLine(list.Count);




//            var journal = new JournalCnki("BZSX");
//            journal.Issue = "04";
//            journal.Year = "2016";
//            string url = journal.ArticleUrlList[0];
//            var downLoader = new DownLoader(url);
//            
//            var page = new PageCnki(downLoader.Html,downLoader.InputUrl);
//            WriteData.InsertPageCnki(page);



        }



    }
}