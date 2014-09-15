using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
  
            
            double totalSum = 1;
            int cashPaid = 1;
            double roundedAmount = 1;
            int changeBack;
            int fiveHundreds;
            int hundreds;
            int twenties;
            int tens;
            int fives;
            int singles;

            //Fråga efter totalsumma och kontrollera om avrundat belopp är < 1 kr.

            Console.Write("Mata in totalsumma för köp:");

            while (true)
            { 
               try           
               {             
                totalSum = double.Parse(Console.ReadLine());
                roundedAmount = (int)Math.Round(totalSum);

                if (roundedAmount < 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Summan blir 0");
                    Console.ResetColor();
                    throw new OverflowException();
                }
                   break;
               }
                catch (FormatException)
               {
                   Console.Write("Var god försök igen:");
               }
                catch (OverflowException)
               { return; }
               
            }
        

            //Fråga efter erhållen summa och kontrollera att den är högre än priset

            Console.Write("Ange erhållet belopp:");
            while (true)
            {
                try
                {
                    cashPaid = int.Parse(Console.ReadLine());

                    if (cashPaid < roundedAmount)
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Summan är mindre än totalbeloppet.");
                        Console.ResetColor();
                        throw new OverflowException();

                    }
                    break;
                }
                catch (FormatException)
                    {
                        Console.Write("Gör ett nytt försök");
                    }
                catch (OverflowException)
                { return; }
            }

           
            
            //Beräkna differensen

            Console.WriteLine("Totalt belopp är {0:c}", totalSum);

            Console.WriteLine("Öresavrundning: {0:c}", roundedAmount - totalSum);

            Console.WriteLine("Summa att betala: {0} kr.", roundedAmount);

            Console.WriteLine("Inbetalt belopp är {0} kr.", cashPaid);

            changeBack = cashPaid - (int)roundedAmount;

            Console.WriteLine("Växeln är {0} kr.", changeBack);
         

            //Beräkna hur mycket som man får tillbaka i...
            //500-lappar

            fiveHundreds = changeBack / 500;
            
            if (fiveHundreds > 0)
            {
            Console.WriteLine("Antal 500-kronorssedlar i växel: {0} st.", fiveHundreds);
            }
            changeBack = changeBack - (fiveHundreds * 500);

            //100-lappar

            hundreds = changeBack / 100;

            if (hundreds > 0)
            {
            Console.WriteLine("Antal 100-kronorssedlar i växel: {0} st.", hundreds);
            }
            changeBack = changeBack - (hundreds * 100);
            
            //20-lappar

            twenties = changeBack / 20;

            if (twenties > 0)
            {
            Console.WriteLine("Antal 20-kronorssedlar i växel: {0} st.", twenties);
            }
            changeBack = changeBack - (twenties * 20);

            //tio-kronor

            tens = changeBack / 10;

            if (tens > 0)
            {
            Console.WriteLine("Antal 10-kronorsmynt i växel: {0}", tens);
            }
            changeBack = changeBack - (tens * 10);

            //5-kronor

            fives = changeBack / 5;

            if (fives > 0)
            {
            Console.WriteLine("Antal 5-kronorsmynt i växel: {0}", fives);
            }
            changeBack = changeBack - (fives * 5);

            //1-kronor

            singles = changeBack / 1;

            if (singles >0)
            {
            Console.WriteLine("Antal 1-kronorsmynt i växel: {0}", singles);
            }
            changeBack = changeBack - (singles * 1);

        
        }
    }
}
