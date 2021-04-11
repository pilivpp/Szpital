using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.Objects;

namespace Szpital
{
    class Program
    {
        public static Lista Osoby;

        static void WczytajAdministratora()
        {
            Osoby.Add(new Administrator(imie: "Filip", nazwisko: "Andryszczyk", pesel: 94044404898, nazwa_uzytkownika:"Fil", haslo:"Med"));
        }

        static void Login()
        {
            string login;
            string haslo;
            bool PoprawnyLogin = false;

            Console.Clear();
            while (PoprawnyLogin == false)
            {
                Console.WriteLine("Witaj w panelu administracyjnym szpitala. W celu zalogowania się podaj login i hasło.");
                Console.Write("Login użytkownika: ");
                login = Console.ReadLine();

                foreach (var pracownik in Osoby.Administratorzy)
                {
                    if (login == pracownik.NazwaUzytkownika)
                    {
                        PoprawnyLogin = true;

                        Console.Write("Hasło użytkownika: ");
                        haslo = Console.ReadLine();
                        while (haslo != pracownik.Haslo)
                        {
                            Console.WriteLine("Błędne hasło");
                            haslo = Console.ReadLine();
                        }

                        FunkcjeAdministratora();
                    }
                }

                if (!PoprawnyLogin)
                {
                    foreach (var pracownik in Osoby.Lekarze)
                    {
                        if (login == pracownik.NazwaUzytkownika)
                        {
                            PoprawnyLogin = true;

                            Console.Write("Hasło użytkownika: ");
                            haslo = Console.ReadLine();
                            while (haslo != pracownik.Haslo)
                            {
                                Console.WriteLine("Błędne hasło");
                                haslo = Console.ReadLine();
                            }
                            FunkcjeLekarza(pracownik);
                        }
                    }
                }

                if (!PoprawnyLogin)
                {
                    foreach (var pracownik in Osoby.Pielegniarki)
                    {
                        if (login == pracownik.NazwaUzytkownika)
                        {
                            PoprawnyLogin = true;

                            Console.Write("Hasło użytkownika: ");
                            haslo = Console.ReadLine();
                            while (haslo != pracownik.Haslo)
                            {
                                Console.WriteLine("Błędne hasło");
                                haslo = Console.ReadLine();
                            }
                            FunkcjePielegniarka(pracownik);
                        }

                    }

                }

                Console.Clear();
                Console.WriteLine("Błędny login");
            }
            Console.Clear();
        }

