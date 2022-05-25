using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    public class Directors : Employees
    {


        public Directors()
        {
            Console.WriteLine("Criando DIRETOR");
            
        }
    
       
    
        public override double GetBonus()
        {

            return Salary + base.GetBonus();

        }
    }
}

