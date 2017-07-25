namespace crawlerStudy
{
    public class StringTools
    {
        public static string DeleteLastChar(string str, string last = ";")
        {
            if (str == null) return null;
            if (str[str.Length - 1] == ';') return str.Substring(0, str.Length - 1);
            return str;
        }
    }
}