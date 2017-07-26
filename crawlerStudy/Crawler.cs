using System;
using System.Collections.Generic;
using System.Threading;

namespace crawlerStudy
{
    public class Crawler
    {
//        public Crawler() { }

        public static List<List<string>> cnkiJournalList;

        public static List<DownLoader> _downloaderList = new List<DownLoader>();

        public static void DownloadHtml()
        {
            while (true)
            {
                if (cnkiJournalList.Count > 0)
                {
                    var journalInfo = cnkiJournalList[0];
                    cnkiJournalList.Remove(journalInfo);
                    Console.WriteLine("Downloading" + journalInfo[0]);
                    var journalKey = journalInfo[0];
                    var year = journalInfo[1];
                    var issue = journalInfo[2];
                    while (true)
                    {
                        var journal = new JournalCnki(year, issue, journalKey);
                        var urlList = journal.ArticleUrlList;
                        if (urlList.Count == 0)
                        {
                            WriteData.UpdateJournalStatus(journalKey, year, issue);
                            break;
                        }
                        foreach (var url in urlList)
                        {
                            var downloader = new DownLoader(url);
                            _downloaderList.Add(downloader);
                        }
                        Console.WriteLine(journalInfo[0] + "issue:" + issue + "Download Complete!" +
                                          "count:" + urlList.Count);
                        issue = StringTools.AddZero(StringTools.PlusOne(issue));
                    }
                }
            }
        }

        public static void analyzeHtml()
        {
            while (true)
            {
                if (_downloaderList.Count > 0)
                {
                    var downLoader = _downloaderList[0];

                    if (downLoader != null)
                    {
                        _downloaderList.Remove(downLoader);
//                        Console.WriteLine("analyze" + downLoader.InputUrl);
                        var page = new PageCnki(downLoader.Html, downLoader.InputUrl);

//                        Console.WriteLine("writing "+ page.Title);
                        WriteData.InsertPageCnki(page);
                    }
                }
            }
        }

        public void Run()
        {
            //读取所有期刊名
            var crawlerReader = new CrawlerReader
            {
                TableName = ("t_CNKI_status"),
                Filter = ("1=1")
            };
            Console.WriteLine("new CrawlerReader");
//            cnkiJournalList = crawlerReader.GetValue("qikanKey");
            cnkiJournalList = crawlerReader.GetAllValue(new List<string>() {"qikanKey", "year", "issue"});





            Console.WriteLine("getValue");


            //多线程处理 模板

            Thread downloadtThread = new Thread(DownloadHtml);
            Thread downloadtThread1 = new Thread(DownloadHtml);
            Thread downloadtThread2 = new Thread(DownloadHtml);
            Thread downloadtThread3 = new Thread(DownloadHtml);
            Thread downloadtThread4 = new Thread(DownloadHtml);
            Thread downloadtThread5 = new Thread(DownloadHtml);
            Thread downloadtThread6 = new Thread(DownloadHtml);
            Thread downloadtThread7 = new Thread(DownloadHtml);
            Thread downloadtThread8 = new Thread(DownloadHtml);
            Thread analyzeThread = new Thread(analyzeHtml);


            downloadtThread1.IsBackground = true;
            downloadtThread2.IsBackground = true;
            downloadtThread3.IsBackground = true;
            downloadtThread4.IsBackground = true;
            downloadtThread.IsBackground = true;
            downloadtThread5.IsBackground = true;
            downloadtThread6.IsBackground = true;
            downloadtThread7.IsBackground = true;
            downloadtThread8.IsBackground = true;


            analyzeThread.IsBackground = true;


            downloadtThread.Start();
            analyzeThread.Start();
            downloadtThread1.Start();
            downloadtThread2.Start();
            downloadtThread3.Start();
            downloadtThread4.Start();
            downloadtThread5.Start();
            downloadtThread6.Start();
            downloadtThread7.Start();
            downloadtThread8.Start();


            Console.ReadKey();


            //单线程处理 程序
//            foreach (var cnkiJournal in cnkiJournalList)
//            {
//                var journal = new JournalCnki(cnkiJournal);
//                journal.Issue = "04";
//                journal.Year = "2016";
//                foreach (var url in journal.ArticleUrlList)
//                {
//                    var page = new PageCnki(url);
////                    Console.WriteLine(page.Author);
//                    WriteData.InsertPageCnki(page);
//                }
//            }


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