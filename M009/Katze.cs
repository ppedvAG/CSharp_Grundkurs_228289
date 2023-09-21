namespace M009;

public class Katze : Lebewesen
{
	public void Bewegen(int d)
	{
        Console.WriteLine($"{GetType().Name} bewegt sich um {d}m");
    }

	public override void WasBinIch()
	{
		Console.WriteLine("Ich bin eine Katze");
	}
}
