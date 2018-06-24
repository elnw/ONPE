using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;
namespace ONPE.WEB.ViewModel
{
    public class AddEditUsuarioViewModel
    {
   
        public int? UsuarioId { get; set; }

        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String codigo { get; set; }
        public String password { get; set; }
        public String rol { get; set; }
        public String estado { get; set; }
        public AddEditUsuarioViewModel()
        {
        }
        public void CargarDatos(int? usuarioId)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();

            this.UsuarioId = usuarioId;



            if (usuarioId.HasValue) // SI ES EDITAR
            {
                Usuarios objUsuario = context.Usuarios.FirstOrDefault(X => X.UsuariosId == usuarioId);
                this.UsuarioId = objUsuario.UsuariosId;
                this.Nombre = objUsuario.Nombres;
                this.Apellido = objUsuario.Apellidos;
                this.codigo = objUsuario.Codigo;
                this.password = objUsuario.Password;
                this.rol = objUsuario.Rol;
            

            }
        }
    
    }
}