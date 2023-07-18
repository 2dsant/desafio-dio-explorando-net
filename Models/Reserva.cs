namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            var capacidade = Suite.Capacidade > hospedes.Count;

            if (capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception($"Capacidade máxima de héspedes permitida na suite é de {Suite.Capacidade} hospede(s)");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.1m;
                valor -= desconto;
            }

            return valor;
        }
    }
}