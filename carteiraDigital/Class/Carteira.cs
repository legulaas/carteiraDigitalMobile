using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Carteira
{

	// Define variável 'Saldo', método set somente dentro da própria classe.
	public double Saldo { get; private set; }

	// Define variável 'Dono', métodos set e get;
	public string Dono { get; set; }

    /*
     * Realiza saque de um valor da carteira digital
     *
     * @param double Valor
     * @return boolean
     */
    public bool Sacar(double Valor)
	{

		if(Valor > this.Saldo)
		{
			return false;

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
	public bool Depositar (double Valor)
	{
		if(Valor > 0) {
            this.Saldo += Valor;
            return true;
        } else {
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
	public bool Transferir (Carteira Destino, double Valor)
	{	
		// Verifica se há saldo para transferência
		if(this.Saldo < Valor)
		{

			return false;

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
}
