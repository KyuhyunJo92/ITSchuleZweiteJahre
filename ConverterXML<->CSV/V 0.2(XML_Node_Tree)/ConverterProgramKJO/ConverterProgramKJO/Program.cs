﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterProgramKJO
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	//schreiben Sie bitte hier einen Verzeichnis von Person.csv, wo Sie Person.csv File gespeichert haben.
		//	//z.B. "D:\Person.csv"
		//	string VerzeichnisCSV = @"Schreiben Sie hier einen Verzeichnis. bitte referenzieren Sie die obergeschribene Kommentare.";

		//	//schreiben Sie bitte hier einen Verzeichnis von Person.xml, wo Sie Person.xml File speicheren wollen.
		//	//z.B. "D:\Person.xml"
		//	string VerzeichnisXML = @"Schreiben Sie hier einen Verzeichnis. bitte referenzieren Sie die obergeschribene Kommentare.";

		//	Converter converter = new Converter();

		//	converter.AnmeldenPerson(converter.ReadCSV(VerzeichnisCSV));
		//	converter.MachenXMLFile(VerzeichnisXML, converter.writeXMLNode(converter.Personen));
		//}

		static void Main(string[] args)
		{
			//schreiben Sie bitte hier einen Verzeichnis von Person.csv, wo Sie Person.csv File gespeichert haben.
			//z.B. "D:\Person.csv"
			//string VerzeichnisCSV = @"D:\Visual Studio 2015 Repository\Projects\ConverterProgramKJO\Person.csv";

			//schreiben Sie bitte hier einen Verzeichnis von Person.xml, wo Sie Person.xml File speicheren wollen.
			//z.B. "D:\Person.xml"
			string VerzeichnisXML = @"D:\Visual Studio 2015 Repository\Projects\ConverterProgramKJO\PersonKJO.xml";
			//string VerzeichnisXML = @"D:\Visual Studio 2015 Repository\Projects\ConverterProgramKJO\TestXML.xml";
			//string VerzeichnisXML = @"D:\Visual Studio 2015 Repository\Projects\ConverterProgramKJO\TestXML2.xml";

			Converter converter = new Converter();

			//wenn Sie möchte CSV File zu XML File konvertieren.
			//converter.ConvertCSVtoXML(VerzeichnisCSV, VerzeichnisXML);

			//Test
			//converter.ReadXML(VerzeichnisXML);

			//Test2
			//converter.MakeAStringFromStrArr(converter.ReadXML(VerzeichnisXML));

			//Test3
			Node node = converter.NodeBaumPlanzen(converter.MakeAStringFromStrArr(converter.ReadXML(VerzeichnisXML)));
		}
	}
}
