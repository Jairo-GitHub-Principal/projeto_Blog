        using Microsoft.EntityFrameworkCore;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        
        
        namespace Blog.Models
        {
        
        
        
        public class PostService
        {
        
        public int CreatePost(Post novoPost)
        {
        using (var context = new BlogContext())
        {
        context.Add(novoPost);
        context.SaveChanges();
        return novoPost.Id;
        }
        
        }

        public ICollection<Post> GetPosts(string q, string ordem)
            {
            using (var context = new BlogContext())
            {
                IQueryable<Post> consulta = context.Posts.Where(p => p.Titulo.Contains(q,StringComparison.OrdinalIgnoreCase));
                if(ordem == "t"){
                    consulta = consulta.OrderBy(p => p.Titulo);
                }else{
                    consulta = consulta.OrderBy(p => p.Data);
                }

            
            return consulta.ToList();
            }
            }

            public ICollection<Post> GetPostsFull(int page, int size){ // parametros aqui informado serve para paginação
                using(var context = new BlogContext()){
                    int pular = (page - 1) * size;
                    IQueryable<Post> consulta = context.Posts.Include(p=> p.Comentarios).OrderByDescending(p=>p.Data);
                    return consulta.Skip(pular).Take(size).ToList();// Skip e take possibilita a paginação
                }
            }

            public Post GetPostDetail(int id) // buscar por Id
            {
                using(BlogContext bc = new BlogContext()){
                    Post registro = bc.Posts.Where(p => p.Id == id).SingleOrDefault();
                    return registro;  
                };
               
            }

            public void atualizarPost(Post post){
                using(BlogContext bc = new BlogContext()){
                     
                     Post registro = bc.Posts.Find(post.Id);

                     if(registro != null){
                        registro.Texto = post.Texto;
                        registro.Titulo = post.Titulo;
                        registro.Data = post.Data;
                        bc.SaveChanges();
                     }
                }

            }

            public void DeletePost(int id){
                using(var context = new BlogContext()){
                 
                 Post registro = context.Posts.Find(id);
                 context.Posts.Remove(registro);
                 context.SaveChanges();   
                }
            }

            public int CountPost(){ // conta os posts existentes 
                using(var context = new BlogContext()){
                    return context.Posts.Count();
                }
            }
        }
        }