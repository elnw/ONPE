using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ONPE.WEB.ViewModel;
using ONPE.WEB.Models;
using ONPE.WEB.Controllers;

namespace TestUnitarios
{
    public class DistritoComparer : System.Collections.IComparer
    {
        public int Compare(object a, object b)
        {
            var x = a as Distrito;
            var y = b as Distrito;
            int temp;

            return (temp = x.Nombre.CompareTo(y.Nombre)) != 0 ? temp : x.Estado.CompareTo(y.Estado);
        }

      
    }

    public class PartidoPoliticoComparer : System.Collections.IComparer
    {
        public int Compare(object a, object b)
        {
            var x = a as PartidoPolitico;
            var y = b as PartidoPolitico;
            int temp;

            return (temp = x.Nombre.CompareTo(y.Nombre)) != 0 ? temp : x.Estado.CompareTo(y.Estado);
        }


    }

    public class CandidatoComparer : System.Collections.IComparer
    {
        public int Compare(object a, object b)
        {
            var x = a as Candidato;
            var y = b as Candidato;
            int temp;

            return (temp = x.Nombres.CompareTo(y.Nombres)) != 0 ? temp : 
                ( temp=x.Apellidos.CompareTo(y.Apellidos)) !=0? temp : 
                (temp=x.DistritoId.CompareTo(y.DistritoId)) !=0? temp:
                (temp=x.CandidatoId.CompareTo(y.CandidatoId)) != 0 ? temp : (
                temp= x.Estado.CompareTo(y.Estado))  ;
        }


    }



    [TestClass]
    public class TestBKLGI005
    {
        [TestMethod]
        public void CP_5_001()
        {
            //Al acceder a la pestaña de gestion de distritos, el sistema debe listarme todos los distritos creados
            ONPEEntities context = new ONPEEntities();
            LstDistritoViewModel TestDistrito = new LstDistritoViewModel();
            List<Distrito> ListaEsperada = context.Distrito.ToList();
            var comparer = new DistritoComparer();
           CollectionAssert.AreEqual(ListaEsperada   , TestDistrito.LstDistrito,comparer);
           



        }
        [TestMethod]
        public void CP_5_002()
        {
            //Al acceder a la pestaña de gestion de Partidos politicos, el sistema debe listarme todos 
            //los Partidos politicos creados
            ONPEEntities context = new ONPEEntities();
            LstPartidoPoliticoViewModel TestPartidoPolitico = new LstPartidoPoliticoViewModel();

            List<PartidoPolitico> ListaEsperada = context.PartidoPolitico.ToList();
            var comparer = new PartidoPoliticoComparer();
            CollectionAssert.AreEqual(ListaEsperada, TestPartidoPolitico.listParitdo, comparer);
        }

        [TestMethod]
        public void CP_5_003()
        {
            //Al acceder a la pestaña de gestion de Candidatos, el sistema debe listarme todos los Candidatos creados
            ONPEEntities context = new ONPEEntities();
            LstCandidatoViewModel TestCandidato = new LstCandidatoViewModel();

            List<Candidato> ListaEsperada = context.Candidato.ToList();
            List<Candidato> ListaActual = TestCandidato.getList();

            var comparer = new CandidatoComparer();
            CollectionAssert.AreEqual(ListaEsperada, ListaActual, comparer);


        }

        [TestMethod]
        public void EliminarUsuarioTest()
        {
            ONPEEntities context = new ONPEEntities();
            Random r = new Random();
            var UsuarioPrueba = r.Next() % context.Usuarios.Count();

            EliminarGeneric.eliminarEntidad(UsuarioPrueba, "Usuario");
           Assert.AreEqual(context.Usuarios.Find(UsuarioPrueba).Estado, "INA");


        }

        [TestMethod]
        public void AddUsuarioTest()
        {
            ONPEEntities context = new ONPEEntities();
            Int32 cont = context.Usuarios.Count();
            var obj = new AddEditUsuarioViewModel();
            obj.Nombre = "aaa";
            obj.ApellidoM = "aaa";
            obj.estado = "ACT";
            obj.codigo = "asaa";
            obj.password = "aasas";
            obj.rol = "ADM";
            AddEditGeneric.AddEditUsuario(obj);
            Int32 cont2= context.Usuarios.Count();
            Assert.AreEqual(cont + 1, cont2);
        }

        [TestMethod]
        public void EditUsuarioTest()
        {
            ONPEEntities context = new ONPEEntities();
            var usuario = context.Usuarios.Find(1);
            String nombreTest = "algo";
            var obj = new AddEditUsuarioViewModel();

            obj.Nombre = nombreTest;
            obj.UsuarioId = 1;
            obj.ApellidoM = usuario.Apellidos;
            obj.estado = usuario.Estado;
            obj.codigo = usuario.Codigo;
            obj.password = usuario.Password;
            obj.rol = usuario.Rol;

            AddEditGeneric.AddEditUsuario(obj);
           


            Assert.AreEqual( nombreTest, context.Usuarios.Find(1).Nombres );
        }



    }
}
