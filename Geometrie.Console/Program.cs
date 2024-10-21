using Geometrie.BLL;

var p1 = new Point(4, 8);
var p2 = new Point(3, 5);
Console.WriteLine(p1.CalculerDistance(p2));
Console.WriteLine(p1.X);

var tri = new Triangle(p1, p2, new Point(1, 2));

for (int i = 0; i < tri.Count; i++)
{
    Console.WriteLine(tri[0]);
}

foreach (var point in tri)
{
    Console.WriteLine(point);
}

var cercle = new Cercle(p1, 5);
Console.WriteLine(tri.CalculerPerimetre());    
Console.WriteLine(cercle.CalculerPerimetre());

var listeDeFormes = new List<IForme>();
listeDeFormes.Add(tri);
listeDeFormes.Add(cercle);

foreach (var forme in listeDeFormes)
{
    Console.WriteLine($"Périmètre : {forme.CalculerPerimetre()}");
    Console.WriteLine($"Aire : {forme.CalculerAire()}");
}