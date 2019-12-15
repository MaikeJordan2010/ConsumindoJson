using System;
using System.Data.SqlClient;

namespace ConsumindoJson.Conexao
{
    public class ConexaoDB
    {
        private String user = ""; // declara o usuario do BD
        private String password = ""; // declara senha do usuario no BD
        private String database = "";         // declara qual banco de dados
        private String server = ""; // declara o  endereço do banco
       

        public SqlConnection abrirConexao() // metodo para abrir conexao no banco/ retorna a conexao aberta
        {
            SqlConnection conn = null; // instancia do tipo Connection
            try
            {
                conn = new SqlConnection("server=" + server + ";database=" + database + ";Uid=" + user + ";pwd=" + password);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível se conectar ao banco de dados!");
            }
            return conn;
        }

    }
}
