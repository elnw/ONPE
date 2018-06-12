using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;
namespace ONPE.WEB.ViewModel
{
    public class ListarUsuariosViewModel
    {
        public List<Usuarios> ListaUsuarios { get; set; }

        public void Fill()
        {
            ONPEEntities context = new ONPEEntities();
            ListaUsuarios = context.Usuarios.Where(x=>x.Estado=="ACT").ToList();

        }
    }
}