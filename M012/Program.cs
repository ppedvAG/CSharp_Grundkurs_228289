using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Linq: Einfaches filtern von Listen
		//-> Alle Klassen von IEnumerable können Linq
		//Alle Linq Funktionen enthalten eine Schleife, über diese Schleife wird die Bedingung auf jedes Element angewandt

		IEnumerable<int> ints = Enumerable.Range(1, 20);
		List<int> zahlen = ints.ToList();

        //IEnumerable<int> x = Enumerable.Range(1, 200_000_000); //Hier wird nur eine Anleitung für diese Range erzeugt (wenig Leistung)
        //List<int> xList = x.ToList(); //Hier wird die Anleitung vollständig iteriert (viel Leistung)
        //int[] xArray = x.ToArray(); //Hier wird die Anleitung vollständig iteriert (viel Leistung)

		//Erweiterungsmethoden: Funktionen die an beliebige Typen angehängt werden können
		//Gezeichnet durch Würfel mit Pfeil und (extension) bei Funktionsbeschreibung
        Console.WriteLine(zahlen.Average());
        Console.WriteLine(zahlen.Sum());
        Console.WriteLine(zahlen.Min());
        Console.WriteLine(zahlen.Max());

        Console.WriteLine(zahlen.First()); //Gibt das erste Element zurück, Exception wenn kein Element gefunden wird
        Console.WriteLine(zahlen.Last()); //Gibt das letzte Element zurück

		Console.WriteLine(zahlen.FirstOrDefault()); //Gibt das erste Element zurück, Standardwert des Typs wenn kein Element gefunden wird
		Console.WriteLine(zahlen.LastOrDefault()); //Gibt das letzte Element zurück

		//Console.WriteLine(zahlen.First(e => e % 50 == 0)); //Finde das erste Element, dass einer Bedingung entspricht
		Console.WriteLine(zahlen.FirstOrDefault(e => e % 50 == 0)); //0
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Objekten
		//Alle Fahrzeuge finden mit mindestens 200km/h
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs finden mit mindestens 200km/h
		fahrzeuge.Where(e => e.MaxV >= 200 && e.Marke == FahrzeugMarke.VW); //12 Durchgänge
		fahrzeuge.Where(e => e.MaxV >= 200).Where(e => e.Marke == FahrzeugMarke.VW); //12 Durchgänge + 7 Durchgänge = 19 Durchgänge
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Where(e => e.MaxV >= 200); //12 Durchgänge + 4 Durchgänge = 16 Durchgänge

		//Alle Fahrzeuge sortieren
		fahrzeuge.OrderBy(e => e.MaxV); //Originale Liste wird nicht verändert
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV); //Primäre, Sekundäre, Tertiäre, ... Sortierung
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Fahren alle Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200);

		if (fahrzeuge.All(e => e.MaxV >= 200))
		{

		}

		//Fährt mindestens ein Fahrzeug mindestens 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200);

		if (fahrzeuge.Any(e => e.MaxV >= 200))
		{

		}

		//Enthält die Liste Elemente?
		fahrzeuge.Any(); //Wird am Ende von Linq Ketten verwendet um zu prüfen ob ein Ergebnis herauskommt

		//Wieviele VWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW); //Keine Liste, sondern die Anzahl (4)
		fahrzeuge.Count(); //Nur bei IEnumerable oder wenn eine Bedingung gegeben ist
        Console.WriteLine(fahrzeuge.Count); //Bei List, Array, Dict, ... immer das entsprechende Property benutzen (Count oder Length)

		//MinBy, MaxBy, Min, Max
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit
		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit

		//Select
		//Wandelt die Liste in eine neue Form um
		//2 Anwendungsfälle

		//1. Fall: Extrahieren von einem Feld aus der Liste (80% aller Fälle)
		fahrzeuge.Select(e => e.Marke); //Marken wurden hier von den Fahrzeugen getrennt (Ergebnis: Fahrzeugmarkenliste)
		fahrzeuge.Select(e => e.MaxV); //MaxV wurden hier von den Fahrzeugen getrennt (Ergebnis: int Liste)

		//2. Fall: Liste umformen (20% aller Fälle)
		zahlen.Select(e => (double) e); //Gesamte Int Liste zu einer double Liste konvertieren
		zahlen.Select(e => (char) e); //Gesamte Int Liste zu einer char Liste konvertieren
		zahlen.Select(e => $"Die Zahl ist {e}"); //String Liste

		//Ordner voller Dateien mit Pfad und Endung, wir wollen Pfade und Endungen wegwerfen
		string[] pfade = Directory.GetFiles(@"C:\Windows\System32");
		List<string> pfadeOhne = new();
		foreach (string s in pfade)
			pfadeOhne.Add(Path.GetFileNameWithoutExtension(s));

		List<string> p2 = Directory
			.GetFiles(@"C:\Windows\System32")
			.Select(e => Path.GetFileNameWithoutExtension(e))
			.ToList();

        Console.WriteLine(pfadeOhne.SequenceEqual(p2)); //Geht beide Listen durch und Vergleicht Links und Rechts

		//Was sind die 3 schnellsten Autos in unserem Fahrzeugpark?
		fahrzeuge.OrderByDescending(e => e.MaxV).Take(3); //Die schnellsten Fahrzeuge oben und dann einfach 3 nehmen

		//GroupBy: Erzeugt Gruppen anhand eines Schlüssels
		//Jedes Element mit einem gegebenen Schlüssel kommt in seine entsprechende Gruppe
		IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>> group = fahrzeuge.GroupBy(e => e.Marke); //3 Gruppen: Audi-Gruppe, BMW-Gruppe, VW-Gruppe

		Dictionary<FahrzeugMarke, List<Fahrzeug>> dict = group.ToDictionary(e => e.Key, e => e.ToList());
		#endregion

		#region	Erweiterungsmethoden
		int x = 325879;
        Console.WriteLine(x.Quersumme());
        Console.WriteLine(38257829.Quersumme());

		fahrzeuge.Shuffle();
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}