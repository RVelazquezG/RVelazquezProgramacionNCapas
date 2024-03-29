﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Aseguradora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Aseguradora.svc or Aseguradora.svc.cs at the Solution Explorer and start debugging.
    public class Aseguradora : IAseguradora
    {
        public SL_WCF.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.AddEF(aseguradora);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, ErrorMessage = result.ErrorMessage, Object = result.Object};
        }
        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllEF();
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, ErrorMessage = result.ErrorMessage, Objects = result.Objects};
        }
        public SL_WCF.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, ErrorMessage = result.ErrorMessage, Object = result.Objects};
        }
        public SL_WCF.Result Delete(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(IdAseguradora);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, ErrorMessage = result.ErrorMessage};
        }
        public SL_WCF.Result GetById(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora);
            return new SL_WCF.Result { Correct = result.Correct, Ex = result.Ex, ErrorMessage = result.ErrorMessage, Object = result.Object};
        }
    }
}
