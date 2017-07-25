using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;

namespace crawlerStudy
{
    
    public class GetJournalName
    {  
        /// <summary>
        /// 为英文字母加一
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static char addOne(char ch)
        {
            return (char)((int)ch+1);
        }
        public static void writeFile(string htmlString)
        {
            FileStream fs = new FileStream("E:\\ak.txt", FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(htmlString); 
            //开始写入
            fs.Write(data, 0, data.Length);
            
            
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
         
        
        /// <summary>
        /// 获得所有期刊名称简写代码
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllJournal()
        {
            var charNum = 'A';
            var result = new List<string>();
            while (true)
            {
                Console.WriteLine(charNum);
                var singleSubjectName= GetSingleSubjectJournalByPage(charNum);
                Console.WriteLine(singleSubjectName.Count);
                if (singleSubjectName.Count == 0) break;
                result.AddRange(singleSubjectName);
                Console.WriteLine(charNum);
                charNum = addOne(charNum);
            }
            return result;
           
        }

        
        
        /// <summary>
        /// 对指定学科的期刊进行获取期刊名，逐页获取，
        /// </summary>
        /// <param name="charNum"></param>
        /// <returns></returns>
        public static List<string> GetSingleSubjectJournalByPage(char charNum)
        {
            var result = new List<string>();
            var page = 1;
            while (true)
            {
                var singlePageName= GetSinglePageJournal(charNum, page);
                if (singlePageName.Count == 0) break;
                result.AddRange(singlePageName);
//                Console.WriteLine(page);
                page++;
            }
            return result;

        }
        /// <summary>
        /// 对指定学科,指定页码获取journal名称
        /// </summary>
        /// <param name="charNum"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static List<string> GetSinglePageJournal(char charNum,int page)
        {
            Random randomDouble = new Random();
            Thread.Sleep((randomDouble.Next(0,100)));
            HttpHelper httpHelper = new HttpHelper();            
            HttpItem item = new HttpItem();
            item.URL = "http://navi.cnki.net/knavi/Common/Search/All";
            item.Method = "POST";
            item.Postdata = String.Format("SearchStateJson=%7B%22StateID%22%3A%22%22%2C%22Platfrom%22%3A%22%22%2C%22QueryTime%22%3A%22%22%2C%22Account%22%3A%22knavi%22%2C%22ClientToken%22%3A%22%22%2C%22Language%22%3A%22%22%2C%22CNode%22%3A%7B%22PCode%22%3A%22SCDB%22%2C%22SMode%22%3A%22%22%2C%22OperateT%22%3A%22%22%7D%2C%22QNode%22%3A%7B%22SelectT%22%3A%22%22%2C%22Select_Fields%22%3A%22%22%2C%22S_DBCodes%22%3A%22%22%2C%22QGroup%22%3A%5B%7B%22Key%22%3A%22Navi%22%2C%22Logic%22%3A1%2C%22Items%22%3A%5B%5D%2C%22ChildItems%22%3A%5B%7B%22Key%22%3A%22All%22%2C%22Logic%22%3A1%2C%22Items%22%3A%5B%7B%22Key%22%3A1%2C%22Title%22%3A%22%22%2C%22Logic%22%3A1%2C%22Name%22%3A%22%E4%B8%93%E9%A2%98%E5%AD%90%E6%A0%8F%E7%9B%AE%E4%BB%A3%E7%A0%81%22%2C%22Operate%22%3A%22%22%2C%22Value%22%3A%22"
                +charNum+
            "%3F%22%2C%22ExtendType%22%3A0%2C%22ExtendValue%22%3A%22%22%2C%22Value2%22%3A%22%22%7D%5D%2C%22ChildItems%22%3A%5B%5D%7D%5D%7D%5D%2C%22OrderBy%22%3A%22%22%2C%22GroupBy%22%3A%22%22%2C%22Additon%22%3A%22%22%7D%7D&displaymode=1&pageindex="+page+"&pagecount=10&index=1&" +
                                          "random="+randomDouble.NextDouble());
            item.Accept = "text/plain, */*; q=0.01";
            item.ContentType = "application/x-www-form-urlencoded";
            item.Referer = "http://navi.cnki.net/KNavi/All.html";
            item.Allowautoredirect = false;
            HttpResult hResult = httpHelper.GetHtml(item);
            writeFile(hResult.Html);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(hResult.Html);  
            HtmlNodeCollection nodeCollection = htmlDoc.DocumentNode.SelectNodes("//div[@class = 're_brief fl']/h1");
            if(nodeCollection == null) return  new List<string>();
            var  resultArray = new List<string>();
            var i = 0;
            foreach (var htmlNode in nodeCollection)
            {            
                Match result = Regex.Match(htmlNode.InnerHtml, "baseid=([a-zA-Z0-9]{1,})[&|\"]?");
                var baseId = result.Groups.Count > 1 ? result.Groups[1].Value: "";
                resultArray.Add(baseId);
            }
            return resultArray;

        }
       
        
        /// <summary>
        /// 得到该学科所有页面的数据，每页显示条数设为6000，但是有的页面错误后面的数据就没有了。
        /// 需要用singlePage方法，所以暂时先不适用这个函数
        /// </summary>
        /// <param name="charNum"></param>
        /// <returns></returns>
        public static List<string> GetSingleSubjectJournalForAllPage(string charNum)
        {
            Random randomDouble = new Random();
            Thread.Sleep((randomDouble.Next(0,100)));
            HttpHelper httpHelper = new HttpHelper();            
            HttpItem item = new HttpItem();
            item.URL = "http://navi.cnki.net/knavi/Common/Search/All";
            item.Method = "POST";
            item.Postdata = String.Format("SearchStateJson=%7B%22StateID%22%3A%22%22%2C%22Platfrom%22%3A%22%22%2C%22QueryTime%22%3A%22%22%2C%22Account%22%3A%22knavi%22%2C%22ClientToken%22%3A%22%22%2C%22Language%22%3A%22%22%2C%22CNode%22%3A%7B%22PCode%22%3A%22SCDB%22%2C%22SMode%22%3A%22%22%2C%22OperateT%22%3A%22%22%7D%2C%22QNode%22%3A%7B%22SelectT%22%3A%22%22%2C%22Select_Fields%22%3A%22%22%2C%22S_DBCodes%22%3A%22%22%2C%22QGroup%22%3A%5B%7B%22Key%22%3A%22Navi%22%2C%22Logic%22%3A1%2C%22Items%22%3A%5B%5D%2C%22ChildItems%22%3A%5B%7B%22Key%22%3A%22All%22%2C%22Logic%22%3A1%2C%22Items%22%3A%5B%7B%22Key%22%3A1%2C%22Title%22%3A%22%22%2C%22Logic%22%3A1%2C%22Name%22%3A%22%E4%B8%93%E9%A2%98%E5%AD%90%E6%A0%8F%E7%9B%AE%E4%BB%A3%E7%A0%81%22%2C%22Operate%22%3A%22%22%2C%22Value%22%3A%22"
                +charNum+
            "%3F%22%2C%22ExtendType%22%3A0%2C%22ExtendValue%22%3A%22%22%2C%22Value2%22%3A%22%22%7D%5D%2C%22ChildItems%22%3A%5B%5D%7D%5D%7D%5D%2C%22OrderBy%22%3A%22%22%2C%22GroupBy%22%3A%22%22%2C%22Additon%22%3A%22%22%7D%7D&displaymode=1&pageindex=6000&pagecount=10&index=1&" +
                                          "random="+randomDouble.NextDouble());
            item.Accept = "text/plain, */*; q=0.01";
            item.ContentType = "application/x-www-form-urlencoded";
            item.Referer = "http://navi.cnki.net/KNavi/All.html";
            item.Allowautoredirect = false;
            HttpResult hResult = httpHelper.GetHtml(item);
            writeFile(hResult.Html);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(hResult.Html);  
            HtmlNodeCollection nodeCollection = htmlDoc.DocumentNode.SelectNodes("//div[@class = 're_brief fl']/h1");
            if(nodeCollection == null) return  new List<string>();
            var  resultArray = new List<string>();
            foreach (var htmlNode in nodeCollection)
            {            
                Match result = Regex.Match(htmlNode.InnerHtml, "baseid=([a-zA-Z0-9]{1,})[&|\"]?");
                var baseId = result.Groups.Count > 1 ? result.Groups[1].Value: "";
                resultArray.Add(baseId);
            }
            return resultArray;

        }
    }
}