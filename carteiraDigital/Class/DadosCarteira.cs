
namespace carteiraDigital.Class
{
    public class DadosCarteira
    {
        public List<Carteira> ListaDados = new List<Carteira>();

        public DateTime DataSistema { get; set; } = DateTime.Now;

        public DateTime HorarioInicial { get; set; } = DateTime.Today.AddHours(8);
        public DateTime HorarioFinal { get; set; } = DateTime.Today.AddHours(18);


        /*
         * 
         * Verifica se o horário do sistema está apto para realizar depósito, saque e transferências.
         * 
         * @return bool HorarioPermitido
         * 
         */
        public bool VerificaHorario()
        {
            Console.WriteLine("horario inicial: "+this.HorarioInicial);
            Console.WriteLine("horario final: " + this.HorarioFinal);

            bool HorarioPermitido = DateTime.Compare(this.HorarioInicial, this.DataSistema) == -1 && DateTime.Compare(this.HorarioFinal, this.DataSistema) == 1 ? true : false;
            return HorarioPermitido;
        }
    }
}
