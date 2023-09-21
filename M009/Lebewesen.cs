namespace M009;

/// <summary>
/// abstract: Definiert eine Strukturklasse
/// Von abstrakten Klassen kann kein Objekt erstellt werden -> Nur Unterklassen können instanziert werden
/// <br/>
/// Methoden werden hier ohne Body definiert (mit Semikolon beendet)
/// Alle abstrakten Methoden MÜSSEN von den Unterklassen implementiert werden
/// Die Oberklasse stellt für abstrakte Methoden keine Basisimplementation bereit
/// <br/>
/// Kein Lebewesen auf dieser Welt wird nur als Lebewesen bezeichnet, jedes Lebewesen hat eine Spezifizierung
/// </summary>
public class Lebewesen
{
	public int Alter { get; set; }

	/// <summary>
	/// Methode ohne Body
	/// Muss von den Unterklassen überschrieben werden
	/// </summary>
	public virtual void WasBinIch() { }

	/// <summary>
	/// Normale Funktionen sind weiterhin möglich
	/// </summary>
	public override string ToString()
	{
		return $"Ich bin ein Lebewesen und bin {Alter} Jahre alt";
	}
}
