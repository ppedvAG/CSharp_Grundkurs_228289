namespace M007;

public class Person
{
	#region Variable
	private string vorname;

	/// <summary>
	/// Gibt den Vornamen zurück (Wert der vorname Variable)
	/// </summary>
	public string GetVorname()
	{
		return vorname;
	}

	/// <summary>
	/// Schreibt in die vorname Variable einen neuen Wert hinein<br/>
	/// Über den Parameter wird der neue Vorname vom Benutzer übernommen
	/// </summary>
	public void SetVorname(string vorname)
	{
		if (vorname.Length > 2 && vorname.Length < 15 && vorname.All(char.IsLetter)) //Überprüfungen vor dem Setzen des Werten
			this.vorname = vorname; //this: Nach oben greifen, wird benötigt bei gleichen Variablennamen
		else
                Console.WriteLine("Vorname ist nicht gültig");
        }
	#endregion

	#region Property
	private string nachname;

	/// <summary>
	/// Property: Vereinfachung von Get- und Set Methoden <br/>
	/// Gibt die Möglichkeit, eine kompakte Syntax zu definieren mithilfe von get- und set Accessoren<br/>
	/// </summary>
	public string Nachname
	{
		get { return nachname; }
		set
		{
			if (value.Length > 2 && value.Length < 15 && value.All(char.IsLetter)) //Überprüfungen vor dem Setzen des Werten
				nachname = value; //this: Nach oben greifen, wird benötigt bei gleichen Variablennamen
			else
				Console.WriteLine("Vorname ist nicht gültig");
		}
	}

	//public string get_Nachname()
	//{
	//	//get Accessor bei dem Nachname Property gibt hier einen Fehler
	//}

	//public void set_Nachname(string x)
	//{
	//	//set Accessor bei dem Nachname Property gibt hier einen Fehler
	//}

	/// <summary>
	/// Get-Only Property
	/// </summary>
	public string VollerName
	{
		get { return vorname + " " + nachname; }
	}

	//public string VollerNameFunc()
	//{
	//	return vorname + " " + nachname;
	//}

	private int gehalt;

	public int Gehalt
	{
		get { return gehalt; }
		private set //private set: Kann nur innerhalb der Klasse gesetzt werden
		{
			if (gehalt >= 0)
				gehalt = value;
		}
	}

	//public void Test()
	//{
	//	Gehalt = 123;  //Hier möglich
	//	VollerName = "";  //Immer noch nicht möglich
	//}

	/// <summary>
	///Auto-Property<br/>
	///Generell sollten alle public Felder die keine Bedingungen haben ein Auto-Property sein<br/>
	///Wird benötigt für z.B.Bindings in WPF, Serialisierung in JSON, ...
	///</summary>
	public DateTime Geburtsdatum { get; set; }

	//public DateTime Geburtsdatum;  //Selbiges wie oben im Bezug auf die Verwendung


	//prop: Auto Property
	//propfull: Full Property (private Variable, public Property)
	//propg: Auto Property mit private set
	//propdp: Dependency Property
	//propa: Dependency Property mit separaten Get- und Set Methoden
	#endregion

	#region Konstruktor
	/// <summary>
	/// Standardkonstruktor explizit erstellen
	/// </summary>
	public Person()
	{
        Console.WriteLine("Person wird erstellt");
        Console.WriteLine("Konstruktor 1");
		Counter++;
    }

	/// <summary>
	/// Konstruktor: Wird bei Objekterstellung ausgeführt und wird verwendet um Initialwerte zu setzen<br/>
	/// Wenn ein Konstruktor angelegt wird, wird der Standardkonstruktor (Person()) entfernt
	/// </summary>
	public Person(string vorname, string nachname) : this()
    {
		this.vorname = vorname;
		this.nachname = nachname;
		Console.WriteLine("Konstruktor 2");
	}

	/// <summary>
	/// Konstruktoren verketten mittels : this(Par1, Par2, ...)
	/// Wenn dieser Konstruktor ausgeführt wird, wird auch der verkettete Konstruktor ausgeführt
	/// Vorteile:
	/// - Wenn sich der verkettete Konstruktor verändert, wird hier der Code automatisch angepasst
	/// - Weniger Redundanz (kein Copy Paste)
	/// </summary>
	public Person(string vorname, string nachname, int gehalt) : this(vorname, nachname)
	{
		this.gehalt = gehalt;
		Console.WriteLine("Konstruktor 3");
	}

	/// <summary>
	/// Konstruktor mit optionalen Parametern<br/>
	/// Ermöglicht, Konfiguration des Objekts
	/// </summary>
	//public Person(string vorname = "", string nachname = "", int gehalt = 0)
	//{
	//	//...
	//}
	#endregion

	public static int Counter { get; set; }

	~Person()
	{
		//Destruktor: Wird ausgeführt, wenn das Objekt vom GC eingesammelt wird
		//GetHashCode: Gibt die Speicheradresse des Objekts zurück
		Console.WriteLine($"Die Person wurde eingesammelt {GetHashCode()}");
	}
}
