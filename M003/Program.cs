using System.Diagnostics;

namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: Eine Variable, die mehrere Werte halten kann (statt einem einzigen)
			int[] zahlen;
			zahlen = new int[10]; //new: Neues Objekt erstellen -> hier ein int[] mit 10 Stellen (Indizes von 0-9)
			zahlen[0] = 5; //An die Stelle 0 den Wert 5 schreiben
			Console.WriteLine(zahlen[0]);

			//Direkte Initialisierung
			int[] direkt1 = new int[] { 1, 2, 3, 4, 5 };
			int[] direkt2 = new[] { 1, 2, 3, 4, 5 };
			int[] direkt3 = { 1, 2, 3, 4, 5 };

            Console.WriteLine(zahlen.Length); //Anzahl Plätze (10)
            Console.WriteLine(zahlen.Contains(5)); //true oder false -> true
            Console.WriteLine(zahlen.Contains(25)); //true oder false -> false

			//Mehrdimensionale Arrays: Arrays von Arrays (2D, 3D, 4D, ...)
			int[,] array2D = new int[3, 3]; //Matrix (3x3)
			array2D[0, 1] = 5;

			array2D = new[,] //Direkte Initialisierung
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

            Console.WriteLine(array2D.Length); //9 Elemente gesamt
            Console.WriteLine(array2D.Rank); //2 Dimensionen
            Console.WriteLine(array2D.GetLength(1)); //Länge der Dimension X
			#endregion

			#region Bedingungen
			//Vergleichsoperatoren: ==, !=, <, >, <=, >=
			//Logische Operatoren: &&, ||, !, ^ 

			//Vergleichsoperatoren vergleichen zwei Werte
			//Logische Operatoren verbinden zwei Bedingungen

			int zahl1 = 5;
			int zahl2 = 8;
			if (zahl1 < zahl2)
			{
                Console.WriteLine("Zahl1 ist kleiner als Zahl2");
            }
			else if (zahl1 > zahl2)
			{
				Console.WriteLine("Zahl1 ist größer als Zahl2");
			}
			else
			{
				Console.WriteLine("Zahl1 ist gleich Zahl2");
			}

			//Einzeilige ifs, elses, Schleifen, Funktionen können ohne Klammern geschrieben werden
			if (zahl1 < zahl2)
				Console.WriteLine("Zahl1 ist kleiner als Zahl2");
			else if (zahl1 > zahl2)
				Console.WriteLine("Zahl1 ist größer als Zahl2");
			else
				Console.WriteLine("Zahl1 ist gleich Zahl2");

			//XOR, ^: Wenn die beiden Bedingungen unterschiedlich sind
			if (zahlen.Contains(5) ^ zahlen.Contains(10)) //Wenn 5 oder 10 aber nicht beide enthalten sind
			{

			}

			if ((zahlen.Contains(5) && !zahlen.Contains(10)) || (!zahlen.Contains(5) && zahlen.Contains(10)))
			{
                Console.WriteLine("Selbiges wie oben aber länger");
            }

			if (zahl1 % 2 == 0) //Hier muss ein Boolean herauskommen (zahl1 % 2 -> 5 % 2 = 1)
			{
				
			}

			//Ternary Operator
			//Fragezeichen Operator
			//Code noch kompakter machen mithilfe von einzeiligen Bedingungen
			//? ist if
			//: ist else
			if (zahl1 < zahl2)
				Console.WriteLine("Zahl1 ist kleiner als Zahl2");
			else if (zahl1 > zahl2)
				Console.WriteLine("Zahl1 ist größer als Zahl2");
			else
				Console.WriteLine("Zahl1 ist gleich Zahl2");

            Console.WriteLine(zahl1 < zahl2 ? "Zahl1 ist kleiner als Zahl2" : (zahl1 > zahl2 ? "Zahl1 ist größer als Zahl2" : "Zahl1 ist gleich Zahl2"));
            
			if (zahl1 == zahl2)
                Console.WriteLine("Gleich");
			else
                Console.WriteLine("Ungleich");

            Console.WriteLine(zahl1 == zahl2 ? "Gleich" : "Ungleich");


			Stopwatch sw = Stopwatch.StartNew();
			for (int i = 0; i < 1_000_000_000; i++)
			{
				string s;
				if (zahl1 == zahl2)
					s = "Gleich";
				else
					s = "Ungleich";
			}
            Console.WriteLine(sw.ElapsedMilliseconds);


			sw = Stopwatch.StartNew();
			for (int i = 0; i < 1_000_000_000; i++)
			{
				string s = zahl1 == zahl2 ? "Gleich" : "Ungleich";
			}
			Console.WriteLine(sw.ElapsedMilliseconds);
			#endregion
		}
	}
}