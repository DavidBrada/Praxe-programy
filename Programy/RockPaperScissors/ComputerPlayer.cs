using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_paper_scissors
{
  public class ComputerPlayer : IPlayer
  {
    public Choice GetChoice()
    {
      Random rnd = new Random();

      Choice p2 = (Choice)rnd.Next(0, 3);
      return p2;
    }
  }
}
