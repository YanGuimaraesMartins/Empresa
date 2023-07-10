using System.ComponentModel.DataAnnotations;

namespace Empresa.Models
{
    public class FuncionarioModel
    {
        public int id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Ativo { get; set; }
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 999.999.999-99.")]
        public string? CPF { get; set; }


    }
}
