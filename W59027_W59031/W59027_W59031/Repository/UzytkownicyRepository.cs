using Dapper;
using W59027_W59031.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace W59027_W59031.Repository
{
    public class UzytkownicyRepository
    {
        public void AddUzytkownicy(Uzytkownicy item)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                if (item.login != null && item.login != "" && item.login.Length > 0 && item.haslo != null && item.haslo != "" && item.haslo.Length > 0)
                {
                    db.Open();
                    db.Execute($"insert into Uzytkownicy (Id,login,haslo,data_utworzenia) values ('1','{item.login}','{item.haslo}','{DateTime.Now.ToUniversalTime().ToString()}')");
                    db.Close();
                }
            }
        }
        public IList<Uzytkownicy> GetUzytkownicy()
        {
            IList<Uzytkownicy> Uzytkownicy = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                Uzytkownicy = db.Query<Uzytkownicy>($"Select * from Uzytkownicy").ToList();
                db.Close();
            }
            return Uzytkownicy;
        }
        public IList<Uzytkownicy> LoginUzytkownik (Uzytkownicy item)
        {
            IList<Uzytkownicy> Uzytkownicy = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                Uzytkownicy = db.Query<Uzytkownicy>($"Select * from Uzytkownicy where login='{item.login}' and haslo='{item.haslo}'").ToList();
                db.Close();
            }
            return Uzytkownicy;
        }
    }
}