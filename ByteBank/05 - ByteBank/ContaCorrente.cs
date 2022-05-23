namespace _05___ByteBank
{
    public class CheckingAccounts
    {
        public Client holder;
        public int agency;
        public int number;
        public double currency = 100;
        public bool Checkout(double value)
        {
            if (this.currency < value)
            {
                return false;
            }


            this.currency -= value;
            return true;

        }
        public void CheckIn(double value)
        {
            this.currency += value;
        }

        public bool Transfer(double value, CheckingAccounts goToAccount)
        {

            if (this.currency < value)
            {
                return false;

            }


            this.currency -= value;
            goToAccount.CheckIn(value);
            return true;

        }
    }
}