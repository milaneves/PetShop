using PetShop.Models;
using System;
using Xunit;

namespace PetShopTeste
{
    public class AnimalTeste
    {
        [Fact]
        public void Animal_CriarAnimal_RetonaAnimal()
        {
            var AnimalEsperado = new
            {
                NomeAnimal = "Luck",
                MotivoInternacao = "dor no ouvido",
                EstadoSaude = "Em tratamento",
                NomeTutor = "Neves",
                EnderecoTutor = "Rua 2",
                TelefoneTutor = "71984787451",
                AlojamentoId = 1

            };
            var animal = new Animal(AnimalEsperado.NomeAnimal, AnimalEsperado.MotivoInternacao,
                                    AnimalEsperado.EstadoSaude, AnimalEsperado.NomeTutor,
                                    AnimalEsperado.EnderecoTutor, AnimalEsperado.TelefoneTutor,
                                    AnimalEsperado.AlojamentoId);
         Assert.Equals(AnimalEsperado.NomeAnimal, animal.NomeAnimal);
        }
    }
}
