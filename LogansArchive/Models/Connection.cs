namespace LogansArchive.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public int gameId { get; set; }
        public int studioId { get; set; }


        public virtual Studio? Studio { get; set; }
        public virtual Game? Game { get; set; }


    }
}
