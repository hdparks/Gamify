using SQLite;

namespace Gamify.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public int XP { get; set; }
    }
}
