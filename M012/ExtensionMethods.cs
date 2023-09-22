namespace M012;

public static class ExtensionMethods
{
	public static int Quersumme(this int x)
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		//Dictionary<T, int> elementeMitZahl = new();
		//foreach (T element in x)
		//{
		//	elementeMitZahl.Add(element, Random.Shared.Next());
		//}
		//IOrderedEnumerable<KeyValuePair<T, int>> order = elementeMitZahl.OrderBy(e => e.Value);
		//return order.Select(e => e.Key);

		return x.OrderBy(e => Random.Shared.Next());
	}
}
