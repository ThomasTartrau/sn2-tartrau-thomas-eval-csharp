namespace Geometrie.DTO
{
    /// <summary>
    /// Point est un DTO (Data Transfer Object)
    /// On ne met pas de logique dans les DTO
    /// Que des propriétés qui représentent des données
    /// et qui seront sérialisées en JSON ou autre par la couche API
    /// </summary>
    public class Cercle_DTO
    {
        public int? Id { get; set; }
        public Point_DTO Centre { get; set; }
        public double Rayon { get; set; }
    }
}
