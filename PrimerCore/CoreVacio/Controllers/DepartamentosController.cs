using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreVacio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreVacio.Controllers
{
    public class DepartamentosController : Controller
    {
        IRepositoryHospital repo;

        //CORE funciona con Inyeccion de dependencias
        public DepartamentosController(IRepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.GetDepartamentos());
        }
    }
}