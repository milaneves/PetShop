using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Repositorio
{
    public class AlojamentoRepositorio
    {
        private readonly PetShopContext _context;
        

        public AlojamentoRepositorio(PetShopContext context)
        {
            _context = context;
        }
        public List<Alojamento> GetAll()
        {
            return _context.Alojamento.ToList();
        }

        public Alojamento GetById(int id)
        {
            return _context.Alojamento.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Alojamento> GetAlojamentosLivres()
        {
            return _context.Alojamento.Where(a => a.Status == "Livre").ToList();
        }

        public Animal AnimalVinculadoAlojamento(int id)
        {
            return _context.Animal.Where(f => f.AlojamentoId == id).FirstOrDefault();

        }
        public void Create(Alojamento alojamento)
        {
            _context.Alojamento.Add(alojamento);
            _context.SaveChanges();
        }
        public void Update(Alojamento alojamento)
        {
            _context.Entry(alojamento).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Alojamento alojamento)
        {
            _context.Alojamento.Remove(alojamento);
            _context.SaveChanges();
        }
    }
}

