using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CTInventoryApp
{
    class DatabaseAccessor
    {

        public string DbName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public string UserSqlCommand { get; set; }
        //public DataTable DataTable { get; set; }

        private  static string sqlConnectionString = @"";
        public DatabaseAccessor()
        {
            DbName = "CTInventory";
            DbUserName = "Christofitis";
            DbPassword = "Nothing";
            UserSqlCommand = "SELECT Mfg_Num from Parts";
            sqlConnectionString = string.Format(@"Server=C13-Desktop\SQLEXPRESS; Database = {2}; User Id={0}; Password={1}", DbUserName, DbPassword, DbName);
            //RunSqlCommand();
        }

        public DataTable RunSqlCommand()
        {
            DataTable dt = new DataTable();
            UserSqlCommand = UserSqlCommand;

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(UserSqlCommand);
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    dt.Clear();
                    da.Fill(dt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error in DataBase Accessor!");
                }
            }
            //MessageBox.Show(dt.Rows[0]["Mfg_Num"].ToString());
            return dt;
            
        }

        
    }

    
}
