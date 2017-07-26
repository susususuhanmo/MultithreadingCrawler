using System;
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
            try
            {
                InsertInToCrawler(pageCnki.Author, pageCnki.Institute, pageCnki.Classification
                    , pageCnki.MyAbstract, pageCnki.KeyWord, pageCnki.DOI, pageCnki.InputUrl, pageCnki.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } 
        }

        public static void UpdateJournalStatus(string journalKey, string year, string issue)
        {
              
            SqlConnection con = new SqlConnection();


            con.ConnectionString = "server=115.236.19.70,35033;database=Crawler;uid=shm;pwd=shm@zju";
            con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "update [dbo].[t_CNKI_status] set [issue] = '"+issue+"',year = '"+year+"' " +
                              "where qikanKey = '" + journalKey+"'";
            SqlDataReader dr = com.ExecuteReader();//执行SQL语句
        }
    }
}