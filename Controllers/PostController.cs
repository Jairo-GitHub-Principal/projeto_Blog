using Blog.Models;
using Microsoft.AspNetCore.Mvc;
namespace Blog.Controllers
{
public class PostController : Controller
{
public IActionResult Cadastro()
{
return View();
} [
HttpPost]
public IActionResult Cadastro(Post novoPost)

{
    PostService service = new PostService();
    
    if(novoPost.Id != 0){
          service.atualizarPost(novoPost);
          
          ViewData["msg"]="Atualização realizado com sucesso";
        
        return RedirectToAction("Lista");
        }else{
    int novoId = service.CreatePost(novoPost);
    
    if(novoId != 0){
        ViewData["msg"]="cadastro realizado com sucesso";
    }else{
        ViewData["msg"]="falha no cadastro";
    }
                return RedirectToAction("Lista");
        }
        
}
public IActionResult editar(int id){
    PostService ps = new PostService();
    Post post = ps.GetPostDetail(id);
    //return View( ps.GetPostDetail(id));
    return View("Cadastro", post);
   
}

/* o codigo abaixo foi anulado, e a ação de atualizção agora 
vai compartilhar do  mesmo codigo da iaction cadastrar, e a view de cadastro 
economizando recurso computacional tanto no back end quanto no front and , 
[HttpPost]  
public IActionResult editar(Post post){
    PostService ps = new PostService();
    ps.atualizarPost(post);
     
     return RedirectToAction("Lista");
}
*/ 


public IActionResult Lista(string ordem, string q)
{
PostService service = new PostService();
        if(q == null){
        q = string.Empty;
        }

        if(ordem == null){
        ordem = "t";
        }
return View(service.GetPosts(q, ordem));
}




public IActionResult excluir(int id){
 PostService ps = new PostService();
Post postparadeletar = ps.GetPostDetail(id);
return View(postparadeletar);

}
[HttpPost]
public IActionResult excluir(int id,string decisao){
    if(decisao == "s"){
        PostService ps = new PostService();
 ps.DeletePost(id);
    }

    return RedirectToAction("Lista");
}

}
}