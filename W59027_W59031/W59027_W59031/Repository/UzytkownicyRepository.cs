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
                    db.Execute($"insert into Users (login,haslo,data_utworzenia) values ('{item.login}','{item.haslo}','{item.data_utworzenia}')");
                    db.Close();
                }
            }
        }
        public void EditUzytkownicy(Uzytkownicy item)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                db.Execute($"update Users set login='{item.login}',haslo='{item.haslo}' where id='{item.Id}'");
                db.Close();
            }
        }
        public IList<Uzytkownicy> GetUzytkownicy()
        {
            IList<Uzytkownicy> Uzytkownicy = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                Uzytkownicy = db.Query<Uzytkownicy>($"Select * from Users where login<>'admin'").ToList();
                db.Close();
            }
            return Uzytkownicy;
        }
        public Uzytkownicy GetUzytkownik(string id)
        {
            Uzytkownicy Uzytkownik = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                Uzytkownik = db.Query<Uzytkownicy>($"Select * from Users where id='{id}'").ToList()[0];
                db.Close();
            }
            return Uzytkownik;
        }
        public IList<Uzytkownicy> LoginUzytkownik(Uzytkownicy item)
        {
            IList<Uzytkownicy> Uzytkownicy = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                Uzytkownicy = db.Query<Uzytkownicy>($"Select * from Users where login='{item.login}' and haslo='{item.haslo}'").ToList();
                db.Close();
            }
            return Uzytkownicy;
        }
        public IList<Uzytkownicy> DelUzytkownik(string id)
        {
            IList<Uzytkownicy> Uzytkownicy = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                Uzytkownicy = db.Query<Uzytkownicy>($"delete Users where id='{id}'").ToList();
                db.Close();
            }
            return Uzytkownicy;
        }
    }
}