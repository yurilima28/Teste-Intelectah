using Agedamento.Models;
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
            List<ConsultaModel> consulta = _consultaRepositorio.BuscarTodos();
            return View(consulta);
        }


        public IActionResult Criar()
        {
            DateTime dataHoraAtual = DateTime.Now;

 
            string protocolo = $"{dataHoraAtual:yyyyMMdd-HHmmss}";
            string filtro = HttpContext.Request.Query["filtro"];
             List<PacientesModel> pacientes = _pacientesRepositorio.BuscarPorNomeCpf(filtro);
            ViewBag.pacientes = pacientes;
            ViewBag.Protocolo = protocolo;

          

            List<TipoExameModel> TipoExame = _tipoExamesRepositorio.BuscarTodos();
            ViewBag.TipoExame =TipoExame;

            
            
            ViewBag.exames = TipoExame;
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
        public IActionResult Agendar(ConsultaModel consulta)
        {
            if (!_consultaRepositorio.DataHoraConflitante(consulta))
            {
                consulta.Protocolo = Guid.NewGuid().ToString();
                _consultaRepositorio.Adicionar(consulta);
                TempData["MensagemSucesso"] = "Consulta marcada com secesso";

                return RedirectToAction("Index", consulta);
            }
            else
            {
                ModelState.AddModelError("DataHora", "Já existe uma consulta agendada para este horário.");
               return this.Criar();
            }

        }
        [HttpGet]
        public IActionResult CarregarExames(int tipoExameId)
        {
            var exames = _exameRepositorio.BuscarPorTipo(tipoExameId); 
            return Json(exames);
        }
        [HttpGet]
            public IActionResult buscarPaciente (string filtroPaciente)
        {
            var Pacientes = _pacientesRepositorio.BuscarPorNomeCpf(filtroPaciente);
              return Json(Pacientes);
        }

    }
}



