using APICatalogo.Data;
using APICatalogo.Models;
using APICatalogo.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _DbContext;
        public ProdutoRepository(AppDbContext appDbContext)
        {
            _DbContext= appDbContext;   
        }
        public async Task<Produto> BuscarIdProdutos(int id)
        {
            return await _DbContext.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _DbContext.Produtos.ToListAsync();
        }
        public async Task<Produto> Adicionar(Produto produto)
        {
            await _DbContext.Produtos.AddAsync(produto);
            _DbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto> Atualizar(Produto produto, int id)
        {
            Produto produtoPorId = await BuscarIdProdutos(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o Id:{id} não foi encontrado no banco de dados.");
            }
            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.DataCadastro = produto.DataCadastro;   
            produtoPorId.Preco = produto.Preco;

            _DbContext.Produtos.Update(produtoPorId); 
            await _DbContext.SaveChangesAsync();
            
            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            Produto produtoPorId = await BuscarIdProdutos(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o Id:{id} não foi encontrado no banco de dados.");
            }
            _DbContext.Produtos.Remove(produtoPorId);
            await _DbContext.SaveChangesAsync();

            return true; 
        }


    }
}
