using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System.Collections.Generic;
using System.Linq;


namespace PetShop.Repositorio
{
    public class AnimalRepositorio
    {
        private readonly PetShopContext _context;
        

        public AnimalRepositorio(PetShopContext context)
        {
            _context = context;
        }
        public List<Animal> GetAll()
        {
            return _context.Animal.ToList();
        }

        public Animal GetById(int id)
        {
            return _context.Animal.Where(f => f.Id == id).FirstOrDefault();
        }

        public List<Animal> GetByNome(string nome)
        {
            return _context.Animal.Where(f => f.NomeAnimal == nome).ToList();

        }

    
        public void Create(Animal animal)
        {
            _context.Animal.Add(animal);
            _context.SaveChanges();
        }
        public void Update(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Animal animal)
        {
            _context.Animal.Remove(animal);
            _context.SaveChanges();
        }
    }
}
