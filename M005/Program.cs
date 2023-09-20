using System.Runtime.Intrinsics.X86;

namespace M005;

internal class Program
{
	static void Main(string[] args)
	{
		int ergebnis = Addiere(3, 4);

		PrintAddiere(3, 4);
		PrintAddiere(6, 2);
		PrintAddiere(9, 1);

		string concat = Concat("Ein", "Text");

        Console.WriteLine(); //18 WriteLine Methoden, per Überladung können diese alle in der selben Klasse existieren
		double summe = Addiere(5.0, 8); //Hier muss über die Parameter ein Overload ausgewählt werden

		Addiere(1, 2, 3);
		Addiere(1, 2, 3, 4, 5, 6);
		Addiere(1);
		Addiere(); //Keine Parameter sind auch beliebig viele Parameter

		Subtrahiere(3, 4); //z = 0
		Subtrahiere(3, 4, 5); //z = 5

		Subtrahiere(3.3, 9);
		Subtrahiere(3.3, 9);
		Subtrahiere(3.3, 9);
		Subtrahiere(3.3, 9);
		Subtrahiere(3.3, 9);
		Subtrahiere(3.3, 9, true); //Hier Sonderfall (Output) aktivieren
		Subtrahiere(3.3, 9);
		Subtrahiere(3.3, 9);

		PrintPerson(alter: 30, adresse: "Zuhause");
		PrintPerson(vn: "Max", nn: "Mustermann");
		PrintPerson(vn: "Max", adresse: "Zuhause"); //Hier können nur die gewünschten Parameter angegeben werden
		PrintPerson("Max", "Mustermann", adresse: "Zuhause"); //Parameter müssen hier nicht mit Bezeichner angegeben werden, sondern werden anhand der Reihenfolge zugeordnet

		int sum;
		int differenz = AddiereUndSubtrahiere(3, 4, out sum); //Hier wird sum zu 7


		string text = "123";
		int r = 0;
		bool funktioniert = int.TryParse(text, out r);
        Console.WriteLine(funktioniert ? "Parsen hat funktioniert: " + r : "Parsen hat nicht funktioniert: " + text);


        string eingabe = "124hi235u3918ngf931";
		foreach (char c in eingabe)
		{
			int result = 0;
			bool b = int.TryParse(c.ToString(), out result);
			if (b)
			{
				Console.WriteLine("Parsen hat funktioniert: " + result);
			}
			else
			{
				Console.WriteLine("Parsen hat nicht funktioniert: " + c);
			}
		}
    }

	/// <summary>
	/// Aufbau einer Funktion:
	/// Modifier Rückgabetyp Name(Parameter1, Parameter2, ...)
	/// {
	///		Body
	/// }
	/// </summary>
	static int Addiere(int x, int y)
	{
		return x + y; //return: Gib das Ergebnis der Funktion zum Aufruf zurück
	}

	static string Concat(string a, string b)
	{
		return a + b;
	}

	/// <summary>
	/// void: Kein Rückgabewert, Funktion benötigt kein return
	/// </summary>
	static void PrintAddiere(int x, int y)
	{
		Console.WriteLine($"{x} + {y} = {x + y}");
	}

	/// <summary>
	/// Überladung von Methoden: Methoden mit dem selben Namen definieren wie andere Methoden, bei denen sich die Parameter unterscheiden
	/// </summary>
	static double Addiere(double x, double y)
	{
		return x + y;
	}

	/// <summary>
	/// params: Ermöglicht den Anwender, beliebig viele Parameter zu übergeben
	/// </summary>
	static int Addiere(params int[] zahlen)
	{
		return zahlen.Sum();
	}

	/// <summary>
	/// Optionale Parameter: Parametern Standardwerte geben, die beim Funktionsaufruf nicht übergeben werden müssen
	/// </summary>
	static int Subtrahiere(int x, int y, int z = 0)
	{
		return x - y - z;
	}

	static double Subtrahiere(double x, double y, bool output = false)
	{
		if (output) //Sonderfall
            Console.WriteLine($"{x} - {y} = {x - y}");
        return x - y;
	}

	/// <summary>
	/// Funktion mit ausschließlich optionalen Parametern
	/// <br/>
	/// Diese Funktion kann "konfiguriert" werden
	/// </summary>
	static void PrintPerson(string vn = "", string nn = "", int alter = 0, string adresse = "")
	{
		//...
	}

	/// <summary>
	/// out Parameter: Gibt die Möglichkeit, mehrere Werte zurückzugeben
	/// </summary>
	static int AddiereUndSubtrahiere(int x, int y, out int add)
	{
		add = x + y;
		return x - y;
	}

	static (int, int) AddiereUndSubtrahiere(int x, int y)
	{
		return (x + y, x - y);
	}
}