        static void DodajAdministratora()
        {
            Administrator nowyAdmin = new Administrator();

            Console.WriteLine("Tworzenie konta administratora:");
            Console.WriteLine("Podaj imię:");
            nowyAdmin.Imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            nowyAdmin.Nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj pesel:");
            while (true)
            {
                try
                {
                    nowyAdmin.Pesel = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Podaj login:");
            nowyAdmin.NazwaUzytkownika = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            nowyAdmin.Haslo = Console.ReadLine();

            Osoby.Add(nowyAdmin);
            Console.WriteLine("Dane stworzonego konta administratora:");
            Console.WriteLine(nowyAdmin.InfoPracownik());
            Console.ReadKey();
        }

        static void DodajLekarza()
        {
            Lekarz nowyLekarz = new Lekarz();

            Console.WriteLine("Tworzenie konta lekarza:");
            Console.WriteLine("Podaj imie:");
            nowyLekarz.Imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            nowyLekarz.Nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj pesel:");

            while (true)
            {
                try
                {
                    nowyLekarz.Pesel = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Podaj login:");
            nowyLekarz.NazwaUzytkownika = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            nowyLekarz.Haslo = Console.ReadLine();
            Console.WriteLine("Podaj specjalizacje:");
            nowyLekarz.Specjalnosc = Console.ReadLine();
            Console.WriteLine("Podaj numer PWZ:");

            while (true)
            {
                try
                {
                    nowyLekarz.NumerPWZ = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Osoby.Add(nowyLekarz);
            Console.WriteLine("");
            Console.WriteLine("Dane stworzonego konta lekarza:");
            Console.WriteLine(nowyLekarz.InfoLekarz());
        }

        static void DodajPielegniarke()
        {
            Pielegniarka nowaPielengniarka = new Pielegniarka();

            Console.WriteLine("Tworzenie konta pielegniarki:");
            Console.WriteLine("Podaj imie:");
            nowaPielengniarka.Imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            nowaPielengniarka.Nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj pesel:");

            while (true)
            {
                try
                {
                    nowaPielengniarka.Pesel = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Podaj login:");
            nowaPielengniarka.NazwaUzytkownika = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            nowaPielengniarka.Haslo = Console.ReadLine();

            Osoby.Add(nowaPielengniarka);
            Console.WriteLine("");
            Console.WriteLine("Dane stworzonego konta pielęgniarki:");
            Console.WriteLine(nowaPielengniarka.InfoPielegniarka());
        }

        static void EdycjaAdministratora(Administrator administrator)
        {
            Console.WriteLine("Edycja danych administratora " + administrator.Imie + " " + administrator.Nazwisko);
            Console.WriteLine("Podaj nowe imie:");
            administrator.NazwaUzytkownika = Console.ReadLine();
            Console.WriteLine("Podaj nowe nazwisko:");
            administrator.Nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj nowy pesel:");
            while (true)
            {
                try
                {
                    administrator.Pesel = long.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Podaj nowy login:");
            administrator.NazwaUzytkownika = Console.ReadLine();
            Console.WriteLine("Podaj nowe hasło:");
            administrator.Haslo = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Nowe dane administratora:");
            Console.WriteLine(administrator.InfoPracownik());
            Console.ReadKey();
        }

        static void EdycjaLekarza(Lekarz lekarz)
        {
            Console.WriteLine("Edycja danych lekarza " + lekarz.Imie + " " + lekarz.Nazwisko);
            Console.WriteLine("Podaj nowe imie:");
            lekarz.Imie = Console.ReadLine();
            Console.WriteLine("Podaj nowe nazwisko:");
            lekarz.Nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj nowy pesel:");
            while (true)
            {
                try
                {
                    lekarz.Pesel = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    ; Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Podaj nowy login:");
            lekarz.NazwaUzytkownika = Console.ReadLine();
            Console.WriteLine("Podaj nowe hasło:");
            lekarz.Haslo = Console.ReadLine();
            Console.WriteLine("Podaj nową specjalizacje:");
            lekarz.Specjalnosc = Console.ReadLine();
            Console.WriteLine("Podaj nowy numer PWZ:");
            while (true)
            {
                try
                {
                    lekarz.NumerPWZ = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Nowe dane lekarza:");
            Console.WriteLine(lekarz.InfoLekarz());
            Console.ReadKey();
        }

        static void EdycjaPielegniarki(Pielegniarka pielegniarka)
        {
            Console.WriteLine("Edycja danych pielegniarki " + pielegniarka.Imie + " " + pielegniarka.Nazwisko);
            Console.WriteLine("Podaj nowe imie:");
            pielegniarka.Imie = Console.ReadLine();
            Console.WriteLine("Podaj nowe nazwisko:");
            pielegniarka.Nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj nowy pesel:");
            while (true)
            {
                try
                {
                    pielegniarka.Pesel = long.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Podaj nowy login:");
            pielegniarka.NazwaUzytkownika = Console.ReadLine();
            Console.WriteLine("Podaj nowe hasło:");
            pielegniarka.Haslo = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Nowe dane pielegniarki:");
            Console.WriteLine(pielegniarka.InfoPielegniarka());
            Console.ReadKey();
        }

        static void AministratorFunckjaEdycji()
        {
            string login;
            Console.WriteLine("Podaj login pracownika, którego chcesz edytować");
            login = Console.ReadLine();

            foreach (Administrator pracownik in Osoby.Administratorzy)
            {
                if (pracownik.NazwaUzytkownika == login)
                {
                    Console.WriteLine("Wybrano uzytkownika " + pracownik.NazwaUzytkownika);
                    Console.ReadKey();
                    Console.Clear();

                    EdycjaAdministratora(pracownik);
                }
            }

            foreach (Lekarz pracownik in Osoby.Lekarze)
            {
                if (pracownik.NazwaUzytkownika == login)
                {
                    Console.WriteLine("Wybrano uzytkownika " + pracownik.NazwaUzytkownika);
                    Console.ReadKey();
                    Console.Clear();

                    EdycjaLekarza(pracownik);
                }
            }

            foreach (Pielegniarka pracownik in Osoby.Pielegniarki)
            {
                if (pracownik.NazwaUzytkownika == login)
                {
                    Console.WriteLine("Wybrano uzytkownika " + pracownik.NazwaUzytkownika);
                    Console.ReadKey();
                    Console.Clear();

                    EdycjaPielegniarki(pracownik);
                }
            }
        }

        static void FunkcjeAdministratora()
        {
            for (; ;)
            {
                Console.Clear();
                int wybor;
                Console.WriteLine("Wybierz odpowiednią opcję: ");
                Console.WriteLine("1. Dodawanie nowych użytkowników");
                Console.WriteLine("2. Wyświetlanie listy użytkowników");
                Console.WriteLine("3. Edycja danych użytkowników");
                Console.WriteLine("4. Dodawnie dyżurów dla lekarzy i pielęgniarek");
                Console.WriteLine("5. Powrót do logowania");
                Console.WriteLine("");
                Console.WriteLine("0. Wyjście");

                while (true)
                {
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                switch (wybor)
                {
                    case 1:
                        {
                            int dodanie;
                            Console.Clear();
                            Console.WriteLine("W celu dodania użytkowników wbierz odpowiednią opcję: ");
                            Console.WriteLine("1. Dodanie administratora");
                            Console.WriteLine("2. Dodanie lekarza");
                            Console.WriteLine("3. Dodanie pielegniarki");
                            Console.WriteLine("");
                            Console.WriteLine("0. Powrót");

                            while (true)
                            {
                                try
                                {
                                    dodanie = int.Parse(Console.ReadLine());
                                    break;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }

                            switch (dodanie)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        DodajAdministratora();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.Clear();
                                        DodajLekarza();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        DodajPielegniarke();
                                        break;
                                    }
                                case 0:
                                    {
                                        FunkcjeAdministratora();
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Osoby.WyswietlPracownikow();
                            Console.ReadKey();
                            break;

                        }
                    case 3:
                        {
                            Console.Clear();
                            AministratorFunckjaEdycji();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            DodajDyzur();
                            break;
                        }
                    case 5:
                        {
                            Login();
                            break;
                        }
                    case 0:
                        {
                            System.Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        static void FunkcjeLekarza(Lekarz lekarz)
        {
            for (; ; )
            {
                Console.Clear();
                int wybor;
                Console.WriteLine("Wybierz odpowiednią opcję: ");
                Console.WriteLine("1. Dodanie administratora");
                Console.WriteLine("2. Dodanie lekarza");
                Console.WriteLine("3. Dodanie pielegniarki");
                Console.WriteLine("");
                Console.WriteLine("0. Wyjście");

                while (true)
                {
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                switch (wybor)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Lista Lekarzy i pielęgniarek: ");
                            Osoby.WyswietlLekarzyPielegniarki();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            lekarz.WyswietlDyzuryLekarza();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Login();
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            System.Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        static void FunkcjePielegniarka(Pielegniarka pielegniarka)
        {
            for (; ;)
            {
                Console.Clear();
                int wybor;
                Console.WriteLine("Wybierz odpowiednią opcję: ");
                Console.WriteLine("1. Wyświetlanie listy lekarzy i pielęgniarek");
                Console.WriteLine("2. Wyświetlanie dyżurów");
                Console.WriteLine("3. Powrót do logowania");
                Console.WriteLine("");
                Console.WriteLine("0. Wyjście");
                while (true)
                {
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                switch (wybor)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Lista lekarzy i pielęgniarek: ");
                            Osoby.WyswietlLekarzyPielegniarki();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            pielegniarka.WyswietlDyzuryPielegniarki();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Login();
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            System.Environment.Exit(0);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        static void DodajDyzur()
        {
            bool istnieje = false;
            while (istnieje == false)
            {
                Console.Clear();
                Console.WriteLine("Podaj login użytkownika, któremu chcesz dodać dyżur");

                string login = Console.ReadLine();

                Console.WriteLine("Wybierz dzień miesiąca od 1 do 30. Dni musisz podawać rosnąco");
                int dzienMiesiaca = 0;
                while (true)
                {
                    try
                    {
                        dzienMiesiaca = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Nieprawidłowy dzień");
                        break;
                    }
                }

                foreach (var pracownik in Osoby.Pielegniarki)
                {
                    if (login == pracownik.NazwaUzytkownika)
                    {
                        SprawdzenieDyzuru(pracownik.Dyzur, dzienMiesiaca);
                        pracownik.Dyzur[dzienMiesiaca - 1] = true;
                        istnieje = true;
                    }
                }
                foreach (var pracownik in Osoby.Lekarze)
                {
                    if (login == pracownik.NazwaUzytkownika)
                    {
                        istnieje = true;
                        if (SprawdzenieDyzuru(pracownik.Dyzur, dzienMiesiaca))
                        {
                            foreach (var lekarz in Osoby.Lekarze)
                            {
                                if (lekarz.Specjalnosc == pracownik.Specjalnosc)
                                {
                                    if (!lekarz.Dyzur[dzienMiesiaca - 1])
                                    {
                                        pracownik.Dyzur[dzienMiesiaca - 1] = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Inny lekarz o tej samej specjalizacji ma dyżur w tym dniu");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Podałeś błędny login");
            }
        }

        static bool SprawdzenieDyzuru(List<bool> dyzur, int dzien_miesiaca)
        {
            bool wynik = false;
            int ilosc_dyzurow = 0;
            foreach (var dzien in dyzur)
            {
                if (dzien == true)
                {
                    ilosc_dyzurow++;
                }
            }

            if (ilosc_dyzurow < 10)
            {
                if ((!dyzur[dzien_miesiaca - 2]) && (!dyzur[dzien_miesiaca - 1]) && (!dyzur[dzien_miesiaca]))
                {
                    wynik = true;
                }
                else
                {
                    Console.WriteLine("Nie możesz mieć w tym dniu dyżuru");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Wybrałeś już dni 10 dni dyżuru");
                Console.ReadKey();
            }
            return wynik;
        }

        static void Main(string[] args)
        {

            Osoby = new Lista();
            WczytajAdministratora();
            Login();
        }
    }
}
