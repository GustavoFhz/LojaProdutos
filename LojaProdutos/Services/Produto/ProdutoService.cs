using LojaProdutos.Data;
using LojaProdutos.Dto.Produto;
using LojaProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        private readonly string _sistema;
        public ProdutoService(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;
        }

        public async Task<List<ProdutoModel>> BuscarProdutos()
        {
            try
            {
                return await _context.Produtos.Include(c => c.Categoria).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<ProdutoModel> Cadastrar(CriarProdutoDto criarProdutoDto, IFormFile foto)
        {
            try
            {
                var nomeCaminhoImagem = GeraCaminhoArquivo(foto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GeraCaminhoArquivo(IFormFile foto)
        {
            var codigoUnico = Guid.NewGuid().ToString();
            var nomeCaminhoImagem = foto.FileName.Replace(" ", "").ToLower() + codigoUnico + ".png"; //Remove os espaços e deixa em letra minuscula
            var caminhoParaSalvarImagens = _sistema + "\\imagem\\";

            if (!Directory.Exists(caminhoParaSalvarImagens)) //Não existir, entra no if
            {
                Directory.CreateDirectory(caminhoParaSalvarImagens);
            }

            using (var strem = File.Create(caminhoParaSalvarImagens + nomeCaminhoImagem))
            {
                foto.CopyToAsync(strem).Wait();
            }

            return nomeCaminhoImagem;
        }
    }
}
