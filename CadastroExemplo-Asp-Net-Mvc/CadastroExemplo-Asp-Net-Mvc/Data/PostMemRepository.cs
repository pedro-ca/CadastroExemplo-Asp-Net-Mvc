using CadastroExemplo_Asp_Net_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroExemplo_Asp_Net_Mvc.Data
{
    public class PostMemRepository
    {
        private static List<Post> posts = new List<Post>();
        private static int Contador = 1;
        static PostMemRepository()
        {
            posts = new List<Post>
            {
                new Post{Id = Contador++, Titulo = "Chamada post 1", Conteudo = "blabalbabla post 1", DataPublicacao = DateTime.Now.AddDays(-6) },
                new Post{Id = Contador++, Titulo = "Chamada post 2", Conteudo = "blabalbabla post 2", DataPublicacao = DateTime.Now.AddDays(-2) },
                new Post{Id = Contador++, Titulo = "Chamada post 3", Conteudo = "blabalbabla post 3", DataPublicacao = DateTime.Now.AddDays(-10) },
            };
        }

        public static List<Post> SelecionarTodos()
        {
            return posts;
        }

        public static void Adicionar(Post post)
        {
            post.Id = Contador++;
            posts.Add(post);
        }

        public static Post SelecionarPorId(int id)
        {
            return posts.FirstOrDefault(x => x.Id == id);
        }

        public static void Editar(int id, Post post)
        {
            foreach (var item in posts)
            {
                if (item.Id == id)
                {
                    item.Titulo = post.Titulo;
                    item.Conteudo = post.Conteudo;
                    item.DataPublicacao = post.DataPublicacao;
                    break;
                }
            }
        }

        public static void Excluir(int id)
        {
            posts.Remove(SelecionarPorId(id));
        }
    }
}
