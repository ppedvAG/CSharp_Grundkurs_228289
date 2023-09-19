namespace M002
{
	internal class Program
	{
		/// <summary>
		/// Die Main Methode
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			#region Variablen
			//Variable: Container der einen Wert halten kann
			//Aufbau: <Typ> <Name>;
			//Optional: <Typ> <Name> = <Wert>;
			int zahl;
			zahl = 1;
            Console.WriteLine(zahl);

			string wort = "Hallo";

			//Ganze Zahlen: byte, short, int, long
			//Ohne Vorzeichen (nur positive Werte): ushort, uint, ulong
			//Standard: int

			//Kommazahlen: float, double, decimal
			//Standard: double
			//decimal für Geldwerte (weil niedrige Gleitkommaungenauigkeit)

			//Text: string, char
			string str = ""; //Doppelte Hochkomma
			char c = 'A'; //Einzelne Hochkomma

			//bool: true oder false
			bool t = true;
			bool f = false;
			#endregion

			#region Strings
			string kombi = "Das Wort ist " + wort;
            Console.WriteLine(kombi);

			string kombination = "Das Wort ist " + wort + ", die Zahl ist " + zahl + ", der Boolean ist " + t; //Anstrengend
            Console.WriteLine(kombination);

			//Interpolated String ($-String): Code in einen String einzubauen
			string kombination2 = $"Das Wort ist {wort}, die Zahl ist {zahl}, der Boolean ist {t}";
            Console.WriteLine(kombination2);

			string zahlMal2 = $"Die Zahl mal 2 ist {zahl * 2}";

			//Escape-Sequenzen: Sonderzeichen in String einbauen (z.B.: Umbruch, Tabulator, ")
			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			string umbruch = "Ein\nUmbruch";
            Console.WriteLine(umbruch);

			//string pfad = "C:\Users\lk3\Lokal\PPKURS-CS-Grundkurs\M-002-CS-Grundkurs Variablen Datentypen Konvertierung Operatoren";
			string pfad = "C:\\Users\\lk3\\Lokal\\PPKURS-CS-Grundkurs\\M-002-CS-Grundkurs Variablen Datentypen Konvertierung Operatoren";

			//Verbatim String (@-String): Ignoriert Escape Sequenzen
			string pfadV = @"C:\Users\lk3\Lokal\PPKURS-CS-Grundkurs\M-002-CS-Grundkurs Variablen Datentypen Konvertierung Operatoren";
			#endregion

			#region Eingabe
			//string eingabe = Console.ReadLine();
			//         Console.WriteLine("Deine Eingabe ist " + eingabe);

			////Parse Funktionen: Strings in andere Typen konvertieren (in dieser Reihenfolge)
			////Syntax: <Typ der herauskommen soll>.Parse(<String>)
			//int konvertiert = int.Parse(eingabe);
			//         Console.WriteLine($"Die Zahl mal zwei ist {konvertiert * 2}");

			//double d = double.Parse(eingabe);
			#endregion

			#region Konvertierungen
			//String -> Zahl: Parse
			//Zahl -> String: ToString()
			//Anderer Typ -> Anderer Typ: Cast, Typecast, Casting
			string zahlS = "123456";
			int zahlI = int.Parse(zahlS);
			string zahlWiederAlsS = zahlI.ToString();

			//Cast
			double komma = 123.456;
			int x = (int) komma; //Explizite Umwandlung, erzwinge die Umwandlung (wenn der double zu groß ist, wird er auf int.MaxValue gesetzt)
			komma = x; //Implizite Umwandlung, keine Erzwingung notwendig
			#endregion

			#region Arithmetik
			int zahl1 = 4;
			int zahl2 = 7;

            Console.WriteLine(zahl1 + zahl2); //Berechnet nur die Summe, verändert nicht die Werte
			zahl1 += zahl2; //Verändert zahl1

			zahl1 -= zahl2;
			zahl1 %= zahl2; //Modulo: Gibt den Rest der Division zurück

			double d2 = 523.24582748;
            //Rundungsfunktionen: Floor, Ceiling, Round
            Console.WriteLine(Math.Floor(d2)); //Abrunden
            Console.WriteLine(Math.Ceiling(d2)); //Aufrunden
            Console.WriteLine(Math.Round(d2)); //Auf- oder Abrunden
            Console.WriteLine(Math.Round(4.5)); //4
            Console.WriteLine(Math.Round(5.5)); //6, rundet zur nächsten geraden Zahl

            Console.WriteLine(Math.Round(d2, 2)); //Kommastellen angeben

			//Division mit Typen
            Console.WriteLine(8 / 5); //Int Division, da die zwei Parameter Integer
            Console.WriteLine(8.0 / 5); //1.6
            Console.WriteLine(8d / 5); //8d: Schnelle Konvertierung zu double, f für Float, m für Decimal
            Console.WriteLine((double) 8 / 5); //1.6
            Console.WriteLine((double) zahl1 / zahl2); //1.6
			#endregion
		}
	}
}