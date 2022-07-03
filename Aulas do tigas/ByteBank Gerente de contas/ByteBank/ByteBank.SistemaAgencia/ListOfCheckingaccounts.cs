using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListOfCheckingaccounts
    {
        private CheckingAccounts[] _itens;
        private int _nextPosition;

        public ListOfCheckingaccounts(int IncialCapacity = 5)
        {
            _itens = new CheckingAccounts[IncialCapacity];
            _nextPosition = 0;

        }
        
        public void add(CheckingAccounts Item)
        {
           VerifyCapacity(_nextPosition + 1);

            Console.WriteLine($"Adicionando item na posição {_nextPosition}");


            _itens[_nextPosition] = Item;
            _nextPosition++;
        }
        public void Remove(CheckingAccounts item)
        {
            int indexItem = -1;

            for (int i = 0; i < _nextPosition; i++)
            {
                CheckingAccounts currentItem = _itens[i];
                if (_itens[i].Equals(item))
                {

                }
            }
        }

        public void myMethodo(string text = "text", int number = 5)
        {

        }

        private void VerifyCapacity(int necessarySeize)
        {
            if (_itens.Length >= necessarySeize)
            {
                return;
            }

            int newSeize = _itens.Length * 2;
            if(newSeize < necessarySeize)
            {
                newSeize = necessarySeize;  
            }

            Console.WriteLine("Aumentando a capacidade da lista!");

            CheckingAccounts[] newArray = new CheckingAccounts[newSeize];

            for(int index = 0; index < _itens.Length; index++)
            {
                newArray[index] = _itens[index];
            }

            _itens = newArray;
        }

        


    }
}
