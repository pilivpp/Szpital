using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Objects
{
    public class Pielegniarka:Osoba
    {
        public Pielegniarka(string imie, string nazwisko, long pesel, string nazwa_uzytkownika, string haslo, List<bool> dyzur): base(imie, nazwisko, pesel, nazwa_uzytkownika, haslo)
        {       
            this.Dyzur = dyzur;
            this.Dyzur = StworzListeDyzurow();
        }

        public Pielegniarka()
        {
            this.Imie = "";
            this.Nazwisko = "";
            this.Pesel = 0;
            this.NazwaUzytkownika = "";
            this.Haslo = "";
            this.Dyzur = StworzListeDyzurow();
        }

        public List<bool> Dyzur { get; set; }

        public string InfoPielegniarka()
        {
            string wynik = ("Imię: " + Imie + "\nNazwisko: " + Nazwisko + "\nPesel: " + Pesel + "\nLogin:" + NazwaUzytkownika);
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

        public void WyswietlDyzuryPielegniarki()
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
