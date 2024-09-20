namespace Hangman;
using System;
using System.Text.Json;

/*
public class hangmanConfig{
    public int MaxMistakes { get; set; }

    public hangmanConfig(int _maxMistakes){
        MaxMistakes = _maxMistakes;
    }
}

public class ReadAndParseJsonFileWithSystemTextJson
{
    private readonly string _sampleJsonFilePath;

    public ReadAndParseJsonFileWithSystemTextJson(string sampleJsonFilePath)
    {
        _sampleJsonFilePath = sampleJsonFilePath;
    }

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public List<hangmanConfig> UseFileReadAllTextWithSystemTextJson()
    {
        var json = File.ReadAllText(_sampleJsonFilePath);
        List<hangmanConfig> settings = JsonSerializer.Deserialize<List<hangmanConfig>>(json, _options);
        return settings;
    }
}
*/
class Program
{
    static void Main(string[] args)
    {
        /*
        ReadAndParseJsonFileWithSystemTextJson readAndParseJsonFileWithSystemTextJson = new ReadAndParseJsonFileWithSystemTextJson("C:/Users/uih05153/Desktop/Programy/Hangman/hangmanConfig.json");
        List<hangmanConfig> test = new List<hangmanConfig>{};
        test = readAndParseJsonFileWithSystemTextJson.UseFileReadAllTextWithSystemTextJson();
        

        foreach(var item in test){
            System.Console.WriteLine(item);
        }*/
        int maxMistakes = 10;

        char userGuess = ' ';
        char playAgain = 'y';
        bool isValid = false;
        int mistakeCount = 0;
        bool foundLetter = false;
        bool alreadyUsed = false;
        List<string> words = new List<string>();
        var wordFile = File.ReadAllLines("C:/Users/uih05153/Desktop/Programy/Hangman/WordList.txt");
        foreach (string s in wordFile) words.Add(s);

        List<char> usedLetters = new List<char>();
        Random rnd = new Random();

        while(char.ToLower(playAgain) == 'y'){

            int randIndex = rnd.Next(0, words.Count - 1);
            string hiddenWord = words[randIndex];
            string wordMask = new string('_', words[randIndex].Length);

            while(wordMask != hiddenWord && mistakeCount < maxMistakes){

                Console.WriteLine(wordMask);

                Console.Write("Guess a letter: ");
                isValid = char.TryParse(Console.ReadLine(), out userGuess);

                while(!char.IsLetter(userGuess) || !isValid){
                    Console.WriteLine("Invalid input.");
                    Console.Write("Guess a letter: ");
                    isValid = char.TryParse(Console.ReadLine(), out userGuess);
                }

                userGuess = char.ToLower(userGuess);

                for(int i = 0; i < hiddenWord.Length; i++){
                    if(hiddenWord[i] == userGuess){
                        wordMask = wordMask.Remove(i, 1).Insert(i, Convert.ToString(userGuess));
                        foundLetter = true;
                    }
                    else if(i == hiddenWord.Length - 1 && foundLetter == false){
                        mistakeCount++;
                        Console.WriteLine("Mistakes: " + mistakeCount + '/' + maxMistakes);
                        if(mistakeCount == maxMistakes){
                            Console.WriteLine("You lost. The word was '" + hiddenWord + "'");
                            break;
                        }
                    }
                }

                if(usedLetters.Count == 0)
                {
                    usedLetters.Add(userGuess);
                }
                else
                {
                    for(int i = 0; i < usedLetters.Count; i++){
                        
                        if(usedLetters[i] == userGuess){
                            alreadyUsed = true;
                        }
                        else if(i == usedLetters.Count - 1 && alreadyUsed == false)
                        {
                            usedLetters.Add(userGuess);
                        }

                    }
                }

                usedLetters.Sort();
                if(foundLetter == false && usedLetters.Count > 0){
                    Console.Write("Used letters: ");
                    foreach(char letter in usedLetters)
                    {
                        Console.Write(letter + " ");
                    }
                    Console.WriteLine();
                }
                foundLetter = false;
                alreadyUsed = false;
            }
            if(wordMask == hiddenWord)
            {
                Console.WriteLine("You won! The word was '" + hiddenWord + "'");
            }

            Console.Write("Play again? (Y/N): ");
            playAgain = Convert.ToChar(Console.ReadLine());

            if(char.ToLower(playAgain) == 'y')
            {
                usedLetters.Clear();
                mistakeCount = 0;
            }
            else
            {
                Console.WriteLine("Quitting program...");
            }
        }
    }
}