using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONPE.WEB.Filters;
using ONPE.WEB.ViewModel;
using ONPE.WEB.Models;
using ONPE.WEB.Helpers;

namespace ONPE.WEB.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        //mas cambios
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult Dashboard()
        {
            DashboardViewModel objViewModel = new DashboardViewModel((Usuarios)Session["logeado"]);
            return View(objViewModel);
        }
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult LstCandidato()
        {
            LstCandidatoViewModel objViewModel = new LstCandidatoViewModel();
            return View(objViewModel);
        }

        [HttpGet]
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult AddEditCandidato(int? CandidatoId)
        {
            AddEditCandidatoViewModel objViewModel = new AddEditCandidatoViewModel();
            objViewModel.CargarDatos(CandidatoId);
            return View(objViewModel);

        }

        [HttpPost]

        public ActionResult AddEditCandidato(AddEditCandidatoViewModel objViewModel)
        {
            try
            {
                
                ONPEWEBEntities context = new ONPEWEBEntities();
                Candidato objCandidato = new Candidato();

                if (objViewModel.CandidatoId.HasValue)
                {
                    objCandidato = context.Candidato.FirstOrDefault(X => X.CandidatoId == objViewModel.CandidatoId);
                    objCandidato.Nombres = objViewModel.Nombres;
                    objCandidato.Apellidos = objViewModel.Apellidos;
                    objCandidato.DistritoId = objViewModel.DistritoId;
                    objCandidato.PartidoPoliticoId = objViewModel.PartidoPoliticoId;
                }
                else
                {
                    objCandidato.Nombres = objViewModel.Nombres;
                    objCandidato.Apellidos = objViewModel.Apellidos;
                    objCandidato.DistritoId = objViewModel.DistritoId;
                    objCandidato.PartidoPoliticoId = objViewModel.PartidoPoliticoId;
                    objCandidato.Estado = "ACT";
                    context.Candidato.Add(objCandidato);
                }
                context.SaveChanges();
                TempData["Mensaje"] = "Candidato guardado";
                return RedirectToAction("LstCandidato");

            }catch(Exception ex)
            {

                TempData["Mensaje"] = "Campo(s) incompleto(s)";
                return View(objViewModel);
            }
        }

        public ActionResult EliminarCandidato(Int32 CandidatoId)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();
            var candidatoElminar = context.Candidato.Find(CandidatoId);
            candidatoElminar.Estado = "INA";
            context.SaveChanges();
            TempData["Mensaje"] = "Candidato eliminado";
            return RedirectToAction("LstCandidato");
        }

        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult AddEditPartidoPolitico(int? PartidoPoliticoId)
        {
            AddEditPartidoPoliticoViewModel objViewModel = new AddEditPartidoPoliticoViewModel();
            objViewModel.CargarDatos(PartidoPoliticoId);
            return View(objViewModel);
        }

        [HttpPost]
        public ActionResult AddEditPartidoPolitico(AddEditPartidoPoliticoViewModel objViewModel)
        {
            try
            {
                ONPEWEBEntities context = new ONPEWEBEntities();
                PartidoPolitico objPartido = new PartidoPolitico();
                if (objViewModel.PartidoPoliticoId.HasValue)
                {
                    objPartido = context.PartidoPolitico.FirstOrDefault(X => X.PartidoPoliticoId == objViewModel.PartidoPoliticoId);
                    objPartido.Nombre = objViewModel.nombre;
                }
                else
                {
                    objPartido.Nombre = objViewModel.nombre;
                    objPartido.Estado = "ACT";
                    context.PartidoPolitico.Add(objPartido);
                }
                
                context.SaveChanges();
                TempData["Mensaje"] = "Partido guardado";
                return RedirectToAction("LstPartidoPolitico");

            }
            catch(Exception ex)
            {

                TempData["Mensaje"] = "Campo(s) incompleto(s)";
                return View(objViewModel);
            }


            //A 
        }
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult AddEditDistrito(int? DistritoId)
        {
            AddEditDistritoViewModel objViewModel = new AddEditDistritoViewModel();
            objViewModel.CargarDatos(DistritoId);
            return View(objViewModel);
        }

        [HttpPost]
        public ActionResult AddEditDistrito(AddEditDistritoViewModel objViewModel)
        {
            try
            {
                ONPEWEBEntities context = new ONPEWEBEntities();
                Distrito objDistrito = new Distrito();
               if (objViewModel.DistritoId.HasValue)
               {
                   objDistrito = context.Distrito.FirstOrDefault(X => X.DistritoId == objViewModel.DistritoId);
                   objDistrito.Nombre = objViewModel.nombre;
                }
               else
               {
                    objDistrito.Nombre = objViewModel.nombre;
                    objDistrito.Estado = "ACT";
                    context.Distrito.Add(objDistrito);
                }

                context.SaveChanges();
                TempData["Mensaje"] = "Distrito guardado";
                return RedirectToAction("LstDistrito");

            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Campo(s) incompleto(s)";
                return View(objViewModel);
            }



        }

        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult EliminarDistrito(int? DistritoId)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();
            var distritoElminar = context.Distrito.Find(DistritoId);
            distritoElminar.Estado = "INA";
            context.SaveChanges(); 
            TempData["Mensaje"] = "Distrito eliminado";
            return RedirectToAction("LstDistrito");
           
        }

        

        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult LstDistrito()
        {
            LstDistritoViewModel objViewModel = new LstDistritoViewModel();
            return View(objViewModel);
        }
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult LstPartidoPolitico()
        {
            LstPartidoPoliticoViewModel objViewModel = new LstPartidoPoliticoViewModel();
            return View(objViewModel);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel)
        {
            try
            {
                ONPEWEBEntities context = new ONPEWEBEntities();
                Usuarios objUsuario = context.Usuarios.FirstOrDefault(x => x.Codigo == objViewModel.codigo && x.Password == objViewModel.Password);
                if (objUsuario == null)
                {
                    TempData["Mensaje"] = "Error! Usuario y/o contraseña incorrectos >:V";
                    return View(objViewModel);
                }
                Session["logeado"] = objUsuario;

                Session.Set(SessionKey.SeguridadGrupo, objUsuario.Rol);
                Session.Set(SessionKey.UsuarioId, objUsuario.UsuariosId);
                Session.Set(SessionKey.Usuario, objUsuario);
                Session.Set(SessionKey.Rol, objUsuario.Rol);
                Session.Set(SessionKey.NombreCompleto, $"{objUsuario.Nombres} {objUsuario.Apellidos} ");
                Session.Set(SessionKey.NombreUsuarioVista, $"{objUsuario.Nombres}");



                return RedirectToAction("Dashboard");
            }
            catch(Exception ex)
            {
                TempData["Mensaje"] = "Error! " + ex.Message;
                return View(objViewModel);
            }
        }
        
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult ListarUsuarios()
        {
            ListarUsuariosViewModel objVM = new ListarUsuariosViewModel();
            objVM.Fill();
            return View(objVM);
        }
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult AddEditUsuario(int? UsuarioId)
        {
            AddEditUsuarioViewModel objViewModel = new AddEditUsuarioViewModel();
            objViewModel.CargarDatos(UsuarioId);
            return View(objViewModel);

        }

        [HttpPost]
        public ActionResult AddEditUsuario(AddEditUsuarioViewModel objViewModel)
        {
     
            try
            {
                ONPEWEBEntities context = new ONPEWEBEntities();
                Usuarios objUsuario = new Usuarios();
                if (objViewModel.UsuarioId.HasValue)
                {
                    objUsuario = context.Usuarios.FirstOrDefault(X => X.UsuariosId == objViewModel.UsuarioId);
                    objUsuario.Nombres = objViewModel.Nombre;
                    objUsuario.Apellidos = objViewModel.Apellido;
                    objUsuario.Codigo = objViewModel.codigo;
                    objUsuario.Password = objViewModel.password;
                    objUsuario.Rol = objViewModel.rol;
                }
                else
                {
                    objUsuario.Nombres = objViewModel.Nombre;
                    objUsuario.Apellidos = objViewModel.Apellido;
                    objUsuario.Codigo = objViewModel.codigo;
                    objUsuario.Password = objViewModel.password;
                    objUsuario.Rol = objViewModel.rol;
                    objUsuario.Estado = "ACT";
                    context.Usuarios.Add(objUsuario);
                }
                context.SaveChanges();
                TempData["Mensaje"] = "Usuario guardado";
                return RedirectToAction("ListarUsuarios");


            }
            catch (Exception ex)
            {

                TempData["Mensaje"] = "Campo(s) incompleto(s)";
                return View(objViewModel);
            }
         }
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult EliminarUsuario(int UsuarioId)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();
            var usuarioEliminar = context.Usuarios.Find(UsuarioId);
            usuarioEliminar.Estado = "INA";
            context.SaveChanges();
            TempData["Mensaje"] = "Usuario eliminado";
            return RedirectToAction("ListarUsuarios");
        }

        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult EliminarPartidoPolitico(Int32 PartidoPoliticoId)
        {
            ONPEWEBEntities context = new ONPEWEBEntities();
            var partidooElminar = context.PartidoPolitico.Find(PartidoPoliticoId);
            partidooElminar.Estado = "INA";
            context.SaveChanges();
            TempData["Mensaje"] = "Partido eliminado";
            return RedirectToAction("LstPartidoPolitico");
        }

    }
}