using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulandoJson
{
    class Program
    {
        static void Main(string[] args)
        {
            SalvarObjetoEmArquivo();
        }

        static void ConverterObjetoParaJson()
        {
            Topico topico = new Topico
            {
                Id = 1,
                Titulo = "Erro ao publicar projeto",
                Conteudo = "Estou obtendo o erro XYZ ao publicar meu projeto na hospedagem.",
                Usuario = "joel",
                Tags = new string[3] { "ASP.NET", "C#", "Visual Studio" }
            };

            string json = JsonConvert.SerializeObject(topico);

            Console.WriteLine(json);
        }

        static void ConverterJsonParaObjeto()
        {
            string json = "{" + 
                          " 'Id':1, " + 
                          " 'Titulo':'Erro ao publicar projeto',"+
                          " 'Conteudo':'Estou obtendo o erro XYZ ao publicar meu projeto na hospedagem.',"+
                          " 'Usuario':'joel',"+
                          " 'Tags': ['ASP.NET','C#','Visual Studio']"+
                          "}";

            Topico topico = JsonConvert.DeserializeObject<Topico>(json);

            Console.WriteLine($"{topico.Id}\n{topico.Titulo}\n{topico.Conteudo}");
        }

        static void SalvarObjetoEmArquivo()
        {
            List<Produto> produtos = CriarListaDeProdutos();

            StreamWriter stream = new StreamWriter("C:\\Projetos\\Produtos.json");
            JsonTextWriter writer = new JsonTextWriter(stream);
            JsonSerializer serializer = new JsonSerializer();

            writer.Formatting = Formatting.Indented;
            
            serializer.Serialize(writer, produtos);

            stream.Close();
        }

        static void LerObjetoDeArquivo()
        {
            StreamReader stream = new StreamReader("C:\\Projetos\\Produtos.json");
            JsonTextReader reader = new JsonTextReader(stream);
            JsonSerializer serializer = new JsonSerializer();

            List<Produto> produtos = serializer.Deserialize<List<Produto>>(reader);

            foreach (var prod in produtos)
                Console.WriteLine(prod);

            stream.Close();
        }

        static List<Produto> CriarListaDeProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            for (int i = 0; i < 1000; i++)
            {
                produtos.Add(new Produto(i + 1, $"Produto {i + 1}", (i + 1) * 5)
                {
                    //DataCadastro = DateTime.Today.AddDays(-i),
                    //PrecoCusto = i * 3
                });
            }
            return produtos;
        }
    }
}
