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

            
            TaxesOperation = 30 / TotalOfCreateadAccoutns;

            TotalOfCreateadAccoutns++;
        }


        public bool Whithdraw(double ammount)
        {
            if (_currency < ammount)
            {
                return false;
            }

            _currency -= ammount;
            return true;
        }

        public void Deposit(double ammount)
        {
            _currency += ammount;
        }


        public bool Transferir(double ammount, CheckingAccounts DestinyAccount)
        {
            if (_currency < ammount)
            {
                return false;
            }

            _currency -= ammount;
            DestinyAccount.Deposit(ammount);
            return true;
        }
    }
}
