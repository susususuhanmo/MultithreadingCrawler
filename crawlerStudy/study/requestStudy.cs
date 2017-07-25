using System;

namespace crawlerStudy
{
    public class requestStudy
    {
        public static void getPartner(string kid)
        {
            HttpHelper httpHelper = new HttpHelper();            
            HttpItem item = new HttpItem();
            item.URL = "http://expert.ckcest.cn/ApiInterface/queryPartner";
            item.Method = "POST";
            item.Postdata = String.Format("isClaimed=0&kid="+kid+"&from=0&size=10");
            item.Accept = "application/json, text/javascript, */*; q=0.01";
            item.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            item.Referer = "http://expert.ckcest.cn/Expert/Details/ExpertInfo?";
            item.Allowautoredirect = false;
            HttpResult hResult = httpHelper.GetHtml(item);
            Console.WriteLine(hResult.StatusCode);
//            writeFile(hResult.Html);
        }
        public static void getResource(string kid)
        {
            HttpHelper httpHelper = new HttpHelper();            
            HttpItem item = new HttpItem();
            item.URL = "http://expert.ckcest.cn/ApiInterface/queryResourcesByKid";
            item.Method = "POST";
            item.Postdata = String.Format("kid="+kid+"&isClaimed=0&nameOrgArray=&sort=&order=&from=0&size=6");
            item.Accept = "application/json, text/javascript, */*; q=0.01";
            item.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            item.Referer = "http://expert.ckcest.cn/Expert/Details/ExpertInfo?";
            item.Allowautoredirect = false;
            HttpResult hResult = httpHelper.GetHtml(item);
            Console.WriteLine(hResult.StatusCode);
//            writeFile(hResult.Html);
        }
    }
}