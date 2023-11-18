using Agedamento.Data;
using Agedamento.Models;
using Agendamento.Models;
using Agendamento.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class TipoExamesController : Controller
{
    private readonly ITipoExamesRepositorio _tipoExamesRepositorio;
    
    public TipoExamesController(ITipoExamesRepositorio TipoExamesRepositorio)
    {
        _tipoExamesRepositorio = TipoExamesRepositorio;
    }

    public IActionResult Index()
    {
        List<TipoExameModel> TipoExames = _tipoExamesRepositorio.BuscarTodos();
        return View(TipoExames);
    }

    public IActionResult Criar()
    {
        return View();
    }
    public IActionResult Editar(int id)
    {
        TipoExameModel TipoExame = _tipoExamesRepositorio.ListarPorId(id);
        return View(TipoExame);
    }
    public IActionResult ApagarConfirmacao(int id)
    {
        TipoExameModel TipoExame= _tipoExamesRepositorio.ListarPorId(id);
        return View(TipoExame);

    }

    public IActionResult Apagar(int id)
    {
        try
        {
            bool apagado = _tipoExamesRepositorio.Apagar(id);
            if (apagado)
            {
                TempData["MensagemSucesso"] = " Exame excluido com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = " Houve um erro ao apagar o exame";

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
    public IActionResult Criar(TipoExameModel TipoExame)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _tipoExamesRepositorio.Adicionar(TipoExame);
                TempData["MensagemSucesso"] = "Exame cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            return View(TipoExame);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Exame não cadastrado, tente novamente. Detalhe do erro {erro.Message}";
            return RedirectToAction("Index");


        }
    }

    [HttpPost]
    public IActionResult Alterar(TipoExameModel TipoExame)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _tipoExamesRepositorio.Atualizar(TipoExame);
                TempData["MensagemSucesso"] = "Exame alterado com sucesso";
                return RedirectToAction("Index");

            }
            return View("Editar", TipoExame);
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Não conseguimos atualizar o exame, tente novamente. Detalhe do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }
}
