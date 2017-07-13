using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CaaS.Interfaces;
using CaaS.Models;
using CaaS.Models.BVModels;

namespace CaaS.DataClassImplementations
{
    public class EquiposRepository : IEquiposRepository
    {
        public IEnumerable<EquipoModel> GetEquipos()
        {
            using (var context = new ApplicationDbContext())
            {
                var equipos = context.Equipos.ToArray();
                return equipos;
            }
        }

        public void CreateEquipo(EquipoModel equipo)
        {

            using (var context = new ApplicationDbContext())
            {
                context.Equipos.Add(equipo);
                context.SaveChanges();
            }
        }

        public EquipoModel GetEquipo(string codigo)
        {
            using (var context = new ApplicationDbContext())
            {
                var equipo = context.Equipos.FirstOrDefault(x => x.Codigo == codigo);
                return equipo;
            }
        }

        public void UpdateEquipo(EquipoModel equipo)
        {
            EquipoModel equipoEntity;

            using (var context = new ApplicationDbContext())
            {
                equipoEntity = context.Equipos.FirstOrDefault(x => x.Codigo == equipo.Codigo);
            }

            equipoEntity.Puntaje = equipo.Puntaje;
            equipoEntity.PuntajeHtml = equipo.PuntajeHtml;
          

            using (var context = new ApplicationDbContext())
            {
                context.Entry(equipoEntity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteEquipo(string id)
        {

            

            using (var context = new ApplicationDbContext())
            {
                var equiposEntity = context.Equipos.FirstOrDefault(x => x.Id == id);
                context.Entry(equiposEntity).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }
    }

    public static class EquiposRepositoryExtensions
    {
        public static EquiposViewModel EquiposToViewModel(this EquipoModel model)
        {

            return new EquiposViewModel
            {
                Id = model.Id,
                Puntaje = model.Puntaje,
                Nombre = model.EquipoNombre,
                Codigo = model.Codigo,
                PuntajeHtml = model.PuntajeHtml
            };
        }

        public static EquiposViewModel EquiposToViewModelPuntaje(this EquipoModel model)
        {

            var equipo = new EquiposViewModel
            {
                Id = model.Id,
                Puntaje = model.Puntaje,
                Nombre = model.EquipoNombre,
                Codigo = model.Codigo,
                PuntajeHtml = model.PuntajeHtml
            };

            if (equipo.PuntajeHtml != 0)
            {
                equipo.Puntaje = equipo.Puntaje * equipo.PuntajeHtml;
            }

            return equipo;
            
        }

    }
}