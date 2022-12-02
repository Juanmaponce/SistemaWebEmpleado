using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoContext _context;

        public EmpleadoController(EmpleadoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Empleados.ToList());
        }

        [HttpGet]
        [ActionName("Details")]
        public IActionResult Details(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }


            return View("Details", empleado);
        }


        [HttpGet]
        [ActionName("ListarPorTitulo")]
        public IActionResult ListarPorTitulo(string titulo)
        {
            List<Empleado> lista = (from e in _context.Empleados
                                    where e.Titulo == titulo
                                    select e).ToList();
            return View("Index", lista);
        }

        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);
        }

        // POST: /Person/Create
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", empleado);
            }
            else
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View("Edit", empleado);

        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {

            _context.Entry(empleado).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var person = _context.Empleados.SingleOrDefault(m => m.Id == id);
            _context.Empleados.Remove(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
