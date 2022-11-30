using APICatalogo.Models;

namespace APICatalogo.Repositorios.Interfaces;

public interface IProdutoRepository
{
    Task<List<Produto>> BuscarTodosProdutos();
    Task<Produto> BuscarIdProdutos(int id);
    Task<Produto> Adicionar(Produto produto);
    Task<Produto> Atualizar(Produto produto, int id);
    Task<bool> Apagar(int id);
}
