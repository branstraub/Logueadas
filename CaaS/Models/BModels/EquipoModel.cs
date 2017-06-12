using System;
using System.Data.Entity;

namespace CaaS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class EquipoModel
    {
        public string Id { get; set; }
        public string EquipoNombre { get; set; }
        public string Codigo { get; set; }
        public int Puntaje { get; set; }

        public int PuntajeHtml { get; set; }
    }

}