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
                ONPEEntities context = new ONPEEntities();
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
                    context.Candidato.Add(objCandidato);
                }
                objCandidato.Nombres = objViewModel.Nombres;
                objCandidato.Apellidos = objViewModel.Apellidos;
                objCandidato.DistritoId = objViewModel.DistritoId;
                objCandidato.PartidoPoliticoId = objViewModel.PartidoPoliticoId;
                objCandidato.Estado = "ACT";
                context.SaveChanges();
                TempData["Mensaje"] = "Exito! La operacion se ejecutó satisfactoriamente";
                return RedirectToAction("LstCandidato");

            }catch(Exception ex)
            {
                return View(objViewModel);
            }
        }

        public ActionResult EliminarCandidato(Int32 CandidatoId)
        {
            EliminarGeneric.eliminarEntidad(CandidatoId, "Candidato");
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
                ONPEEntities context = new ONPEEntities();
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
                TempData["Mensaje"] = "Exito! La operacion se ejecutó satisfactoriamente";
                return RedirectToAction("LstPartidoPolitico");

            }
            catch(Exception ex)
            {
                return View(objViewModel);
            }


             
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
                ONPEEntities context = new ONPEEntities();
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
                TempData["Mensaje"] = "Exito! La operacion se ejecutó satisfactoriamente";
                return RedirectToAction("LstDistrito");

            }
            catch (Exception ex)
            {
                return View(objViewModel);
            }



        }

        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult EliminarDistrito(int? DistritoId)
        {
            ONPEEntities context = new ONPEEntities();
            var distritoElminar = context.Distrito.Find(DistritoId);
            distritoElminar.Estado = "INA";
            context.SaveChanges();
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
                ONPEEntities context = new ONPEEntities();
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
        public ActionResult AddEditUsuario(Int32? UsuarioId)
        {
            var obj = new AddEditUsuarioViewModel();
            obj.Fill(UsuarioId);
            return View(obj);

        }

        [HttpPost]
        public ActionResult AddEditUsuario(AddEditUsuarioViewModel model)
        {
            try
            {
                AddEditGeneric.AddEditUsuario(model);
            }catch(Exception ex)
            {
                return RedirectToAction("AddEditUsuario");
            }
            
            

            return RedirectToAction("ListarUsuarios");

            }
        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult EliminarUsuario(Int32 UsuarioId)
        {
            EliminarGeneric.eliminarEntidad(UsuarioId, "Usuario");


            return RedirectToAction("ListarUsuarios");
        }

        [ONPEAuthorize(Roles.ADMIN)]
        public ActionResult EliminarPartidoPolitico(Int32 PartidoId)
        {
            EliminarGeneric.eliminarEntidad(PartidoId, "PartidoPolitico");
            return RedirectToAction("LstPartidoPolitico");
        }



    }
}