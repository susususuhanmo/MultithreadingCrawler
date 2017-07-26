using System.Linq;
using HtmlAgilityPack;

namespace crawlerStudy
{
    public class Page
    {
       
        private readonly HtmlDocument _htmlDoc;
        public string Html { get; set; }
        public string InputUrl { get; set; }
        public Page(string html,string inputUrl)
        {
            Html = html;
            InputUrl = inputUrl;
            _htmlDoc = new HtmlDocument();
            _htmlDoc.LoadHtml(Html);
        }

        public string GetValueFromXpath(string xpath)
        {
            HtmlNodeCollection nodes = _htmlDoc.DocumentNode.SelectNodes(xpath);
            if (nodes == null) return null;
            var value = nodes.Aggregate("", (current, node) =>
                current + ((node == null)
                    ? ""
                    : StringTools.DeleteLastChar(node.InnerText.Trim()) + ";"));
            return StringTools.DeleteLastChar(value);
        }
        
    }
}