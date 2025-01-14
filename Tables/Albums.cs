namespace RecordShop_BE.Tables
{
    public class Albums
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Artist {  get; set; }
        public DateOnly ReleaseDate { get; set; }        
    }
}
