using ONPE.WEB.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace ONPE.WEB.Helpers
{
    public enum AppRol 
    {
        Administrador

    }

    public class Roles
    {
        public const String ADMIN = "ADM";
    }

    public enum SessionKey
    {
        Usuario,
        UsuarioId,
        NombreUsuarioVista,
        NombreVista,
        NombreCompleto,
        NombreGrupo,
        SeguridadGrupo,
        Permisos,
        Menu,
        UsuarioExterno,
        RegionCliente,
        Rol
    }

    public static class SessionHelpers
    {
        #region GetUsuario
        public static Usuarios GetUsuario(this HttpSessionState Session)
        {
            return (Usuarios)Get(Session, SessionKey.Usuario);
        }

        public static Usuarios GetUsuario(this HttpSessionStateBase Session)
        {
            return (Usuarios)Get(Session, SessionKey.Usuario);
        }
        #endregion

        #region GetUsuarioId
        public static Int32? GetUsuarioId(this HttpSessionState Session)
        {
            return (Int32)Get(Session, SessionKey.UsuarioId);
        }

        public static Int32? GetUsuarioId(this HttpSessionStateBase Session)
        {
            return (Int32)Get(Session, SessionKey.UsuarioId);
        }
        #endregion
        #region GetRol
        public static AppRol? GetRol(this HttpSessionState Session)
        {
            return (AppRol?)Get(Session, SessionKey.Rol);
        }

        public static AppRol? GetRol(this HttpSessionStateBase Session)
        {
            return (AppRol?)Get(Session, SessionKey.Rol);
        }
        #endregion

        #region GetNombreCompleto
        public static String GetNombreCompleto(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.NombreCompleto);
        }

        public static String GetNombreCompleto(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.NombreCompleto);
        }
        #endregion

        #region GetNombreUsuarioVista
        public static String GetNombreUsuarioVista(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.NombreUsuarioVista);
        }

        public static String GetNombreUsuarioVista(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.NombreUsuarioVista);
        }
        #endregion

        #region GetNombreVista
        public static String GetNombreVista(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.NombreVista);
        }

        public static String GetNombreVista(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.NombreVista);
        }
        #endregion

        #region GetNombreGrupo

        #endregion

        //#region GetPermisos
        //public static List<SeguridadPermiso> GetPermisos(this HttpSessionState Session)
        //{
        //    return Get(Session, SessionKey.Permisos) as List<SeguridadPermiso>;
        //}

        //public static List<SeguridadPermiso> GetPermisos(this HttpSessionStateBase Session)
        //{
        //    return Get(Session, SessionKey.Permisos) as List<SeguridadPermiso>;
        //}
        //#endregion

        #region GetMenu
        public static String GetMenu(this HttpSessionState Session)
        {
            return (String)Get(Session, SessionKey.Menu);
        }

        public static String GetMenu(this HttpSessionStateBase Session)
        {
            return (String)Get(Session, SessionKey.Menu);
        }
        #endregion

       

        #region Private

        private static object Get(HttpSessionState Session, String Key)
        {
            return Session[Key];
        }

        private static void Set(HttpSessionState Session, String Key, object Value)
        {
            Session[Key] = Value;
        }

        private static bool Exists(HttpSessionState Session, String Key)
        {
            return Session[Key] != null;
        }

        private static object Get(HttpSessionStateBase Session, String Key)
        {
            return Session[Key];
        }

        private static void Set(HttpSessionStateBase Session, String Key, object Value)
        {
            Session[Key] = Value;
        }

        private static bool Exists(HttpSessionStateBase Session, String Key)
        {
            return Session[Key] != null;
        }

        #endregion

        #region Getters setters GlobalKey
        //HttpSessionState
        public static object Get(this HttpSessionState Session, SessionKey Key)
        {
            return Get(Session, Key);
        }

        public static void Set(this HttpSessionState Session, SessionKey Key, object Value)
        {
            Set(Session, Key.ToString(), Value);
        }

        public static bool Exists(this HttpSessionState Session, SessionKey Key)
        {
            return Exists(Session, Key.ToString());
        }

        //HttpSessionStateBase
        public static object Get(this HttpSessionStateBase Session, SessionKey Key)
        {
            return Get(Session, Key.ToString());
        }

        public static void Set(this HttpSessionStateBase Session, SessionKey Key, object Value)
        {
            Set(Session, Key.ToString(), Value);
        }

        public static bool Exists(this HttpSessionStateBase Session, SessionKey Key)
        {
            return Exists(Session, Key.ToString());
        }
        #endregion


    }
}