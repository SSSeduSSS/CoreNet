
using CoreVacio.Models;
using ProyectoCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreVacio.Repositories
{
    public class RepositoryHospital
    {
        IHospitalContext context;


        //El repositorio usa siempre inyeccion de dependencias
        public RepositoryHospital(IHospitalContext context)
        {
            this.context = context;
        }
        public List<Departamento> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }
    }    
}
