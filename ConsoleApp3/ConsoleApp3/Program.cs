using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp3
{
    class konyv 
    {
        public string cime { get; set; }
        public string iroja { get; set; }
        public int oldalSzam { get; set; }

        public konyv(string s)
        {
            var fasz = s.Split(';');
            this.cime = fasz[0];
            this.iroja = fasz[1];
            this.oldalSzam = int.Parse(fasz[2]);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader("konyvek.txt");
            List<konyv> konyvek = new List<konyv>();

            while (!sr.EndOfStream) 
            {
                string sor = sr.ReadLine();
                var konyv = new konyv(sor);
                konyvek.Add(konyv);
            }

            int osszes = konyvek.Sum(k => k.oldalSzam);
            int max = konyvek.Max(k => k.oldalSzam);
            int min = konyvek.Min(k => k.oldalSzam);

            var asd = konyvek.Where(k => k.oldalSzam == 100).Select(k => k.cime).First();

            Console.WriteLine($"{osszes} az oldalak összege");
            Console.WriteLine($"{max} oldalas a leghoszabb könyv");
            Console.WriteLine($"{min} oldalas a legrövidebb könyv");

            Console.WriteLine(asd);

            Console.ReadKey();

        }
    }
}
