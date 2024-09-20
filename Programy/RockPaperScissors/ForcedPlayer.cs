using Rock_paper_scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_paper_scissors.Tests
{
  internal class ForcedPlayer : IPlayer
  {
    private Choice _choice;

    public ForcedPlayer(Choice choice)    {
      _choice = choice;
    }


    public Choice GetChoice()
    {
      return _choice;
    }
  }
}
