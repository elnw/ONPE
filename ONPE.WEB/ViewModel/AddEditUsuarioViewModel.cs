using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;
namespace ONPE.WEB.ViewModel
{
    public class AddEditUsuarioViewModel
    {
   
        public Int32? UsuarioId { get; set; }

        public String Nombre { get; set; }
        public String ApellidoM { get; set; }
        public String codigo { get; set; }
        public String password { get; set; }
        public String rol { get; set; }
        public String estado { get; set; }

        public void Fill(Int32? usuarioId)
        {
            UsuarioId = usuarioId;
            if (UsuarioId.HasValue)
            {
                var context = new ONPEEntities();
                var obj = new Usuarios();
                obj = context.Usuarios.Find(UsuarioId);
                Nombre = obj.Nombres;
                ApellidoM = obj.Apellidos;
                codigo = obj.Codigo;
                password = obj.Password;
                rol = obj.Rol;
                estado = obj.Estado;
            }
        }
    
    }
}