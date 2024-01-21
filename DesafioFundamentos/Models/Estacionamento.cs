using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }
        private decimal PrecoPorHora { get; set; }

        private List<string> veiculosCarro = new List<string>();
        private List<string> veiculosMoto = new List<string>();

        public void CadastrarVeiculo()
        {
            DateTime horaEntrada = DateTime.Now;

            //IDENTIFICA SE O ESTACIONAMENTO ESTÁ EM HORÁRIO DE FUNCIONAMENTO
            if (!VerificarEstacionamentoAberto(horaEntrada))
            {
                Console.WriteLine("O Estacionamento está fora do horário de funcionamento.");
                return;
            }

            // IDENTIFICAÇÃO DO VEÍCULO E VAGAS
            TipoVeiculo tipoVeiculo = IdentificarTipoVeiculo();
            if (tipoVeiculo == TipoVeiculo.invalido)
            {
                Console.WriteLine("Digite uma opção válida");
                return;
            }

            if (tipoVeiculo == TipoVeiculo.carro)
            {
                VagaCarro vagaCarro = new VagaCarro();
                if (!vagaCarro.VagasDisponiveis(veiculosCarro))
                {
                    Console.WriteLine("O estacionamento atingiu a sua capacidade máxima de carros!");
                    return;
                }
            }
            else if (tipoVeiculo == TipoVeiculo.moto)
            {
                VagaMoto vagaMoto = new VagaMoto();
                if (!vagaMoto.VagasDisponiveis(veiculosMoto))
                {
                    Console.WriteLine("O estacionamento atingiu a sua capacidade máxima de motos!");
                    return;
                }
            }

            // LEITURA E VALIDAÇÃO DA PLACA
            Console.WriteLine("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();
            if (!ValidarPlaca(placa))
            {
                Console.WriteLine("Esta placa não é válida!");
                return;
            }

            // ADICIONAR O VEÍCULO NA LIST
            if (tipoVeiculo == TipoVeiculo.carro)
                veiculosCarro.Add(placa);
            else
                veiculosMoto.Add(placa);

            Console.WriteLine("Veículo inserido no estacionamento!");
        }


        public void RemoverVeiculo()
        {
            PrecoInicial = 10;
            PrecoPorHora = 5;

            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (!ValidarPlaca(placa))
            {
                Console.WriteLine("Esta placa não é válida!");
                return;
            }

            Console.Clear();

            if (veiculosCarro.Any() || veiculosMoto.Any())
            {
                // CÁLCULO HORAS
                Console.WriteLine("Em que horário o veículo foi estacionado?(HH:mm)");
                string horaEntradaString = Console.ReadLine();
                Console.Clear();
                DateTime horaEntrada = DateTime.Parse(horaEntradaString);

                TimeSpan TempoTotal = DateTime.Now.Subtract(horaEntrada);
                int horasTotais = TempoTotal.Hours;
                int minutosTotais = TempoTotal.Minutes;

                // CÁLCULO VALOR
                decimal valorTotal = 0;
                if (horasTotais <= 1)
                {
                    valorTotal = PrecoInicial;
                }
                else
                {
                    valorTotal = PrecoInicial + ((horasTotais - 1) * PrecoPorHora);
                }

                // REMOVENDO DAS LISTAS
                veiculosCarro.Remove(placa);
                veiculosMoto.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido. O tempo total foi de {horasTotais} horas e {minutosTotais} minutos, e o valor total a ser pago é de R${valorTotal}.");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }

        }


        public void ListarVeiculos()
        {
            if (veiculosCarro.Any() || veiculosMoto.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                Console.WriteLine("Carros: ");

                foreach (string carros in veiculosCarro)
                {
                    Console.WriteLine(carros);
                }

                Console.WriteLine("Motos: ");
                foreach (string motos in veiculosMoto)
                {
                    Console.WriteLine(motos);
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }


        // MÉTODO PARA VERIFICAR SE O ESTACIONAMENTO ESTÁ ABERTO
        public bool VerificarEstacionamentoAberto(DateTime hora)
        {
            if (hora.Hour < 7 && hora.Hour > 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // MÉTODO PARA VALIDAR PLACA
        private bool ValidarPlaca(string placa)
        {
            try
            {
                return ValidacaoPlaca.ValidarPlaca(placa);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

        }

        // MÉTODO PARA IDENTIFICAR O TIPO DE VEICULO
        private TipoVeiculo IdentificarTipoVeiculo()
        {
            Console.WriteLine("Qual tipo de veículo será estacionado (carro/moto)?");
            string identificaVeiculo = Console.ReadLine();

            if (identificaVeiculo == "carro")
            {
                return TipoVeiculo.carro;
            }
            else if (identificaVeiculo == "moto")
            {
                return TipoVeiculo.moto;
            }
            else
            {
                return TipoVeiculo.invalido;
            }
        }

    }
}



