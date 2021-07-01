using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using PetShop.Repositorio;
using System;
using System.Linq;

namespace PetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalRepositorio _animalRepositorio;
        private readonly AlojamentoRepositorio _alojamentoRepositorio;
        private readonly PetShopContext _context;

        public AnimalController()
        {
            _context = new PetShopContext();
            _animalRepositorio = new AnimalRepositorio(_context);
            _alojamentoRepositorio = new AlojamentoRepositorio(_context);


        }

        public IActionResult Consultar()
        {
            var animal = _animalRepositorio.GetAll();
            return View(animal);
        }

        [HttpPost]
        public IActionResult ConsultarAnimal(Pesquisa pesquisa)
        {

            var animal = _animalRepositorio.GetByNome(pesquisa.nomeDigitado);
            if (animal == null)
            {
                return NotFound();
            }

            return View("Consultar", animal);
        }

        public class Pesquisa
        {
            public string nomeDigitado { get; set; }
        }

        public IActionResult Cadastrar()
        {
            PreencherViewBag();

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Animal _animal)
        {
          try
            {
                var animal = new Animal
                {
                    NomeAnimal = _animal.NomeAnimal,
                    MotivoInternacao = _animal.MotivoInternacao,
                    NomeTutor = _animal.NomeTutor,
                    TelefoneTutor = _animal.TelefoneTutor,
                    EnderecoTutor = _animal.EnderecoTutor,
                    EstadoSaude = _animal.EstadoSaude,
                    AlojamentoId = _animal.AlojamentoId
                };

               
                _animalRepositorio.Create(animal);

                AnimalAlojamento(_animal.AlojamentoId, "Ocupado");

                return RedirectToAction(nameof(Consultar));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult EditarAnimal(int id)
        {
            Animal animal = _animalRepositorio.GetById(id);
            var alojamentoLivres = _alojamentoRepositorio.GetAlojamentosLivres();

            ViewBag.lstEstadoSaude = new SelectList(new EstadoSaude().Lista(), "Status", "Status");
            ViewBag.lstalojamentoLivres = new SelectList(alojamentoLivres.OrderBy(a => a.Id), nameof(Alojamento.Id), nameof(Alojamento.Id));

            return View(animal);
        }

        [HttpPost]
        public IActionResult Editar(Animal _animal, int id)
        {
            var alojamentoLivres = _alojamentoRepositorio.GetAlojamentosLivres();
            var _animalSelecionado = _animalRepositorio.GetById(id);

            if (_animal == null)
            {
                return NotFound();
            }

            try
            {

                AnimalAlojamento(_animalSelecionado.AlojamentoId, "Livre");

                _animalSelecionado.NomeAnimal = _animal.NomeAnimal;
                _animalSelecionado.MotivoInternacao = _animal.MotivoInternacao;
                _animalSelecionado.NomeTutor = _animal.NomeTutor;
                _animalSelecionado.TelefoneTutor = _animal.TelefoneTutor;
                _animalSelecionado.EnderecoTutor = _animal.EnderecoTutor;
                _animalSelecionado.EstadoSaude = _animal.EstadoSaude;
                _animalSelecionado.AlojamentoId = _animal.AlojamentoId;

                _animalRepositorio.Update(_animalSelecionado);
             
                
                //instanciando novamente o context para não ocorrer erro de chaves conflitantes
                var _context = new PetShopContext();
                var atualizarStatus = new Alojamento{ Id = _animal.AlojamentoId,Status = "Ocupado" };
                _context.Entry(atualizarStatus).State = EntityState.Modified;
                _context.SaveChanges();



                return RedirectToAction(nameof(Consultar));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult DeletarAnimal(int id)
        {
            try
            {

                var animal = _context.Animal.FirstOrDefault(m => m.Id == id);

                if (animal == null)
                {
                    return NotFound();
                }

                return View(animal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var animal = _animalRepositorio.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }

            try
            {
                AnimalAlojamento(id, "Livre");

                _animalRepositorio.Delete(animal);
                return RedirectToAction(nameof(Consultar));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AnimalAlojamento(int id, string status)
        {
            var animalVinculado = _alojamentoRepositorio.AnimalVinculadoAlojamento(id);

            if (animalVinculado.NomeAnimal != null)
            {
                var DesvincularAnimalAlojamento = new Alojamento{ Id = id, Status = status };
                _alojamentoRepositorio.Update(DesvincularAnimalAlojamento);

            }
        }

        public void PreencherViewBag()
        {
            var alojamentoLivres = _alojamentoRepositorio.GetAlojamentosLivres();

            ViewBag.lstEstadoSaude = new SelectList(new EstadoSaude().Lista(), "Status", "Status");
            ViewBag.lstalojamentoLivres = new SelectList(alojamentoLivres.OrderBy(a => a.Id), nameof(Alojamento.Id), nameof(Alojamento.Id));
        }

        

    }
}
