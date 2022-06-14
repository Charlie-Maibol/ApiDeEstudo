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

        public InsufficientBalanceException(double Balance, double WithdrawValue) : this ("Tentativa de saque no valor de " + WithdrawValue + " em uma conta com saldo de " + Balance)
        {

        }
        public InsufficientBalanceException(string message) : base(message)
        {

        }
    }
}
