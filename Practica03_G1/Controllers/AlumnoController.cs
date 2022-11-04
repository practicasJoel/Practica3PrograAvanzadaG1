using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica03_G1.Models;

namespace Practica03_G1.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Pelicula
        public ActionResult IndexAlumno(Practica03_G1.Models.ViewModel.AlumnoModelo model)
        {
            if (model == null)
                model = new Practica03_G1.Models.ViewModel.AlumnoModelo();

            return View(model);
        }

        public ActionResult Guardar(Practica03_G1.Models.ViewModel.AlumnoModelo model)
        {
            using (Practica03Entities db = new Practica03Entities())
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("IndexAlumno", model);
                }
                Alumno obj_alumno = new Alumno();
                obj_alumno.carnet = model.carnet;
                obj_alumno.nombre = model.nombre;
                obj_alumno.apellido = model.apellido;
                obj_alumno.genero = model.genero;
                obj_alumno.telefono = model.telefono;
                obj_alumno.email = model.email;
                obj_alumno.fecha_nacimiento = model.fecha_nacimiento;

                db.Alumno.Add(obj_alumno);
                db.SaveChanges();

                return RedirectToAction("Exito", model);
            }
        }

        public ActionResult Exito()
        {
            return View();
        }
    }
}