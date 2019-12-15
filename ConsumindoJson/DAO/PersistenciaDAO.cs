using ConsumindoJson.Conexao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ConsumindoJson.PersistenciaDAO
{
    public class PersistenciaDAO
    {
        private SqlConnection conn = null;
        private SqlCommand comand = null;
        private SqlDataReader result = null;
        private String xCampos;
        private String xValores;
        private int CompareInt;
        private float CompareFloat;
        private String CompareString;
        private DateTime CompareData;
 

        // Função para executar qualquer query no banco de dados, qualquer query que não precise de retorno
        public bool inserirQuery(String query)// exemplo insert, update, create table e etc.
        {
            try
            {
                conn = new ConexaoDB().abrirConexao(); // abrindo conexao com o banco de dados

                if (conn != null) // verificando se conexao não é nula
                {
                    comand = new SqlCommand(query, conn); // preenchendo variavel de execução
                    comand.ExecuteNonQuery(); // executando comando
                    conn.Close(); // fechando conexao
                    return true;//retorna true;
                }
            }
            catch (Exception ex)
            {

            }

            return false; // retorna false caso a transação apresente erro
        }

//-----------------Função para criar a query de inserção----------------------------------

        public bool criarInsercao(Dictionary<String, String> mapaDeDados, String table) // Recebe um mapa de dados com todos os campos recebidos no Json
                                                                                        // e o nome da tabela onde serão gravados!
        {
            bool resp = false;
            
            String sql = "select top 1  * from " + table; // criar um select com a variavel tabela que está chegando!!!
            try
            {
                conn = new ConexaoDB().abrirConexao(); // criar conexao com o banco
                if (conn != null)// verifica se a conexao não é nula
                {
                    comand = new SqlCommand(sql, conn); // cria o comando que vai ser rodado no banco de dados
                    result = comand.ExecuteReader(); // executa o comando no banco de dados e recebe a resposta
                    List<String> campos = new List<String>(); //instancia uma lista onde serão guardados os nomes dos campos do banco
                    List<String> valores = new List<String>(); //instancia uma lista onde serão guardados os Valores dos campos do banco
                    for (int i = 0; i < result.FieldCount; i++) // enquanto i for menor que a quantidade de colunas da tabela o loop continua
                    {
 
                        if (mapaDeDados.ContainsKey(result.GetName(i)) ) // verificar se o nome da coluna recebida do banco de dados existe no mapa de dados
                        {
                            Console.WriteLine(i);
                            Console.WriteLine(result.GetName(i));
                            if (result.GetFieldType(i) == CompareInt.GetType()) // verificando se o tipo do campo é igual a variavel 
                            {                                                   // a variavel CompareInt é do tipo int
                                if (i + 1 < result.FieldCount) //verificando se é o ultima coluna da tabela, pois caso seja não precisa concatenar a virgula, para criação da query
                                {
                                    campos.Add(result.GetName(i) + ",");
                                    valores.Add(mapaDeDados[result.GetName(i)] + ",");
                                }
                                else
                                {
                                    campos.Add(result.GetName(i)); //adicionando o nome do campo na lista
                                    valores.Add(mapaDeDados[result.GetName(i)]);// adionando o valor do campo na lista
                                }

                            }
                            else if (result.GetFieldType(i) == CompareFloat.GetType())// verificando se o tipo do campo é igual a variavel 
                            {                                                               // a variavel CompareInt é do tipo Float
                                if (i + 1 < result.FieldCount)//verificando se é o ultima coluna da tabela, pois caso seja não precisa concatenar a virgula, para criação da query
                                {
                                    campos.Add(result.GetName(i) + ",");
                                    valores.Add(mapaDeDados[result.GetName(i)] + ",");
                                }
                                else
                                {
                                    campos.Add(result.GetName(i));
                                    valores.Add(mapaDeDados[result.GetName(i)]);
                                }
                            }
                            else if (Object.Equals(result.GetFieldType(i), CompareData.GetType()))// verificando se o tipo do campo é igual a variavel 
                                                                                                  // a variavel CompareInt é do tipo Date
                            {
                                if (i + 1 < result.FieldCount)
                                {
                                    campos.Add(result.GetName(i) + ",");
                                    valores.Add( mapaDeDados[result.GetName(i)] + ",");
                                }
                                else
                                {
                                    campos.Add(result.GetName(i));
                                    valores.Add(mapaDeDados[result.GetName(i)]);
                                }
                            }
                            else // caso não se encaixe em outro tipo é pq valor é String
                            {
                                if (i + 1 < result.FieldCount)
                                {
                                    campos.Add(result.GetName(i) + ",");
                                    valores.Add("\'" +mapaDeDados[result.GetName(i)] + "\',"); // adicionando o valor na lista
                            
                                }
                                else
                                {
                                    campos.Add(result.GetName(i));
                                    valores.Add("\'" + mapaDeDados[result.GetName(i)] + "\'");// adicionando o valor na lista
  
                                }
                            }
                        }
                       
                    }
                    xCampos = string.Concat(campos); // concatenando todos os campos e passando para variavel xCampos resultao -> text1,text2,text3,...
                    xValores = string.Concat(valores);// concatenando todos os valorese passando para variavel xValores resultao ->
                    String query = "insert into " + table + "(" + xCampos + ") values(" + xValores + ")"; // montando a string que deve ser inserida no banco
                    conn.Close(); // fechando a conexao com o banco de dados

                    if (verificarExistencia(table))// chamando a função 
                    {
                        if (inserirQuery(query))
                        {
                            resp = true; // caso verdadeira retorna a true -> verdadeiro
                        }
                        else
                        {
                            resp = false;
                        }
                    }
                    else
                    {
                        if (criarTabela(table, mapaDeDados)) // chama a função criar tabela e verifica se a transação foi bem sucedida!
                        {// caso tenho sido bem sucedida
                            if (inserirQuery(query))//chama a função de inserir query passando a query como parametro
                            {
                                resp = true; //retorna verdadeiro caso a inserção seja concluida com sucesso
                            }
                            else
                            {
                                resp = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            conn.Close(); // fecha conexaõ com banco de dados
            return resp; // retorna falso, caso a inserção não seja bem sucedida
        }


        // função para verificar existencia de uma tabela, retorna true se existir
        public bool verificarExistencia(String tabela)
        {
            try { 
            String sql = "select top 1 * from " + tabela; // seleciona a tabela à ser verificada!
            conn = new ConexaoDB().abrirConexao();  // abre conexao com o banco de dados!

            if (conn != null) // se a conexao não for nula
            {
                comand = new SqlCommand(sql, conn);  // seta o comando que será enviado para o banco junto com a conexao
                result = (SqlDataReader)comand.ExecuteReader(); // executa o comando e recebe uma resposta
                if (result.FieldCount > 0) //se tiver pelo menos uma coluna, a tabela existe, caso contrario cai no try e retorna falso
                {
                    return true; // retorna true caso verdadeiro
                    
                }    
            }
            }catch(Exception ex)
            {

            }
            conn.Close(); //fecha conexao
            return false; // retorna falso caso dê errado
        }


        //---------------------------Função para criar a tabela --------------------------------------

        public bool criarTabela(String tabela, Dictionary<String, String> mapaDeDados)
        {
            String sql; // criar um select com a variavel tabela que está chegando!!!
            try
            {
                int i = 0;
                List<String> campos = new List<String>(); //instancia uma lista onde serão guardados os nomes dos campos do banco
                foreach (KeyValuePair<String, String> mapa in mapaDeDados) // enquanto i for menor que a quantidade de colunas da tabela o loop continua
                {
                    campos.Add(mapa.Key); // adiciona a nome guardado na chave a lista campos
                    campos.Add(" varchar(max)"); // adiciona o tipo para criação do campos na tebela
                    if (i + 1 < mapaDeDados.Count)
                    {
                        campos.Add(","); // adiciona a virgula para criar a query
                    }

                    i++;
                }
                String xCampos = string.Concat(campos); //  concatena todos os campos
                sql = "create table " + tabela + " (" + // cria a string para criação das tabelas
                    xCampos + ")";

                if (inserirQuery(sql)) //chama função inserir uma nova tabela verficando se a inserção deu certo
                {
                    if(criarInsercao(mapaDeDados, tabela)) // criando string para inserir informações na tabela
                    {
                        return true; // retorna verdadeiro
                    }
                }
              
               
            }
            catch (Exception ex)
            {

            }
            return false; // retorna falso, caso a inserção não seja bem sucedida
        }

    }
}
