using System;
using System.Runtime.CompilerServices;
namespace Test;

class Program
{
    static void Main(string[] args)
    {
        char continueChoice= 'Y';
        string userInput = "";
        int userInputVal = 0;

        while(continueChoice == 'Y'){
            Random rnd = new Random();
            int randNum = rnd.Next(1, 100);   
            Console.Write("Guess a number from 1 to 100: ");
            userInput = Console.ReadLine();


            while(userInputVal != randNum){

                if (!int.TryParse(userInput, out userInputVal) || string.IsNullOrWhiteSpace(userInput)){
                    Console.WriteLine("Invalid input");
                    Console.Write("Guess a number from 1 to 100: ");
                    userInput = Console.ReadLine();
                }
                else if(userInputVal > randNum){
                    Console.WriteLine("Lower");
                    Console.Write("Guess a number from 1 to 100: ");
                    userInput = Console.ReadLine();
                }
                else if(userInputVal < randNum){
                    Console.WriteLine("Higher");
                    Console.Write("Guess a number from 1 to 100: ");
                    userInput = Console.ReadLine();
                }
            }
 
            Console.WriteLine("Correct!");
            Console.WriteLine();
            Console.WriteLine("Play again? (Y/N)");
            continueChoice = Convert.ToChar(Console.ReadLine().ToUpper());

            userInputVal = 0;
        }
        

    }
}