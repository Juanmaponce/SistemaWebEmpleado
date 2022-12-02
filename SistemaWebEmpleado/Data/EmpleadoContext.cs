using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;
using System;
using System.Data;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoContext : DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options)
            : base(options)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }

    }
}

