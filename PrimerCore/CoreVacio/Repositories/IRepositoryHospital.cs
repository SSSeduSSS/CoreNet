
using CoreVacio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreVacio.Repositories
{
    public interface IRepositoryHospital
    {
       
        List<Departamento> GetDepartamentos();
    }
}
