using LojaProdutos.Data;
using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Categoria
{
    public class CategoriaService : ICategoriaInterface
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoriaModel>> BuscarCategorias()
        {
            try
            {
                var categorias = await _context.Categorias.ToListAsync();
                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
