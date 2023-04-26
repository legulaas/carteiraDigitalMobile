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


		/*
		 * Realiza saque de um valor da carteira digital
		 *
		 * @param double Valor
		 * @return boolean
		 */
		public bool Sacar(double Valor)
		{

			double SaldoTransferivel = this.Saldo + this.Limite;

			if(Valor <= SaldoTransferivel)
			{

				this.Saldo -= Valor;
				return true;

			} 
			else
			{
				return false;
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
			if (Valor > 0)
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
            double SaldoTransferivel = this.Saldo + this.Limite;

            // Verifica se há saldo para transferência
            if (Valor <= SaldoTransferivel)
			{

                // Realiza o saque de uma conta e o deposito em outra
                bool saque = this.Sacar(Valor);
                bool transferencia = Destino.Depositar(Valor);

                // Verifica se a transferência foi realizada
                if (transferencia && saque)
                {
                    return true;
                }
                else
                {
                    // Deposita o valor da transferência caso haja falha
                    this.Depositar(Valor);
                    return false;
                }

			}
			else
			{
				// Realiza o saque de uma conta e o deposito em outra
				bool saque = this.Sacar(Valor);
				bool transferencia = Destino.Depositar(Valor);

				// Verifica se a transferência foi realizada
				if (transferencia)
				{
					return true;
				}
				else
				{
					// Deposita o valor da transferência caso haja falha
					this.Depositar(Valor);
					return false;
				}
			}
		}

		/*
		 * 
		 * Realiza a cobrança de tarifa mensalmente
		 * 
		 * @param int Dia
		 * @return boolean
		 * 
		
		public bool CobrarTarifa(int Dia)
		{



		}*/
	}
}