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
            ONPEEntities context = new ONPEEntities();
            ListCandidato = context.Candidato.ToList();
        }
        public List<Candidato> getList()
        {
            return ListCandidato;
        }
    }
}