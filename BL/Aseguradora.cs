using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL_EF;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result Add(ML.Aseguradora aseguradora)   //Add con Stored Procedure
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "AseguradoraAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = aseguradora.Nombre;

                        collection[1] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.VarChar);
                        collection[1].Value = aseguradora.Usuario.IdUsuario;


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
        public static ML.Result Update(ML.Aseguradora aseguradora)   //Add con Stored Procedure
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "AseguradoraUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[3];


                        collection[0] = new SqlParameter("@idAseguradora", System.Data.SqlDbType.VarChar);
                        collection[0].Value = aseguradora.IdAseguradora;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = aseguradora.Nombre;

                        collection[2] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.VarChar);
                        collection[2].Value = aseguradora.Usuario.IdUsuario;


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
        public static ML.Result Delete(ML.Aseguradora aseguradora)
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
                        cmd.CommandText = "AseguradoraDelete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        //Ya tiene la sentencia y la conexion, hacen falta los parametros

                        //Agregar parametros
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.VarChar);
                        collection[0].Value = aseguradora.IdAseguradora;

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
                        cmd.CommandText = "AseguradoraGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableAseguradora = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableAseguradora);

                        if (tableAseguradora.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableAseguradora.Rows)
                            {
                                ML.Aseguradora aseguradora = new ML.Aseguradora();
                                aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                                aseguradora.Nombre = row[1].ToString();
                                aseguradora.FechaCreacion = row[2].ToString();
                                aseguradora.FechaModificacion = row[3].ToString();

                                aseguradora.Usuario = new ML.Usuario();
                                aseguradora.Usuario.IdUsuario = int.Parse(row[4].ToString());

                                result.Objects.Add(aseguradora);
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
        public static ML.Result GetById(int IdAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AseguradoraGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdAseguradora", System.Data.SqlDbType.Int);
                        collection[0].Value = IdAseguradora;

                        cmd.Parameters.AddRange(collection); // Pasarle a mi commando los parametros

                        //Aqui voy a almacenar la informacion
                        DataTable tableAseguradora = new DataTable();

                        //Me permite llenar un data tablbe
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableAseguradora);

                        if (tableAseguradora.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();
                            //foreach (DataRow row in tableUsuario.Rows)

                            DataRow row = tableAseguradora.Rows[0];

                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                            aseguradora.Nombre = row[1].ToString();
                            aseguradora.FechaCreacion = row[2].ToString();
                            aseguradora.FechaModificacion = row[3].ToString();

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = int.Parse(row[4].ToString());



                            result.Object = aseguradora;

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


        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    var query = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.Usuario.IdUsuario);


                    if (query > 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se registro el aseguradora";
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
        public static Result UpdateEF(ML.Aseguradora aseguradora)
        {
            Result result = new Result();
            try
            {

                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    {
                        var updateResult = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Usuario.IdUsuario);
                        if (updateResult >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se actualizó el registro del aseguradora";
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
        public static Result DeleteEF(int IdAseguradora)
        {
            Result result = new Result();

            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    var query = context.AseguradoraDelete(IdAseguradora);
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
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {
                    var aseguradoras = context.AseguradoraGetAll().ToList();

                    result.Objects = new List<object>();

                    if (aseguradoras != null)
                    {
                        foreach (var obj in aseguradoras)
                        {
                            ML.Aseguradora aseguradora= new ML.Aseguradora();
                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre = obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = obj.FechaModificacion.ToString();
 
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = int.Parse(obj.IdUsuario.ToString());
                            aseguradora.Usuario.Nombre = obj.NombreUsuario;
                            result.Objects.Add(aseguradora);
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
        public static ML.Result GetByIdEF(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {

                    var objAseguradora = context.AseguradoraGetById(IdAseguradora).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objAseguradora != null)
                    {

                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = objAseguradora.IdAseguradora;
                        aseguradora.Nombre = objAseguradora.Nombre;
                        aseguradora.FechaCreacion = objAseguradora.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = objAseguradora.FechaModificacion.ToString();

                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = objAseguradora.IdUsuario.Value;
                        result.Object = aseguradora;


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


        public static ML.Result AddLinq(ML.Aseguradora aseguradora)
        {
            Result result = new ML.Result();

            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    DL_EF.Aseguradora aseguradoraDL = new DL_EF.Aseguradora();

                    aseguradoraDL.Nombre = aseguradora.Nombre;
                    aseguradoraDL.FechaCreacion = DateTime.Parse(aseguradora.FechaCreacion);
                    aseguradoraDL.FechaModIficacion = DateTime.Parse(aseguradora.FechaModificacion);
                    aseguradoraDL.IdUsuario = aseguradora.IdUsuario;

                    context.Aseguradoras.Add(aseguradoraDL);

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

        public static ML.Result UpdateLinq(ML.Aseguradora aseguradora)
        {
            Result result = new Result();

            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    var query = (from aseguradoras in context.Aseguradoras 
                                 where aseguradoras.IdAseguradora == aseguradora.IdAseguradora
                                 select aseguradoras).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = aseguradora.Nombre;
                        //query.FechaCreacion = DateTime.Parse(aseguradora.FechaCreacion);
                        //query.FechaModIficacion = DateTime.Parse(aseguradora.FechaModificacion);
                        query.IdAseguradora = aseguradora.Usuario.IdUsuario;
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

        public static ML.Result DeleteLinq(ML.Aseguradora aseguradora)
        {
            Result result = new ML.Result();

            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    var query = (from a in context.Aseguradoras
                                 where a.IdAseguradora == aseguradora.IdAseguradora
                                 select a).First();

                    if (query != null)
                    {

                        context.Aseguradoras.Remove(query);
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
                    var query = from aseguradoras in context.Aseguradoras
                                join aseguradora in context.Aseguradoras on aseguradoras.IdAseguradora equals aseguradora.IdAseguradora
                                join usuario in context.Aseguradoras on aseguradoras.IdUsuario equals usuario.IdUsuario 
                                where aseguradoras.IdAseguradora == aseguradora.IdAseguradora
                                where aseguradoras.IdUsuario == usuario.IdUsuario
                                select new
                                {
                                    IdAseguradora = aseguradora.IdAseguradora,
                                    Nombre = aseguradora.Nombre,
                                    FechaCreacion = aseguradora.FechaCreacion,
                                    FechaModificacion = aseguradora.FechaModIficacion,
                                    IdUsuario = usuario.IdUsuario
                                };

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var objAseguradora in query)
                        {


                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = objAseguradora.IdAseguradora;
                            aseguradora.Nombre = objAseguradora.Nombre;
                            aseguradora.FechaCreacion = objAseguradora.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = objAseguradora.FechaCreacion.ToString();

                        
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = objAseguradora.IdUsuario.Value;
                            result.Objects.Add(aseguradora);
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

        public static Result GetByIdLinq(int IdAseguradora)
        {
            ML.Result result = new Result();
            try
            {
                using (RVelazquezProgramacionNCapasEntities1 context = new RVelazquezProgramacionNCapasEntities1())
                {
                    var query = (from aseguradora in context.Aseguradoras   
                                 where aseguradora.IdAseguradora == IdAseguradora
                                 select new
                                 {
                                     aseguradora.IdAseguradora,
                                     aseguradora.Nombre,
                                     aseguradora.FechaCreacion,
                                     aseguradora.FechaModIficacion,
                                     aseguradora.IdUsuario
                                 }).FirstOrDefault();

                    if (query != null)
                    {

                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;
                        aseguradora.FechaCreacion = query.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = query.FechaModIficacion.ToString();

                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = query.IdUsuario.Value;

                        result.Object = aseguradora;

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

    }
}
