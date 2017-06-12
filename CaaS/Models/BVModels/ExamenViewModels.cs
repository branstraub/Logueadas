using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaaS.Models.BVModels
{

    public class ExamenViewModel
    {
        [Required] 
        [Display(Name = "Codigo")]
        public string Codigo { get; set; }
        public string Respuesta1 { get; set;}
        public string Respuesta2 { get; set; }
        public string Respuesta3 { get; set; }
        public string Respuesta4 { get; set; }
        public string Respuesta5 { get; set; }
        public string Respuesta6 { get; set; }
        public string Respuesta7 { get; set; }
        public string Respuesta8 { get; set; }
        public string Respuesta9 { get; set; }
        public string Respuesta10 { get; set; }


    }


}