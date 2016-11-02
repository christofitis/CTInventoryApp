using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CTInventoryApp
{
    class DatabaseAccessor
    {

        public string DatabaseName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public string DbTable { get; set; }
        public DatabaseAccessor()
        {
            DatabaseName = "CTInventory";
            DbUserName = "Christofitis";
            DbPassword = "Nothing";

            
        }

        public void RunSqlCommand()
        {
            
        }

        public DataTable RunSqlCommand(string s)
        {
            return null;
        }
    }

    
}
