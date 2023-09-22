using System.Globalization;

namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new DivideByZeroException();

		try
		{
			//Maus über Methode -> Exceptions einsehen
			string eingabe = Console.ReadLine(); //3 Exceptions: IOException, OutOfMemoryException, ArgumentOutOfRangeException
			int zahl = int.Parse(eingabe); //3 Exceptions: FormatException, OverflowException, ArgumentNullException
			if (zahl == 0)
				throw new Exception("Zahl darf nicht 0 sein");
		}
		catch (FormatException e) //Durch catch Abstürze verhindern
		{
			Console.WriteLine("Keine Zahl eingegeben");
			Console.WriteLine(e.Message);  //Die C# interne Nachricht zu dem Fehler
			Console.WriteLine(e.StackTrace); //Die Rückverfolgung des Fehlers mittels Codezeilen (von unten nach oben lesen)
		}
		catch (OverflowException)
		{
            Console.WriteLine("Zahl zu klein/groß");
        }
		catch (Exception) //Alle anderen Fehler
		{
            Console.WriteLine("Anderer Fehler");
			throw; //Fataler Fehler
        }
		finally
		{
			Console.WriteLine("Wird immer ausgeführt");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Log.txt", ex.Message + "\n" + ex.StackTrace);
	}
}