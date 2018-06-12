using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ONPE.WEB.Models;

namespace ONPE.WEB.ViewModel
{
    public class AddEditPartidoPoliticoViewModel
    {
        public int? PartidoPoliticoId { get; set; }
        public String nombre { get; set; }
  
   
        public AddEditPartidoPoliticoViewModel()
        {}

        public void CargarDatos(int? PartidoPoliticoId)
        {
            ONPEEntities context = new ONPEEntities();

            this.PartidoPoliticoId = PartidoPoliticoId;
           
            

            if (PartidoPoliticoId.HasValue) // SI ES EDITAR
            {
                PartidoPolitico objPartido = context.PartidoPolitico.FirstOrDefault(X => X.PartidoPoliticoId == PartidoPoliticoId);
                this.nombre = objPartido.Nombre;
                
                
               
            }
        }

    }
}