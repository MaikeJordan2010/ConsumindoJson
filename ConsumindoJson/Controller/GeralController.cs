using ConsumindoJson.Util;
using System;
using System.Collections.Generic;

namespace ConsumindoJson.Controller
{
    public class GeralController
    {
        private Boolean resp = false; // declara uma resposta do tipo boolean

        public bool BuscarJson(String url, String tabela)
        { 
            // função que realiza a quebra do Json e chama a gravação
            Negocio.GeralNegocio negocio = new Negocio.GeralNegocio(); //Instacia um objeto do DAO para inserir
            Funcoes web = new Funcoes(); // instacia  uma função que realiza a busca do Json
            dynamic JsonDinamic = web.ConverterURL(url); //convert o json recebido em dynamic
            Dictionary<String, String> mapaDeDados = new Dictionary<String, String>(); //instaciando um dicionário de dados onde serão guardados os valores
            String chave, valor; // declara variaveis chave a valor
           

            
            dynamic str;

            if (JsonDinamic.items == null)
            {
                //dynamic str = "items\":" + "[\"" + JsonDinamic + "]";
                // JsonDinamic = str;
                str = JsonDinamic;
            }
            else
            {
                str = JsonDinamic.items;
            }
            
                foreach (var item in str) // passa em todo o Json buscando os todos os Items
                {
                
                if (JsonDinamic.items != null)
                {
                        do
                        {
                            try
                            {
                                foreach (var it in item) // passa em todos os campos do item
                                {
                                    chave = it.Name; // pega o nome do do campo dentro de it e passa para chave
                                    valor = it.Value; // pega o valor do campo dentro de it e passa para valor
                                    mapaDeDados.Add(chave, valor); // adiciona ao dicionario de dados
                                }
                                if (negocio.gravar(tabela, mapaDeDados))
                                {
                                    mapaDeDados.Clear();
                                    resp = true;
                                }
                                else
                                {
                                    resp = false;
                                }
                            }
                            catch (Exception e)
                            {

                            }
                        
                        } while (item.Next != null); // o loop continua enquanto ainda tiver items para grvação
                }
                else
                {
                    chave = item.Name; // pega o nome do do campo dentro de it e passa para chave
                    valor = item.Value; // pega o valor do campo dentro de it e passa para valor
                    mapaDeDados.Add(chave, valor); // adiciona ao dicionario de dados
                }
               if(mapaDeDados.Count != 0)
               {
                    if (negocio.gravar(tabela, mapaDeDados)) // chamando função para gravar dados
                    {
                        mapaDeDados.Clear(); // limpando Diconario de dados, pois caso exista um segundo item, o mapa deve estar limpo para recebe-lo
                        resp = true; // 
                    }
                }  
            }
            return resp;
        }
    }
}
