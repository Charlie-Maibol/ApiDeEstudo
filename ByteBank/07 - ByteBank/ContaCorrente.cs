namespace _07___ByteBank
{
    public class CheckingAccounts
    {
        private static int TotalOfAccountsCreatead { get; set; }

        public static int GetTotalOfAccountsCreatead()
        {
            return TotalOfAccountsCreatead;
        }

        private Client _holder;
        private int _number;
        private int _agency;
        private double _currency = 100;


        public Client Holder { get; set; }

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

            TotalOfAccountsCreatead++;            
        }
        public bool Checkout(double value)
        {
            if (_currency < value)
            {
                return false;
            }


            _currency -= value;
            return true;

        }
        public void CheckIn(double value)
        {
            _currency += value;
        }

        public bool Transfer(double value, CheckingAccounts goToAccount)
        {

            if (_currency < value)
            {
                return false;

            }


            _currency -= value;
            goToAccount.CheckIn(value);
            return true;

        }
    }
}