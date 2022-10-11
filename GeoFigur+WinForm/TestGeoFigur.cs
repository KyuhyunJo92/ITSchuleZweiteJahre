using System;
using System.Collections.Generic;
using System.Text;

namespace geometrische_Figuren
{
    class TestGeoFigur
    {
        //Der Typ von List muss List fuer IGeometrischeFigur.
        //z.B List<Kreis> Kreisen funktiniert nicht.

        private List<IGeometrischeFigur> Rechtecks;
        private List<IGeometrischeFigur> Quadrats;
        private List<IGeometrischeFigur> Kreisen;
        private Random rand = new Random();
        public List<IGeometrischeFigur> GetKreisen() { return Kreisen; }
        public List<IGeometrischeFigur> GetRechtecks() { return Rechtecks; }
        public List<IGeometrischeFigur> GetQuadrats() { return Quadrats; }
        //Konstruktor
        public TestGeoFigur()
        {
            Kreisen = new List<IGeometrischeFigur>();
            Rechtecks = new List<IGeometrischeFigur>();
            Quadrats = new List<IGeometrischeFigur>();
        }

        public void erstellenRandomKreise(int wieVielmal)
        {
            for (int i = 0; i < wieVielmal; i++)
            {
                Kreis newKreis = new Kreis(Math.Round(rand.NextDouble() * 10, 2));
                Kreisen.Add(newKreis);
            }
        }
        public void erstellenRandomRechteck(int wieVielmal)
        {
            for (int i = 0; i < wieVielmal; i++)
            {
                Rechteck newRechteck = new Rechteck(Math.Round(rand.NextDouble() * 10, 2), Math.Round(rand.NextDouble() * 10, 2));
                Rechtecks.Add(newRechteck);
            }
        }
        public void erstellenRandomQuadrat(int wieVielmal)
        {
            for (int i = 0; i < wieVielmal; i++)
            {
                Quadrat newQuadrat = new Quadrat(Math.Round(rand.NextDouble() * 10, 2));
                Quadrats.Add(newQuadrat);
            }
        }

        public void SehenAllenFlaecheninhaltDesFigurList(List<IGeometrischeFigur> geometrischesFiguren)
        {
            int counter = 0;
            foreach (IGeometrischeFigur geoFigur in geometrischesFiguren)
            {
                Console.WriteLine("{0}te {1}'s Flaecheninhalt : {2}",
                    counter,
                    geoFigur.GetArtDesFigur(),
                    Convert.ToString(geoFigur.BerechneFlaecheninhalt()));
                counter++;
            }
        }

        public void SehenAllenDetailDesObjekts(List<IGeometrischeFigur> geometrischesFiguren)
        {
            int counter = 0;
            foreach (IGeometrischeFigur geoFigur in geometrischesFiguren)
            {
                Console.WriteLine("{0}te {1}",counter,geoFigur.NamenDesFigurUndInhalten());
                counter++;
            }
        }
    }
}
