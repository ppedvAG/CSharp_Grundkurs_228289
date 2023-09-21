namespace M009;

public sealed class Mensch : Lebewesen //sealed: Vererbung verhindern
{
	public string Name { get; set; }

	public void Sprechen(int distanz) { }

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
