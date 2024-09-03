using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DataAccess
    {
        private SqlConnection _connection;

        private SqlCommand _command;

        private SqlDataReader _reader;

        public SqlDataReader Reader
        {
            get { return _reader; }
        }

        public DataAccess()
        {
            _connection = new SqlConnection("server=.\\SQLEXPRESS; database = CATALOGO_P3_DB; integrated security = true");
            _command = new SqlCommand();
        }

        public void setQuery(String query)
        {
            _command.CommandType = System.Data.CommandType.Text;
            _command.CommandText = query;
        }

        public void executeRead()
        { 
            _command.Connection = _connection;
            try
            { 
                _connection.Open();
                _reader = _command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }

        }


        public void setParameter(string name, object value)
        { 
            _command.Parameters.AddWithValue(name, value);
        }

        public void closeConnection()
        {
            if (_reader != null)
            {
                _reader.Close();
                _connection.Close();
            }
        }
    }
}
