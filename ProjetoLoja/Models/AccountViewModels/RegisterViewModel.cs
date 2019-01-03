using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage="O campo {0} é inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, ErrorMessage = "A {0} deve conter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação são diferentes")]
        public string ConfirmPassword { get; set; }
    }
}
