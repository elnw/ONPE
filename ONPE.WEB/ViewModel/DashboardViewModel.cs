using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ONPE.WEB.Models;

namespace ONPE.WEB.ViewModel
{
    public class DashboardViewModel
    {
        public int NroCandidato { get; set; }
        public int NroPartidoPolitico { get; set; }
        public int NroDistrito { get; set; }

        public DashboardViewModel(Usuarios objUsuario)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();

            if(objUsuario.Rol == "ADM")
            {
                NroCandidato = context.Candidato.Count();
                NroPartidoPolitico = context.PartidoPolitico.Count();
                NroDistrito = context.Distrito.Count();
            }
            if(objUsuario.Rol== "CAN")
            {
                Candidato objCandidatoAux = context.Candidato.FirstOrDefault(x => x.Nombres == objUsuario.Nombres);
                NroCandidato = context.PartidoPolitico.Where(x => x.PartidoPoliticoId == objCandidatoAux.PartidoPoliticoId).Count();
                NroPartidoPolitico = 1;
                NroDistrito = context.Distrito.Where(x=>x.DistritoId == objCandidatoAux.DistritoId).Count();
            }

            
        }
    }
}