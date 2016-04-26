using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FyndDyne {
    class DBConnection {
        private DBConnection() {
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance() {
            if(_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public void Open() {
            if(Connection == null) {
                string connstring = string.Format("Server=localhost; database=fynddyne; UID=root; password=omgitsujj");
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

        }

        public void Close() {
            connection.Close();
            connection = null;
        }
    }
}
