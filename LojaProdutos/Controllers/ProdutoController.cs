using LojaProdutos.Dto.Produto;
using LojaProdutos.Services.Categoria;
using LojaProdutos.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoInterface _produtoInterface;
        private readonly ICategoriaInterface _categoriaInterface;
        public ProdutoController(IProdutoInterface produtoInterface, ICategoriaInterface categoriaInterface)
        {
            _produtoInterface = produtoInterface;
            _categoriaInterface = categoriaInterface;
        }
        public async Task<IActionResult> Index()
        {

            var produtos = await _produtoInterface.BuscarProdutos();

            return View(produtos);
        }

        public async Task<IActionResult> Cadastrar()
        {

            ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();

            return View();
        }

        public async Task<IActionResult> Editar(int id)
        {
            var produto = await _produtoInterface.BuscarProdutoPorId(id);

            var editarProdutoDto = new EditarProdutoDto
            {
                Nome = produto.Nome,
                Marca = produto.Marca,
                Valor = produto.Valor,
                Foto = produto.Foto,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CategoriaModelId = produto.CategoriaModelId,
            };

            ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();

            return View(editarProdutoDto);
        }

        public async Task<IActionResult> Remover(int id)
        {
            var produto = await _produtoInterface.Remover(id);
            return RedirectToAction("Index", "Produto");
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CriarProdutoDto criarProdutoDto, IFormFile foto)
        {
            if (ModelState.IsValid) //Valida os ErrosMessage
            {
                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                var produto = await _produtoInterface.Cadastrar(criarProdutoDto, foto);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
               TempData["MensagemError"] = "Ocorreu algum erro no processo!";
               ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
               return View(criarProdutoDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarProdutoDto editarProdutoDto, IFormFile? foto)
        {
            if (ModelState.IsValid)
            {
                TempData["MensagemSucesso"] = "Produto editado com sucesso!";
                var produto = await _produtoInterface.Editar(editarProdutoDto, foto);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu algum erro no processo!";
                ViewBag.Categorias = await _categoriaInterface.BuscarCategorias();
                return View(editarProdutoDto);
            }
        }
    }
}
