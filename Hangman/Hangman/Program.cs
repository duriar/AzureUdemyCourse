namespace Hangman
{
    internal class Program
    {
        static string correctWord;
        static char[] letters;
        static Player player;
        static void Main(string[] args)
        {
            try
            {
                StartGame();
                PlayGame();
                EndGame();
            }
            catch //(Exception e)
            {
                //to do: log exception 
                //e.g, this would log it  --> e.ToString();
                Console.WriteLine("wooops, something went wrong");
            }
        }
        private static void StartGame()
        {
            string[] words;
            try
            {
                words = File.ReadAllLines(@"C:\Users\DurnianI\Desktop\Words.txt");
            }
            catch
            {
                words = new string[] { "Fermanagh", "Down", "Armagh" };
            }

            Random random = new Random();
            correctWord = words[random.Next(0, words.Length)];


            letters = new char[correctWord.Length];
            for (int i = 0; i < correctWord.Length; i++)
                letters[i] = '-';

            AskForUsersName();
        }

        static void AskForUsersName()
        {
            Console.WriteLine("Enter your name hi lawd...");
            string input = Console.ReadLine();

            if (input.Length >= 2)
                player = new Player(input);
            else
            {
                Console.WriteLine("name must be longer than two characters"); 
                AskForUsersName();
            }
        }
        private static void PlayGame()
        {
            do
            {
                Console.Clear();
                DisplayMaskedWord();
                char guessedLetter = AskForLetter();
                CheckLetter(guessedLetter);
            } while (correctWord != new string(letters));

            Console.Clear();
        }

        private static void CheckLetter(char guessedLetter)
        {
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (guessedLetter == correctWord[i])
                {
                    letters[i] = guessedLetter;
                    player.Score++;
                }
            }
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in letters)
                Console.Write(c);

            Console.WriteLine();
        }
        static char AskForLetter()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a letter:");
                input = Console.ReadLine();
            } while (input.Length != 1);


            var letter = input[0];

            if (!player.GuessedLetters.Contains(letter))
                player.GuessedLetters.Add(letter);

            return letter;
        }

        private static void EndGame()
        {
            Console.WriteLine($"Congratulations!");
            Console.WriteLine($"Thanks for playing {player.Username}, you had {player.GuessedLetters.Count} attempts.");
            Console.WriteLine($"Score:{player.Score}");
        }

    }
}