using LojaGames.Data;
using LojaGames.Model;
using Microsoft.EntityFrameworkCore;

namespace LojaGames.Service.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();
        }
        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Produto = await _context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(i => i.Id == id);
                return Produto;
            }
            catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<Produto>> GetByDescricao(string descricao)
        {
            var Produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Descricao.Contains(descricao))
                .ToListAsync();
            return Produto;
        }

        public async Task<IEnumerable<Produto>> GetByBetweenPreco(decimal precoInicial, decimal precoFinal)
        {
            var Produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Preco >= precoInicial && p.Preco <= precoFinal)
                .ToListAsync();
            return Produto;
        }

        public async Task<IEnumerable<Produto>> GetByNomeOuConsole(string nome, string console)
        {
            var Produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Nome.Contains(nome) || p.Console.Contains(console))
                .ToListAsync();
            return Produto;
        }
        public async Task<Produto?> Create(Produto produto)
        {
            if (produto.Categoria is not null)
            {
                var BuscarTema = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscarTema is null)
                    return null;

                produto.Categoria = BuscarTema;
            }

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task<Produto?> Update(Produto produto)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(produto.Id);

            if (ProdutoUpdate is null)
                return null;

            if (produto.Categoria is not null)
            {
                var BuscarCategoria = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscarCategoria is null)
                    return null;

                produto.Categoria = BuscarCategoria;
            }

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }

    }
}
