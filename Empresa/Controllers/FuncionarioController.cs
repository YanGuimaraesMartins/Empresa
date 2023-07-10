using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Empresa.Models;
using Empresa.Repositorios.Interfaces;

namespace Empresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<FuncionarioModel>>> BuscarTodosFuncionarios()
        {
            List<FuncionarioModel> funcionarios = await _funcionarioRepositorio.BuscarTodosFuncionarios();
            return Ok(funcionarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioModel>> BuscarPorId(int id)
        {
           FuncionarioModel funcionario = await _funcionarioRepositorio.BuscarPorId(id);
            return Ok(funcionario);
        }
        [HttpGet("CPF")]
        public async Task<ActionResult<FuncionarioModel>> BuscarPorCPF(string CPF)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.BuscarPorCPF(CPF);
            return Ok(funcionario);
        }
        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> cadastrar([FromBody] FuncionarioModel funcionarioModel, string CPF)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.Adicionar(funcionarioModel, CPF);
            funcionario.Ativo = "sim";
            return Ok(funcionario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Atualizar([FromBody] FuncionarioModel funcionarioModel, int id)
        {
            funcionarioModel.id = id;
            FuncionarioModel funcionario = await _funcionarioRepositorio.Atualizar(funcionarioModel, id);
            return Ok(funcionario);
        }
        [HttpPut("Demitir")]
        public async Task<ActionResult<FuncionarioModel>> Demitir(string CPF)
        {
            
            FuncionarioModel funcionario = await _funcionarioRepositorio.Demitir(CPF);
            funcionario.Ativo = "não";
            return Ok(funcionario);
        }
            [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Apagar(int id)
        {
            bool apagado = await _funcionarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
