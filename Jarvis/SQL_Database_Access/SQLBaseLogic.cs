using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Database_Access
{
    public abstract class SQLBaseLogic
    {

        private string _connectionstring = "Data Source=DESKTOP-T3GHSNR;Initial Catalog=NLP_Statistic_db;Integrated Security=True";
        public string connectionString
        {
            get
            {
                return _connectionstring;
            }
            set
            {
                _connectionstring = value;
            }
        }
        private SqlConnection _con;
        public SqlConnection con
        {
            get
            {
                if (_con == null)
                {
                    _con = new SqlConnection(connectionString);
                }
                return _con;
            }
            set
            {
                _con = value;

            }
        }
    }
}
