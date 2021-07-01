
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do animal")]
        [Display(Name = "Nome do Animal")]
        public string NomeAnimal { get; set; }

        [Required(ErrorMessage = "Informe o motivo")]
        [Display(Name = "Motivo da Internação")]
        public string MotivoInternacao { get; set; }

        [Display(Name = "Estado de Saúde")]
        [Required(ErrorMessage = "Informe o estado de saúde")]
        public string EstadoSaude { get; set; }

        [Display(Name = "Nome do Tutor")]
        [Required(ErrorMessage = "Informe o nome do tutor")]
        public string NomeTutor { get; set; }

        [Display(Name = "Endereço do Tutor")]
        [Required(ErrorMessage = "Informe o endereço do tutor")]
        public string EnderecoTutor { get; set; }

        [Display(Name = "Telefone do Tutor")]
        [Required(ErrorMessage = "Informe o telefone do tutor")]
        public string TelefoneTutor { get; set; }

        public Alojamento Alojamento { get; set; }

        [Display(Name = "Alojamento")]
        public int AlojamentoId { get; set; }
        public string Foto { get; set; }

        public Animal()
        {
        }
        public Animal (string nome, string motivo, string estadoSaude, string nomeTutor, string endereco, string telefone, int alojamentoId)
        {
            NomeAnimal = nome;
            MotivoInternacao = motivo;
            EstadoSaude = estadoSaude;
            NomeTutor = nomeTutor;
            EnderecoTutor = endereco;
            TelefoneTutor = telefone;
            AlojamentoId = alojamentoId;

        }
            
       
    }
}
