using Agendamento.Models;

namespace Agendamento.Repositorio
{
    public interface IExameRepositorio
    {
        ExameModel ListarPorId(int id);
        List<ExameModel> BuscarTodos();
        ExameModel Adicionar(ExameModel exame);
        ExameModel Atualizar(ExameModel exame);
        bool Apagar(int id);

    }
}
