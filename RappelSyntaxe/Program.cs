//commentaire
/* commentaire
 * commentaire
 * commentaire
 */

//déclaration de variable
int a;
//dfslfjd
a = 5;
if (true)
{
    int b = 3;
}


//Inférence de type
var c = "5";
var d = new InvalidCastException();
InvalidCastException e = new();

//type anonyme
var voiture = new { Marque = "Renault", Modele = "Clio" };
Console.WriteLine(voiture.Marque);

//type nullable
//sur les types par valeur c'est obligatoire
//si on veut que la variable soit null
int? f = null;
bool? bb = null;
//sur les types par référence c'est optionnel
//si on veut que la variable soit null
//Ca enlève des warning et c'est une bonne indication
//pendant le codage
string? s = null;

//type dynamique
//on peut changer le type de la variable
//a n'utiliser que si on ne peut pas faire autrement
dynamic g = 5;
g = "5";
g = new InvalidCastException();

//tableau
int[] tab = new int[5];
tab[0] = 5;
//syntaxe rapide d'affectation
int[] tab2 = { 1, 2, 3, 4, 5 };
//tableau multidimensionnel
int[,] tab3 = new int[2, 3];
tab3[0, 0] = 1;
//tableau de tableau
int[][] tab4 = new int[2][];
tab4[0] = new int[3];
tab4[0][0] = 1;
tab4[0][1] = 2;

//Liste
List<int> liste = new List<int>();
liste.Add(5);
//syntaxe rapide d'affectation
List<int> liste2 = new List<int> { 1, 2, 3, 4, 5 };



