using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generisches Typargument: Typ der in spitzen Klammern bei einer Klasse oder einer Methode übergeben werden kann
		//Über dieses Typargument wird die Klasse/Methode auf einen bestimmten Typen spezifiziert
		List<int> list = new List<int>(100); //Alle T in der Klasse werden durch den gegebenen Typ ersetzt (hier int)
		list.Add(1); //T wird durch int ersetzt

		List<string> strings = new List<string>();
		strings.Add("123"); //T wird durch string ersetzt

		List<List<Person>> personen = new List<List<Person>>();
		personen.Add(new List<Person>()); //T wird durch List<Person> ersetzt

		Test<int>(1, 2, 3, 4);
		Test<string>("X", "Y", "Z");

		foreach (int i in list)
		{
			//foreach wie bei einem Array
		}

		Console.WriteLine(list[0]);
		list[0] = 10; //Index wie bei Array

		list.Sort();

		/////////////////////////////////////////////////////////////////

		Stack<int> stack = new(); //Target-Typed new: Nimmt den Typen von links an
		stack.Push(1);
		stack.Push(2);
		stack.Push(3);
		stack.Push(4); //Elemente auflegen

        Console.WriteLine(stack.Peek()); //Oberstes Element anschauen

        Console.WriteLine(stack.Pop()); //Oberstes Element anschauen und entfernen

		foreach (int i in stack)
			Console.WriteLine(i);

		//Console.WriteLine(stack[0]); //Nicht möglich

		/////////////////////////////////////////////////////////////////

		Queue<int> queue = new();
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4); //Elemente zur Schlange hinzufügen

        Console.WriteLine(queue.Peek()); //Vorderstes Element anschauen

		Console.WriteLine(queue.Dequeue()); //Vorderstes Element anschauen und entfernen

		foreach (int i in queue)
			Console.WriteLine(i);

		//Console.WriteLine(queue[0]); //Nicht möglich

		/////////////////////////////////////////////////////////////////

		//Dictionary: Liste von Key-Value Paaren
		Dictionary<string, int> einwohnerzahlen = new();
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 123); //Nicht möglich, da keine Schlüsselduplikate erlaubt (Schlüssel links)

		if (einwohnerzahlen.ContainsKey("Wien")) //Prüfe ob der Key existiert
			Console.WriteLine(einwohnerzahlen["Wien"]); //Über den Typ des Schlüssels (hier string) das Dictionary angreifen

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //var, Strg + . -> Umwandeln zum korrekten Typ
		{
            Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
        }

		/////////////////////////////////////////////////////////////////

		//SortedDictionary: Sortiert sich automatisch nach dem Schlüssel, wenn sich ein Wert ändert
		SortedDictionary<string, int> sorted = new(); //Achtung: Performance
		sorted.Add("Wien", 2_000_000);
		sorted.Add("Berlin", 3_650_000);
		sorted.Add("Paris", 2_160_000);

		/////////////////////////////////////////////////////////////////

		ObservableCollection<int> o = new();
		o.Add(1);

		//Event: Statischer Punkt in der Klasse, an den von außen eine Methode angehängt werden kann
		//Die Methode wird ausgeführt, wenn in der gegebenen Klasse das Event gefeuert
		//Add, Remove, Move, ... führen das Event aus und dadurch unsere Methode
		o.CollectionChanged += CollectionChanged; //Mit += eine Funktion anhängen

		o.Add(3);
		o.Add(5);
		o.Remove(1);
	}

	private static void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
                Console.WriteLine($"Element hinzugefügt: {e.NewItems[0]}");
                break;
			case NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"Element entfernt: {e.OldItems[0]}");
				break;
		}
	}

	public static void Test<T>(params T[] x) { }
}

public class Person { }