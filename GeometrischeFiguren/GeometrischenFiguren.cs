using System;
using System.Collections.Generic;
using System.Text;

namespace geometrische_Figuren
{
    interface IGeometrischeFigur
    {
        double BerechneFlaecheninhalt();
        string NamenDesFigurUndInhalten();
        string GetArtDesFigur();
    }


    class Rechteck : IGeometrischeFigur
    {
        double breite;
        double laenge;

        //konstrukt
        public Rechteck(double Breite, double Laenge) { breite = Breite; laenge = Laenge; }

        public double BerechneFlaecheninhalt()
        {
            double flaechen = Math.Round(breite * laenge * 0.5,5);
            return flaechen;
        }

        public void SetNewBreite(double NewBreite) { breite = NewBreite; }
        public void SetNewLaenge(double NewLaenge) { laenge = NewLaenge; }
        public string NamenDesFigurUndInhalten()
        {
            string str;
            string sBreite = Convert.ToString(breite);
            string sLaenge = Convert.ToString(laenge);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Rechteck({0},{1})", sBreite, sLaenge);
            str = sb.ToString();
            return str;
        }
        public string GetArtDesFigur() { return "Rechteck"; }
    }



    class Quadrat : IGeometrischeFigur
    {
        double seitenLaenge;

        //konstrukt
        public Quadrat(double SeitenLaenge) { seitenLaenge = SeitenLaenge; }

        public double BerechneFlaecheninhalt()
        {
            double flaechen = Math.Round(seitenLaenge * seitenLaenge,5);
            return flaechen;
        }

        public void SetNewSeitenLaenge(double NewSeitenLaenge) { seitenLaenge = NewSeitenLaenge; }

        public string NamenDesFigurUndInhalten()
        {
            string str;
            string sSeitenLaenge = Convert.ToString(seitenLaenge);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Quadrat({0})", sSeitenLaenge);
            str = sb.ToString();
            return str;
        }
        public string GetArtDesFigur() { return "Quadrat"; }

    }



    class Kreis : IGeometrischeFigur
    {
        double radius;

        //konstrukt
        public Kreis(double Radius) { radius = Radius; }

        public double BerechneFlaecheninhalt()
        {
            double flaechen = Math.Round(radius * Constants.pi,5);
            return flaechen;
        }
        public void SetNewRadius(double NewRadius) { radius = NewRadius; }
        public string NamenDesFigurUndInhalten()
        {
            string str;
            string sRadius = Convert.ToString(radius);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Kreis({0})", sRadius);
            str = sb.ToString();
            return str;
        }
        public string GetArtDesFigur() { return "Kreis"; }
    }
}
