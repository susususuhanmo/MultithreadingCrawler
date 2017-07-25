using System.Linq;
using HtmlAgilityPack;

namespace crawlerStudy
{
    public class Page
    {
        private readonly string _inputUrl;
        private readonly HtmlDocument _htmlDoc;
        public string InputUrl
        {
            get { return _inputUrl; }
        }
        public Page(string inputUrl)
        {
            _inputUrl = inputUrl;
            var httpHelper = new HttpHelper();
            var result = httpHelper.GetHtml(
                new HttpItem()
                {
                    URL = _inputUrl
                });

            _htmlDoc = new HtmlDocument();
            _htmlDoc.LoadHtml(result.Html);
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