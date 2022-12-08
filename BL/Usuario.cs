using DL_EF;
using ML;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Usuario
    {
        //Add con result
        //public static ML.Result Add(ML.Aseguradora usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "INSERT INTO Aseguradora (UserName, Nombre, ApellidoPaterno, ApellidoMaterno, Email, Password, FechaNacimiento, Sexo, Telefono, Celular, CURP) VALUES (@UserName, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Email, @Password, @FechaNacimiento, @Sexo, @Telefono, @Celular, @CURP)";
        //                cmd.Connection = context;

        //                SqlParameter[] collection = new SqlParameter[11];

        //                collection[0] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
        //                collection[0].Value = usuario.Nombre;

        //                collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
        //                collection[1].Value = usuario.Nombre;

        //                collection[2] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
        //                collection[2].Value = usuario.ApellidoPaterno;

        //                collection[3] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
        //                collection[3].Value = usuario.ApellidoMaterno;

        //                collection[4] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
        //                collection[4].Value = usuario.Email;

        //                collection[5] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
        //                collection[5].Value = usuario.Password;

        //                collection[6] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.DateTime);
        //                collection[6].Value = usuario.FechaNacimiento;

        //                collection[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.VarChar);
        //                collection[7].Value = usuario.Sexo;

        //                collection[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
        //                collection[8].Value = usuario.Telefono;

        //                collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
        //                collection[9].Value = usuario.Celular;

        //                collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
        //                collection[10].Value = usuario.CURP;

        //                cmd.Parameters.AddRange(collection); // Pasarle a mi commando los parametros

        //                cmd.Connection.Open(); //Abrir la conexion

        //                int rowsAffectedAdd = cmd.ExecuteNonQuery(); //Ejecutando nuestra sentencia

        //                if (rowsAffectedAdd > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;

        //}


        public static ML.Result AddSP(ML.Usuario usuario)   //Add con Stored Procedure
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "UsuarioAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.UserName;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Password;

                        collection[6] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.FechaNacimiento;

                        collection[7] = new SqlParameter("@Sexo", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.Sexo;

                        collection[8] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("@idRol", System.Data.SqlDbType.VarChar);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection); // Pasarle a mi commando los parametros

                        cmd.Connection.Open(); //Abrir la conexion

                        int rowsAffectedAdd = cmd.ExecuteNonQuery(); //Ejecutando nuestra sentencia

                        //cmd.Connection.Close();
                        if (rowsAffectedAdd > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result UpdateSP(ML.Usuario usuario)   //Add con Stored Procedure
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //Ya tiene la sentencia y la conexion, hacen falta los parametros

                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("@UserName", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.UserName;

                        collection[2] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.Nombre;

                        collection[3] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;

                        collection[4] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.ApellidoMaterno;

                        collection[5] = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;

                        collection[6] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                        collection[6].Value = usuario.Password;

                        collection[7] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[7].Value = usuario.FechaNacimiento;

                        collection[8] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[8].Value = usuario.Sexo;

                        collection[9] = new SqlParameter("@Telefono", System.Data.SqlDbType.VarChar);
                        collection[9].Value = usuario.Telefono;

                        collection[10] = new SqlParameter("@Celular", System.Data.SqlDbType.VarChar);
                        collection[10].Value = usuario.Celular;

                        collection[11] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                        collection[11].Value = usuario.CURP;

                        collection[12] = new SqlParameter("@idRol", System.Data.SqlDbType.VarChar);
                        collection[12].Value = usuario.Rol.IdRol;

                        //Pasarle a mi command los parametros
                        cmd.Parameters.AddRange(collection); // Pasarle a mi commando los parametros

                        //Abrir la conexion
                        cmd.Connection.Open();

                        //Ejecutando nueestra sentencia
                        int rowsAffectedUpdate = cmd.ExecuteNonQuery();

                        if (rowsAffectedUpdate > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {//Instancia de result 

                //SqlConnection es para conexion a sql server
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //Almacenar querys de sql y ejecutarlos
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //Ya tiene la sentencia y la conexion, hacen falta los parametros

                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection); // Pasarle a mi commando los parametros

                        //Abrir la conexion
                        cmd.Connection.Open();

                        //Ejecutando nueestra sentencia
                        int rowsAffectedUpdate = cmd.ExecuteNonQuery();

                        if (rowsAffectedUpdate > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.UserName = row[1].ToString();
                                usuario.Nombre = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.Password = row[6].ToString();
                                usuario.FechaNacimiento = row[7].ToString();
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = int.Parse(row[12].ToString());

                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection); // Pasarle a mi commando los parametros

                        //Aqui voy a almacenar la informacion
                        DataTable tableUsuario = new DataTable();

                        //Me permite llenar un data tablbe
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();
                            //foreach (DataRow row in tableUsuario.Rows)

                            DataRow row = tableUsuario.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.FechaNacimiento = row[7].ToString();
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = int.Parse(row[12].ToString());


                            result.Object = usuario;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    var query = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                        usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se registro el usuario";
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

        public static Result UpdateEF(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {

                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    {
                        var updateResult = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                        usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen,
                        usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                        if (updateResult >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se actualizó el registro del usuario";
                        }
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

        public static Result DeleteEF(int IdUsuario)
        {
            Result result = new Result();

            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    var query = context.UsuarioDelete(IdUsuario);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
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

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
           ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {
                    usuario.Nombre = (usuario.Nombre == null)? "":usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null)? "":usuario.ApellidoPaterno;
                    usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol; //operador ternario
                    var usuarios = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno, usuario.Rol.IdRol).ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario objUsuario = new ML.Usuario();
                            objUsuario.IdUsuario = obj.IdUsuario;
                            objUsuario.UserName = obj.UserName;
                            objUsuario.Nombre = obj.Nombre;
                            objUsuario.ApellidoPaterno = obj.ApellidoPaterno;
                            objUsuario.ApellidoMaterno = obj.ApellidoMaterno;
                            objUsuario.Email = obj.Email;
                            objUsuario.Password = obj.Password;
                            objUsuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            objUsuario.Sexo = obj.Sexo;
                            objUsuario.Telefono = obj.Telefono;
                            objUsuario.Celular = obj.Celular;
                            objUsuario.CURP = obj.CURP;

                            objUsuario.Rol = new ML.Rol();
                            objUsuario.Rol.IdRol = int.Parse(obj.idRol.ToString());
                            objUsuario.Rol.Nombre = obj.NombreRol;
                            objUsuario.Imagen = obj.Imagen.ToString();

                            objUsuario.Direccion = new ML.Direccion();
                            objUsuario.Direccion.IdDireccion = obj.IdDireccion;
                            objUsuario.Direccion.Calle = obj.Calle;
                            objUsuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            objUsuario.Direccion.NumeroExterior = obj.NumeroExterior;

                            objUsuario.Direccion.Colonia = new ML.Colonia();
                            objUsuario.Direccion.Colonia.IdColonia = int.Parse(obj.IdColonia.ToString());
                            objUsuario.Direccion.Colonia.Nombre = obj.NombreColonia;



                            objUsuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            objUsuario.Direccion.Colonia.Municipio.IdMunicipio = int.Parse(obj.IdMunicipio.ToString());
                            objUsuario.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

                            objUsuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            objUsuario.Direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(obj.IdEstado.ToString());
                            objUsuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.NombreEstado;

                            objUsuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            objUsuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = int.Parse(obj.IdPais.ToString());
                            objUsuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;

                            objUsuario.Status = obj.Status.Value;
                            result.Objects.Add(objUsuario);
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

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    var objUsuario = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.idRol.Value;
                        result.Object = usuario;

                        usuario.Imagen = objUsuario.Imagen.ToString();

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = int.Parse(objUsuario.IdColonia.ToString());
                        usuario.Direccion.Colonia.Nombre = objUsuario.NombreColonia;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = int.Parse(objUsuario.IdMunicipio.ToString());
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(objUsuario.IdEstado.ToString());
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = int.Parse(objUsuario.IdPais.ToString());
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Aseguradora";
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

        public static ML.Result AddLinq(ML.Usuario usuario)
        {
            Result result = new ML.Result();

            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;
                    usuarioDL.idRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);

                    var query = context.SaveChanges();

                    if (query > 0)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result UpdateLinq(ML.Usuario usuario)
        {
            Result result = new Result();

            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    var query = (from usuarios in context.Usuarios
                                 where usuarios.IdUsuario == usuario.IdUsuario
                                 select usuarios).SingleOrDefault();

                    if (query != null)
                    {
                        query.UserName = usuario.UserName;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        query.Sexo = usuario.Sexo;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.idRol = usuario.Rol.IdRol;
                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result DeleteLinq(ML.Usuario usuario)
        {
            Result result = new ML.Result();

            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    var query = (from u in context.Usuarios
                                 where u.IdUsuario == usuario.IdUsuario
                                 select u).First();

                    if (query != null)
                    {

                        context.Usuarios.Remove(query);
                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static Result GetAllLinq()
        {
            Result result = new Result();
            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    var query = from usuarios in context.Usuarios
                                join usuario in context.Usuarios on usuarios.IdUsuario equals usuario.IdUsuario
                                join rol in context.Usuarios on usuarios.idRol equals rol.idRol
                                where usuarios.IdUsuario == usuario.IdUsuario
                                where usuarios.idRol == rol.idRol
                                select new
                                {
                                    IdUsuario = usuario.IdUsuario,
                                    UserName = usuario.UserName,
                                    Nombre = usuario.Nombre,
                                    ApellidoPaterno = usuario.ApellidoPaterno,
                                    ApellidoMaterno = usuario.ApellidoMaterno,
                                    Email = usuario.Email,
                                    Password = usuario.Password,
                                    FechaNacimiento = usuario.FechaNacimiento,
                                    Sexo = usuario.Sexo,
                                    Telefono = usuario.Telefono,
                                    Celular = usuario.Celular,
                                    CURP = usuario.CURP,
                                    IdRol = rol.idRol
                                };

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var objUsuario in query)
                        {


                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = objUsuario.IdUsuario;
                            usuario.UserName = objUsuario.UserName;
                            usuario.Nombre = objUsuario.Nombre;
                            usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                            usuario.Email = objUsuario.Email;
                            usuario.Password = objUsuario.Password;
                            usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString();
                            usuario.Sexo = objUsuario.Sexo;
                            usuario.Telefono = objUsuario.Telefono;
                            usuario.Celular = objUsuario.Celular;
                            usuario.CURP = objUsuario.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = objUsuario.IdRol.Value;
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static Result GetByIdLinq(int IdUsuario)
        {
            ML.Result result = new Result();
            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    var query = (from usuario in context.Usuarios
                                 where usuario.IdUsuario == IdUsuario
                                 select new
                                 {
                                     usuario.IdUsuario,
                                     usuario.UserName,
                                     usuario.Nombre,
                                     usuario.ApellidoMaterno,
                                     usuario.ApellidoPaterno,
                                     usuario.Email,
                                     usuario.Password,
                                     usuario.FechaNacimiento,
                                     usuario.Sexo,
                                     usuario.Telefono,
                                     usuario.Celular,
                                     usuario.CURP,
                                     usuario.idRol
                                 }).FirstOrDefault();

                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.idRol.Value;

                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result ChangeStatus(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {

                    var query = context.UsuarioChangeStatus(usuario.IdUsuario, usuario.Status);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se registro el usuario";
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
    }

}
