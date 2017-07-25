using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace crawlerStudy
{
   public class Reader
    {
        public string TableName { get; set; }

        public string Filter { get; set; }
        public List<string> ColumnList { get; set; }
        private SqlConnection con;
        private SqlCommand com;

        public Reader(string ip, string database, string user, string password)
        {
            con = new SqlConnection
                {ConnectionString = "server=" + ip + ";database=" + database + ";uid=" + user + ";pwd=" + password};
            com = new SqlCommand
            {
                Connection = con,
                CommandType = CommandType.Text
            };
        }

        public string GetCount()
        {
            con.Open();
            com.CommandText = "select count(*) as num from " + TableName + " where " + Filter;
            SqlDataReader dr = com.ExecuteReader(); //执行SQL语句
            dr.Read();
            var result = dr["num"].ToString();
            dr.Close();
            con.Close();
            return result;
        }
        
        public List<string> GetFirstValue()
        {
            return GetFirstValue(ColumnList);
        }

        public string GetFirstValue(string column)
        {
            con.Open();
            com.CommandText = "select * from " + TableName + " where " + Filter;
            SqlDataReader dr = com.ExecuteReader(); //执行SQL语句
            dr.Read();
            var result = dr[column].ToString();
            dr.Close();
            con.Close();
            return result;
        }

        public List<string> GetFirstValue(List<string> columnList)
        {
            con.Open();
            com.CommandText = "select * from " + TableName + " where " + Filter;
            SqlDataReader dr = com.ExecuteReader(); //执行SQL语句
            dr.Read();
            var result = new List<string>();
            columnList.ForEach(column => result.Add(dr[column].ToString()));
            dr.Close();
            con.Close();
            return result;
        }

        
        public List<string> GetValue(string column)
        {
            con.Open();
            com.CommandText = "select * from " + TableName + " where " + Filter;
            SqlDataReader dr = com.ExecuteReader(); //执行SQL语句

            var result = new List<string>();
            while (dr.Read())
            {
                result.Add(dr[column].ToString());
            }

            dr.Close();
            con.Close();
            return result;
        }
        
        
        public List<List<string>> GetAllValue(List<string> columnList)
        {
            con.Open();
            com.CommandText = "select * from " + TableName + " where " + Filter;
            SqlDataReader dr = com.ExecuteReader(); //执行SQL语句

            var result = new List<List<string>>();
            while (dr.Read())
            {
                var resultList = new List<string>();
                columnList.ForEach(column => resultList.Add(dr[column].ToString()));
                result.Add(resultList);
            }

            dr.Close();
            con.Close();
            return result;
        }
    }
    public class CrawlerReader:Reader
    {
        public CrawlerReader():base("115.236.19.70,35033","Crawler","shm","shm@zju") { }
    }
}