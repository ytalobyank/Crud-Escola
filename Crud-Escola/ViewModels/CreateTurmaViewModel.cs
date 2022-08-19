using System.ComponentModel.DataAnnotations;

namespace Crud_Escola.ViewModels
{
    public class CreateTurmaViewModel
    {
        [Required]
        public int IdSchool { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
