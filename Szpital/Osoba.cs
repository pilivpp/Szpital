using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Objects
{
    public class Osoba
    {
        public Osoba(string imie, string nazwisko, long pesel, string nazwa_uzytkownika, string haslo)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Pesel = pesel;
            this.NazwaUzytkownika = nazwa_uzytkownika;
            this.Haslo = haslo;
        }
        public Osoba()
        {

        }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public double Pesel { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Haslo { get; set; }

        public string InfoPracownik()
        {
            string wynik = ("Imie: " + Imie + " Nazwisko: " + Nazwisko + " Pesel: " + Pesel);
            return wynik;
        }
    }
}
