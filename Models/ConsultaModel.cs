using Agedamento.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamento.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="A data e hora são obrigatárias.")]
        [Display(Name = " Data e Hora")]
        public DateTime DataHora { get; set; } = DateTime.Now.ToLocalTime();


        [ForeignKey("Exame")]
        public int ExameId { get; set; }



        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }
        public PacientesModel Paciente { get; set; }



        public string Protocolo { get; set; }




    }
}
