using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PetShop.Models
{
    public class Alojamento
    {
        [Display(Name = "Alojamento")]
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public Alojamento()
        {
        }


        public Alojamento(int id, string status)
        {
            Id = id;
            Status = status;
        }

        public List<Alojamento> ListaStatus()
        {
            return new List<Alojamento>
            {
                new Alojamento(Id, Status) { Id = 1 , Status = "Livre"},

                new Alojamento(Id, Status) {Id = 2 ,Status = "Ocupado"},

                new Alojamento(Id, Status) {Id = 3,   Status = "Esperando dono" }
            };
        }
    }
}
