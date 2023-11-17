using Agedamento.Models;
using Agendamento.Models;

namespace Agendamento.Repositorio
{
    public interface IExameRepositorio
    {
        ExameModel ListarPorId(int id);
        List<ExameModel> BuscarTodos();
        ExameModel Atualizar (ExameModel exame);
        ExameModel Adicionar(ExameModel exame);
        bool Apagar(int id);
    }
}
