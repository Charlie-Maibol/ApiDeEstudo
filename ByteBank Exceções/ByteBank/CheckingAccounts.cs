using System;

namespace ByteBank
{
    public class CheckingAccounts
    {
        public Client Holder { get; set; }

        public static double TaxesOperation { get; private set; }

        public double _currency = 100;

        public static int TotalOfCreateadAccoutns { get; private set; }


        private readonly int _agency;
        public int Agency { get; }
         
        private readonly int _number;
        public int Number { get; }

        

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
                throw new ArgumentException("O argumento número ser maior que zero.", nameof(number));
            }
            if (agency <= 0)
            {
                
                throw new ArgumentException("A agencia deve ser maior que zero.", nameof(agency));
            }
            

            Agency = agency;
            Number = number;

            
            

            TotalOfCreateadAccoutns++;
            TaxesOperation = 30 / TotalOfCreateadAccoutns;
        }


        public void Whithdraw(double ammount)
        {
            if(ammount < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(ammount));
            }
            if (_currency < ammount)
            {
                throw new InsufficientBalanceException(Currency, ammount);
            }

            _currency -= ammount;
            return;
        }

        public void Deposit(double ammount)
        {
            _currency += ammount;
        }


        public void Transfer(double ammount, CheckingAccounts DestinyAccount)
        {
            if (ammount < 0)
            {
                throw new ArgumentException("Valor inválido para o tranferencia.", nameof(ammount));
            }
            Whithdraw(ammount);
            DestinyAccount.Deposit(ammount);
           
        }
    }
}
