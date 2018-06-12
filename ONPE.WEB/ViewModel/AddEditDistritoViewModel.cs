using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;
namespace ONPE.WEB.ViewModel
{
    public class AddEditDistritoViewModel
    {
      
            public int? DistritoId { get; set; }
            public String nombre { get; set; }


            public AddEditDistritoViewModel()
            { }

            public void CargarDatos(int? DistritoId)
            {
                ONPEEntities context = new ONPEEntities();

                this.DistritoId = DistritoId;



                if (DistritoId.HasValue) // SI ES EDITAR
                {
                    Distrito objDistrito = context.Distrito.FirstOrDefault(X => X.DistritoId == DistritoId);
                    this.nombre = objDistrito.Nombre;



                }
            }

        }
    
}