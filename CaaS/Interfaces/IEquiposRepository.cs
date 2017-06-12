using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaaS.Models;

namespace CaaS.Interfaces
{
    public interface IEquiposRepository
    {
        IEnumerable<EquipoModel> GetEquipos();

        void CreateEquipo(EquipoModel equipo);

        EquipoModel GetEquipo(string id);

        void UpdateEquipo(EquipoModel equipo);

        void DeleteEquipo(string id);
    }
}
