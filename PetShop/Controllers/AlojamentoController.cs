using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using PetShop.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Controllers
{
    public class AlojamentoController : Controller
    {
        private readonly AlojamentoRepositorio _alojamentoRepositorio;
        private readonly AnimalController _animalController;
        private readonly AnimalRepositorio _animalRepositorio;
        private readonly PetShopContext _context;

        public AlojamentoController()
        {
            _context = new PetShopContext();
            _alojamentoRepositorio = new AlojamentoRepositorio(_context);
            _animalRepositorio = new AnimalRepositorio(_context);
            _animalController  = new AnimalController();
        }
        public IActionResult Consultar()
        {
            var alojamento = _alojamentoRepositorio.GetAll();
            return View(alojamento);
        }

        public IActionResult Verificar( int id)
        {
            var animalVinculado = _alojamentoRepositorio.AnimalVinculadoAlojamento(id);
            
            if (string.IsNullOrEmpty(animalVinculado?.NomeAnimal))
             {
                return RedirectToAction("Consultar", "Animal");

            }
            AlojamentoViewModel viewModel = new AlojamentoViewModel { AlojamentoId = id, NomeAnimal = animalVinculado.NomeAnimal };
     
            ViewBag.lstStatusAlojamento = new SelectList(new Alojamento().ListaStatus(), "Status", "Status");

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DesvincularAnimal(AlojamentoViewModel _alojamento, int id  )
        {
            var alojamentoSelecionado = _alojamentoRepositorio.GetById(id);
            var animalVinculado = _alojamentoRepositorio.AnimalVinculadoAlojamento(id);


            if ( _alojamento.StatusAlojamento == "Livre")
            {
                return RedirectToAction("Consultar", "Animal");
            }

            var _context = new PetShopContext();
            var atualizarStatus = new Alojamento {
                                              Id = _alojamento.Id,
                                              Status = _alojamento.StatusAlojamento

                                 };
            _context.Entry(atualizarStatus).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Consultar));

        }

    }
}
