using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            //result = BL.Aseguradora.GetAllEF();
            ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();
            var result = context.GetAll();

            if (result.Correct)
            {
             
                aseguradora.Aseguradoras = result.Objects.ToList();
                return View(aseguradora);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdAseguradora)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario(); 

            usuario.Rol = new ML.Rol();
            ML.Result resultRol = BL.Rol.GetAllEF();
            ML.Result resultUsuario = BL.Usuario.GetAllEF(usuario);


            if (IdAseguradora == null)
            {
                aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                return View(aseguradora);
            }
            else
            {
                //ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora.Value);
                ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();
                var result = context.GetById(IdAseguradora.Value);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el usuario seleccionado";
                }

                return View(aseguradora);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {

            if (aseguradora.IdAseguradora == 0)
            {
                

                ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();
                var result = context.Add(aseguradora);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    ViewBag.Message = " El usuario ha sido agregado con exito";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar el usuario seleccionado";
                    return PartialView("Modal");
                }

            }
            else
            {
                
                //ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
                ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();
                var result = context.Update(aseguradora);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    ViewBag.Message = "La aseguradora seleccionada ha sido actualizada con exito";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar la aseguradora seleccionada";
                    return PartialView("Modal");
                }
            }

        }


        [HttpGet]
        public ActionResult Delete(int? IdAseguradora)
        {

            if (IdAseguradora == null)
            {
                ViewBag.Message = "Ocurrio un error al eliminar el usuario seleccionado";
            }
            else
            {
                //result = BL.Aseguradora.DeleteEF(IdAseguradora.Value);
                ServiceAseguradora.AseguradoraClient context = new ServiceAseguradora.AseguradoraClient();
                var result = context.Delete(IdAseguradora.Value);
                ViewBag.Message = "El usuario seleccionado ha sido eliminado";
            }
            return PartialView("Modal");
        }

    }
}
