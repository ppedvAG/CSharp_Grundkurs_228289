namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		//Polymorphismus
		//-> Typkompatibilität
		//Welche Typen passen mit welchen anderen Typen zusammen

		//int und double
		double d = 5; //Direkt Kompatibel
		int i = (int) 5.0; //Indirekt Kompatibel (über Typecast)

		//int und char
		char c = 'A'; //Jeder char hat einen Code dahinter
		int ci = (int) c; //Über Umwandlung kann der Code hinter dem char in eine Variable geschrieben werden

		int xyz = 38572924;
		char x = (char) xyz;
        Console.WriteLine(xyz % ushort.MaxValue);

		//int und bool
		int a = 1;
		//bool b = (bool) a; //Nicht möglich, außer über Umwege

		//float und double
		float f = 39.2f;
		double fd = f;
		float ff = (float) fd; //Kompatibel

		//Lebewesen und Mensch
		Lebewesen lw = new Mensch(); //Oberklasse = Unterklasse -> Immer möglich
		//Mensch m = new Lebewesen(); //Unterklasse = Oberklasse -> Nicht möglich
		Mensch m = (Mensch) lw; //Mit Cast kann es möglich sein, aber kann auch fehlschlagen

		//object und Mensch
		object o = new Mensch(); //In Object passt alles hinein
		//Mensch mo = new object();
		Mensch mo = (Mensch) o; //Selbiges wie oben

		//object und char
		object oc = 'A';
		//char c = oc;
		//Über Cast möglich

		//Mensch und Katze
		//Mensch mk = new Katze();
		//Katze mk = new Mensch();
		//Katze k = new Katze();
		//Mensch mk = (Mensch) k; //Klassen auf der selben Vererbungsebene können nie kompatibel sein (außer mit Interfaces)

		//Umweg über die Oberklasse
		//Katze k = new Katze();
		//Lebewesen lebewesen = k; //Zwischenschritt
		//Mensch mk = (Mensch) lebewesen;

		//Überall wo ein Typ steht (Variable, Parameter, Rückgabetyp, ...) kann Polymorphismus angewendet werden
		//Ein Typ kann mit einem Objekt von dem Typen selbst oder einer Unterklasse belegt werden
		//Beispiel
		Lebewesen lebewesen = new Lebewesen();
		Test(lebewesen); //Der Typ selbst
		Test(new Katze()); //Eine Unterklasse von dem Typen selbst
		Test(mo); //Eine Unterklasse von dem Typen selbst
		Test(new Tiger());

		//object fasst alles
		Test2(123); //int
		Test2("Text"); //string
		Test2(true); //bool
		Test2(lebewesen); //Lebewesen

		//Typ
		//Jedes Objekt hat einen Typen
		//-> Dieser Typ wird als Typ Objekt repräsentiert
		//Lebewesen, int, char, float, bool, Mensch, Katze, Program, ...
		//Ein Typ Objekt kann viele Dinge

		//GetType(): Typ eines Objekts holen
		Console.WriteLine(lebewesen.GetType().Name); //Gibt den Typ des Objekts welches an der lebewesen Variable angehängt ist
        Console.WriteLine(oc.GetType().Name); //Typ von oc -> char
		Type lt = lebewesen.GetType();

        //typeof(<Klassenname>): Typ über Klassenname holen
        Console.WriteLine(typeof(Lebewesen).Name);
		Type kt = typeof(Lebewesen);

        Console.WriteLine(lt == kt); //True

		//Typvergleiche
		//Genauer Typverlgeich mittels GetType() und typeof
		//Funktioniert nur, wenn Links und Rechts gleich sind
		if (lebewesen.GetType() == typeof(Lebewesen))
		{
			//true
		}

		if (lebewesen.GetType() == typeof(object)) //Links: Lebewesen, Rechts: object
		{
			//false
		}

		//Typvergleich mit is
		//Beachtet auch Vererbungshiearchien
		//-> Wäre eine Variable vom Typ rechts, kompatibel mit einem Objekt vom Typ links?
		if (lebewesen is Lebewesen)
		{
			//true
		}

		if (lebewesen is object)
		{
			//true
		}

		if (new Katze() is Lebewesen)
		{
			//true
		}

		//Virtuelle Member
		Lebewesen leb = new Mensch();
		leb.WasBinIch(); //Code von Mensch wird ausgeführt

		leb = new Tiger();
		leb.WasBinIch(); //Wenn Tiger WasBinIch() überschreibt (mit override) -> Methode von Tiger
						 //Wenn Tiger nicht WasBinIch() implementiert, wird in der Vererbungshierarchie nach oben gegangen, bis eine Implementation vorliegt

		//Beispiel Polymorphismus
		Lebewesen[] arr = new Lebewesen[5];
		arr[0] = new Mensch(); //Alle Unterklassen von Lebewesen passen in das Array
		arr[1] = new Tiger();
		arr[2] = new Katze();
		arr[3] = new Mensch();
		arr[4] = new Katze();

		foreach (Lebewesen g in arr)
		{
			g.WasBinIch(); //Jedes Lebewesen muss diese Methode implementieren, weil abstract

			if (g.GetType() == typeof(Mensch))
			{
				Mensch r = (Mensch) g; //Cast funktioniert immer, weil der Typ Mensch ist (durch die if)
				r.Sprechen(10);
			}

			if (g is Katze) //Katze und Tiger werden bei dieser if behandelt (Nachdem Tiger eine Unterklasse von Katze ist)
			{
				Katze u = (Katze) g; //Cast funktioniert immer, weil der Typ Katze oder eine Unterklasse von Katze ist (durch die if)
				u.Bewegen(10);
			}
		}
	}

	static void Test(Lebewesen lebewesen) { }

	static void Test2(object o) { }

	/// <summary>
	/// Beim Rückgabetyp gilt auch Polymorphismus
	/// </summary>
	static Lebewesen Test3() 
	{
		//return new Lebewesen();
		return new Katze();
		return new Tiger();
		return new Mensch();
	}
}