using System;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class PatioTeste : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            veiculo = new Veiculo();
            estacionamento = new Patio();
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComoUmVeiculo()
        {
            //Arrange           
            veiculo.Proprietario = "Murilo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("José Silva", "POL-1498", "Cinza", "Fusca")]
        [InlineData("Mario Silva", "LKJ-1498", "Azul", "Palio")]
        [InlineData("Murilo dos Santos", "GKJ-1010", "Azul", "Corso")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos            (string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca
            (string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consulta = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consulta.Placa);    

        }

        [Fact]
        public void AlterarDadosVeiculosDoProprioVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "Murilove";
            veiculo.Placa = "JKL-8888";
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Ferrari";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "Murilove",
                Placa = "JKL-8888",
                Cor = "Preto",
                Modelo = "Ferrari"
            };            

            //Act
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
