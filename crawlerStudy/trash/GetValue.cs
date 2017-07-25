using System.Text.RegularExpressions;

namespace crawlerStudy
{
    public class GetValue
    {
        public static string GetValueFromHtml(string htmlString,string key)
        {
            Match authorResult = Regex.Match(htmlString, key+"=([a-zA-Z0-9]{1,})[&|\"]?");
            
            return authorResult.Groups.Count > 1 ? authorResult.Groups[1].Value: "";
        }
    }
}