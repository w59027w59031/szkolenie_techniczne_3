using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W59027_W59031.domain
{
    public class Uzytkownicy
    {
        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        private string _login;
        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        private string _haslo;
        public string haslo
        {
            get
            {
                return _haslo;
            }
            set
            {
                _haslo = value;
            }
        }
        private string _data_utworzenia;
        public string data_utworzenia
        {
            get
            {
                return _data_utworzenia;
            }
            set
            {
                _data_utworzenia = value;
            }
        }
    }
}