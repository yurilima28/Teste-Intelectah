﻿using Agedamento.Models;

namespace Agendamento.Repositorio
{
    public interface IPacientesRepositorio
    {
        PacientesModel ListarPorId(int id);
        List<PacientesModel> BuscarTodos();
        PacientesModel Adicionar(PacientesModel paciente);

        PacientesModel Atualizar (PacientesModel paciente);
        bool Apagar(int id);
    }
}
