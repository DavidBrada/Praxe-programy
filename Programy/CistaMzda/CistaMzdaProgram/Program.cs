namespace CistaMzdaProgram;
public class Program
{
    public static int VypocitejMzdu(int hrubaMzda, int pocetDeti){
        float socialniPojisteni = hrubaMzda * 0.065f; // 6,5%
        float zdravotniPojisteni = hrubaMzda * 0.045f; // 4,5%
        float zalohaNaDan = hrubaMzda * 0.15f;
        if(hrubaMzda > 161296){
            zalohaNaDan = hrubaMzda * 0.23f;
        }
        int slevyNaDani = 2570;
        int zvyhodneniNaDeti = 0; // 1. - 1267, 2. - 1860, 3. 2320 a na další taky 2320
        int slevaNaStudenta = 0;
        int slevaPrukazZTP = 0;
        
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
        /*
        string odpoved = "";
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
        }*/

        float vyslednaDan = socialniPojisteni + zdravotniPojisteni + zalohaNaDan - zvyhodneniNaDeti - slevyNaDani - slevaNaStudenta - slevaPrukazZTP;
        int cistaMzda = (int)(hrubaMzda - vyslednaDan);

        return cistaMzda;

    }
    private static void Main(string[] args)
    {

        Console.Write("Hrubá mzda: ");
        int hrubaMzda = int.Parse(Console.ReadLine());

        Console.Write("Počet dětí: ");
        int pocetDeti = int.Parse(Console.ReadLine());

        Console.WriteLine(VypocitejMzdu(hrubaMzda, pocetDeti));

    }
}