using System.Collections.Generic;
using System.Linq;
namespace Blog.Models
{
    public class ComentarioService
    {
        public int CreateComentario(Comentario coment){
            using(var context = new BlogContext()){

                context.Add(coment);
                context.SaveChanges();
                return coment.Id;
            }
        }

        public List<Comentario> GetComentarios(int idPost){
            using(var context = new BlogContext()){
                    return context.Comentarios.Where(c => c.PostId == idPost).ToList();
            }
        }

    }
}