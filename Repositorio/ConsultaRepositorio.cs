using Agedamento.Data;
using Agendamento.Models;

namespace Agendamento.Repositorio
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly BancoContext _bancoContext;
        private readonly ILogger<ConsultaModel> _logger;

        public ConsultaRepositorio(BancoContext bancoContext, ILogger<ConsultaModel> logger)
        {
            _bancoContext = bancoContext;
            _logger = logger;
        }
        public bool DataHoraConflitante(ConsultaModel novaConsulta)
        {
            try
            {
                return (_bancoContext.Consulta.Any(c =>
                c.DataHora == novaConsulta.DataHora && 
                c.ExameId == novaConsulta.ExameId && 
                c.Id != novaConsulta.Id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao verificar conflito de data e hora: {ex.Message}");
                throw;
            }
        }

        public List<ConsultaModel> BuscarTodos()
        {
            return _bancoContext.Consulta.ToList();
        }
        public ConsultaModel ListarPorId(int id)
        {
            return _bancoContext.Consulta.FirstOrDefault(x => x.Id == id);
        }
        public ConsultaModel Atualizar(ConsultaModel consulta)
        {
            ConsultaModel consultaDB = ListarPorId(consulta.Id);
            if (consultaDB == null) throw new Exception("Houve um erro ao atualizar a consulta");

            consultaDB.ExameId = consulta.ExameId;
            consultaDB.PacienteId = consulta.PacienteId;
            consultaDB.DataHora = consulta.DataHora;
            consultaDB.Protocolo = consulta.Protocolo;

            _bancoContext.Consulta.Update(consultaDB);
            _bancoContext.SaveChanges();
            return consultaDB;
        }

        public ConsultaModel Adicionar(ConsultaModel consulta)
        {
            if(DataHoraConflitante(consulta))
            {
                throw new Exception("Conflito de horário. Já existe uma consultada agendada neste horario");
            }


            _bancoContext.Consulta.Add(consulta);
            _bancoContext.SaveChanges();
            return consulta;
        }

        public bool Apagar(int id)
        {
            ConsultaModel consultaDB = ListarPorId(id);
            if (consultaDB == null) throw new Exception("Houve um erro ao excluir a consulta");

            _bancoContext.Consulta.Remove(consultaDB);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
