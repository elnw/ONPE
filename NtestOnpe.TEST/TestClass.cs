using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONPE.WEB.ViewModel;
using ONPE.WEB.Models;

namespace NtestOnpe.TEST
{
    [TestFixture]
    public class Class1
    {
        [TestCase]
        public void CP_3_01()
        {
            //validar que las estadisticas mostradas sobre el partido politico sean 
            //relacionadas al partido politico del usuario logeado
            ONPEWEBEntities context = new ONPEWEBEntities();
            Usuarios testUsuario = context.Usuarios.Find(2);
            var dashboard = new DashboardViewModel(testUsuario);
            Assert.AreEqual(1, dashboard.NroCandidato);


        }

        [TestCase]
        public void CP_3_02()
        {
            //validar que las estadisticas mostradas no tengan valores negativos
            ONPEWEBEntities context = new ONPEWEBEntities();
            Usuarios testUsuario = context.Usuarios.Find(1);
            var dashboard = new DashboardViewModel(testUsuario);

            Assert.IsTrue(dashboard.NroPartidoPolitico >= 0 && dashboard.NroDistrito >= 0 && dashboard.NroCandidato >= 0);

        }
    }
}
