using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class InsufficientBalanceException : Exception
    {
        public double Balance { get; }
        public double WithdrawValue { get; }

        public InsufficientBalanceException()
        {

        }

        public InsufficientBalanceException(double balance, double withdrawValue)
            : this("Tentativa de saque do valor de " + withdrawValue + " em uma conta com saldo de " + balance)
        {
            Balance = Balance;
            WithdrawValue = withdrawValue;
        }

        public InsufficientBalanceException(string message)
            : base(message)
        {
        }
    }
}
