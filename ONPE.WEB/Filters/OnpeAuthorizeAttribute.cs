using ONPE.WEB.Helpers;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using ONPE.WEB.Models;

namespace ONPE.WEB.Filters
{
    public class ONPEAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        private readonly String[] _acceptedRoles;

        public ONPEAuthorizeAttribute(params String[] acceptedRoles)
        {
            _acceptedRoles = acceptedRoles;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var unauthorized = false;

            try
            {
                var user = (Usuarios)filterContext.HttpContext.Session.Get(SessionKey.Usuario);
                var rol = user.Rol;

                if (_acceptedRoles.Length > 0)
                {
                    // rol = (AppRol)filterContext.HttpContext.Session.Get(SessionKey.Usuario);
                    
                    //if (!_acceptedRoles.Contains(rol))
                    //{
                    //    unauthorized = true;
                    //}
                    foreach( var item in _acceptedRoles)
                    {
                        if (!item.Equals(rol))
                        {
                            unauthorized = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                unauthorized = true;
            }

            if (unauthorized)
            {


                if (filterContext.HttpContext.Session.Get(SessionKey.UsuarioId) == null)
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
                else
                    filterContext.Result = new ViewResult() { ViewName = filterContext.HttpContext.Request.IsAjaxRequest() ? "_PermisoInsuficienteModal" : "PermisoInsuficiente" };
            }
        }
    }
}