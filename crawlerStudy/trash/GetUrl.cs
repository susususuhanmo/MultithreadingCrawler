using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;

namespace crawlerStudy.Properties
{
    public class GetUrl
    {
        public static List<string> GetSinglePageUrl(string year,string issue,string pykm)
        {
           
            HttpHelper httpHelper = new HttpHelper();
            HttpResult result = httpHelper.GetHtml(
                new HttpItem()
                {
                    URL ="http://navi.cnki.net/knavi/JournalDetail/GetArticleList?" +
                         "year="+year+"&issue="+issue+"&pykm="+pykm+"&pageIdx=0"
                }); 
            HtmlDocument htmlDoc = new HtmlDocument();
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