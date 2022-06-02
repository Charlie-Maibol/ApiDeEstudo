// using _05_ByteBank;

namespace ByteBank
{
    public class CheckingAccounts
    {
        public Client Holder { get; set; }
        public double _currency = 100;
        public static int TotalOfCreateadAccoutns { get; private set; }


        private int _agency;
        public int Agency
        {
            get
            {
                return _agency;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }

                _agency = value;
            }
        }
        public int Number { get; set; }

        

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
            Agency = agency;
            Number = number;

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
