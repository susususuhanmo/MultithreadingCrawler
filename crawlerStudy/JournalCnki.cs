using System.Collections.Generic;
using HtmlAgilityPack;

namespace crawlerStudy
{
    public class JournalCnki:Journal
    {
        public JournalCnki(string year, string issue, string journalName) : base(year, issue, journalName) { }
        public JournalCnki(string journalName):base(journalName) { }
        public List<string> ArticleUrlList
        {
            get
            {  
                var httpHelper = new HttpHelper();
                var result = httpHelper.GetHtml(
                    new HttpItem()
                    {
                        URL = "http://navi.cnki.net/knavi/JournalDetail/GetArticleList?" +
                              "year="+Year+"&issue="+Issue+"&pykm="+JournalName+"&pageIdx=0"
                    });

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(result.Html);
                
                HtmlNodeCollection nodeCollection = htmlDoc.DocumentNode.SelectNodes("//span[@class = 'name']"); 
            
                if(nodeCollection == null) return  new List<string>();
                var resultList = new List<string>();
                foreach (var htmlNode in nodeCollection)
                {
                    var fileName = GetValue.GetValueFromHtml(htmlNode.InnerHtml, "filename");
                    var dbCode = GetValue.GetValueFromHtml(htmlNode.InnerHtml, "dbCode");
                    var dbName = GetValue.GetValueFromHtml(htmlNode.InnerHtml, "tableName");

                    var resultHtml = "http://kns.cnki.net/kcms/detail/detail.aspx?dbCode=" + dbCode + "&filename=" +
                                     fileName + "&dbName=" + dbName;
                    resultList.Add(resultHtml);
                }
                return resultList;
            }
        }
    }
}