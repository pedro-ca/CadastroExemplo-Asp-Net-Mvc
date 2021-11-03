using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroExemplo_Asp_Net_Mvc.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }

        public Post()
        {
            DataPublicacao = DateTime.Now;
        }
    }
}
