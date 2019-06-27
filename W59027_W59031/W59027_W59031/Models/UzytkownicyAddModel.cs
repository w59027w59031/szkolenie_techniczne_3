using W59027_W59031.domain;
using W59027_W59031.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W59027_W59031.Models
{
    public class UzytkownicyAddModel
    {
        public Uzytkownicy Uzytkownik { get; set; }
        public List<SelectListItem> Uzytkownicy;
        public UzytkownicyAddModel()
        {
            Uzytkownicy = new List<SelectListItem>();
            IList<Uzytkownicy> aaa = new UzytkownicyRepository().GetUzytkownicy();
            foreach(var a in aaa)
            {
                Uzytkownicy.Add(new SelectListItem()
                {
                    Text = a.login,
                    Value = a.Id
                });
            }
        }
    }
}