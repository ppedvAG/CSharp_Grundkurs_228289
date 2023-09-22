using M013;

namespace M013_Tests;

[TestClass]
public class RechnerTests
{
	//Test Explorer: View -> Test Explorer
	//Rechtsklick auf Dependencies -> Add Project Reference -> Projekt auswählen -> Links Haken setzen

	[TestMethod]
	public void TesteAddiere()
	{
		Rechner r = new Rechner();
		double ergebnis = r.Addiere(3, 4);
		Assert.AreEqual(7, ergebnis); //Assert: Erwartetes Testergebnis mit dem tatsächlichen Ergebnis vergleichen
	}
}