using SQLite;
using MyPatchV3.BL.Contracts;

namespace MyPatchV3.DL.Models
{
    [Table("User")]
    public class User : IEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

