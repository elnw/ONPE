using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ONPE.WEB.Models;

namespace ONPE.WEB.ViewModel
{
    public class LstDistritoViewModel
    {
        public List<Distrito> LstDistrito { get; set; }

        public LstDistritoViewModel()
        {
            ONPEWEBEntities context = new ONPEWEBEntities();
            //cambios
           
            LstDistrito = context.Distrito.Where(x=>x.Estado!="INA").ToList();
        }
    }
}
