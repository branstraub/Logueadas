using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaaS.DataClassImplementations;
using CaaS.Interfaces;
using CaaS.Models;
using CaaS.Models.BVModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebGrease.Css.Extensions;

namespace CaaS.Controllers
{

    [RequireHttps]
    public class HomeController : Controller
    {

        private readonly IEquiposRepository _equiposRepository;

        public HomeController(IEquiposRepository lugaresRepository)
        {
            _equiposRepository = lugaresRepository;
        }

        public HomeController() : this(new EquiposRepository())
        {

        }
        //Dashborad
        public ActionResult Index()
        {
            var equipos = _equiposRepository.GetEquipos().Select(x => x.EquiposToViewModelPuntaje()).OrderByDescending(x => x.Puntaje);

            
         


            return View(equipos);
        }

        private static readonly Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }   

        public ActionResult CreateEquipo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEquipo(EquiposViewModel model)
        {

            if (_equiposRepository.GetEquipos().FirstOrDefault(x => x.EquipoNombre == model.Nombre) != null)
            {
                ModelState.AddModelError("","El nombre del equipo ya existe");
                return View();
            }

            var equipo = new EquipoModel
            {
                Codigo = RandomString(6),
                Puntaje = 0,
                EquipoNombre = model.Nombre,
                Id = Guid.NewGuid().ToString()
            };

            _equiposRepository.CreateEquipo(equipo);

            return View("VerEquipo", equipo.EquiposToViewModel());
        }

        [HttpPost]
        public ActionResult UpdateEquipo(int puntos, string codigo)
        {
            var equipo = _equiposRepository.GetEquipos().FirstOrDefault(x => x.Codigo == codigo);

            if (equipo == null) return new HttpStatusCodeResult(HttpStatusCode.NoContent);

            if (puntos > equipo.Puntaje)
            {
                equipo.Puntaje = puntos;
                _equiposRepository.UpdateEquipo(equipo);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Accepted);
        }

        public ActionResult Examen()
        {
            return View(new ExamenViewModel());
        }

        [HttpPost]
        public ActionResult Examen(ExamenViewModel model)
        {

            var cont = 0;

            if (!ModelState.IsValid)
            {
              
                return View();
            }

            if (model.Respuesta1 == "0")
                cont++;

            if (model.Respuesta2 == "0")
                cont++;

            if (model.Respuesta3 == "2")
                cont++;

            if (model.Respuesta4 == "3")
                cont++;

            if (model.Respuesta5 == "1")
                cont++;

            if (model.Respuesta6 == "0")
                cont++;

            if (model.Respuesta7 == "1")
                cont++;

            if (model.Respuesta8 == "0")
                cont++;

            if (model.Respuesta9 == "2")
                cont++;

            if (model.Respuesta10 == "0")
                cont++;

            var equipo =_equiposRepository.GetEquipos().FirstOrDefault(x => x.Codigo == model.Codigo);

            if (equipo == null)
            {
                ModelState.AddModelError("", "Revisar el codigo de equipo");
                return View();
            }

            if (equipo.PuntajeHtml != 0)
            {
                ModelState.AddModelError("", "Ya se hizo el examen");
                return View();
            }

            equipo.PuntajeHtml = cont;
            _equiposRepository.UpdateEquipo(equipo);
            //update puntaje
            return View("VerResultado", equipo.EquiposToViewModel());
        }

        public ActionResult VerResultado(EquipoModel equipo)
        {
            return View(equipo);
        }


    }
}