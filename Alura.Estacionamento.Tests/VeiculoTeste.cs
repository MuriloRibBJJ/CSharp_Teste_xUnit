using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste : IDisposable
    {
        private Veiculo veiculo = new Veiculo();
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]        
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact]        
        public void TestaVeiculoFrearComParamentro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar!")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }
        

        [Fact]
        public void FichaDeInfoDoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo
            {
                Proprietario = "André Silva",
                Tipo = TipoVeiculo.Automovel,
                Cor = "Preto",
                Modelo = "Fusca",
                Placa = "ZXC-8888"
            };

            //Act
            string dadosVeiculo = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dadosVeiculo);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            //Assert.Throws<System.FormatException>(
            //    //Act
            //    () => new Veiculo(nomeProprietario)
            //);
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF1234";

            var mensagem = Assert.Throws<System.FormatException>(
                    () => new Veiculo().Placa = placa
                );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
