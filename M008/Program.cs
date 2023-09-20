namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Lebewesen lebewesen = new Lebewesen(22);
		lebewesen.WasBinIch();

		Mensch m = new Mensch(23, "Max"); //Mensch hat Alter und WasBinIch geerbt
		m.WasBinIch();

		//Nachdem object die oberste Klasse ist, kann jedes Objekt in C# zu Object zugewiesen werden
		object o = m;
		o = lebewesen;

        Console.WriteLine(m.ToString()); //Typ des Objekts: M008.Mensch
        Console.WriteLine(new int[] { 1, 2, 3 }); //System.Int32[]

		//Nach Überschreibung in Lebewesen
		Console.WriteLine(m.ToString());
		//Ich bin ein Lebewesen und bin 23 Jahre alt

		//Nach Überschreibung in Mensch
		Console.WriteLine(m.ToString());
		//Ich bin ein Lebewesen und bin 23 Jahre alt und heiße Max
	}
}

/// <summary>
/// Oberklasse
/// Felder/Properties/Methoden werden nach unten weitervererbt
/// Unterklassen sind mit dem Typen der Oberklasse kompatibel
/// </summary>
public class Lebewesen : object //Alle Klassen erben von Object -> Equals, GetHashCode, GetType, ToString
{
	public int Alter { get; set; }

    public Lebewesen(int alter)
    {
		Alter = alter;
        Console.WriteLine("Lebewesen Konstruktor");
    }

	/// <summary>
	/// virtual: Ermöglicht das Überschreiben von Funktionen in den Unterklassen mittels override-Keyword
	/// Effekt: Eigene Implementation pro Klasse
	/// </summary>
    public virtual void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Lebewesen");
    }

	/// <summary>
	/// Kommt von Object
	/// </summary>
	public override string ToString()
	{
		return $"Ich bin ein Lebewesen und bin {Alter} Jahre alt";
	}
}

public sealed class Mensch : Lebewesen //sealed: Vererbung verhindern
{
	public string Name { get; set; }

	//Strg + . -> Generate Constructor
	public Mensch(int alter, string name) : base(alter) //base: Selbiges wie this, nur mit einer Vererbungshierarchie (Greife nach oben in die Oberklasse)
	{
		Name = name;
		Console.WriteLine("Mensch Konstruktor");
	}

	/// <summary>
	/// override Leerzeichen -> Vorschläge für überschreibbare Methoden
	/// </summary>
	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Mensch");
    }

	public override string ToString()
	{
		return base.ToString() + $" und heiße {Name}";
	}
}

public class Katze : Lebewesen
{
	public Katze(int alter) : base(alter)
	{
	}

	public sealed override void WasBinIch() //sealed bei override verhindert weiteres Überschreiben
	{
		base.WasBinIch();
	}
}

public class Tiger : Katze
{
	public Tiger(int alter) : base(alter)
	{
	}

	//public override void WasBinIch()
	//{
	//	base.WasBinIch();
	//}
}