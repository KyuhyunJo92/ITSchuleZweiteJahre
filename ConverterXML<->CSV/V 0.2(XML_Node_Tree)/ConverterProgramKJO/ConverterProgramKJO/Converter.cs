﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConverterProgramKJO
{
	class Converter
	{
		public void ConvertCSVtoXML(string pathOfCSVFile_import, string pathOfXMLFile_export)
		{
			//Lesen CSV File
			string[] strArr = ReadCSV(pathOfCSVFile_import);

			//Struktrieren Dateien als Person Typ
			CSVAnmeldenPerson(strArr);

			//schreiben mit Personen Einen XMLNode
			string xmlNode = writeXMLNode(Personen);

			//exportieren XML File
			File.WriteAllText(pathOfXMLFile_export, xmlNode);
		}

		private List<Person> Personen = new List<Person>();
		private string[] ReadCSV(string Verzeichnis)
		{
			string[] str = File.ReadAllLines(Verzeichnis);
			return str;
		}
		public string[] ReadXML(string Verzeichnis)
		{
			string[] str = File.ReadAllLines(Verzeichnis);
			return str;
		}
		public string MakeAStringFromStrArr(string[] strArr)
		{
			string res = string.Empty;
			foreach (string str in strArr)
			{
				res += str;
			}
			return res;
		}

		//*****Funktionsweise***** NodeBaumPlanzen()
		//<Parent>
		//	<Child_1>                      |von hier
		//		<Onkel_1>...</Onkel_1>      |                                                    |von hier
		//		<Onkel_2>...</Onkel_2>      |                                                    |bis hier ist der teil1
		//	</Child_1>                     |
		//	<Child_2>                      |
		//		<Onkel_3>...</Onkel_3>      |                                                    |von hier
		//		<Onkel_4>...</Onkel_4>      |                                                    |bis hier ist der teil2
		//	</Child_2>                     |bis hier ist "Ganze_Satz_der_inhalt_der_string_1".
		//</Parent>
		//
		//1. machen einen Node "node_1" mit Konstruktor der Class Node.
		//2. nehmen den Title"Parent" in der Erste Klammer "<Parent>" und schreiben den Title auf indeNodeTitle.
		//3. wenn es keins "<" oder ">" und nur string gibt, einfach speichern den string als "node_1.NodeInhalt".
		//4. wenn es mindestens ein "<" oder ">" gibt, aufrufen NodeBaumPlanzen(inhalt_der_string).
		//5. Geben "node_1" zurück. 

		public Node NodeBaumPlanzen(string gelesendeneXMLstr)
		{
			//1. machen einen Node "node_1" mit Konstruktor der Class Node. das wird Rückgabe sein.
			Node TheNode = new Node();

			//2. 
			TheNode.info = AusfuellenAllInfoOfNode(gelesendeneXMLstr);

			//3. Wenn "TheNode.info.
			//überprufen, ob "inhalt_der_string_1" null ist.

			//내용물이 있고,
			if (TheNode.info.AnzahlKinderUndInhalts != null)
			{
				//자식이 있다면
				if (TheNode.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
				{
					//자식의 숫자만큼 반복하면서,
					for (int i = 0; i < TheNode.info.AnzahlKinderUndInhalts.schnideteInhalts.Count; i++)
					{
						//Fügen ChildNode. Dafür benutzen wir "rekursive Funktion".(weil ChildNode auch ihre KindNode haben können.)
						//TheNode.ChildNodes.Add(NodeBaumPlanzen(TheNode.info.stringEtwasZwischenNode));
						TheNode.ChildNodes.Add(NodeBaumPlanzen(TheNode.info.AnzahlKinderUndInhalts.schnideteInhalts[i]));
					}
				}
				//내용물은 있는데 그 내용물이 자식이 아니라면 항목(element)가 있다고 판단. ex)<Name>Schmidt</Name>처럼..
			}
			//5. Geben "TheNode" zurück. 
			return TheNode;
		}


		private InfoOfNode AusfuellenAllInfoOfNode(string StringEinNodeDerXML)
		{
			InfoOfNode infoOfNode = new InfoOfNode();

			//아마도 처음 받아온 스트링에 노드는 딱 한개여야겠지? <Alle>...</Alle>처럼 말이지.
			//받아온 스트링을 처음부터 끝까지 보면서 일하는거지.
			//과제는 노드의 시작부분괄호와 끝부분괄호의 위치를 찾는거야.
			for (int index = 0; index < StringEinNodeDerXML.Length; index++)
			{
				//만약에 노드시작을 의미하는 '<'를 만나면
				if (StringEinNodeDerXML[index] == '<')
				{
					//판단할 수 있겠지? 지금 보고있는 스트링에는 적어도 한개의 노드가 있다는것을
					infoOfNode.gibtEsNeueNodeInGeradeArbeitendeString = true;

					infoOfNode.index_Vor_AnfangNode = index;
					//StringGeradeArbeit[index+1]이 바로 '>'이어서는 안된다.
					if (StringEinNodeDerXML[index + 1] == '>') { Console.WriteLine("Falsche XML File."); break; }
					else
					{
						for (int index_2 = index + 2; index_2 < StringEinNodeDerXML.Length - index - 2; index_2++)
						{
							if (StringEinNodeDerXML[index_2] == '>')
							{
								infoOfNode.index_Hinter_AnfangNode = index_2;
								break;
							}
						}
						break;
					}
				}
			}
			//지금 일하고 있는 스트링에 새로운 노드가 있다면 작업을 하면돼. 사실 이 조건문이 없어도 상관없지만
			//런타임중에 반복문이 시간을 낭비하는것을 방지하고자 이 조건문을 넣은거야
			if (infoOfNode.gibtEsNeueNodeInGeradeArbeitendeString)
			{
				//일단 노드의 이름을 저장하고,
				infoOfNode.title_Node = StringEinNodeDerXML.Substring(infoOfNode.index_Vor_AnfangNode + 1, infoOfNode.index_Hinter_AnfangNode - 1);
				//그 노드의 이름을 가지고 
				//<aa>aa</aa> -> for(int index = 3+1;index<11-1;
				for (int index = infoOfNode.index_Hinter_AnfangNode + 1; index < StringEinNodeDerXML.Length - 1; index++)
				{
					//정확히 </infoOfNode.title_Node>이 나오는곳을 찾으면,
					//ex) <aa>aa</aa>, index = 6
					//6, 7, substring(8,2), 
					string strGerade = string.Empty;
					strGerade += StringEinNodeDerXML[index];
					strGerade += StringEinNodeDerXML[index + 1];
					strGerade += StringEinNodeDerXML.Substring(index + 2, infoOfNode.title_Node.Length);
					strGerade += StringEinNodeDerXML[index + infoOfNode.title_Node.Length + 2];
					string strZiel = "</" + infoOfNode.title_Node + ">";
					if (strGerade == strZiel)
					{
						//그 위치를 저장하고,
						infoOfNode.index_Vor_EndeNode = index;
						//</aaaa> 0+4+2 = 6 으로 예상하는데 이 계산은 착오가 있을수 있겠다는 생각이 든다.
						infoOfNode.index_Hinter_EndeNode = index + infoOfNode.title_Node.Length + 2;
						//뒤에 같은 이름을 가진 쌍둥이자식이 있을 경우 똑같이 생긴 종료문자열이 있을 수 있으므로 일단 종료하기위해 break.
						break;
					}
				}
			}
			//노드 사이에 뭔가 있는지를 확인하는 과정이다.
			//뭔가가 있다면 이것을 infoOfNode.stringEtwasZwischenNode에 저장하는 부분이지.
			//<aa></aa>처럼 노드 사이에 아무것도 없는 경우 4-3 = 1 이므로 이렇게 계산한 값이 1보다 크다면 노드 사이에 뭔가가 있다고 판단
			if (infoOfNode.index_Vor_EndeNode - infoOfNode.index_Hinter_AnfangNode > 1)
			{
				infoOfNode.gibtEsEtwasZwischenNode = true;
				//Length_stringEtwasZwischenNode =  infoOfNode.index_Vor_EndeNode - infoOfNode.index_Hinter_AnfangNode - 1; ex) <aa>abcd</aa> -> length = 8-3-1 = 4.
				//<aa>abcd</aa> -> infoOfNode.index_Hinter_AnfangNode = 3, infoOfNode.index_Vor_EndeNode = 8 -> stringEtwasZwischenNode = Substring( 4, 4)
				int Length_stringEtwasZwischenNode = infoOfNode.index_Vor_EndeNode - infoOfNode.index_Hinter_AnfangNode - 1;
				infoOfNode.stringEtwasZwischenNode = StringEinNodeDerXML.Substring(infoOfNode.index_Hinter_AnfangNode + 1, Length_stringEtwasZwischenNode);
			}

			//zahlen wie viel kinder habe ich.
			//지금부터 봐야하는 스트링부분이다.

			//만약에 노드사이에 뭔가 있다면
			if (infoOfNode.gibtEsEtwasZwischenNode == true)
			{
				string stringEtwasZwischen = infoOfNode.stringEtwasZwischenNode;
				//그 뭔가에 자식이 포함되어있는지 확인한다.
				infoOfNode.AnzahlKinderUndInhalts = ZaehlenWieVielKinderUndInhaltsVonKinder(stringEtwasZwischen);
				//뭔가 있는데 자식이 없다? 그게 빈공간이 아니다? 그럼 뭐다?
				if(infoOfNode.AnzahlKinderUndInhalts.anzahlDerKinderNode==0)
				{
					//그 뭔가는 해당노드의 원소로 판단
					infoOfNode.element_Node = infoOfNode.stringEtwasZwischenNode;
					//그럼 여기서 혹시 그 판단 infoOfNode.gibtEsEtwasZwischenNode을 false로 바꿔야하나?
				}
			}
			//	//한 노드 덩어리를 찾는 부분이 캡슐화 될 수 있겠다.

			//	//찾아낸 이름에 대한 노드가 끝나는 곳."</title_Child_node>"까지를 하나로 세면 된다. while(gibtEsMehreEtwas)를 사용.
			//	//찾아낸 이름에 대한 노드가 끝나는 곳 뒤에 또다른 노드가 그 내용물(부모노드 사이의 무언가)의 끝인것으로 판명되면
			//	//gibtEsMehreKinder를 false로 바꾸어서 탈출.
			//	//그 위치의 뒤에 같은 이름의 자식이 있는지 확인.


			//	//뒤에 나오는 이름이 다른 경우, 이름이 다른 자식으로 간주.
			//	//즉 자식은 쌍둥이 일수도 혹은 쌍둥이가 아닐수도 있다.
			//	//다시 말해 Alle 는 Person이라는 쌍둥이 자식을 가지지만,
			//	//Person은 Name,Vorname,Alter라는 각각다른 자식을 가질 수 도 있다.

			//	//부모가 있고, 그의 자식이 또다른 자식을 가질수 있기에
			//	//이것이 구현되기 위해서는 부모는 자신의 자식에대해서만 알아야하는 것이다.
			//	//즉 부모는 자신의 자녀가 자식(손자)를 낳았는지 여부를 결코 알아서는 안된다는 뜻이다.

			return infoOfNode;
		}
		private AnzahlDerKinderUndSchnideteInhaltList ZaehlenWieVielKinderUndInhaltsVonKinder(string StringGeradeArbeit)
		{
			AnzahlDerKinderUndSchnideteInhaltList anzahlDerKinderUndSchnideteInhaltList = new AnzahlDerKinderUndSchnideteInhaltList();
			int anzahlDerKinder = 0;

			bool gibtEsMehreEtwas = true;
			while (gibtEsMehreEtwas)
			{
				//준비물들
				int index_Vor_AnfangChildNode = 0;
				int index_Hinter_AnfangChildNode = 0;

				int index_Vor_EndeChildNode = 0;
				int index_Hinter_EndeChildNode = 0;

				string title_Child_node = string.Empty;

				//일을 시작하기에 앞서 비어있는 공간 제거.
				bool GibtEsLeerRaum = true;
				while (GibtEsLeerRaum)
				{
					if (StringGeradeArbeit[0] == ' ')
					{
						StringGeradeArbeit = StringGeradeArbeit.Substring(1, StringGeradeArbeit.Length - 1);
					}
					else
					{
						//비어있지 않으므로 탈출 후 작업 시작.
						GibtEsLeerRaum = false;
					}
				}


				//받아온 일거리를 차근히 봅시다.
				for (int index = 0; index < StringGeradeArbeit.Length; index++)
				{
					//노드가 시작되는 부분을 찾았다면 일단 저장하고 나서, 
					if (StringGeradeArbeit[index] == '<')
					{
						index_Vor_AnfangChildNode = index;
						//뒤에 이어지는 문자가 바로 '>'가 아니라는 것을 확인한뒤.
						if (StringGeradeArbeit[index + 1] == '>') { Console.WriteLine("Falsche XML File."); break; }
						else
						{
							//노드의 이름이 최소한 한글자라는 것을 가정하고 2칸 뒤부터 계속 검색한다.
							for (int index_2 = index + 2; index_2 < StringGeradeArbeit.Length - index - 2; index_2++)
							{
								if (StringGeradeArbeit[index_2] == '>')
								{
									index_Hinter_AnfangChildNode = index_2;
									break;
								}
							}
							break;
						}
					}
				}
				//만약 괄호를 찾았다면 그것은 자녀 노드가 있다는 뜻이고,
				if (index_Hinter_AnfangChildNode > 0)
				{
					//일단 찾은 괄호의 위치를 이용해 노드의 이름을 얻고,
					title_Child_node = StringGeradeArbeit.Substring(index_Vor_AnfangChildNode + 1, index_Hinter_AnfangChildNode - 1);
					//뒤에 반드시 있어야할 닫히는 괄호를 찾는다.
					for (int index = index_Hinter_AnfangChildNode + 1; index < StringGeradeArbeit.Length - title_Child_node.Length - 1; index++)
					{
						//index = position of "<"
						//index+title_Child_node.Length+1 = position of ">"
						string strGerade = string.Empty;
						strGerade += StringGeradeArbeit[index];
						strGerade += StringGeradeArbeit[index + 1];
						strGerade += StringGeradeArbeit.Substring(index + 2, title_Child_node.Length);
						strGerade += StringGeradeArbeit[index + title_Child_node.Length + 2];
						string strZiel = "</" + title_Child_node + ">";
						if (strGerade == strZiel)
						{
							index_Vor_EndeChildNode = index;
							index_Hinter_EndeChildNode = index + title_Child_node.Length + 2;
							//뒤에 같은 이름을 가진 쌍둥이자식이 있을 경우 똑같이 생긴 종료문자열이 있을 수 있으므로 일단 종료하기위해 break.
							break;
						}
					}
					if (index_Hinter_EndeChildNode - index_Vor_AnfangChildNode >= 6)
					{
						//childNode한개를 확인했으므로 자식노드 한개 추가.
						anzahlDerKinder++;
						//아울러 문자열의 첫번째 부분이 뭔지도 확인했다.
						//<ab>a</ab> -> 9 - 0 + 1 = length 10 
						int LengthDerTeil = index_Hinter_EndeChildNode - index_Vor_AnfangChildNode + 1;
						anzahlDerKinderUndSchnideteInhaltList.schnideteInhalts.Add(StringGeradeArbeit.Substring(index_Vor_AnfangChildNode, LengthDerTeil));
					}
					else { Console.WriteLine("Falsche XML File"); break; }
					//z.B. Kurzste Title Name "a" => <a></a> => index_Hinter_EndeChildNode(6) - index_Vor_AnfangChildNode(0)

					//wenn obergeschriebene bedingung falsch ist, es "<></>" teil.. das ist falsch Format in XML Regeln.

					//뒤에 뭐가 더 있는지 확인하고나서.
					int anzahlDerVerbleibendenCharDesStrings = StringGeradeArbeit.Length - index_Hinter_EndeChildNode - 1;
					if (anzahlDerVerbleibendenCharDesStrings > 0)
					{

						//gibt es etwas mehr in hintern
						//schneiden den Hintersatze und
						//StringGeradeArbeit = StringGeradeArbeit.Substring(index_Hinter_EndeChildNode + 1, StringGeradeArbeit.Length - index_Hinter_EndeChildNode - 1);
						StringGeradeArbeit = StringGeradeArbeit.Substring(index_Hinter_EndeChildNode + 1, StringGeradeArbeit.Length - index_Hinter_EndeChildNode - 1);
						//nochmal Arbeit.
					}
					else
					{
						//무한 루프가 발생하면 안되기에 아마도 반복문 첫쨰 행에서 판명해야할 내용들이 많이 있을듯하다.
						//gibt es etwas mehr in hintern
						//ESCAPE!
						gibtEsMehreEtwas = false;
					}
				}
				//만약에 괄호가 없었다면 
				else
				{
					//자식이 없다는 것을 다시한번 확인하고
					anzahlDerKinder = 0;
					//while문에서 탈출.
					gibtEsMehreEtwas = false;
				}


			}//while Ende
			anzahlDerKinderUndSchnideteInhaltList.anzahlDerKinderNode = anzahlDerKinder;
			return anzahlDerKinderUndSchnideteInhaltList;
		}
		private void CSVAnmeldenPerson(string[] strArr)
		{
			//erste zeile der strArr ist immer der spalteName
			foreach (string strEl in strArr)
			{
				Person person = new Person();
				string[] res = strEl.Split(';');
				person.name = res[0];
				person.vorname = res[1];
				person.alt = res[2];
				Personen.Add(person);
			}
		}

		private string writeXMLNode(IEnumerable<Person> personen)
		{
			string el_1 = "<" + personen.ElementAt(0).name + ">";
			string ende_el_1 = "</" + personen.ElementAt(0).name + ">";

			string el_2 = "<" + personen.ElementAt(0).vorname + ">";
			string ende_el_2 = "</" + personen.ElementAt(0).vorname + ">";

			string el_3 = "<" + personen.ElementAt(0).alt + ">";
			string ende_el_3 = "</" + personen.ElementAt(0).alt + ">";


			string res = "<Alle>";
			for (int i = 1; i < personen.Count(); i++)
			{
				res += "<Person>";

				res += el_1;
				res += personen.ElementAt(i).name;
				res += ende_el_1;

				res += el_2;
				res += personen.ElementAt(i).vorname;
				res += ende_el_2;

				res += el_3;
				res += personen.ElementAt(i).alt;
				res += ende_el_3;

				res += "</Person>";
			}
			res += "</Alle>";
			return res;
		}
	}





	public class Node
	{
		//public string NodeTitle;
		//public string NodeInhalt;
		public List<Node> ChildNodes = new List<Node>();
		public InfoOfNode info = new InfoOfNode();
	}

	public class InfoOfNode
	{
		public string element_Node = string.Empty;
		public bool gibtEsNeueNodeInGeradeArbeitendeString = false;

		public int index_Vor_AnfangNode = 0;
		public int index_Hinter_AnfangNode = 0;

		public int index_Vor_EndeNode = 0;
		public int index_Hinter_EndeNode = 0;

		public string title_Node = string.Empty;

		public bool gibtEsEtwasZwischenNode = false;

		public string stringEtwasZwischenNode = string.Empty;

		public AnzahlDerKinderUndSchnideteInhaltList AnzahlKinderUndInhalts;

		////der Parent muss nicht wissen, ob der Kind Kinder hat oder nicht.
		//public bool gibtEsNeueNodeInDerInhalt = false;

	}

	public class AnzahlDerKinderUndSchnideteInhaltList
	{
		public int anzahlDerKinderNode = 0;
		public List<string> schnideteInhalts = new List<string>();
	}

	public class Person
	{
		public string name;
		public string vorname;
		public string alt;
	}
}
