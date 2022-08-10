namespace _06___ByteBank
{
    public class CheckingAccounts
    {
        private Client _holder;
        private int _numeber;
        private int _agency;
        private double _currency = 100;

        public Client Holder { get; set; }

        public int Agency { get; set; }
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