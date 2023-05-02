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

			double restante;

			if(Valor > this.Saldo)
			{

				if(Valor > this.Saldo + this.Limite){


                    Console.WriteLine(this.Saldo);
                    Console.WriteLine(this.Limite);
                    return false;

				} 
				else if(Valor < (this.Saldo + this.Limite))
				{

					restante = (this.Saldo+this.Limite) - Valor;

					if(restante < 0)
					{

                        return false;

					} 
					else
					{
						this.Saldo = restante - this.Limite;
						this.Limite = restante;

                        return true;
					}

                } 
				else
				{

                    Console.WriteLine(this.Saldo);
                    Console.WriteLine(this.Limite);

                    this.Saldo = 0 - this.Limite;
					this.Limite = 0;
					return true;
				}

			} 
			else if(Valor < this.Saldo)
			{

                Console.WriteLine(this.Saldo);
                Console.WriteLine(this.Limite);

                this.Saldo -= Valor;
				return true;

			} 
			else
			{

                Console.WriteLine(this.Saldo);
                Console.WriteLine(this.Limite);

                this.Saldo = 0;
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
		public bool Transferir(Carteira Destino, double Valor)
		{

			double valorTransferivel = this.Saldo + this.Limite;
			bool transferencia;

			if(valorTransferivel >= Valor) 
			{

				bool saque = this.Sacar(Valor);

				Console.WriteLine(saque);

				transferencia = Destino.Depositar(Valor);

				if(transferencia) 
				{
					return true;
				} 
				else
				{
					this.Depositar(Valor);
					return false;
				}
				
			} 
			else
			{
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

				this.Saldo -= this.Tarifa;													
				this.UltimaCobranca = dataSistema;

                return true;

			} else {

				return false;

			}
		}
	}
}