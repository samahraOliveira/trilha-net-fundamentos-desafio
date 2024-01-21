using DesafioFundamentos.Models;

namespace EstacionamentoTestes;

public class TesteEstacionamento
{
    Estacionamento estacionamento = new Estacionamento();

    [Fact]
    public void VerificarEstacionamentoAbertoHoraDentroDoHorarioRetornarTrue()
    {
        DateTime horaDentroDoHorario = new DateTime(2024, 1, 1, 10, 0, 0);

        bool resultado = estacionamento.VerificarEstacionamentoAberto(horaDentroDoHorario);

        Assert.True(resultado);
    }

    [Fact]
    public void VerificarEstacionamentoAbertoHoraForaDoHorarioRetornarFalse()
    {
        DateTime horaForadoHorario = new DateTime(2024, 1, 1, 6, 0, 0);

        bool resultado = estacionamento.VerificarEstacionamentoAberto(horaForadoHorario);

        Assert.False(resultado);
    }
}