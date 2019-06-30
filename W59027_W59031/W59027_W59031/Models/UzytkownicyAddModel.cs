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
        public List<Uzytkownicy> Uzytkownicy;
        public UzytkownicyAddModel()
        {
            Uzytkownicy = new List<Uzytkownicy>();
            IList<Uzytkownicy> aaa = new UzytkownicyRepository().GetUzytkownicy();
            foreach (var a in aaa)
            {
                Uzytkownicy.Add(new Uzytkownicy()
                {
                    Id = a.Id,
                    login = a.login,
                    haslo = a.haslo,
                    data_utworzenia = a.data_utworzenia
                });
            }
        }
        public UzytkownicyAddModel(string id = "")
        {
            if (id != null && id != "" && id.Length > 0)
            {
                Uzytkownik = new UzytkownicyRepository().GetUzytkownik(id);
            }
            Uzytkownicy = new List<Uzytkownicy>();
            IList<Uzytkownicy> aaa = new UzytkownicyRepository().GetUzytkownicy();
            foreach (var a in aaa)
            {
                Uzytkownicy.Add(new Uzytkownicy()
                {
                    Id = a.Id,
                    login = a.login,
                    haslo = a.haslo,
                    data_utworzenia = a.data_utworzenia
                });
            }
        }
    }
}