using Agendamento.Models;
using Agendamento.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Agendamento.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConsultaRepositorio _consultaRepositorio;
        private readonly IPacientesRepositorio _pacientesRepositorio;
        private readonly ITipoExamesRepositorio _tipoExamesRepositorio;
        private readonly IExameRepositorio _exameRepositorio;

        public ConsultaController
         (
            IConsultaRepositorio consultaRepositorio,
            IPacientesRepositorio pacientesRepositorio,
            ITipoExamesRepositorio tipoExamesRepositorio,
            IExameRepositorio exameRepositorio
         )
        {
            _consultaRepositorio = consultaRepositorio;
            _pacientesRepositorio = pacientesRepositorio;
            _tipoExamesRepositorio = tipoExamesRepositorio;
            _exameRepositorio = exameRepositorio;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ExameModel exame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _exameRepositorio.Adicionar(exame);
                    TempData["MensagemSucesso"] = "Consulta marcada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(exame);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Consulta não agendada, tente novamente{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Agendar( ConsultaModel consulta)
        {
            if (!_consultaRepositorio.DataHoraConflitante(consulta))
            {
                consulta.Protocolo = Guid.NewGuid().ToString();
                _consultaRepositorio.Adicionar(consulta);

                return RedirectToAction("Index", "Consultas");
            }
            else
            {
                ModelState.AddModelError("DataHora", "Já existe uma consulta agendada para este horário.");
                return View(consulta);
            }
        }
    }
}



