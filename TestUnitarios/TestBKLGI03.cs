using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONPE.WEB.ViewModel;
using ONPE.WEB.Models;
namespace TestUnitarios
{
    [TestClass]
    public class TestBKLGI03
    {
        [TestMethod]
        public void CP_3_01()
        {
            //validar que las estadisticas mostradas sobre el partido politico sean 
            //relacionadas al partido politico del usuario logeado
            ONPEEntities context = new ONPEEntities();
            Usuarios testUsuario = context.Usuarios.Find(2);
            var dashboard = new DashboardViewModel(testUsuario);
            Assert.AreEqual(1, dashboard.NroCandidato);
            
            
        }

        [TestMethod]
        public void CP_3_02()
        {
            //validar que las estadisticas mostradas no tengan valores negativos
            ONPEEntities context = new ONPEEntities();
            Usuarios testUsuario = context.Usuarios.Find(1);
            var dashboard = new DashboardViewModel(testUsuario);

            Assert.IsTrue(dashboard.NroPartidoPolitico >= 0 && dashboard.NroDistrito >= 0 && dashboard.NroCandidato >= 0);

        }


    }
}
