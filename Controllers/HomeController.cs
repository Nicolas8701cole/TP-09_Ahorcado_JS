using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04___Jugando_al_Ahorcado.Models;

namespace TP04___Jugando_al_Ahorcado.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Contenido.iniciarJuego();
        return View("Index");
    }
    public IActionResult Juego()
    {
        ViewBag.Palabra = Contenido.DicPalabras[Contenido.PalabraActualId].palabra;
        return View("Juego");
    }
    public IActionResult Resultado(bool gano, int intentos)
    {
        ViewBag.Gano = gano;
        ViewBag.Intentos = intentos;
        ViewBag.PalabraCorrecta = Contenido.DicPalabras[Contenido.PalabraActualId].palabra;
        return View();
    }

    public IActionResult ArriesgarLetra(string letra)
    {
        if (letra != null && letra != "")
        {
            char caracter = letra.ToLower()[0];  //Lo pasa a minusculas para evitar problemas

            if (Contenido.DicLetrasUsadas.ContainsValue(caracter) == false)
            {
                Contenido.DicLetrasUsadas.Add(Contenido.DicLetrasUsadas.Count, caracter);

                var palabra = Contenido.DicPalabras[Contenido.PalabraActualId];
                bool acerto = palabra.arriesgarLetra(caracter);

                if (acerto == false)
                {
                    Contenido.sumarIntentos();
                    // Si se oasa del siguiente límite pierde
                    const int lím = 10;
                    if (Contenido.intentos >= lím)
                    {
                        return RedirectToAction("Resultado", new { gano = false, intentos = Contenido.intentos });
                    }

                }
                if (Contenido.obtenerPalabraMedioEcha().Contains("_") == false)
                {
                    return RedirectToAction("Resultado", new { gano = true, intentos = Contenido.intentos });
                }
            }
        }

        return RedirectToAction("Juego");
    }

    public IActionResult ArriesgarPalabra(string palabra)
    {
        if (palabra != null && palabra != "")
        {
            palabra = palabra.ToLower(); //Lo digo arriba
            var palabraCorrecta = Contenido.DicPalabras[Contenido.PalabraActualId];
            bool acerto = palabraCorrecta.arriesgarPalabra(palabra);

            if (acerto)
            {
                return RedirectToAction("Resultado", new { gano = true, intentos = Contenido.intentos });
            }
            else
            {
                Contenido.sumarIntentos();
                return RedirectToAction("Resultado", new { gano = false, intentos = Contenido.intentos });
            }
        }

        return RedirectToAction("Juego");
    }

    //public IActionResult Resultado(bool gano)
    //{
    //Añadir que me traigan un string palabra que sea el resultado correcto y eso mandarlo como ViewBag.PalabraCorrecta
    //ViewBag.Gano = gano;
    //ViewBag.PalabraCorrecta = Contenido.DicPalabras[Contenido.PalabraActualId].palabra; // Lo mete en un ""
    //ViewBag.Intentos = Contenido.intentos;
    //return View("resultado");
    //}

    private IActionResult MostrarEstadoJuego()
    {
        ViewBag.PalabraParcial = Contenido.obtenerPalabraMedioEcha();
        ViewBag.LetrasUsadas = Contenido.DicLetrasUsadas.Values;
        return View("Juego");
    }
}
