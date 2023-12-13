namespace Clicker.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int clicks { get; set; }
        public int time { get; set; }
        public string name { get; set; } = "";
        public float clicksPerMinute { get; set; }

    }
}
