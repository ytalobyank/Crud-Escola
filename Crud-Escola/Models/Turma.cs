using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Escola.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("School")]
        public int IdSchool { get; set; }
        public string Name { get; set; }
        public Escola School { get; set; }
    }
}
