using Agedamento.Data;
using Agedamento.Models;
using System.Collections.Generic;


namespace Agendamento.Repositorio
{
    public class PacientesRepositorio : IPacientesRepositorio
    {
        private readonly BancoContext _bancoContext;
        public PacientesRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<PacientesModel> BuscarTodos()
        {
            return _bancoContext.Pacientes.ToList();
        }
        public PacientesModel ListarPorId(int id)
        {
            return _bancoContext.Pacientes.FirstOrDefault(x => x.Id == id);
        }
        public PacientesModel Atualizar(PacientesModel paciente)
        {
            PacientesModel pacienteDB = ListarPorId(paciente.Id);
            if (pacienteDB == null) throw new Exception("Houve um erro na atualizalção do paciente");
            pacienteDB.Nome = paciente.Nome;
            pacienteDB.Cpf = paciente.Cpf;
            pacienteDB.DataDeNascimento = paciente.DataDeNascimento;
            pacienteDB.Sexo = paciente.Sexo;
            pacienteDB.Telefone = paciente.Telefone;
            pacienteDB.Email = paciente.Email;

            _bancoContext.Pacientes.Update(pacienteDB);
            _bancoContext.SaveChanges();

            return pacienteDB;
        }


        public PacientesModel Adicionar(PacientesModel paciente)
        {
           
                _bancoContext.Pacientes.Add(paciente);
                _bancoContext.SaveChanges();
                return paciente;
          
        }

        public bool Apagar(int id)
        {
            PacientesModel pacienteDB = ListarPorId(id);
            if (pacienteDB == null) throw new Exception("Houve um erro na deleção do paciente");

            _bancoContext.Pacientes.Remove(pacienteDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
