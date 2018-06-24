using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;

namespace ONPE.WEB.ViewModel
{
    public class LstPartidoPoliticoViewModel
    {
        public List<PartidoPolitico> listParitdo { get; set; }

        public LstPartidoPoliticoViewModel()
        {

            ONPEWEBEntities context = new ONPEWEBEntities();
            listParitdo = context.PartidoPolitico.Where(x => x.Estado != "INA").ToList();
        }
    }
}