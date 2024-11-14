using LagerApplikation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lager> LagerList = new List<Lager>();
            List<Artikel> ArtikelList = new List<Artikel>();

            while (true) { MainFunction(); Console.Clear(); }

            void MainFunction() {

                Console.WriteLine("Guten Tag. Bitte geben sie den entsprechende Ziffer ein.");

                Console.WriteLine();

                Console.WriteLine("Lager hinzufügen: \t\t 1");
                Console.WriteLine("Artikel Umschieben: \t\t 2");
                Console.WriteLine("Artikel einbuchen: \t\t 3");
                Console.WriteLine("Artikel ausbuchen: \t\t 4");
                Console.WriteLine("Artikel suchen: \t\t 5");

                Console.WriteLine();



                switch (Convert.ToByte(Console.ReadLine()))
                {

                    case (1):
                        createLager();
                        break;
                    case (2):
                        MoveArtikel();
                        break;
                    case (3):
                        createArtikel();
                        break;
                    case (4):
                        deleteArtikel();
                        break;
                    case (5):
                        LookForArtikel();
                        break;

                }
            } 

            void createLager() {

                string valueTemp = "";
                Lager m = new Lager();

                Console.Write("Geben sie den Namen des Lagers ein: ");

                valueTemp = Console.ReadLine();

                m._LagerName = valueTemp;

                if(LagerList.Find(a => a._LagerName == valueTemp) == null) LagerList.Add(m);

                Console.Clear();    
                
            }


            void createArtikel()
            {

                string valueTemp = "";
                int numberTemp = 0;
                Artikel m = new Artikel();

                Console.Write("Geben sie den Namen des Artikels ein: ");
                
                valueTemp = Console.ReadLine();

                m._ArtikelName = valueTemp;

                do
                {
                    Console.Write("Geben sie den Id des Artikels ein: ");

                    valueTemp = Console.ReadLine();

                } while (int.TryParse(valueTemp, out numberTemp) == false);

                m._ArtikelIdIntern = numberTemp;


                    Console.Write("Geben sie den Lieferanten des Artikels ein: ");

                    valueTemp = Console.ReadLine();

                    m._Lieferant = valueTemp;


                do { 

                    Console.Write("Geben sie die Anzahl des Artikels ein: ");

                    valueTemp = Console.ReadLine();


                } while (int.TryParse(valueTemp, out numberTemp) == false) ;

                    m._Amount = numberTemp;


                do {

                    Console.Write("Geben sie die Grösse in Meter des Artikels ein: ");

                    valueTemp = Console.ReadLine();

                } while (int.TryParse(valueTemp, out numberTemp) == false);

                    m._SizeInMeter = numberTemp;

                do
                {

                    Console.Write("Geben sie die Grösse in Liter des Artikels ein: ");

                    valueTemp = Console.ReadLine();

                } while (int.TryParse(valueTemp, out numberTemp) == false);

                    m._SizeInLiter = numberTemp;

                do
                {
                    Console.Write("Wo soll sie gespeichert werden? (Name des Lagers eingeben): ");

                    valueTemp = Console.ReadLine();

                } while (LagerList.Find(r => r._LagerName == valueTemp) == null);


                Lager FoundLager = LagerList.Find(r => r._LagerName == valueTemp);

                FoundLager._ArtikelStock.Add(m);

                Console.Clear();

            }

            void deleteArtikel()
            {
                int valueTemp = 0;
                string SpecLager = "";
                int numberTemp = 0;
                int removeAmount = 0;

                do { 

                    Console.Write("Geben sie den Artikel Id ein: ");

                } while (int.TryParse(Console.ReadLine(), out numberTemp) == false) ;

                    valueTemp = numberTemp;

                    Console.Write("Geben sie den Lagernamen ein: ");

                    SpecLager = Console.ReadLine();

                do
                {

                    Console.Write("Geben sie die zu entfernende Anzahl ein: ");

                } while (int.TryParse(Console.ReadLine(), out numberTemp) == false);

                removeAmount = numberTemp;


                foreach (Lager m in LagerList)
                {

                    if (m._LagerName == SpecLager)
                    {
                        Artikel FoundArtikel = m._ArtikelStock.Find(a => a._ArtikelIdIntern == valueTemp);
                        int index = m._ArtikelStock.FindIndex(a => a._ArtikelIdIntern == valueTemp);

                        if (index != -1)
                        {
                            if (removeAmount > FoundArtikel._Amount) m._ArtikelStock.RemoveAt(index);
                            else FoundArtikel._Amount -= removeAmount;
                        }
                    }


                }

                Console.Clear();
            }

            void LookForArtikel() {

                int numberTemp = 0;
                string valueTemp = "";

                do { 

                Console.Write("Geben sie den Artikel Id ein: ");

                valueTemp = Console.ReadLine();

                } while (int.TryParse(valueTemp, out numberTemp) == false) ;

            foreach (Lager m in LagerList)
                {

                    if (m._ArtikelStock.Find(a => a._ArtikelIdIntern == numberTemp) != null) {

                        Artikel FoundArtikel = m._ArtikelStock.Find(a => a._ArtikelIdIntern == numberTemp);

                        Console.WriteLine("Artikelname: \t\t" + FoundArtikel._ArtikelName);
                        Console.WriteLine("Artikel Id Intern: \t" + FoundArtikel._ArtikelIdIntern);
                        Console.WriteLine("Lieferant: \t\t" + FoundArtikel._Lieferant);
                        Console.WriteLine("Anzahl: \t\t" + FoundArtikel._Amount);
                        Console.WriteLine("Meter: \t\t\t" + FoundArtikel._SizeInMeter);
                        Console.WriteLine("Liter: \t\t\t" + FoundArtikel._SizeInLiter);
                        Console.WriteLine("Gefunden in: \t\t" + m._LagerName);

                        Console.WriteLine();
                        Console.WriteLine("Enter drücken zum fortfahren...");   

                    }
                }

                Console.ReadLine();
                Console.Clear();

            }

            void MoveArtikel()
            {
                string valueTemp;
                int numberTemp;
                string LagerName;
                string destinationLager;
                int amountRemove;

                bool isFound = false;


                do
                {

                    Console.Write("Geben sie den Artikel Id ein: ");

                    valueTemp = Console.ReadLine();

                } while (int.TryParse(valueTemp, out numberTemp) == false);

                foreach (Lager m in LagerList) {
                    if (m._ArtikelStock.Find(a => a._ArtikelIdIntern == numberTemp) != null) isFound = true;
                }

                if (isFound == false) return;

                Console.Write("Von wo wollen sie es verschieben? (Lagername eingeben): ");

                LagerName = Console.ReadLine();

                if (LagerList.Find(a => a._LagerName == LagerName) == null) return;

                Console.Write("Wie viel wollen sie verschieben: ");

                amountRemove = Convert.ToInt32(Console.ReadLine());

                Console.Write("Wohin wollen sie es verschieben? (Lagername eingeben): ");

                destinationLager = Console.ReadLine();

                if (LagerList.Find(a => a._LagerName == destinationLager) == null) return;


                Lager FoundLager = LagerList.Find(a => a._LagerName == LagerName);

                Artikel FoundArtikel = FoundLager._ArtikelStock.Find(a => a._ArtikelIdIntern == numberTemp);

                Lager FoundDestinationlager = LagerList.Find(a => a._LagerName == destinationLager);

                Artikel FoundDestinationArtikel = FoundDestinationlager._ArtikelStock.Find(a => a._ArtikelIdIntern == numberTemp);

                FoundArtikel._Amount -= amountRemove;

                if (FoundDestinationlager._ArtikelStock.Find(a => a._ArtikelIdIntern == numberTemp) == null) {

                    Artikel fgh = new Artikel();
                    fgh._ArtikelName = FoundArtikel._ArtikelName;
                    fgh._ArtikelIdIntern = FoundArtikel._ArtikelIdIntern;
                    fgh._Lieferant = FoundArtikel._Lieferant;
                    fgh._Amount = amountRemove;
                    fgh._SizeInLiter = FoundArtikel._SizeInLiter;
                    fgh._SizeInMeter = FoundArtikel._SizeInMeter;
                    FoundDestinationlager._ArtikelStock.Add(fgh);
                }
                else
                    {
                    FoundDestinationArtikel._Amount += amountRemove;
                    }

                if (FoundLager._ArtikelStock.Find(a => a._ArtikelIdIntern == numberTemp)._Amount <= 0) {
                    FoundLager._ArtikelStock.RemoveAt(FoundLager._ArtikelStock.FindIndex(a => a._ArtikelIdIntern == FoundArtikel._ArtikelIdIntern));
                }

                Console.Clear();

            }

        }
    }
}
