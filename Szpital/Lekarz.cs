using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Objects
{
    public class Lekarz : Osoba
    {
        public Lekarz(string imie, string nazwisko, long pesel, string nazwa_uzytkownika, string haslo, string specjalnosc, int numerpwz, List<bool> dyzur):base(imie, nazwisko, pesel, nazwa_uzytkownika, haslo)
        {
            this.Specjalnosc = specjalnosc;
            this.NumerPWZ = numerpwz;
            this.Dyzur = StworzListeDyzurow();
        }

        public Lekarz()
        {
            this.Imie = "";
            this.Nazwisko = "";
            this.Pesel = 0;
            this.NazwaUzytkownika = "";
            this.Haslo = "";
            this.Specjalnosc = "";
            this.NumerPWZ = 0;
            this.Dyzur = StworzListeDyzurow();
        }

        public string Specjalnosc { get; set; }
        public int NumerPWZ { get; set; }
        public List<bool> Dyzur { get; set; }

        public string InfoLekarz()
        {
            string wynik = ("Imię: " + Imie + "\nNazwisko: " + Nazwisko + "\nPesel: " + Pesel + "\nLogin:" + NazwaUzytkownika + "\nSpecjalizacja: " + Specjalnosc + "\nNumer PWZ: " + NumerPWZ);
            return wynik;
        }

        private List<bool> StworzListeDyzurow()
        {
            List<bool> wynik = new List<bool>();

            for (int i = 0; i < 30; i++)
            {
                wynik.Add(false);
            }

            return wynik;
        }

        public void WyswietlDyzuryLekarza()
        {
            for (int i = 1; i < 31; i++)
            {
                if (Dyzur[i - 1])
                {
                    Console.WriteLine("Masz dyżur " + i + " dnia");
                }
            }
        }
    }

}
