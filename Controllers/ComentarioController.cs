using System;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ComentarioController:Controller
    {
        [HttpPost]
public IActionResult Cadastrar(Comentario c)
{
ComentarioService service = new ComentarioService();
c.Data = DateTime.Now; //data do comentário é o momento em que ele foi cadastrado
service.CreateComentario(c);
return RedirectToAction("Index", "Home");
}
        
    }
}