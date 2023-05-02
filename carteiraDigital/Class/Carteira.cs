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

		public DateTime UltimaCobranca { get; set; }


		/*
		 * Realiza saque de um valor da carteira digital
		 *
		 * @param double Valor
		 * @return boolean
		 */
		public bool Sacar(double Valor)
		{

			if(Valor > this.Saldo){															//	Verifica necessidade de utilizar limite para o saque

				if(Valor > (this.Saldo + this.Limite) && Valor > this.Limite)				// Se o valor for maior que o saldo e o limite juntos
				{
					return false;
				} 
				else if (Valor <= this.Limite)												// Verifica necessidade de utilizar o limite (em caso de saldo <= 0)
				{	
					this.Limite -= Math.Round(Valor,2);
					this.Saldo -= Math.Round(Valor,2);
					Console.WriteLine("Saque realizado: " + Valor.ToString("C"));

					return true;
				}
				else																		// Utilizando o saldo e o limite para o saque
				{

					double restante = Math.Round(((this.Saldo + this.Limite) - Valor), 2);	
					
					if(restante < 0){

						return false;

					} else {
						
						this.Saldo = Math.Round((restante - this.Limite), 2);				// Saldo negativo devido ao uso do limite
						this.Limite = Math.Round(restante, 2);								// Limite diminui após o uso dele

						Console.WriteLine("Saque realizado: " + Valor.ToString("C"));

						return true;
					}

				}

			} 
			else 
			{

				this.Saldo -= Math.Round(Valor, 2);
				Console.WriteLine("Saque realizado: " + Valor.ToString("C"));
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

				this.Saldo += Math.Round(Valor, 2);

				Console.WriteLine("Depósito realizado: " + Valor.ToString("C"));

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
		public bool Transferir(Carteira Destino, double Valor)
		{

			bool transferencia;

			bool saque = this.Sacar(Math.Round(Valor, 2));

			if(saque){

				transferencia = Destino.Depositar(Math.Round(Valor,2));

				if(transferencia) 
				{	
					Console.WriteLine($"Transferência realizada.\r\n Origem: {this.Numero}\r\n Destino: {Destino.Numero}\r\n Valor: {Valor.ToString("C")}");
					return true;
				} 
				else
				{	
					Console.WriteLine("Falha na transferência, valor retornado para conta de origem.");
					this.Depositar(Math.Round(Valor, 2));
					return false;
				}
			
			} else {
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
			DateTime periodoMes = this.UltimaCobranca.AddMonths(1);							//	Acrescenta 1 mês na data da ultima cobrança para verificação.
			int validaPeriodo = DateTime.Compare(dataSistema, periodoMes);                  //	Verifica se a data está válida para realizar a cobrança

			if(validaPeriodo >= 0){															// Verifica se a última cobrança foi realizada há 1 mês ou mais.

				this.Saldo -= Math.Round(this.Tarifa, 2);													
				this.UltimaCobranca = dataSistema;

				Console.WriteLine("Tarifa cobrada para conta "+this.Numero);

                return true;

			} else {

				return false;

			}
		}
	}
}