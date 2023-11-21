using Agedamento.Data;
using Agendamento.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Agendamento.Repositorio
{

    public class ExameRepositorio : IExameRepositorio
    {
        private readonly BancoContext _bancoContext;


        public ExameRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ExameModel> BuscarTodos()
        {
            return _bancoContext.Exames.ToList();
        }

        public ExameModel ListarPorId(int id)
        {
            return _bancoContext.Exames.FirstOrDefault(x => x.Id == id);
        }

        public ExameModel Atualizar(ExameModel exame)
        {
            ExameModel exameDB = ListarPorId(exame.Id);
            if (exameDB == null) throw new Exception("Houve um erro na atualização do exame");
            
            exameDB.TipoExameId = exame.TipoExameId;
            exameDB.Nome = exame.Nome; 
            exameDB.Observacoes = exame.Observacoes;

            _bancoContext.Exames.Update(exameDB);
            _bancoContext.SaveChanges();

            return exameDB;
        }

        public ExameModel Adicionar(ExameModel exame)
        {
            _bancoContext.Exames.Add(exame);
            _bancoContext.SaveChanges();
            return exame;
        }

        public bool Apagar(int id)
        {
            ExameModel exameDB = ListarPorId(id);
            if (exameDB == null) throw new Exception("Houve um erro ao deletar o exame");

            _bancoContext.Exames.Remove(exameDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public List<ExameModel> BuscarPorTipo(int tipoExameId)
        {
            return _bancoContext.Exames
                .Where(e => e.TipoExameId == tipoExameId)
                .ToList();
        }

    }
}
    

