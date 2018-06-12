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
            ONPEEntities context = new ONPEEntities();
            listParitdo = context.PartidoPolitico.ToList();
        }
    }
}