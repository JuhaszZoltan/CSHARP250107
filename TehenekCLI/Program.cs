using TehenekCLI;

const string DIR = "D:\\PROJECTS\\CSHARP250107\\TehenekCLI\\src";

List<Tehen> happyCows = [];

using StreamReader sr = new($"{DIR}\\hozam.txt");

while (!sr.EndOfStream)
{
    string adatSor = sr.ReadLine();

    string id = adatSor.Split(';')[0];
    string nap = adatSor.Split(';')[1];
    string mennyiseg = adatSor.Split(';')[2];

    Tehen aktTehen = new(id);
    if(!happyCows.Contains(aktTehen))
    {
        happyCows.Add(aktTehen);
    }
    else
    {
        int index = happyCows.IndexOf(aktTehen);
        happyCows[index].EredmenytRogzit(nap, mennyiseg);
    }
}

Console.WriteLine("3. feladat");
Console.WriteLine($"Az állomány {happyCows.Count} tehén adatait tartalmazza");

var joltejelok = happyCows.Where(t => t.HetiAtlag != -1);

Console.WriteLine("6. feladat");
Console.WriteLine($"{joltejelok.Count()} darab sort írtam az állományba");

using StreamWriter sw = new($"{DIR}\\joltejelok.txt");

foreach (var tehen in joltejelok)
{
    sw.WriteLine($"{tehen.Id} {tehen.HetiAtlag}");
}

Console.WriteLine("7. feladat:");
Console.WriteLine("Kérem adja meg a tehén azonosítóját!");
string azon = Console.ReadLine();
if (string.IsNullOrWhiteSpace(azon))
    throw new Exception("asdasd");
int leszarmazott = happyCows
    .Count(t => t.Id.StartsWith(azon) && t.Id != azon);
Console.WriteLine($"A leszármazottak száma: {leszarmazott}");
