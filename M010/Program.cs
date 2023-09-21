using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		Mensch m = new Mensch();
		m.Job = "Softwareentwickler";
		m.Gehalt = 5000;

		m.Lohnauszahlung();

		//Polymorphismus
		//-> Interfaces sollen den implementierenden Klassen einen extra Typen geben
		IArbeit arbeit = m;
		arbeit.Lohnauszahlung();

		arbeit = new Mensch2();
		arbeit.Lohnauszahlung();

		//Beispiele für vorhandene Interfaces
		//IEnumerable: Basis von allen Listentypen in C#
		int[] x = new int[10];
		List<int> y = new List<int>();
		Dictionary<int, int> z = new Dictionary<int, int>();
		//Diese 3 Listentypen haben alle das IEnumerable Interface
		PrintList(x);
		PrintList(y);
		PrintList(z); //Hier passen alle 3 Listen hinein

		//IEnumerable ist hier der gemeinsame Basistyp
		//-> Ein Paramter/Rückgabetyp/Variable vom Typ IEnumerable kann ein Array, eine List oder ein Dict halten
		IEnumerable<int> xe = new int[10];
		IEnumerable<int> ye = new List<int>();
		IEnumerable<KeyValuePair<int, int>> ze = new Dictionary<int, int>();
	}

	public static IEnumerable<T> PrintList<T>(IEnumerable<T> a)
	{
		return new T[10];
		return new List<T>();
		//return new Dictionary<T, T>();
	}
}

public class Mensch : IArbeit
{
	public string Job { get; set; }

	public int Gehalt { get; set; }

	public int Jahresgehalt()
	{
		return Gehalt * 12;
	}

	public void Lohnauszahlung()
	{
        Console.WriteLine($"Diese Person hat für den Job {Job} ein Gehalt von {Gehalt}€ bekommen." +
			$"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
    }

	public int LohnProStunde(int lohn)
	{
		return lohn / 160;
	}
}

public class Mensch2 : IArbeit
{
	public string Job { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public int Gehalt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public int Jahresgehalt()
	{
		throw new NotImplementedException();
	}

	public void Lohnauszahlung()
	{

	}

	public int LohnProStunde(int lohn)
	{
		throw new NotImplementedException();
	}
}