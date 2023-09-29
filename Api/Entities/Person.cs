using Api.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Person : Contact
    {
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
