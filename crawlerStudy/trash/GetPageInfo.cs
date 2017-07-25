using System;
using System.IO;

using HtmlAgilityPack;

namespace crawlerStudy
{
    public class GetPageInfo
    {
        public static string cutStr(string str, int length = 2000)
        {
            if (str == null) return null;
            if (str.Length <= length) return str;
            return str.Substring(0, length);
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
        public static void getCNki(string inputUrl)
        {
            HttpHelper httpHelper = new HttpHelper();
            HttpResult result = httpHelper.GetHtml(
                new HttpItem()
                {
                    URL =inputUrl
                }); 
            var i = 1;
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result.Html);
//            writeFile(result.Html);
            
            
            HtmlNodeCollection authorNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class = 'author']/span");
            var author = "";
            foreach (var authorNode in authorNodes)
                  author += (authorNode == null) ? "" : authorNode.InnerText.Trim() + ";";
            author = author.Substring(0, author.Length-1);
            
            
            
//            var author = (authorNodes == null) ? null : authorNodes.InnerText.Trim();  
            
            HtmlNode instituteNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class = 'orgn']");           
            var institute = (instituteNode == null)? null: instituteNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           

            HtmlNode classificationNode = htmlDoc.DocumentNode.SelectSingleNode("//label[@id = 'catalog_ZTCLS']/../text()");           
            var classification = (classificationNode == null)? null: classificationNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
            HtmlNode abstractNode = htmlDoc.DocumentNode.SelectSingleNode("//label[@id = 'catalog_ABSTRACT']/../span/text()");  
            var myAbstract = (abstractNode == null)? null: abstractNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
             
            HtmlNode keyWordNode = htmlDoc.DocumentNode.SelectSingleNode("//label[@id = 'catalog_KEYWORD']/..");  
            var keyWord = (keyWordNode == null)? null: keyWordNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
            
            HtmlNode DOINode = htmlDoc.DocumentNode.SelectSingleNode("//label[@id = 'catalog_ZCDOI']/../text()");  
            var DOI = (DOINode == null)? null: DOINode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
             
            
            HtmlNode titleNode = htmlDoc.DocumentNode.SelectSingleNode("//h2[@class = 'title']");  
            var title = (titleNode == null)? null: titleNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
         
            
            
//            WriteData.InsertInToCrawler(cutStr(author),cutStr(institute),cutStr(classification),cutStr(myAbstract),cutStr(keyWord),cutStr(DOI),cutStr(inputUrl),cutStr(title)); 
            
            Console.WriteLine("author:"+author + "\tinstitute:" + institute + "\tclassification:"+classification
            );
            Console.WriteLine("\n\nabstract:" + myAbstract +"\n\n\n\nkeyword:"+keyWord+"\n\ndoi:" + DOI);
        }
        public static void getVIP()
        {
            HttpHelper httpHelper = new HttpHelper();
            HttpResult result = httpHelper.GetHtml(
                new HttpItem()
                {
                    URL ="http://lib.cqvip.com/qk/83862B/201601/668727480.html"
                }); 
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result.Html);
            HtmlNode authorNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'author']/a");           
            var author = (authorNode == null)? null: authorNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
            HtmlNode instituteNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'org']/a");           
            var institute = (instituteNode == null)? null: instituteNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
                       
            HtmlNode classificationNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'class']/a/b");           
            var classification = (classificationNode == null)? null: classificationNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
            HtmlNode abstractNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'abstrack']");           
            var myAbstract = (abstractNode == null)? null: abstractNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
               
//           WriteData.InsertInToCrawler(author,institute,classification,myAbstract); 
//            GetJournalName.writeFile("author:"+author + "\tinstitute:" + institute + "\tclassification:"+classification +"\r\nabstract:" + myAbstract);

        
        }
        
        
        public static void getWF()
        {
            HttpHelper httpHelper = new HttpHelper();
            HttpResult result = httpHelper.GetHtml(
                new HttpItem()
                {
                    URL ="http://d.wanfangdata.com.cn/Periodical/yydb201601001"
                }); 
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(result.Html);
            HtmlNode authorNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[4]/div/div[2]/span[2]/a");           
            var author = (authorNode == null)? null: authorNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
            HtmlNode instituteNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[4]/div/div[4]/span[2]");           
            var institute = (instituteNode == null)? null: instituteNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
                       
            HtmlNode classificationNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[4]/div/div[8]/span[2]");           
            var classification = (classificationNode == null)? null: classificationNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
            HtmlNode abstractNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[3]/div/div[2]/div/div[2]/text()");           
            var myAbstract = (abstractNode == null)? null: abstractNode.InnerText.Trim().Replace("&nbsp;", "").Replace(Environment.NewLine, "");   
           
                
            
            GetJournalName.writeFile("author:"+author + "\tinstitute:" + institute + "\tclassification:"+classification +"\r\nabstract:" + myAbstract);

//            Console.WriteLine("author:"+author + "\tinstitute:" + institute + "\tclassification:"+classification +"\nabstract:" + myAbstract);
        
        }
    }
}