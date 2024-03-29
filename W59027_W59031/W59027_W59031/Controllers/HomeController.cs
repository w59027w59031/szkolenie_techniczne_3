﻿using W59027_W59031.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W59027_W59031.domain;
using W59027_W59031.Repository;

namespace W59027_W59031.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UzytkownicyAddModel Ab = new UzytkownicyAddModel();
            return View(Ab);
        }
        public ActionResult IndexLogged(string ID, string DelEd)
        {
            if (ID != null && ID != "" && ID.Length > 0) {
                if (DelEd != null && DelEd != "" && DelEd.Length > 0) {
                    if (DelEd == "0")
                    {
                        new UzytkownicyRepository().DelUzytkownik(ID);
                    }
                    else
                    {
                        var Uzytkownik = new UzytkownicyRepository().GetUzytkownik(ID);

                        if (!ModelState.IsValid)
                        {
                            return View(Uzytkownik);
                        }

                        new UzytkownicyRepository().EditUzytkownicy(Uzytkownik);
                        return RedirectToAction("IndexLogged");
                    }
                }
            }
            UzytkownicyAddModel Ab = new UzytkownicyAddModel();
            return View(Ab);
        }
        public ActionResult IndexRegister()
        {
            UzytkownicyAddModel Ab = new UzytkownicyAddModel();
            return View(Ab);
        }
        public ActionResult IndexEdit(string ID)
        {
            UzytkownicyAddModel Ab = new UzytkownicyAddModel(ID);
            return View(Ab);
        }
        [HttpPost]
        public ActionResult Index(UzytkownicyAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Uzytkownik = new Uzytkownicy();
            Uzytkownik.Id = model.Uzytkownik.Id;
            Uzytkownik.login = model.Uzytkownik.login;
            Uzytkownik.haslo = model.Uzytkownik.haslo;
            //
            IList<Uzytkownicy> logowany = new UzytkownicyRepository().LoginUzytkownik(Uzytkownik);
            if (logowany.Count > 0)
            {
                return RedirectToAction("IndexLogged");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult IndexLogged(UzytkownicyAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Uzytkownik = new Uzytkownicy();
            Uzytkownik.Id = model.Uzytkownik.Id;
            Uzytkownik.login = model.Uzytkownik.login;
            Uzytkownik.haslo = model.Uzytkownik.haslo;
            //
            IList<Uzytkownicy> logowany = new UzytkownicyRepository().LoginUzytkownik(Uzytkownik);
            if (logowany.Count > 0)
            {
                return RedirectToAction("IndexLogged");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult IndexRegister(UzytkownicyAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Uzytkownik = new Uzytkownicy();
            Uzytkownik.Id = model.Uzytkownik.Id;
            Uzytkownik.login = model.Uzytkownik.login;
            Uzytkownik.haslo = model.Uzytkownik.haslo;
            //
            new UzytkownicyRepository().AddUzytkownicy(Uzytkownik);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult IndexEdit(UzytkownicyAddModel model)
        {
            if (!ModelState.IsValid)
            {
                UzytkownicyAddModel uzytkownicyAddModel = new UzytkownicyAddModel(model.Uzytkownik.Id);
                uzytkownicyAddModel = model;
                uzytkownicyAddModel.Uzytkownik = new Uzytkownicy();
                uzytkownicyAddModel.Uzytkownik.Id = "test";
                return View(uzytkownicyAddModel);
            }
            var Uzytkownik = new Uzytkownicy();
            Uzytkownik.Id = model.Uzytkownik.Id;
            Uzytkownik.login = model.Uzytkownik.login;
            Uzytkownik.haslo = model.Uzytkownik.haslo;
            //
            new UzytkownicyRepository().EditUzytkownicy(Uzytkownik);
            return RedirectToAction("IndexLogged");

        }
        [HttpPost]
        public ActionResult IndexUsun(string ID)
        {
            new UzytkownicyRepository().DelUzytkownik(ID);
            return RedirectToAction("Index");

        }
    }
}