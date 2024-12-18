namespace Geometrie.DAL
{
    public class Cercle_DAL
    {
        public int? Id { get; set; }
        public double Rayon {  get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }
        public Point_DAL Centre { get; set; }

        public Cercle_DAL()
        {
            
        }
        public Cercle_DAL(Point_DAL centre, double rayon)
        {
            Centre = centre;
            Rayon = rayon;
        }

        public Cercle_DAL(int id, Point_DAL centre, double rayon)
            : this(centre, rayon)
        {
            Id = id;
        }
    }
}
