using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ONPE.WEB.Models;

namespace ONPE.WEB.ViewModel
{
    public class LstCandidatoViewModel
    {
        public List<Candidato> ListCandidato { get; set; }

        public LstCandidatoViewModel()
        {
            ONPEWEBEntities context = new ONPEWEBEntities();
            ListCandidato = context.Candidato.Where(x => x.Estado != "INA").ToList();
        }
        public List<Candidato> getList()
        {
            return ListCandidato;
        }
    }
}