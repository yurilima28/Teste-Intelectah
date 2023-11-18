
using Agendamento.Models;

namespace Agendamento.Repositorio
{
    public interface ITipoExamesRepositorio
    {
        TipoExameModel ListarPorId(int id);
        List<TipoExameModel> BuscarTodos();
        TipoExameModel Atualizar(TipoExameModel exame);
        TipoExameModel Adicionar(TipoExameModel exame);
        bool Apagar(int id);
    }
}
