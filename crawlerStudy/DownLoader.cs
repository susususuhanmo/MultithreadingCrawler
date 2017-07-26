using System.Diagnostics.Eventing.Reader;
using System.Linq;
using HtmlAgilityPack;

namespace crawlerStudy
{
    public class DownLoader
    {
        private readonly string _inputUrl;

        public string Html { get; set; }

        public static bool operator ==(DownLoader downLoader1,DownLoader downLoader2)
        {
            
           return  object.Equals(downLoader1, downLoader2);
        }
        public static bool operator !=(DownLoader downLoader1,DownLoader downLoader2)
        {
            return !object.Equals(downLoader1, downLoader2);
        }
        public override int GetHashCode()
        {
// 在这里使用字符串数组的hashcode，避免自己完成一个算法
            return InputUrl.GetHashCode();
        }

        public override bool Equals(object obj)
        {
//判断与之比较的类型是否为null。这样不会造成递归的情况
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            DownLoader downLoader = (DownLoader)obj;
            if (this.InputUrl == downLoader.InputUrl)
                return true;
            else return false;
//            int count = rec.arr.Length;
//
//            for (int i = 0; i < count; i++)
//            {
//                if (this.arr[i] != rec.arr[i])
//                {
//                    return false;
//                }
//            }
//            return true;
        }
        public string InputUrl
        {
            get { return _inputUrl; }
        }
        public DownLoader(string inputUrl)
        {
            _inputUrl = inputUrl;
            var httpHelper = new HttpHelper();
            var result = httpHelper.GetHtml(
                new HttpItem()
                {
                    URL = _inputUrl
                });
            Html = result.Html;
        }
    }
}