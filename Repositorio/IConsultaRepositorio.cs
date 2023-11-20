using Agendamento.Models;
using System.Collections.Generic;

namespace Agendamento.Repositorio
{
    public interface IConsultaRepositorio
    {
        ConsultaModel ListarPorId(int id);
        List<ConsultaModel> BuscarTodos();
   
        ConsultaModel Adicionar(ConsultaModel consulta);
        ConsultaModel Atualizar(ConsultaModel consulta);

        bool DataHoraConflitante(ConsultaModel consulta);
        bool Apagar(int id);
    }
}
