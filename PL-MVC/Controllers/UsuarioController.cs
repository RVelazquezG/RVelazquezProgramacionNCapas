using BL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();
            usuario.Rol = new ML.Rol();

            ML.Result resultRol = BL.Rol.GetAllEF();
            result = BL.Usuario.GetAllEF(usuario);


            if (result.Correct)
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
                return View();
            }
        }


        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {

            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultPais = BL.Pais.GetAll();
            ML.Result resultRol = BL.Rol.GetAllEF();  


            if (IdUsuario == null)
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                if (result.Correct)
                {

                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                    ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;

                    ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;

                    ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.IdColonia);
                    usuario.Direccion.Colonia.Colonias = resultColonias.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el usuario seleccionado";
                }

                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            //HttpPostedFileBase file = Request.Files["ImagenData"];

            //if(file.ContentLength > 0)
            //{
            //    usuario.Imagen = ConvertToBytes(file);
            //}

            if (usuario.IdUsuario == 0)
            {
                //add
                //ml.result = agregar
                ML.Result result = BL.Usuario.AddEF(usuario);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
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
                //update
                //ml.result = update
                //if
                ML.Result result = BL.Usuario.UpdateEF(usuario);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    ViewBag.Message = "El usuario seleccionado ha sido actualizado con exito";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el usuario seleccionado";
                    return PartialView("Modal");
                }
            }

        }


        [HttpGet]
        public ActionResult Delete(int? IdUsuario)
        {

            ML.Result result = new ML.Result();


            if (IdUsuario == null)
            {
                ViewBag.Message = "Ocurrio un error al eliminar el usuario seleccionado";
            }
            else
            {
                result = BL.Usuario.DeleteEF(IdUsuario.Value);
                ViewBag.Message = "El usuario seleccionado ha sido eliminado";
            }
            return PartialView("Modal");
        }
         
         public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }

        public JsonResult CambiarStatus(ML.Usuario usuario)
        {
            var result = BL.Usuario.ChangeStatus(usuario);

            return Json(result.Object);
        }
    }

 }