using System;
using System.ComponentModel.DataAnnotations;
using static Agendamento.Validator.CpfValidacao;

namespace Agedamento.Models
{
    public class PacientesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe nome do paciente")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        [Cpf(ErrorMessage = "CPF informado é inválido")]
        
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento")]
        [DataType(DataType.Date)]
        public string DataDeNascimento { get; set; }

        [Required(ErrorMessage = "Informe o sexo do paciente")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Número obrigatório")]
        [MaxLength(16)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o E-mail")]
        [EmailAddress(ErrorMessage = "E-mail informado é inválido")]
        
        public string Email { get; set; }
    }

}
