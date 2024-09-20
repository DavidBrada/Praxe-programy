namespace RockPaperScissors;

class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        do{
            gameManager.PlayRound();

            System.Console.WriteLine("Play again?");
        }while(Console.ReadLine().ToUpper() == "Y");
    }
}
