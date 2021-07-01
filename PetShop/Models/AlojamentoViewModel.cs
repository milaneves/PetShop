
namespace PetShop.Models
{
    public class AlojamentoViewModel
    {
        public int Id { get; set; }
        public string NomeAnimal { get; set; }

        public string MotivoInternacao { get; set; }

        public string EstadoSaude { get; set; }

        public string NomeTutor { get; set; }


        public string EnderecoTutor { get; set; }

        public string TelefoneTutor { get; set; }
        public int AlojamentoId { get; set; }
        public string StatusAlojamento { get; set; }
    }
}
