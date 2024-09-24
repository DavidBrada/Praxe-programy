internal class Program
{
    private static void Main(string[] args)
    {
        int hrubaMzda;
        float socialniPojisteni; // 6,5 %
        float zdravotniPojisteni; // 4,5 %
        float zalohaNaDan; // 15%
        int slevyNaDani; // 2570,-
        int zvyhodneniNaDeti = 0; // 1. - 1267, 2. - 1860, 3. 2320 a na další taky 2320
        int pocetDeti = 0;
        int slevaNaStudenta = 0;
        string odpoved;
        float vyslednaDan;
        int cistaMzda;
        int slevaPrukazZTP = 0;

        Console.Write("Čistá mzda: ");
        hrubaMzda = int.Parse(Console.ReadLine());

        Console.Write("Počet dětí: ");
        pocetDeti = int.Parse(Console.ReadLine());

        Console.Write("Status studenta (ano/ne): ");
        odpoved = Console.ReadLine();
        if(odpoved.ToLower() == "ano"){
            slevaNaStudenta = 335;
        }

        odpoved = "";
        Console.Write("Průkaz ZTP (ano/ne): ");
        odpoved = Console.ReadLine();
        if(odpoved.ToLower() == "ano"){
            slevaPrukazZTP = 1345;
        }

        int prvniDite = 1267;
        int druheDite = 1860;
        int dalsiDite = 2320;

        switch(pocetDeti){
            case 1:
            zvyhodneniNaDeti = prvniDite;
            break;

            case 2:
            zvyhodneniNaDeti = prvniDite + druheDite;
            break;

            case int n when n >= 3:
            zvyhodneniNaDeti = prvniDite + druheDite + dalsiDite * pocetDeti - 2;
            break;

            default:
            Console.WriteLine("Neplatný počet.");
            break;
        }

        socialniPojisteni = hrubaMzda * 0.065f;
        zdravotniPojisteni = hrubaMzda * 0.045f;
        zalohaNaDan = hrubaMzda * 0.15f;
        slevyNaDani = 2570;

        vyslednaDan = socialniPojisteni + zdravotniPojisteni + zalohaNaDan - zvyhodneniNaDeti - slevyNaDani - slevaNaStudenta - slevaPrukazZTP;
        cistaMzda = (int)(hrubaMzda - vyslednaDan);

        Console.WriteLine(cistaMzda);

    }
}