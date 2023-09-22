namespace M014;

internal class Program
{
	static void Main(string[] args)
	{
		//Dateimanagement
		//File, Directory, Path, Environment
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test");  //Nur ein String Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Text.txt"); //Dateipfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//StreamWriter
		//Öffnet einen Stream auf eine Datei und ermöglicht das Schreiben der Datei
		//Stream: Gibt einen Tunnel auf die entsprechende Resource
		//Der Stream wird beschrieben und danach kann er geschrieben werden
		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1"); //Hier werden Inhalte in den Stream geschrieben
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.WriteLine("Test4");
		sw.Flush(); //Schreibe den Inhalt des Streams in die Datei
		sw.Close(); //Schließe den Stream

		//using-Block: Ermöglicht das automatische Schließen des unterliegenden Streams am Ende des Blocks
		using (StreamReader sr = new StreamReader(filePath))
		{
			string text = sr.ReadToEnd();
			string[] lines = text.Split(Environment.NewLine);
		} //Hier wird .Dispose() aufgerufen

		using StreamReader sr2 = new StreamReader(filePath); //Using-Statement: Wird am Ende der Methode automatisch geschlossen

		//Schnelle Funktionen
		File.WriteAllText(filePath, "Ein Text");
		File.WriteAllLines(filePath, new string[] { "Ein Text", "Zwei Text" });

		string file = File.ReadAllText(filePath);
		string[] line = File.ReadAllLines(filePath);

		//NuGet-Packages
		//Externe Pakete, die zu unserem Projekt hinzuinstalliert werden können
		//Tools -> NuGet-Package Manager -> Manage NuGet Packages
	}
}