using System;

namespace carteiraDigital.Class
{

	public class Carteira
	{

		public double Saldo { get; private set; }

		public string Dono { get; set; }

		public int Numero { get; set; }

		public string CPF { get; set; }

		public double Limite { get; set; }

		public double Tarifa { get; private set; } = 19.90;

		public DateTime UltimaCobranca {get; set;}


		/*
		 * Realiza saque de um valor da carteira digital
		 *
		 * @param double Valor
		 * @return boolean
		 */
		public bool Sacar(double Valor)
		{

			if(Valor > this.Saldo){

				if(Valor > this.Saldo + this.Limite){

					return false;

				} else {

					double restante = Valor - (this.Saldo+this.Limite);

					if(restante < 0){

						return false;

					} else {
						this.Saldo = this.Limite - restante;
						this.Limite = restante;
						return true;
					}

				}

			} else {

				this.Saldo -= Valor;
				return true;

			}
		}

		/*
		*
		* Realiza deposito de um valor na carteira digital
		*
		* @param double Valor
		* @return boolean
		* 
		*/
		public bool Depositar(double Valor)
		{
			if (Valor > 0)						//Verifica se o valor de depósito é maior que R$0,00
			{
				this.Saldo += Valor;
				return true;
			}
			else
			{
				return false;
			}

		}

		/*
		 * 
		 * Realiza transferência de uma carteira a outra
		 * 
		 * @param Carteira Destino
		 * @param double Valor
		 * @return boolean
		*/
		public bool Transferir(Carteira Destino, double Valor) // CORRIGIR ERRO DE LIMITE E TRANSFERENCIA
		{
			bool saque = this.Sacar(Valor);						// Realiza o saque da conta de origem.

			if (saque)											// Verifica se o saque foi realizado.
			{
				bool transferencia = Destino.Depositar(Valor);	// Realiza o deposito do valor da transferência para a conta destino.
				return true;
			}
			else
			{
				this.Depositar(Valor);							// Deposita o valor da transferência para conta origem caso haja falha.
				return false;
			}
		}

		/*
		 * 
		 * Realiza a cobrança de tarifa mensalmente
		 * 
		 * @param DateTime dataSistema
		 * @return boolean
		 * 
		*/
		public bool CobrarTarifa(DateTime dataSistema)
		{
			DateTime periodoMes = this.UltimaCobranca.AddMonths(1);
			int validaPeriodo = DateTime.Compare(dataSistema, periodoMes);

			Console.WriteLine(validaPeriodo);

			if(validaPeriodo >= 0){

				this.Saldo -= this.Tarifa;
				return true;

			} else {

				return false;

			}
		}
	}
}