using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_FIFA
{
    internal partial class Program
    {
        static List<Csapat> csapatok = new List<Csapat>();
        static void Main(string[] args)
        {
            Beolvasas();
            F01();
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
        }

        private static void F08()
        {
            var sw = new StreamWriter(@"..\..\RES\legtobbszor.txt", false, Encoding.UTF8);
            foreach (var csapat in csapatok)
            {
                if (csapat.ReszvetelekSzama >= 10)
                {
                    sw.WriteLine($"{csapat.Nev}: {DateTime.Today.Year - csapat.ElsoReszvetel}");
                }
            }
            sw.Close();
            Console.WriteLine($"\n8. Feladat: legtobbszor.txt kész!");
        }

        private static void F07()
        {
            var elsoVB = csapatok.OrderBy(x => x.ElsoReszvetel).First();
            var kijutottE = csapatok.Where(x => x.Nev == "Magyarország" && x.ElsoReszvetel == elsoVB.ElsoReszvetel).Count();
            if (kijutottE != 0)
            {
                Console.WriteLine("\n7. Feladat: Magyarország ott volt az első VB-n.");
            }
            else
            {
                Console.WriteLine("\n7. Feladat: Magyarország nem volt ott az első VB-n.");
            }
        }

        private static void F06()
        {
            var szlovakia = csapatok.Where(x => x.Nev == "Szlovákia").First();
            Console.WriteLine($"\n6. Feladat: Szlovákia legjobb eredménye: {szlovakia.LegjobbEredmeny}");
        }

        private static void F05()
        {
            var megnyertek = csapatok.Where(x => x.LegjobbEredmeny.Contains("Világbajnok")).Count();
            Console.WriteLine($"\n5. Feladat: Eddig {megnyertek} ország csapata volt vlágbajnok");
        }

        private static void F04()
        {
            var elsoVB = csapatok.OrderBy(x => x.ElsoReszvetel).First();
            Console.WriteLine($"\n4. Feladat: Az első VB-t {elsoVB.ElsoReszvetel}-ban rendezték");
           
        }

        private static void F03()
        {
            //Benelux országok = Belgium, Hollandia, Luxemburg
            var counter = 0;
            foreach (var csapat in csapatok)
            {
                if (csapat.Nev == "Belgium" || csapat.Nev == "Hollandia" || csapat.Nev == "Luxemburg")
                {
                    counter += csapat.ReszvetelekSzama;
                }
            }

            Console.WriteLine($"\n3. Feladat: A BeNeLux országok összesen {counter} alkalommal vettek részt a VB-n");
        }

        private static void F02()
        {
            Console.WriteLine("\n2. Feladat: A 2018-as VB-n az alábbi csapatok voltak kinn: ");
            var c = 0;
            foreach (var csapat in csapatok)
            {
                if (csapat.LegutobbiReszvetel == 2018)
                {
                    Console.Write("\t{0, -10}",csapat.Nev);
                    c+=1;
                }
                else
                {
                    continue;
                }
                if (c % 4 == 0)
                {
                    Console.WriteLine();
                }

            }
        }

        private static void F01()
        {
            Console.WriteLine($"1. Feladat: Csapatok száma: {csapatok.Count} ");
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader(@"..\..\RES\fociVBk.csv", Encoding.UTF8))
            {
                var fejlec = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    csapatok.Add(new Csapat(sr.ReadLine()));
                }
            }
        }
    }
}
