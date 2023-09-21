namespace M010;

/// <summary>
/// Interface: Struktur, die ihre Inhalte an die Unterklassen erzwingt
/// Hier werden Properties und Methoden ohne Body definiert, die in den Unterklassen implementiert werden müssen
/// Kann nicht instanziert werden
/// </summary>
public interface IArbeit
{
	static readonly int Wochenstunden = 40; //Konstante

	string Job { get; set; }

	int Gehalt { get; set; }

	void Lohnauszahlung();

	int Jahresgehalt();

	int LohnProStunde(int lohn);

	void Test()
	{
		//Bad Practice, Interfaces sind nur für die Struktur da
	}
}
