using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorEnderecos.Data;
using GerenciadorEnderecos.Models;
using System.Text;

namespace GerenciadorEnderecos.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnderecosController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index() 
        {
            var lista = await _context.Enderecos.OrderByDescending(x => x.Id).ToListAsync();
            return View(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Endereco endereco)
        {
            endereco.UsuarioId = 1; // Mock do usuário autenticado
            
            ModelState.Remove("Usuario");

            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Endereco endereco)
        {
            ModelState.Remove("Usuario");

            if (ModelState.IsValid)
            {
                _context.Update(endereco);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExportarCsv()
        {
            var enderecos = await _context.Enderecos.ToListAsync();
            var csv = new StringBuilder();
            
            csv.AppendLine("CEP;Logradouro;Bairro;Cidade;UF;Numero");
            foreach (var e in enderecos)
                csv.AppendLine($"{e.Cep};{e.Logradouro};{e.Bairro};{e.Cidade};{e.Uf};{e.Numero}");

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            var bom = Encoding.UTF8.GetPreamble();
            var resultado = bom.Concat(bytes).ToArray();

            return File(resultado, "text/csv", "enderecos.csv");
        }

        [HttpGet]
        public async Task<IActionResult> BuscarCep(string cep)
        {
            try 
            {
                using var client = new HttpClient();
                var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                var json = await response.Content.ReadAsStringAsync();
                return Content(json, "application/json");
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}