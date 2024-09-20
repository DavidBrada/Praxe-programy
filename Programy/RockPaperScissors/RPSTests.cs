using Rock_paper_scissors;
using System;

namespace Rock_paper_scissors.Tests
{
  public class RPSTests{
    public bool RockBeatsScissors()
    {
      GameManager gameManager = new GameManager(new ForcedPlayer(Choice.Rock), new ForcedPlayer(Choice.Scissors));

      if(RoundResult.Player1Win == gameManager.PlayRound()){
        return true;
      }
      return false;
    }
  }
}
