using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace geometrische_Figuren
{
    class Rechteck : IGeometrischeFigur
    {
        double breite;
        double hoehe;
        public int xAxis=0;
        public int yAxis=0;
        Brush farbe = Brushes.White;

        //konstrukt
        public Rechteck(double Breite, double Laenge) { breite = Breite; hoehe = Laenge; }

        public Rechteck(int x, int y, double Breite, double Laenge, Brush Farbe) 
        {
            xAxis = x;
            yAxis = y;
            breite = Breite;
            hoehe = Laenge;
            farbe = Farbe;
        }
        public double BerechneFlaecheninhalt()
        {
            double flaechen = Math.Round(breite * hoehe * 0.5, 5);
            return flaechen;
        }

        public void SetNewBreite(double NewBreite) { breite = NewBreite; }
        public void SetNewLaenge(double NewLaenge) { hoehe = NewLaenge; }
        public string NamenDesFigurUndInhalten()
        {
            string str;
            string sBreite = Convert.ToString(breite);
            string sLaenge = Convert.ToString(hoehe);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Rechteck({0},{1})", sBreite, sLaenge);
            str = sb.ToString();
            return str;
        }
        public string GetArtDesFigur() { return "Rechteck"; }
        public void Paint(Graphics g)
        {
            g.DrawRectangle(new Pen(farbe), xAxis, yAxis, (float)breite,(float)hoehe);
        }
    }



    class Quadrat : IGeometrischeFigur
    {
        double seitenLaenge;

        public int xAxis=0;
        public int yAxis=0;
        Brush farbe = Brushes.White;
        //konstrukt
        public Quadrat(double SeitenLaenge) { seitenLaenge = SeitenLaenge; }
        public Quadrat(int x, int y, double SeitenLaenge, Brush Farbe)
        {
            xAxis = x;
            yAxis = y;
            seitenLaenge = SeitenLaenge;
            farbe = Farbe;
        }
        public double BerechneFlaecheninhalt()
        {
            double flaechen = Math.Round(seitenLaenge * seitenLaenge, 5);
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
        public void Paint(Graphics g) { g.FillRectangle(farbe, xAxis, yAxis, (float)seitenLaenge, (float)seitenLaenge); }
    }



    class Kreis : IGeometrischeFigur
    {
        double radius;

        public int xAxis=0;
        public int yAxis=0;
        Brush farbe = Brushes.White;
        //konstrukt
        public Kreis(double Radius) { radius = Radius; }
        public Kreis(int x, int y, double Radius, Brush Farbe)
        {
            xAxis = x;
            yAxis = y;
            radius = Radius;
            farbe = Farbe;
        }
        public double BerechneFlaecheninhalt()
        {
            double flaechen = Math.Round(radius*radius * Constants.pi, 5);
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
        public void Paint(Graphics g) { g.FillEllipse(farbe, xAxis, yAxis, (float)radius + (float)radius, (float)radius + (float)radius); }
    }
}
