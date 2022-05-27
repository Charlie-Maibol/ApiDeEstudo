using ByteBank.Employee;
using System;


namespace ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
           BonusCalculator();
           Console.ReadLine();

        }
        public static void BonusCalculator()
        {
            BonusManager bonusManager = new BonusManager();

            Designers pedro = new Designers("833.222.048-29");
            pedro.Name = "Pedro";

            Directors roberta = new Directors("833.222.048-29");
            roberta.Name = "Roberta";

            Ancillary igor = new Ancillary("833.222.048-29");
            igor.Name = "Igor";

            AccountsManager camila = new AccountsManager("833.222.048-29");
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
