using ByteBank.Employee;
using System;
using ByteBank.System;


namespace ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BonusCalculator();
            StartInternalSystem();


           Console.ReadLine();

        }
        public static void StartInternalSystem()
        {
            InternalSystem internalSystem = new InternalSystem();

            Directors roberta = new Directors("833.222.048-29");
            roberta.Name = "Roberta";
            roberta.Password = "123";

            AccountsManager camila = new AccountsManager("833.222.048-29");
            camila.Name = "Camila";
            camila.Password = "123";


            internalSystem.Login(roberta, "abc");
            //internalSystem.Login(camila, "abc");

          
        }
        public static void BonusCalculator()
        {
            BonusManager bonusManager = new BonusManager();

            Employees pedro = new Designers("833.222.048-29");
            pedro.Name = "Pedro";

            Employees roberta = new Directors("833.222.048-29");
            roberta.Name = "Roberta";

            Employees igor = new Ancillary("833.222.048-29");
            igor.Name = "Igor";

            Employees camila = new AccountsManager("833.222.048-29");
            camila.Name = "Camila";

            Dev charles = new Dev("456.275.468-20");
            charles.Name = "Charles";

            bonusManager.Register(pedro);
            bonusManager.Register(roberta);
            bonusManager.Register(igor);
            bonusManager.Register(camila);
            bonusManager.Register(charles);


            Console.WriteLine("Total de bonificações do mês " +
            bonusManager.GetTotalBonus());


        }

    }
}
