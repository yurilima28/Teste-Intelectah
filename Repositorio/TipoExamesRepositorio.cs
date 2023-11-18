using Agedamento.Data;
using Agendamento.Models;

namespace Agendamento.Repositorio
{
    public class TipoExamesRepositorio : ITipoExamesRepositorio
    {
        private readonly BancoContext _bancoContext;

        public TipoExamesRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<TipoExameModel> BuscarTodos()
        {
            return _bancoContext.TipoExames.ToList();
        }

        public TipoExameModel ListarPorId(int id)
        {
            return _bancoContext.TipoExames.FirstOrDefault(x => x.Id == id);
        }

        public TipoExameModel Atualizar(TipoExameModel exame)
        {
            TipoExameModel exameDB = ListarPorId(exame.Id);
            if (exameDB == null) throw new Exception("Houve um erro na atualização do exame");

            exameDB.Nome = exame.Nome;
            exameDB.Descricao = exame.Descricao;

            _bancoContext.TipoExames.Update(exameDB);
            _bancoContext.SaveChanges();

            return exameDB;
        }

        public TipoExameModel Adicionar(TipoExameModel exame)
        {
            _bancoContext.TipoExames.Add(exame);
            _bancoContext.SaveChanges();
            return exame;
        }

        public bool Apagar(int id)
        {
            TipoExameModel exameDB = ListarPorId(id);
            if (exameDB == null) throw new Exception("Houve um erro ao deletar o exame");

            _bancoContext.TipoExames.Remove(exameDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
