using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int p = 1) // esse parametro possibilita a paginação indica o numero da pagina que sera exibida
        {
            int quantidadeDEpostsPorPaginas = 3; // quantidade de posts por paginas
            PostService ps = new PostService();
            ICollection<Post> lista = ps.GetPostsFull(p,quantidadeDEpostsPorPaginas); 

            int quantidadePosts = ps.CountPost();
            ViewData["paginas"] = (int)Math.Ceiling((double)quantidadePosts/quantidadeDEpostsPorPaginas);

            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
