using System.Data;
using System.Data.SqlClient;

namespace crawlerStudy
{
    public class WriteData
    {
        public  static void InsertInToCrawler
            (string author,string institute, string classification
            ,string abstractPassage,string keyword,string doi
            ,string url,string title)
        {
            
            SqlConnection con = new SqlConnection();


            con.ConnectionString = "server=.;database=Crawler;uid=shm;pwd=shm@zju";
            con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "INSERT INTO [Crawler].[dbo].[t_Crawler] " +
                              "(author,institute,classification,abstractPassage,keyword,DOI,url,title) " +
                              "VALUES " +
                              "('"+author+"','"+institute+"','"+classification
                              +"','"+abstractPassage+"','"+keyword+"','"+doi+"','"+url+"','"+title+"')";
            SqlDataReader dr = com.ExecuteReader();//执行SQL语句
        }
        
        public  static void InsertPageCnki(PageCnki pageCnki)
        {
            InsertInToCrawler(pageCnki.Author, pageCnki.Institute, pageCnki.Classification
                , pageCnki.MyAbstract, pageCnki.KeyWord, pageCnki.DOI, pageCnki.InputUrl, pageCnki.Title);
        }
    }
}