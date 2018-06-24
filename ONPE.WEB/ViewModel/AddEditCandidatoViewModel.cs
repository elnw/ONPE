using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ONPE.WEB.Models;

namespace ONPE.WEB.ViewModel
{
    public class AddEditCandidatoViewModel
    {
        public int? CandidatoId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public int PartidoPoliticoId { get; set; }
        public int DistritoId { get; set; }
        public List<Distrito> ListDistrito { get; set; }
        public List<PartidoPolitico> ListPartidoPolitico { get; set; }

        public AddEditCandidatoViewModel()
        {
        }

        public void CargarDatos(int? CandidatoId)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();

            this.CandidatoId = CandidatoId;
            this.ListDistrito = context.Distrito.Where(x => x.Estado != "INA").ToList();
            this.ListPartidoPolitico = context.PartidoPolitico.Where(x => x.Estado != "INA").ToList();

            if (CandidatoId.HasValue) // SI ES EDITAR
            {
                Candidato objCandidato = context.Candidato.FirstOrDefault(
                    X => X.CandidatoId == CandidatoId);
                this.Nombres = objCandidato.Nombres;
                this.Apellidos = objCandidato.Apellidos;
                this.CandidatoId = objCandidato.CandidatoId;
                this.DistritoId = objCandidato.DistritoId;
            }
        }
    }
}