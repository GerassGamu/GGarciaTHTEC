using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult GetAll()
        {
            ML.Profesor profesor = new ML.Profesor();

            ML.Result result = BL.Profesor.GetAllEF();

            if (result.Correct)
            {
                profesor.Profesores = result.Objects.ToList();
                return View(profesor);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("Modal");
            }


        }

        /////
        [HttpGet]
        public ActionResult Form(int? IdProfesor)
        {
            //Instancia de clase Usuario
            ML.Profesor profesor = new ML.Profesor();
       
            if (IdProfesor == null)//ADD
            {
                return View(profesor);
            }
            else //Update Aseguradora
            {
                ML.Result result = BL.Profesor.GetByIdEF(IdProfesor.Value);

                if (result.Correct)
                {
                    // ML.Aseguradora aseguradora = new ML.Aseguradora();
                    profesor = ((ML.Profesor)result.Object);

                  
                    return View(profesor);

                }
                else
                {
                    ViewBag.Message = "No se pudo realizar la consulta" + result.ErrorMessage;
                    return PartialView("Modal");
                }

            }
        }
        [HttpPost]
        public ActionResult Form(ML.Profesor profesor)
        {
            if (profesor.IdProfesor == 0)
            {
                ML.Result result = BL.Profesor.AddEF(profesor);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente un Profesor";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al insertar el Profesor" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Profesor.UpdateEF(profesor);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizó correctamente un Profesor";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Messge = "No se actualizó correctamente un Profesor";
                    return PartialView("Modal");
                }
            }

        }

        [HttpGet]
        public ActionResult Delete(int IdProfesor)
        {
            ML.Profesor profesor = new ML.Profesor();
            profesor.IdProfesor = IdProfesor;
            var result = BL.Profesor.DeleteEF(profesor);

            if (result.Correct)
            {

                ViewBag.Message = "El profesor se ha eliminado correctamente";


            }
            else
            {
                ViewBag.Message = "Error al eliminar  Profesor";



            }
            return PartialView("Modal");
        }
    }
}

