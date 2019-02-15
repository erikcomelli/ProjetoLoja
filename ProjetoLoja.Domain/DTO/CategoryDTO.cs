using System.ComponentModel.DataAnnotations;

namespace ProjetoLoja.Domain.DTO
{
    public class CategoryDTO : EntityDTO
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage ="O campo Nome é obrigatório")]
        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "Insira ao menos 3 caracteres")]
        public string Name { get; set; }
    }
}