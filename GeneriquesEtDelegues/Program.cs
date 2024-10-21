var liste = new Liste<int>();
liste.Ajouter(5);
liste.Ajouter(8);
liste.Ajouter(3);
foreach (var element in liste)
{
    Console.WriteLine(element);
}
//for
for (int i = 0; i < liste.Count; i++)
{
    Console.WriteLine(liste[i]);
}

//tri
liste.Trier();

foreach (var element in liste)
{
    Console.WriteLine(element);
}

//une liste de string
var listeString = new Liste<string>();
listeString.Ajouter("toto");
listeString.Ajouter("titi");
listeString.Ajouter("tata");
foreach (var element in listeString)
{
    Console.WriteLine(element);
}
//tri
listeString.Trier();
foreach (var item in listeString)
{
    Console.WriteLine(item);
}
