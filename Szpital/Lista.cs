using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Objects
{
    public class Lista
    {
        public Lista()
        {
            this.Administratorzy = new List<Administrator>();
            this.Lekarze = new List<Lekarz>();
            this.Pielegniarki = new List<Pielegniarka>();
        }

        public List<Administrator> Administratorzy { get; set; }
        public List<Lekarz> Lekarze { get; set; }
        public List<Pielegniarka> Pielegniarki { get; set; }

        public void Add(Administrator administrator)
        {
            this.Administratorzy.Add(administrator);
        }

        public void Add(Lekarz lekarz)
        {
            this.Lekarze.Add(lekarz);
        }

        public void Add(Pielegniarka pielengniarka)
        {
            this.Pielegniarki.Add(pielengniarka);
        }

        public void WyswietlLekarzy()
        {
            Console.WriteLine("Lista lekarzy: ");
            foreach (var lekarz in Lekarze)
            {
                Console.WriteLine(lekarz.InfoLekarz());
            }
        }

        public void WyswietlAdministratorow()
        {
            Console.WriteLine("Lista administratorów: ");
            foreach (var admin in Administratorzy)
            {
                Console.WriteLine(admin.InfoPracownik());
            }
        }
        public void WyswietlPielegniarki()
        {
            Console.WriteLine("Lista pielęgniarek: ");
            foreach (var pielegniarka in Pielegniarki)
            {
                Console.WriteLine(pielegniarka.InfoPielegniarka());
            }
        }
        public void WyswietlPracownikow()
        {
            WyswietlAdministratorow();
            Console.WriteLine("");
            WyswietlLekarzy();
            Console.WriteLine("");
            WyswietlPielegniarki();
        }
        public void WyswietlLekarzyPielegniarki()
        {
            WyswietlLekarzy();
            WyswietlPielegniarki();
        }


    }
}
