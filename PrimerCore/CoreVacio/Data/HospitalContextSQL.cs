
using CoreVacio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Data
{
    public class HospitalContextSQL : DbContext, IHospitalContext
    {
        public HospitalContextSQL(DbContextOptions options)
            : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
