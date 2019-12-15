using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoJson.Negocio
{
    public class GeralNegocio
    {
        private bool resp = false;

        public bool criarInsercao(Dictionary<String,String> mapaDeDados,String tabela)
        {
            PersistenciaDAO.PersistenciaDAO persistencia = new PersistenciaDAO.PersistenciaDAO();
            return persistencia.criarInsercao(mapaDeDados, tabela);
        }

        public bool criarTabela(Dictionary<String, String> mapaDeDados, String tabela)
        {
            PersistenciaDAO.PersistenciaDAO persistencia = new PersistenciaDAO.PersistenciaDAO();
            return persistencia.criarTabela (tabela,mapaDeDados);
        }

        public bool inserirQuery(String query)
        {
            PersistenciaDAO.PersistenciaDAO persistencia = new PersistenciaDAO.PersistenciaDAO();
            return persistencia.inserirQuery(query);
        }

        public bool verificarExistencia(String tabela)
        {
            PersistenciaDAO.PersistenciaDAO persistencia = new PersistenciaDAO.PersistenciaDAO();
            return persistencia.verificarExistencia(tabela);
        }

        public bool gravar(String tabela, Dictionary<String,String> mapaDeDados)
        {
            
            if (verificarExistencia(tabela)) // chama a função de gravação passando o mapa e o nome da tabela
            {                                                   // 
                if (criarInsercao(mapaDeDados, tabela))
                {
                    Console.WriteLine("Items Gravados com sucesso!"); // mensagem de sucesso na gravação
                    resp = true; // a variavel resp recebe true -> verdadeiro
                    mapaDeDados.Clear(); // limpa o mapa de dados para evitar conflito de nomes no dicionario
                                         // uma vez que não é possivel inserir duas chaves com mesmo nome
                }
                else
                {
                    Console.WriteLine("Erro ao gravar Item!"); // mensagem de erro de gravação
                    resp = false; // a variavel resp recebe false 
                }

            }
            else
            {
                if (criarTabela(mapaDeDados, tabela))
                {
                    if (criarInsercao(mapaDeDados, tabela))
                    {
                        Console.WriteLine("Items Gravados com sucesso!"); // mensagem de sucesso na gravação
                        resp = true; // a variavel resp recebe true -> verdadeiro
                        mapaDeDados.Clear(); // limpa o mapa de dados para evitar conflito de nomes no dicionario
                                             // uma vez que não é possivel inserir duas chaves com mesmo nome
                    }
                    else
                    {
                        Console.WriteLine("Erro ao gravar Item!"); // mensagem de erro de gravação
                        resp = false; // a variavel resp recebe false 
                    }
                }
                else
                {
                    Console.WriteLine("Erro ao gravar Item!"); // mensagem de erro de gravação
                    resp = false; // a variavel resp recebe false 
                }
            }
            return resp;
        }
    }
}
