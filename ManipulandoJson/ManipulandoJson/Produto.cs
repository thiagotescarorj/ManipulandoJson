using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManipulandoJson
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public decimal PrecoVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal PrecoCusto { get; set; }
        public string DescricaoEtiqueta { get; set; }

        public Produto(int codigo, string nome, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            PrecoVenda = preco;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nome} - {PrecoVenda}";
        }
    }
}
