
namespace carteiraDigital.Class
{
    public class DadosCarteira
    {
        public List<Carteira> ListaDados = new List<Carteira>();

        public DateTime DataSistema { get; set; } = DateTime.Now;

        public DateTime HorarioInicial = DateTime.Today.AddHours(8);
        public DateTime HorarioFinal = DateTime.Today.AddHours(18);


        /*
         * 
         * Verifica se o horário do sistema está apto para realizar depósito, saque e transferências.
         * 
         * @return bool HorarioPermitido
         * 
         */
        public bool VerificaHorario()
        {
            bool HorarioPermitido = DateTime.Compare(this.HorarioInicial, this.DataSistema) == -1 && DateTime.Compare(this.HorarioFinal, this.DataSistema) == 1 ? true : false;
            return HorarioPermitido;
        }
    }
}
