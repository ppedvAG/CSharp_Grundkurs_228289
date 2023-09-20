using System.Collections.Concurrent;

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
    }
}