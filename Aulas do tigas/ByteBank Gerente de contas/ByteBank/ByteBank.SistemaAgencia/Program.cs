using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.SistemaAgencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime exipireDate = new DateTime(2022, 7, 21);
            DateTime currentDay = DateTime.Now;
            TimeSpan period = TimeSpan.FromMinutes(60);

            string message = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(period);

            Console.WriteLine(message);
            

            Console.ReadLine();
        }
        
    }


}
