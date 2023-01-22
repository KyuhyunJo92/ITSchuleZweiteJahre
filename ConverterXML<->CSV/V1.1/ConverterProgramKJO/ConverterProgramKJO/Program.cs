using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterProgramKJO
{
	class Program
	{

		static void Main(string[] args)
		{
			//schreiben Sie bitte einen Verzeichnis nur bis Ordner. 
			//z.B. string VerzeichnisOrdner = @"C: \IhreOrdner";
			string VerzeichnisOrdner = @"C: \Users\gogoo\source\repos\ConverterProgramKJO";
			
			//schreiben Sie bitte hier einen Verzeichnis von Person.csv, wo Sie Person.csv File gespeichert haben.
			//z.B. "D:\Person.csv"
			//string VerzeichnisCSV = @"C:\Users\gogoo\source\repos\ConverterProgramKJO\TestCSV6.csv";

			//schreiben Sie bitte hier einen Verzeichnis von Person.xml, wo Sie Person.xml File speicheren wollen.
			//z.B. "D:\Person.xml"
			
			string VerzeichnisXML = @"C:\Users\gogoo\source\repos\ConverterProgramKJO\TestXML5.xml";
			Converter converter = new Converter();

			//wenn Sie möchte CSV File zu XML File konvertieren.
			//converter.ConvertCSVtoXML(VerzeichnisCSV, VerzeichnisXML);
			converter.ConvertXMLtoCSV(VerzeichnisXML, VerzeichnisOrdner);
		}
	}
}
