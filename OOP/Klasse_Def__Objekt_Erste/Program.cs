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
            CAlbum ca = new CAlbum("kyuhyun's Erste Album","kyuhyun",1992);

            ca.Print();

        }
    }
    public class CAlbum
    {
        private string albumName;
        private string interpret;
        private int erscheinungsJahr;

        string[] Lieder = new string[10];
        
        //Constructor
        public CAlbum(string AlbumName,string Interpret, int ErscheinungsJahr)
        {
            albumName = AlbumName;
            interpret = Interpret;
            erscheinungsJahr = ErscheinungsJahr;
            SetLieder();
        }

        public void Print()
        {
            Console.WriteLine("AlbumName : {0}\n Published Year : {1} \n Singer Name : {2}",albumName,erscheunungsJahr,interpret);
        }
        public string LiedTitel(int N_teLiede)
        {
            StringBuilder LiedTitel = new StringBuilder();
            string res = string.Empty;
            
            foreach( string li in Lieder)
            {
                LiedTitel.Append(li);
            }
            return LiedTitel.ToString();
             
        }
        private void SetLieder()
        {
            foreach (string Li in Lieder)
            {
                Console.WriteLine("\nSchreiben Sie erste LiedTitel : ");
                Console.Read();
                Console.WriteLine("\nSchreiben Sie zweite LiedTitel : ");
                Console.Read();
                Console.WriteLine("\nSchreiben Sie dritte LiedTitel : ");
                Console.Read();
                Console.WriteLine("\nSchreiben Sie vierte LiedTitel : ");
                Console.Read();
                Console.WriteLine("\nSchreiben Sie fuenfte LiedTitel : ");
                Console.Read();
            }
        }
    }
}
