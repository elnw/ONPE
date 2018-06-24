using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;
namespace ONPE.WEB.ViewModel
{
    public class EliminarGeneric
    {
        public static void eliminarEntidad(Int32 entidadId, String tabla)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();
            switch (tabla)
            {
                case "Usuario":
                    {
                        var obj = context.Usuarios.Find(entidadId);
                        obj.Estado = "INA";

                    }break;
                case "Distrito":
                    {
                        var obj = context.Distrito.Find(entidadId);
                        obj.Estado = "INA";
                    }break;
                case "PartidoPolitico":
                    {
                        var obj = context.PartidoPolitico.Find(entidadId);
                        obj.Estado = "INA";
                    }break;
                case "Candidato":
                    {
                        var obj = context.Candidato.Find(entidadId);
                        obj.Estado = "INA";
                    }break;
            }

            context.SaveChanges();
        }
    }
}