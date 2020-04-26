using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace TradeMaster.Data {
    public sealed class Database {
        private MySqlCommand cmd = null;
        private MySqlConnection con = null;
        private MySqlDataReader dataReader = null;

        //DATABASE=employee;SERVER=localhost;UID=root;PORT=3306;PASSWORD="
        /// <summary>
        /// Creates MySql Connection.
        /// </summary>
        public Database() { } 

        public void CreateConnection(string database, string server, string user, string port, string pass) {
            if (string.IsNullOrEmpty(database) || string.IsNullOrEmpty(server) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(port)) return;
            try {
                con = new MySqlConnection("DATABASE=" + database + ";SERVER=" + server + ";UID=" + user + ";PORT=" + port + ";PASSWORD=" + pass);
                cmd = new MySqlCommand("", con);
                con.Open();
            }
            catch (Exception) { throw; }
        }

        public void CloseConnection() {
            if (con == null) return;
            con.Close();
        }

        public bool InsertRow(string tableName, string data, bool reload) {
            if (!con.Ping()) return false;
            try {
                cmd.CommandText = $"Insert into {tableName} Values ({data})";
                bool b = cmd.ExecuteNonQuery() > 0 ? true : false;
                if (reload) Reload(tableName);
                return b;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteRow(string tableName, int id, bool Serialize, bool reload) {
            if (!con.Ping()) return false;
            try {
                if (CheckId(tableName, id)) { MessageBox.Show($"{id} from {tableName} Not Found !\nreturning."); return false; }
                cmd.CommandText = $"Delete from {tableName} where id = " + id;
                bool b = cmd.ExecuteNonQuery() > 0 ? true : false;
                if (Serialize) SerializeRow(tableName);
                if (reload) Reload(tableName);
                return b;
            }
            catch (Exception) { throw; }
        }

        public bool UpdateRow(string tableName, int id, string data) {
            if (!con.Ping()) return false;
            try {
                if (CheckId(tableName, id)) { MessageBox.Show($"{id} from {tableName} Not Found !\nreturning."); return false; }
                DeleteRow(tableName, id, false, false);
                InsertRow(tableName, data, true);
                return true;
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// To Reload the specified table's Rows.
        /// </summary>
        public DataTable Reload(string tableName) {
            if (!con.Ping()) return null;
            try {
                cmd.CommandText = $"Select * from {tableName} order by id asc";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// To Check if id is exist in specified table.
        /// </summary>
        private bool CheckId(string tableName, int id) {
            if (!con.Ping()) return false;
            try { 
                cmd.CommandText = $"Select {id} from {tableName}";
                dataReader = cmd.ExecuteReader();
                bool b = false;

                while (dataReader.Read())
                    if (dataReader.GetInt32("id") == id) { b = true; break; }
                dataReader.Close();
                return b;
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// To Serialize all existing Rows.
        /// </summary>
        private void SerializeRow(string tableName) {
            if (!con.Ping()) return;
            try {
                cmd.CommandText = $"Select id from {tableName}";
                dataReader = cmd.ExecuteReader();
                int id = 0;
                while (dataReader.Read()) {
                    cmd.CommandText = $"Update {tableName} set id = " + (++id) + " where id = " + dataReader.GetInt32("id");
                    cmd.ExecuteNonQuery();
                }
                dataReader.Close();

            }
            catch (Exception) { throw; }
        }

    }
}
