using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ConsumindoJson.Util
{
    public class Funcoes
    {
        public String Api(String url)
        {
            var requisicaoWeb = WebRequest.CreateHttp(url); // Declara variavel do tipo WebRequest passando a URL como parametro!
            requisicaoWeb.Method = "GET"; //chama o metodo da requisição, nesse caso é GET.
            requisicaoWeb.UserAgent = "RequisicaoWebDemo"; // Realiza a Requisição utilizando os parametros anteriores.
            
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd(); //
                    return objResponse.ToString(); // retorna a resposta como String

                }
            
        }

        public dynamic ConverterURL(String url)
        {
            String json = Api(url); // Chama função de busca do Json passando como parametro a url recebida

            //String dados = JsonConvert.ToString(json.ToString());
            //dynamic jsonTratado = JValue.Parse(dados);

            dynamic JsonDinamic = JsonConvert.DeserializeObject(json); // converte a resposta recebida em dynamic

            return JsonDinamic;  // retorna a resposta

        }
    }
}
