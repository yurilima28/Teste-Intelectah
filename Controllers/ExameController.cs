using Agedamento.Models;
using Agendamento.Models;
using Agendamento.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    public class ExameController : Controller
    {
 
            private readonly IExameRepositorio _exameRepositorio;
            private readonly ITipoExamesRepositorio _tipoExamesRepositorio;

            public ExameController(IExameRepositorio exameRepositorio, ITipoExamesRepositorio tipoExamesRepositorio)
            {
                _exameRepositorio = exameRepositorio;
                 _tipoExamesRepositorio = tipoExamesRepositorio;

            }

            public IActionResult Index()
            {
                
                List<ExameModel> exames = _exameRepositorio.BuscarTodos();
                return View(exames);
            }
            public IActionResult Criar()
            {
                   
                   List<TipoExameModel> tipoExames = _tipoExamesRepositorio.BuscarTodos();
                    ViewBag.TipoExames = tipoExames;
                    ViewBag.Teste = "Teste";
                   return View();
            }
            public IActionResult Editar(int id)
            {
                 
                ExameModel exame = _exameRepositorio.ListarPorId(id);
                return View(exame);
            }
            public IActionResult ApagarConfirmacao(int id)
            {
                ExameModel exame = _exameRepositorio.ListarPorId(id);
                return View(exame);
            }

            public IActionResult Apagar(int id)
            {
                try
                {
                    bool apagado = _exameRepositorio.Apagar(id);
                    if (apagado)
                    {
                        TempData["MensagemSucesso"] = "Exame apagado com sucesso!";
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Não conseguimos apagar o exame";
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Não conseguimos apagar o exame, detalhes do erro: {erro.Message}";
                    return RedirectToAction("Index");

                }

            }


            [HttpPost]
            public IActionResult Criar(ExameModel exame)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                    _exameRepositorio.Adicionar(exame);
                        TempData["MensagemSucesso"] = "Exame cadastrado com sucesso";
                        return RedirectToAction("Index");
                    }

                    return View(exame);

                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Exame não cadastrado, tente novamente. Detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");

                }

            }
            [HttpPost]
            public IActionResult Alterar(ExameModel exame)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                    _exameRepositorio.Atualizar(exame);
                        TempData["MensagemSucesso"] = "Paciente alterado com sucesso";
                        return RedirectToAction("Index");
                    }
                    return View("Editar", exame);

                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"Não conseguimos atualizar os dados do paciente, tente novamente. Detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
        }
    }



