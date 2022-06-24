using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class CheckingAccounts
    {
        private static int TaxesOperation;

        public static int TotalOfCreateadAccounts { get; private set; }

        public int CheckOutFailureCounter { get; private set; } 

        public int TransferFailureCounter { get; private set; } 

        public Client Titular { get; set; }

        public int WithdrawCounter { get; set; }    

        public int Number { get; }
        public int Agency { get; }

        private double _currency = 100;
        public double Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _currency = value;
            }
        }

        public CheckingAccounts(int agency, int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agency));
            }

            if(number <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(number));
            }

            Agency = agency;
            Number = number;

            TotalOfCreateadAccounts++;
            TaxesOperation = 30 / TotalOfCreateadAccounts;
        }

        public void Whithdraw(double ammount)
        {
            if (ammount < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(ammount));
            }

            if (_currency < ammount)
            {
                CheckOutFailureCounter++;
                throw new InsufficientBalanceException(Currency, ammount);
            }
            try
            {
                Whithdraw(ammount);

            }
            catch (InsufficientBalanceException ex)
            {
                TransferFailureCounter++;
                throw new FinancialOperationException("Operação não realizada.", ex);
            }


            _currency -= ammount;
        }

        public void Deposit(double ammount)
        {
            _currency += ammount;
        }

        public void Transfer(double ammount, CheckingAccounts DestinyAccount)
        {
            if (ammount < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(ammount));
            }

            try
            {
                Whithdraw(ammount);
                
            }
            catch (InsufficientBalanceException ex)
            {
                TransferFailureCounter++;
                throw new FinancialOperationException("Operação não realizada.", ex);
            }

            DestinyAccount.Deposit(ammount);
        }
    }
}
