﻿using ProyectoFinal.Web.Infrastructure.Helpers;
using ProyectoFinal.Web.Models;
using ProyectoFinal.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Web.Controllers
{
    public class AccountController : Controller
    {
        private SmartSell db = new SmartSell();

        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Login()
        {
            if (HttpContext.Session["UserID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string passwordHash = Hasher.toSHA256(model.Password);
            Usuario usuario = db.Usuario.Where(u => u.Correo == model.Email && u.Clave == passwordHash).FirstOrDefault();
            if (usuario == null)
            {
                ModelState.AddModelError("loginError", "Las credenciales ingresadas no son válidas.");
                return View();
            }
            HttpContext.Session["UserID"] = usuario.UsuarioID;
            HttpContext.Session["Username"] = $"{usuario.Nombres} {usuario.Apellidos}";
            return RedirectToAction("Index", "Subastas");
        }

        public ActionResult Logout()
        {
            HttpContext.Session["UserID"] = null;
            HttpContext.Session["Username"] = null;
            return RedirectToAction("Login", "Account");
        }

        
    }
}