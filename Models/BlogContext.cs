using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
public class BlogContext: DbContext
{
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
optionsBuilder.UseMySql("Server=localhost;DataBase=Blog;Uid=root;");
}


public DbSet<Post> Posts { get; set; }
public DbSet<Comentario> Comentarios { get; set; }
}
}