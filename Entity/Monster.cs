using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostGreBE.Entity
{
    public class Monster
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [Column(TypeName = "varchar")]
        public string image { get; set; }
    }
}
