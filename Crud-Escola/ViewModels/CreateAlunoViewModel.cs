﻿using System.ComponentModel.DataAnnotations;

namespace Crud_Escola.ViewModels
{
    public class CreateAlunoViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int IdSchool { get; set; }
        [Required]
        public int IdClassroom { get; set; }
    }
}
