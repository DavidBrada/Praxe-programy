using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace RockPaperScissors;

class GameManager
{
    private IPlayer _player1;

    public RoundResult PlayRound(){
        // Human player
        

        //Computer player

        if(p1 == p2){
            System.Console.WriteLine("It's a draw.");
            return RoundResult.Draw;
        }
        if(p1 == Choice.Rock && p2 == Choice.Scissors || 
            p1 == Choice.Paper && p2 == Choice.Rock ||
            p1 == Choice.Scissors && p2 == Choice.Paper){
            Console.WriteLine("Player 1 wins.");
            return RoundResult.PlayerWin;
        }
        Console.WriteLine("Player2 wins.");
        return RoundResult.Player2Win;
    }

    public enum Choice{
        Rock,
        Paper,
        Scissors
    }

    public enum RoundResult{
        PlayerWin,
        Player2Win,
        Draw
    }
}
