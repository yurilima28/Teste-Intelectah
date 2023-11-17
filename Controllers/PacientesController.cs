using Agedamento.Models;
using Agendamento.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Agedamento.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacientesRepositorio _pacientesRepositorio;
        public PacientesController(IPacientesRepositorio PacientesRepositorio)
        {
            _pacientesRepositorio = PacientesRepositorio;
        }
        public IActionResult Index()
        {
            List<PacientesModel> pacientes = _pacientesRepositorio.BuscarTodos();
            return View(pacientes);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
             PacientesModel paciente =  _pacientesRepositorio.ListarPorId(id);
            return View(paciente);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            PacientesModel paciente = _pacientesRepositorio.ListarPorId(id);
            return View(paciente);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado = _pacientesRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Paciente apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar o paciente";
                }
                return RedirectToAction("Index");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar o paciente, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");

            }

        }


        [HttpPost]
        public IActionResult Criar(PacientesModel paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacientesRepositorio.Adicionar(paciente);
                    TempData["MensagemSucesso"] = "Paciente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(paciente);

            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Paciente não cadastrado, tente novamente. Detalhe do erro: {erro.Message }";
                return RedirectToAction("Index");

            }
            
        }
        [HttpPost]
        public IActionResult Alterar(PacientesModel paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pacientesRepositorio.Atualizar(paciente);
                    TempData["MensagemSucesso"] = "Paciente alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", paciente);

            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos atualizar os dados do paciente, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
