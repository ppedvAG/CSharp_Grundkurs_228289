using System.Runtime.CompilerServices;

namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		#region GC
		for (int i = 0; i < 5; i++)
		{
			Person p = new Person(); //5x wird ein Speicherbereich reserviert, der Personendaten enthält
			//p wird mehrmals neu referenziert -> alte Referenz gelöscht
		}
		//GC ist dafür verantwortlich, die Unreferenzierten Personen (4 Stück) zu löschen
		GC.Collect();
		GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren
		#endregion

		#region Static
		//Static: Definiert einen Member als "global"
		//Normale Methoden/Member sind mit dem Objekt verknüpft
		//Statische Methoden/Member befinden sich auf der Klasse
		Person p1 = new Person();
		//p.Counter++; //Nicht möglich
		Person.Counter++; //Der Counter befindet sich auf der Klasse selbst

		Person p2 = new Person();

        Console.WriteLine(); //WriteLine ist auf der Console Klasse selbst und nicht auf einem Objekt
							 //Console c = new Console();  //Nicht möglich
		#endregion

		#region Arbeiten mit Datumswerten
		DateTime now = DateTime.Now; //Zeitpunkt + Datum
		TimeSpan span = TimeSpan.FromHours(2); //Zeitspanne (Dauer)

        Console.WriteLine(now + span);

        Console.WriteLine(now.Day);
        Console.WriteLine(now.Minute);
        Console.WriteLine(now.Year);
        Console.WriteLine(now > DateTime.Now);

        Console.WriteLine(now.ToUniversalTime());
		#endregion

		#region Werte- und Referenztypen
		//Referenztyp
		//class
		//Bei Zuweisungen wird eine Referenz erzeugt auf das entsprechende Objekt
		//Bei Vergleichen werden die Speicheradressen (Handles) verglichen
		Person p3 = new Person(); //Referenz auf den Speicherbereich
		Person p4 = p3; //Erstelle eine Referenz auf das Objekt hinter p3
		p3.Nachname = "Test";
        Console.WriteLine(p3.GetHashCode());
        Console.WriteLine(p4.GetHashCode());

		//Wertetyp
		//struct
		//Bei Zuweisungen wird der Inhalt kopiert
		//Bei Vergleichen werden die Werte verglichen
		int original = 5;
		int x = original;
		original = 10;

		//Sonderfall
		string s1 = "Test";
		string s2 = "Test";
        Console.WriteLine(s1 == s2);
        Console.WriteLine(s1.GetHashCode());
        Console.WriteLine(s2.GetHashCode());
		#endregion

		#region Null
		//null: Leerer Wert, keine Referenz
		Person p5 = new Person(); // p5 --> [Person]
		Person p6 = p5; // p5 --> [Person] <-- p6
		p5 = null; //Löscht die Referenz auf das unterliegende Objekt   p5   [Person] <-- p6

		if (p5 == null)
		{
			//...
		}

		if (p5 is not null || p5 is null)
		{

		}

		int y = 5;
		//y = null;  //Wertetypen können nicht null sein
		int? z = 5;  //Fragenzeichen am Ende vom Typen definiert den Typen als nullable
		z = null;
		#endregion

		//var v = new Person(); //Compiler nimmt den Typen automatisch an
		//object o = "123"; //Object kann alles halten
		//o = false;
		//o = v;
	}
}