using System.Net;

namespace M004;

internal class Program
{
	static void Main(string[] args)
	{
		#region Schleifen
		int a = 0;
		int b = 10;
		while (a < b)
		{
			Console.WriteLine("while: " + a);
			a++;
		}

		int c = 0;
		int d = 10;
		do //Der Code im do Block wird immer mindestens einmal ausgeführt (auch wenn die Bedingung von Anfang an falsch ist)
		{
			Console.WriteLine("do-while: " + c);
			c++;
		}
		while (c < d);

		//while (true) { } //Endlosschleife

		int e = 0;
		int f = 10;
		while (true) //do-while mit while(true) dargestellt
		{
			e++;
			if (e == 5)
				continue; //continue: Hier wird zum Schleifenkopf zurück gesprungen (führt den Code danach nicht mehr aus)
			Console.WriteLine("while true: " + e);

			if (e >= f)
			{
				//Hier kann noch extra Code hinzugefügt werden (bei do-while nicht möglich)
				Console.WriteLine("Schleife Ende");
				break; //break: Springt aus der Schleife/Beendet die Schleife
					   //Wenn bei break verschachtelte Schleifen verwendet werden (Schleifen in Schleifen) dann wird die innere Schleife beendet
			}
		}
		Console.WriteLine();

		//for Schleife
		for (int i = 0; i < 10; i++) //Zählervariable, Bedingung(en), Inkrement
		{
			Console.WriteLine("for: " + i);
		}

		for (int i = 0, j = 1; i < 30; i++, j *= 2) //Mehrere Inkremente, Zähler
		{
			Console.WriteLine($"2^{i}={j}");
		}

		//for (int i = 0; ; i++) { } //Endlose for-Schleife

		//for(;;) { }

		for (int i = 10 - 1; i >= 0; i--)
		{
			Console.WriteLine("forr: " + i);
		}

		//foreach
		int[] zahlen = { 1, 2, 3, 4, 5 };
		for (int i = 0; i < zahlen.Length; i++)
		{
			Console.WriteLine(zahlen[i]); //for Schleife kann daneben greifen
		}

		foreach (int zahl in zahlen) //Aufbau: <Elementtyp> <Variablenname> in <Collection>
		{
			Console.WriteLine(zahl);
		}

		string text = "Ein Text";
		foreach (char buchstabe in text)
		{
			Console.WriteLine(buchstabe);
		}

		int[,] array2D = new[,] //Direkte Initialisierung
		{
			{ 1, 2, 3 },
			{ 4, 5, 6 },
			{ 7, 8, 9 }
		};

		foreach (int element in array2D) //2D Array wird automatisch geglättet
		{
			Console.WriteLine(element);
		}
		#endregion

		#region	Enums
		//Eigener Typ mit fixen Werten
		//Variable von dem gegebenen Enum Typen kann nur Werte aus dem Enum enthalten

		Wochentag tag = Wochentag.Mo;

		Status(HttpStatusCode.OK);
		//int zu Enum
		int code = 200; //Invalide Codes sind auch in Ordnung
		HttpStatusCode statusCode = (HttpStatusCode) code;

		//string zu Enum
		HttpStatusCode statusCode2 = Enum.Parse<HttpStatusCode>(code.ToString());

		HttpStatusCode[] codes = Enum.GetValues<HttpStatusCode>();

		Console.WriteLine((int) statusCode2);
		#endregion

		#region	Switch
		//if-else if-else Baum aber schön
		switch (tag)
		{
			case Wochentag.Mo: //Sozusagen eine if
				Console.WriteLine("Wochenanfang");
				break; //Am Ende von jedem Case mit Code muss ein break stehen
			case Wochentag.Di:
			case Wochentag.Mi:
			case Wochentag.Do:
			case Wochentag.Fr: //Di bis Fr werden kombiniert
				Console.WriteLine("Wochenmitte");
				break;
			case Wochentag.Sa:
			case Wochentag.So:
				Console.WriteLine("Wochenende");
				break;
			default: //Sozusagen die else
				Console.WriteLine("Fehler");
				break;
		}

		switch (tag)
		{
			case Wochentag.Mo:
				break;
			case Wochentag.Di:
				break;
			case Wochentag.Mi:
				break;
			case Wochentag.Do:
				break;
			case Wochentag.Fr:
				break;
			case Wochentag.Sa:
				break;
			case Wochentag.So:
				break;
			default:
				break;
		}
		#endregion
	}

	static void Test(Wochentag tag)
	{

	}

	static void Status(HttpStatusCode code)
	{

	}
}

/// <summary>
/// Wochentag ist eine Struktur, daher muss es außerhalb einer Funktion sein
/// Im besten Fall in einem eigenen File
/// </summary>
enum Wochentag
{
	Mo = 1, Di, Mi, Do = 10, Fr, Sa, So
}