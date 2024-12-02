namespace Geometrie.DAL
{
    public class Point
    {
        public int? Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }

        public Polygone? Polygone { get; set; }

        public Point(int x, int y, DateTime dateDeCreation)
        {
            X = x;
            Y = y;
            DateDeCreation = dateDeCreation;
        }

        public Point(int id, int x, int y, DateTime dateDeCreation,
                DateTime? dateDeModification, Polygone? polygone)
            :this(x,y, dateDeCreation)
        {
            Id = id;
            DateDeModification = dateDeModification;
            Polygone = polygone;
        }
    }
}
