using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyectos; // instansiación de clase RepositorioProyectos, debo modificar en Program

        public HomeController(IRepositorioProyectos repositorioProyectos)
        {
            this.repositorioProyectos = repositorioProyectos;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos 
            };
            return View(modelo); // Recibe como parámetro el modelo
        }

        public IActionResult Contacto()
        {
            return View();
        }

        // HTTP GET es para solicitar datos del servidor
        // HTTP POST es para enviar datos al servidor para el procesamiento
        // Si no se especifica como aqui abajo, por defecto es GET
        [HttpPost]
        public IActionResult Contacto(ContactoViewModel contactoViewModel) 
        {
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}