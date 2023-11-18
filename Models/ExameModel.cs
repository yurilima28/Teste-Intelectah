using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamento.Models
{
    public class ExameModel
    {
        public int Id { get; set; }

        [ForeignKey("TipoExame")]
        public int TipoExameId { get; set; }
        public virtual TipoExameModel tipoExame { get; set; }

        [Required(ErrorMessage = "Informe nome do paciente")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(1000)]
        public string Observacoes { get; set; }

    }
}
