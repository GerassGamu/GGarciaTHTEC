using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Profesor
    {
        public static ML.Result AddEF(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.GGarciaTHTECEntities context = new DL.GGarciaTHTECEntities())
                {
                    var query = context.ProfesorAdd(profesor.Nombre,profesor.ApellidoPaterno,profesor.ApellidoMaterno,profesor.Sueldo );


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el Profesor";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.GGarciaTHTECEntities context = new DL.GGarciaTHTECEntities())
                {
                    var query = context.ProfesorUpdate(profesor.IdProfesor, profesor.Nombre,profesor.ApellidoPaterno,profesor.ApellidoMaterno,profesor.Sueldo);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el Profesor";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result DeleteEF(ML.Profesor profesor)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.GGarciaTHTECEntities context = new DL.GGarciaTHTECEntities())
                {
                    var query = context.ProfesorDelete(profesor.IdProfesor);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el Profesor";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.GGarciaTHTECEntities context = new DL.GGarciaTHTECEntities())
                {

                    var profesores = context.ProfesorGetAll().ToList();

                    result.Objects = new List<object>();

                    if (profesores != null)
                    {
                        foreach (var objProfesor in profesores)
                        {

                            //Instancia de la Clase
                            ML.Profesor profesor = new ML.Profesor();
                            profesor.IdProfesor = objProfesor.IdProfesor;
                            profesor.Nombre = objProfesor.Nombre;
                            profesor.ApellidoPaterno = objProfesor.ApellidoPaterno;
                            profesor.ApellidoMaterno = objProfesor.ApellidoMaterno;
                            profesor.Sueldo = (decimal)objProfesor.Sueldo;

                            
                            

                            result.Objects.Add(profesor);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdProfesor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.GGarciaTHTECEntities context = new DL.GGarciaTHTECEntities())
                {

                    var objProfesor = context.ProfesorGetById(IdProfesor).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objProfesor != null)
                    {



                        //Instancia de la Clase
                        ML.Profesor profesor = new ML.Profesor();
                        profesor.IdProfesor = objProfesor.IdProfesor;
                        profesor.Nombre = objProfesor.Nombre;
                        profesor.ApellidoPaterno = objProfesor.ApellidoPaterno;
                        profesor.ApellidoMaterno = objProfesor.ApellidoMaterno;
                        profesor.Sueldo = (decimal)objProfesor.Sueldo;


                        ///Linea oara igualar el resultado de mi consulta
                        result.Object = profesor;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Profesor";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
