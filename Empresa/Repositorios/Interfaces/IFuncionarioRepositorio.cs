using Empresa.Models;

namespace Empresa.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<FuncionarioModel>> BuscarTodosFuncionarios();
        Task<FuncionarioModel> BuscarPorId(int id);
        Task<FuncionarioModel> BuscarPorCPF(string CPF);
        Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario, string CPF);
        Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id);
        Task<FuncionarioModel> Demitir(string CPF);
        Task<bool> Apagar(int id);
    }
}

