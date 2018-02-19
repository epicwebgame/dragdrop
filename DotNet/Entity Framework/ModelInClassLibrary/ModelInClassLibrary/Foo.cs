using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelInClassLibrary
{
    [Table("Foo")]
    public class Foo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
