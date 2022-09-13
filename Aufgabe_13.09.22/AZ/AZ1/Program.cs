using System;
using System.Collections.Generic;
using System.Text;
namespace Aufgabe4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NummerAndereRichtung(12345678));
        }
        static int NummerAndereRichtung(int zahl)
        {
            int result = 0;
            
            string strZahl = Convert.ToString(zahl);
            StringBuilder sb = new StringBuilder();
            string revZahl = string.Empty;
            Stack<char> stackStr= new Stack<char>();
            foreach(char el in strZahl)
            {
                stackStr.Push(el);   
            }
            while(stackStr.Count !=0)
            {
                sb.Append(stackStr.Pop());
            }
            revZahl = sb.ToString();
            result = Convert.ToInt32(revZahl);
            return result;
        }
    }
}
