namespace M006.Data;

internal class Kurs
{
	public string Titel { get; set; }

	public Person[] Teilnehmer { get; set; } = new Person[10];

	public Kurs(string titel, params Person[] teilnehmer)
	{
		Titel = titel;
		Teilnehmer = teilnehmer;
	}

	public void AddTeilnehmer(Person p)
	{
		for (int i = 0; i < Teilnehmer.Length; i++)
		{
			if (Teilnehmer[i] == null)
			{
				Teilnehmer[i] = p;
				return;
			}
		}

		//Kein Platz mehr
		Person[] tnNeu = new Person[Teilnehmer.Length * 2];
		Array.Copy(Teilnehmer, tnNeu, Teilnehmer.Length);
		tnNeu[Teilnehmer.Length] = p;
		Teilnehmer = tnNeu;
	}
}
