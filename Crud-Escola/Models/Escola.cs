using System.ComponentModel.DataAnnotations;

namespace Crud_Escola.Models
{
    public class Escola
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
