namespace LogansArchive.Models
{
    public class GameStudio
    {
        public int GameStudioId { get; set; }
        public int GameId { get; set; }
        public int StudioId { get; set; }


        public virtual Studio? Studio { get; set; }
        public virtual Game? Game { get; set; }


    }
}
