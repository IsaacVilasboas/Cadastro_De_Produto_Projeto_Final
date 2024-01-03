using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class ProdutoController : Controller
    {
       

        private ProjetoFinalContext _dbContext = new ProjetoFinalContext();
        public IActionResult Index()
        {
            //listagem dos produtos
            var produtos = _dbContext.Produtos.OrderBy(p => p.Id).ToList();
            return View(produtos);

        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Sobre() 
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var produto = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);

            return View(produto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var produto = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);

            return View(produto);
        }

        public IActionResult Exibir(int id)
        {
            var produto = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);

            return View(produto);
        }

       [HttpPost]
        public IActionResult Criar(Produto p) //Função para criar o produto
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Produtos.Add(p);
                    _dbContext.SaveChanges();
                    TempData["Sucesso"] = "Produto cadastrado com sucesso"; //Exibir mensagem caso produto seja criado
                    return RedirectToAction("Index");
                }
                
                return View(p);
            }
            catch (Exception ex)
            {
                TempData["Falha"] = $"Não foi possivel cadastra o produto. \n " +
                    $"Erro:Um outro produto com o mesmo código de barra já foi cadastrado "; //Exibir mensagem caso p produto não seja criado
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(Produto produto) //Função para editar o produto
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var p = _dbContext.Produtos.FirstOrDefault(p => p.Id == produto.Id);

                    p.Categoria = produto.Categoria;
                    p.NomeProduto = produto.NomeProduto;
                    p.Preco = produto.Preco;
                    p.Tipo = produto.Tipo;
                    p.Qtd = produto.Qtd;
                    p.Sabor = produto.Sabor;
                    p.NomeFornecedor = produto.NomeFornecedor;
                    p.CodBarra = produto.CodBarra;
                    p.DataCadastro = produto.DataCadastro;
                    p.Peso = produto.Peso;
                    p.Recipiente = produto.Recipiente;

                    _dbContext.Produtos.Update(p);
                    _dbContext.SaveChanges();
                    TempData["Sucesso"] = "Produto atualizado com sucesso";  //Exibir mensagem caso produto seja atualizado
                    return RedirectToAction("Index");
                }
                
                return View("Editar", produto);
            }
            catch (Exception ex)        
            {
                TempData["Falha"] = $"Não foi possivel atualizar o produto. \n " + 
                    $"Erro: Um outro produto com o mesmo código de barra já foi cadastrado"; //Exibir mensagem caso p produto não seja atualizado
                return RedirectToAction("Index");
            }

        }
        
        public IActionResult Apagar(Produto produto) //Função para apagar o produto
        {
            try
            {

                var p = _dbContext.Produtos.FirstOrDefault(p => p.Id == produto.Id);

                if (p != null) 
                { 

                    _dbContext.Produtos.Remove(p);
                    TempData["Sucesso"] = "Produto excluido com sucesso!";
                   
                }
                else
                {
                    TempData["Falha"] = $"Não foi possivel excluir o produto!";
                }

                _dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["Falha"] = $"Não foi possivel excluir o produto! \n " +
                    $"Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }   
    }
}
