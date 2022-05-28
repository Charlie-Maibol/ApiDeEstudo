using ByteBank.Employee;

namespace ByteBank
{
    public class BonusManager
    {
        private double _TotalBonus;
        public void Register(Employees employees)
        {
            _TotalBonus += employees.GetBonus();
        }
       

        public double GetTotalBonus()
        {
            return _TotalBonus;
        }
    }
}
