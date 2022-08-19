using System.ComponentModel.DataAnnotations;

namespace Crud_Escola.ViewModels
{
    public class CreateEscolaViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
