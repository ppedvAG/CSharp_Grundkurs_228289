using M006.Data;
using System.Diagnostics;

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		Person p1 = new Person(); //new: Erzeuge ein neues Objekt aus dem gegebenen Bauplan
		//p1.vorname = ""; //Nicht möglich, da vorname private ist
		p1.SetVorname("Max");
        Console.WriteLine(p1.GetVorname());

        Person p2 = new Person();
		p2.Nachname = "Mustermann"; //Properties können direkt beschrieben werden
		Console.WriteLine(p2.Nachname); //Properties können auch direkt ausgelesen werden

        Console.WriteLine(p2.VollerName);
        //p2.VollerName = ""; //Kein set-Accessor -> readonly

        Console.WriteLine(p2.Gehalt);
		//p2.Gehalt = 0;

		Person p3 = new Person("Max", "Mustermann", 100000000);

		//Assozation von Objekten
		//Objekte zueinander referenzieren
		Kurs k = new Kurs("C# Grundkurs", p1, p2, p3);

		Person p4 = new Person("Max", "Muster");
		k.AddTeilnehmer(p4);

		Person p5 = new Person("Max", "Muster");
		k.AddTeilnehmer(p5);

		//Durch using System.Diagnostics die Stopwatch importieren
		Stopwatch sw = new Stopwatch();

		//System: Console, int, double, string
		//System.IO: File, Directory, Path
		//System.Net.Http: HttpClient, HttpStatusCodes
		//System.Text.Json: JsonSerializer, JsonDocument
	}
}