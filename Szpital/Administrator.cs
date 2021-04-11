using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Objects
{
    public class Administrator : Osoba
    {
        public Administrator(string imie, string nazwisko, long pesel, string nazwa_uzytkownika, string haslo):base(imie,nazwisko,pesel,nazwa_uzytkownika,haslo)
        {

        }

        public Administrator()
        {

        }

        public List<Osoba> Osoby { get; set; }
    }
}
