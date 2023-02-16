using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class InsufficientBalanceException : FinancialOperationException
    {
        public double Currency { get; }
        public double WithdrawValue { get; }

        public InsufficientBalanceException()
        {

        }

        public InsufficientBalanceException(double currency, double withdrawValue)
            : this("Tentativa de saque do valor de " + withdrawValue + " em uma conta com saldo de " + currency)
        {
            Currency = currency;
            WithdrawValue = withdrawValue;
        }

        public InsufficientBalanceException(string message)
            : base(message)
        {
        }

        public InsufficientBalanceException(string message, Exception InnerException)
            : base(message, InnerException)
        {

        }
    }
}
