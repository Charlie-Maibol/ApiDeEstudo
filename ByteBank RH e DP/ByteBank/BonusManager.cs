using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Register(Directors directors)
        {
            _TotalBonus += directors.GetBonus();
        }

        public double GetTotalBonus()
        {
            return _TotalBonus;
        }
    }
}
