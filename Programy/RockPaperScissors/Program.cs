using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock_paper_scissors.Tests;

namespace Rock_paper_scissors
{
  internal class Program
  {
    static void Main(string[] args)
    {
      GameManager gameManager = new GameManager(new HumanPlayer(), new ComputerPlayer());

      do
      {
        RoundResult result = gameManager.PlayRound();
        Console.Write("Play again? (Y/N): ");

      } while (Console.ReadLine().ToUpper() == "Y");
    }
  }
}
