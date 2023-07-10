using Empresa.Data;
using Empresa.Models;
using Empresa.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Empresa.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly SistemaTarefasDBcontex _dbContext;
        public FuncionarioRepositorio(SistemaTarefasDBcontex SistemaTarefasDBcontex)
        {
            _dbContext = SistemaTarefasDBcontex;
        }
         public async Task<FuncionarioModel> BuscarPorId(int id)
        {
            
             return await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<FuncionarioModel> BuscarPorCPF(string CPF)
        {
            return await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.CPF == CPF);
        }
        public async Task<List<FuncionarioModel>> BuscarTodosFuncionarios()
        {
            return await _dbContext.Funcionarios.ToListAsync();
        }
        public async Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario, string CPF)
        {
            FuncionarioModel funcionarioExistente = await BuscarPorCPF(CPF);
            if (funcionarioExistente != null)
            {
                funcionarioExistente.Ativo = "sim";
                await _dbContext.SaveChangesAsync();
                return funcionarioExistente;
            }

            funcionario.Ativo = "sim";
            await _dbContext.Funcionarios.AddAsync(funcionario);
            await _dbContext.SaveChangesAsync();

            return funcionario;
        }

        public async Task<FuncionarioModel> Atualizar(FuncionarioModel Funcionario, int id)
        {
            FuncionarioModel FuncionarioPorId = await BuscarPorId(id);
            if (FuncionarioPorId == null)
            {
                throw new Exception($"Usuário por ID:{id} Não foi encontrado no banco de dados.");
            }
            FuncionarioPorId.Nome = Funcionario.Nome;
            FuncionarioPorId.Email = Funcionario.Email; 
            FuncionarioPorId.CPF = Funcionario.CPF;
            _dbContext.Funcionarios.Update(FuncionarioPorId);
           await _dbContext.SaveChangesAsync(); 
            return FuncionarioPorId;
        }
        public async Task<FuncionarioModel> Demitir(string CPF )
        {
            FuncionarioModel FuncionarioPorCPF = await BuscarPorCPF(CPF);
            if (FuncionarioPorCPF == null)
            {
                throw new Exception($"Usuário por ID:{CPF} Não foi encontrado no banco de dados.");
            }
            FuncionarioPorCPF.Ativo = "não";
            _dbContext.Funcionarios.Update(FuncionarioPorCPF);
            await _dbContext.SaveChangesAsync();
            return FuncionarioPorCPF;
        }
        public async Task<bool> Apagar(int id)
        {
            FuncionarioModel FuncionarioPorId = await BuscarPorId(id);
            if (FuncionarioPorId == null)
            {
                throw new Exception($"Usuário por ID:{id} Não foi encontrado no banco de dados.");
            }
            _dbContext.Funcionarios.Remove(FuncionarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
       }   
    }
}
