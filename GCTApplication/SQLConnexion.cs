using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GCTApplication
{
    class SQLConnexion
    {
        public SQLiteCommand com;
        public SQLiteConnection con;
        public SQLConnexion()
        {
            this.con = new SQLiteConnection("data source=" + System.IO.Directory.GetCurrentDirectory() + @"\gct.sqlite");
            con.Open();
            this.com = new SQLiteCommand(con);
        }

        public void FermerConnexion()
        {
            this.con.Close();
        }
    }
}
