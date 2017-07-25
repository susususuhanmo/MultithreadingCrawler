using System;
using System.Threading;
using System.Threading.Tasks;

namespace crawlerStudy
{
    public  class Crawler
    {
//        public Crawler() { }

        public void Run()
        {

            var crawlerReader = new CrawlerReader
            {
                TableName = ("知网CNKI期刊名录_2016"),
                Filter = ("1=1")
            };
            Console.WriteLine("new CrawlerReader");
            var cnkiJournalList = crawlerReader.GetValue("qikanKey");
            
            Console.WriteLine("getValue");
            
            
   

            

            
            
            foreach (var cnkiJournal in cnkiJournalList)
            {
            var journal = new JournalCnki(cnkiJournal);
            journal.Issue = "04";
            journal.Year = "2016";
            foreach (var url in journal.ArticleUrlList)
            {
                var page = new PageCnki(url);
                Console.WriteLine(page.Author);
                 WriteData.InsertPageCnki(page);
            }
                
            }
            
//            var journal = new JournalCnki("BZSX");
//            journal.Issue = "04";
//            journal.Year = "2016";
//            foreach (var url in journal.ArticleUrlList)
//            {
//                var page = new PageCnki(url);
//                Console.WriteLine(page.Author);
////                 WriteData.InsertPageCnki(page);
//            }
        }
      
    }
}