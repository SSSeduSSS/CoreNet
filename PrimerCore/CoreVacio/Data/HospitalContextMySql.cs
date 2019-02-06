using CoreVacio.Models;
using Microsoft.EntityFrameworkCore;
using ProyectoCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreVacio.Data
{
    public class HospitalContextMySql :DbContext, IHospitalContext
    {
        public HospitalContextMySql(DbContextOptions options) :base (options){ }
        public DbSet<Departamento> Departamentos { get ; set ; }
    }
}
