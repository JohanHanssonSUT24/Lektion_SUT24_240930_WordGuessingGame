namespace Lektion_SUT24_240930
{
    class WordGuessingGame
    {
        static string[] words = { "apple", "banana", "cherry", "date", "elderberry", "house", "mouse", "nationalencyklopedin" };
        static Random random = new Random();
        static int highScore = int.MaxValue;
        static string wordToGuess = "";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWord Guessing Game");
                Console.WriteLine("1. Play singleplayer");
                Console.WriteLine("2. Play multiplayer ");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    PlayGame(words[random.Next(words.Length)]);
                }
                else if (choice == "2")
                {
                    Console.Write("Enter a word:");
                    PlayGame(Console.ReadLine());
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        
        static void PlayGame(string wordToGuess)
        {
            char[] guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            int attemptsLeft = 6;
            Console.Clear();
            while (attemptsLeft > 0)
            {
                Console.WriteLine($"\nWord: {new string(guessedWord)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");
                
                string input = Console.ReadLine();
                bool result = input.All(Char.IsLetter);
                if (string.IsNullOrEmpty(input) || input.Length > 1 || !input.All(Char.IsLetter))
                {
                    Console.WriteLine("Wrong input, please enter one single letter.");
                    continue;
                }

                char guess = char.ToLower(input[0]);
                bool correctGuess = false;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                        correctGuess = true;
                    }
                } 

                if (!correctGuess)
                {
                    attemptsLeft--;
                    Console.WriteLine("Incorrect guess!");
                    Console.WriteLine("\r\n __          __                    _ \r\n \\ \\        / /                   | |\r\n  \\ \\  /\\  / / __ ___  _ __   __ _| |\r\n   \\ \\/  \\/ / '__/ _ \\| '_ \\ / _` | |\r\n    \\  /\\  /| | | (_) | | | | (_| |_|\r\n     \\/  \\/ |_|  \\___/|_| |_|\\__, (_)\r\n                              __/ |  \r\n                             |___/   \r\n");
                }

                if (!correctGuess && attemptsLeft == 3)
                {
                    Console.WriteLine("Do you want to quit? [Y] or [N]");
                    string userInput = Console.ReadLine().ToUpper();

                    if ( userInput == "Y")
                    {
                        break;
                    }
                    else if (userInput == "N")
                    {
                        Console.WriteLine("Keep on playing.");
                    }
  
                }

                if (new string(guessedWord) == wordToGuess)
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
                    if ((6 - attemptsLeft) < highScore) { highScore = (6 - attemptsLeft); }
                    Console.WriteLine($"\nYour new highscore is: {highScore}");

                    return;
                }
            }

            Console.WriteLine($"Game over! The word was: {wordToGuess}");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
