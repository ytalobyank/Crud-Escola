using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Escola.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("School")]
        public int IdSchool { get; set; }
        [ForeignKey("Classroom")]
        public int IdClassroom { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Escola School { get; set; }
        public Turma Classroom { get; set; }

    }
}
