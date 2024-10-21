using Geometrie.BLL;

var p1 = new Point(4, 8);
var p2 = new Point(3, 5);
Console.WriteLine(p1.CalculerDistance(p2));
Console.WriteLine(p1.X);

var poly=new Polygone(p1, p2, new Point(1, 2), new Point(3, 4));

Console.WriteLine(poly[0].X);
