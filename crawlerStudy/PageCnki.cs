namespace crawlerStudy
{
    public class PageCnki:Page
    {
        public PageCnki(string inputUrl):base(inputUrl){ }
        public string InputUrl
        {
            get { return base.InputUrl; }
        }

        public string Author
        {
            get { return GetValueFromXpath("//div[@class = 'author']/span"); }
        }

        public string Institute
        {
            get { return GetValueFromXpath("//div[@class = 'orgn']/span"); }
        }

        public string Classification
        {
            get { return GetValueFromXpath("//label[@id = 'catalog_ZTCLS']/../text()"); }
        }

        public string MyAbstract
        {
            get { return GetValueFromXpath("//label[@id = 'catalog_ABSTRACT']/../span/text()"); }
        }

        public string KeyWord
        {
            get { return GetValueFromXpath("//label[@id = 'catalog_KEYWORD']/../a"); }
        }

        public string DOI
        {
            get { return GetValueFromXpath("//label[@id = 'catalog_ZCDOI']/../text()"); }
        }

        public string Title
        {
            get { return GetValueFromXpath("//h2[@class = 'title']"); }
        }
        
        
        
        
      
    }
}