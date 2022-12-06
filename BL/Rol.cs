using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllEF()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RVelazquezProgramacionNCapasEntities1 context = new DL_EF.RVelazquezProgramacionNCapasEntities1())
                {
                    var usuarios = context.RolGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var objRol in usuarios)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = objRol.IdRol;
                            rol.Nombre = objRol.Nombre; 
                           
                            result.Objects.Add(rol);
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

    }
}
