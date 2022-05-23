namespace _06___ByteBank
{
    public class CheckingAccounts
    {
        public Client holder;
        public int agency;
        public int number;
        private double currency = 100;

        public void BalanceCurrecy(double currency)
        {
            if(currency < 0)
            {
                return;
            }
            
            
            this.currency = currency;   
            
        }

        public double ObtainCurrecy()
        {
            return currency;
        }
        public bool Checkout(double value)
        {
            if (currency < value)
            {
                return false;
            }


            currency -= value;
            return true;

        }
        public void CheckIn(double value)
        {
            currency += value;
        }

        public bool Transfer(double value, CheckingAccounts goToAccount)
        {

            if (currency < value)
            {
                return false;

            }


            currency -= value;
            goToAccount.CheckIn(value);
            return true;

        }
    }
}