using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    internal class Employees
    {
        //0 - funcionário
        //1 - Diretor
        //2 - Designer
        //3 - Gerente de contas
        //4 - Coordenador
        //n - ...
        private int _type;
        public string Name { get; set; }
        public string CPF { get; set; }
        public double Salary { get; set; }

        public Employees(int type)
        {
            _type = type;
        }

        
        public double GetBonus()
        {
            if(_type == 1)
            {
                return Salary;
                
            }
            return Salary * 0.10;

        }
            
    }
}
