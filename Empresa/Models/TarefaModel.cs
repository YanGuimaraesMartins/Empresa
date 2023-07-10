using Empresa.Enums;

namespace Empresa.Models
{
    public class TarefaModel
    {
        public int id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Status { get; set;}
    }
}
