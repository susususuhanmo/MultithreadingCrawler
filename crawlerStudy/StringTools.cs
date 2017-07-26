namespace crawlerStudy
{
    public class StringTools
    {
        public static string DeleteLastChar(string str, string last = ";")
        {
            if (string.IsNullOrEmpty(str)) return null;
            if (str[str.Length - 1] == ';') return str.Substring(0, str.Length - 1);
            return str;
        }
         public static string PlusOne(string str)
        {
            return(int.Parse(str) + 1).ToString();
        }

        public static string AddZero(string str)
        {
            if (str.Length > 1) return str;
            else return "0" + str;
        }
    }
}