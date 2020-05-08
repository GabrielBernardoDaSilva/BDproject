using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioADO 
{
    public class BD : IDisposable
    {
        private readonly SqlConnection conexao;
        public BD()
        {
            conexao = new SqlConnection(@"data source=DESKTOP-BHS1VEV\SQLEXPRESS;Integrated Security=SSPI; Initial Catalog=ExemploBD;");
            conexao.Open();
        }

        public void excutaComando(string strQuery)
        {
            var cmd = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            cmd.ExecuteNonQuery();

        }

        public SqlDataReader executaDataReader(string strQuery)
        {
            SqlCommand cmdSelect = new SqlCommand(strQuery, conexao);
            return cmdSelect.ExecuteReader();
        }

        public void Dispose()
        {
            try
            {
                if (conexao.State == ConnectionState.Open)
                    this.conexao.Close();
            }
            catch
            {

            }

        }
    }



}
