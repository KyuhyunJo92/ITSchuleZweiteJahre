using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CD_Album
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CAlbum ca = new CAlbum("kyuhyun's Erste Album", "kyuhyun", 1992);

            ca.SetLieder("LiedA", 10);
            ca.SetLieder("LiedB", 7);

            ca.SetLieder("LiedC", 4);

            ca.SetLieder("LiedD", 3);

            Console.WriteLine("Laenge Von Allem LaufZeit Album {0} ist {1}Sekunden.",ca.getName(),ca.AddAllenLaufZeitVomLieder());


        }
    }
    public class Lied
    {
        public Lied(string name, int laufZeit)
        {
            Name = name;
            LaufZeit = laufZeit;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int laufZeit;

        public int LaufZeit
        {
            get { return laufZeit; }
            set { laufZeit = value; }
        }

    }
    public class CAlbum
    {
        private string albumName;
        private string interpret;
        private int erscheinungsJahr;

        List<Lied> Lieder = new List<Lied>();

        //Constructor
        public CAlbum(string AlbumName, string Interpret, int ErscheinungsJahr)
        {
            albumName = AlbumName;
            interpret = Interpret;
            erscheinungsJahr = ErscheinungsJahr;
        }

        public void Print()
        {
            Console.WriteLine("AlbumName : {0}\n Published Year : {1} \n Singer Name : {2}", albumName, erscheinungsJahr, interpret);
        }
        public string getName()
        {
            return albumName;
        }
        public void SetLieder(string liedName, int laufZeit)
        {
            Lied newLied = new Lied(liedName, laufZeit);
            Lieder.Add(newLied);
        }

        public int AddAllenLaufZeitVomLieder()
        {
            int ergebnisVonAddien = 0;
            foreach(Lied el in Lieder)
            {
                ergebnisVonAddien += el.LaufZeit;
            }
            return ergebnisVonAddien;
        }
    }
}