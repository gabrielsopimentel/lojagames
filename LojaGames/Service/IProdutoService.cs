using LojaGames.Model;

namespace LojaGames.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByDescricao(string descricao);

        Task<IEnumerable<Produto>> GetByNomeOuConsole(string nome, string console);

        Task<IEnumerable<Produto>> GetByBetweenPreco(decimal precoInicial, decimal precoFinal);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);
    }
}
