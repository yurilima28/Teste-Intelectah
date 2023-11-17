using System.ComponentModel.DataAnnotations;

namespace Agendamento.Models
{
    public class ExameModel
    {
        public int Id { get; set; }



        [Required(ErrorMessage ="Nome  do exame obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; }



        [Required (ErrorMessage ="Descrição obrigatório")]
        [MaxLength (256)]
        public string Descricao { get; set; }

    }
}
