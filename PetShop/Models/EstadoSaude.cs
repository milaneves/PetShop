using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class EstadoSaude
    {
        public int Id  { get; set; }
        public string Status { get; set; }

        public List<EstadoSaude> Lista()
        {
            return new List<EstadoSaude>
            {
                new EstadoSaude { Id = 1 , Status = "Em tratamento"},

                new EstadoSaude {Id = 2 ,Status = "Se recuperando"},

                new EstadoSaude {Id = 3,   Status = "Recuperada" }
            };
        }
    }
}
