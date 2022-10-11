using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Jackie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Adat> lista = new List<Adat>();

            //2.Feladat
            using (StreamReader fajl = new StreamReader("jackie.txt", Encoding.UTF8))
            {
                fajl.ReadLine();
                while (!fajl.EndOfStream)
                {
                    lista.Add(new Adat(fajl.ReadLine()));
                }

            }

            //3.Feladat
            Console.WriteLine($"3.Feladat: {lista.Count}");

            //4.Feladat
            Console.WriteLine($"4.Feladat: {lista.First(x => x.Verseny == lista.Max(y => y.Verseny)).Ev}");

            //5.Feladat
            Console.WriteLine($"5.Feladat:\n\r\t60-as évek {lista.Where(x => x.Ev >= 1960 && x.Ev < 1970).Sum(y => y.Gyozelmek)} megnyert verseny\n\r\t70-as évek {lista.Where(x => x.Ev >= 1970 && x.Ev < 1980).Sum(y => y.Gyozelmek)} megnyert verseny");

            //6.Feladat
            using (StreamWriter html = new StreamWriter("jackie.html", false, Encoding.UTF8))
            {
                html.WriteLine("<!DOCTYPE html>");
                html.WriteLine("<html>");
                html.WriteLine("<head><style>td{border: solid 1px #000;}</style></head>");
                html.WriteLine("<body>");
                html.WriteLine("<h1>Jackie Stewart</h1>");
                html.WriteLine("<table border=\"1px\">");
                html.WriteLine("<thead><tr><th>Év</th><th>Versenyek száma</th><th>Győzelmek száma</th></tr></thead>");
                html.WriteLine("<tbody>");
                foreach (Adat item in lista.OrderBy(x => x.Ev))
                {
                    html.WriteLine($"\t\t\t\t<tr><td>{item.Ev}</td><td>{item.Verseny}</td><td>{item.Gyozelmek}</td></tr>");
                }
                html.WriteLine("</tbody>");
                html.WriteLine("</table>");
                html.WriteLine("</body>");
                html.WriteLine("</html>");
            }
            Console.WriteLine("6.Feladat: jackie.html");
            Console.ReadKey();
        }
        class Adat
        {
            int ev, verseny, gyozelmek, podium, gyors;

            public int Ev { get => ev; set => ev = value; }
            public int Verseny { get => verseny; set => verseny = value; }
            public int Gyozelmek { get => gyozelmek; set => gyozelmek = value; }
            public int Podium { get => podium; set => podium = value; }
            public int Gyors { get => gyors; set => gyors = value; }

            public Adat(int ev, int verseny, int gyozelmek, int podium, int gyors)
            {
                Ev = ev;
                Verseny = verseny;
                Gyozelmek = gyozelmek;
                Podium = podium;
                Gyors = gyors;
            }

            public Adat(string adatsor)
            {
                string[] adatok = adatsor.Split('\t');
                Ev = int.Parse(adatok[0]);
                Verseny = int.Parse(adatok[1]);
                Gyozelmek = int.Parse(adatok[2]);
                Podium = int.Parse(adatok[3]);
                Gyors = int.Parse(adatok[4]);
            }
        }
    }
}
