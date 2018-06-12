using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;
namespace ONPE.WEB.ViewModel
{
    public class AddEditGeneric
    {
        public static void AddEditUsuario(AddEditUsuarioViewModel model)
        {
            ONPEEntities context = new ONPEEntities();
            var obj = new Usuarios();
            var candidato = new Candidato();
            if (model.UsuarioId.HasValue)
            {
                obj = context.Usuarios.Find(model.UsuarioId.Value);
                candidato = context.Candidato.FirstOrDefault(x => x.Nombres == obj.Nombres);


            }
            else
            {
                obj.Estado = "ACT";
                context.Usuarios.Add(obj);
            }

            obj.Nombres = model.Nombre;
            obj.Apellidos = model.ApellidoM;
            obj.Codigo = model.codigo;
            obj.Password = model.password;
            obj.Rol = model.rol;
            if (candidato != null)
            {
                candidato.Nombres = model.Nombre;
                candidato.Apellidos = model.ApellidoM;
            }


            context.SaveChanges();
        }
    }
}