using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaaS.Models.BVModels
{
    public class EquiposViewCreateModel
    {

    [Display(Name = "Nombre del Equipo")]
    public string Nombre { get; set; }

    }

    public class EquiposViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "Nombre del Equipo")]
        public string Nombre { get; set; }

        [Display(Name = "Puntaje")]
        public int Puntaje { get; set; }

        [Display(Name = "Puntaje HTML")]
        public int PuntajeHtml { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo { get; set; }

    }

   
}