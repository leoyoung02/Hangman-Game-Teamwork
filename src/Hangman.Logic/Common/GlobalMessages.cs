namespace Hangman.Logic.Common
{
    public class GlobalMessages
    {
        public const string  Welcome = "<< Welcome to “Hangman” game >>\n" +
                                       "<< Please try to guess the secret word >>\n";
        public const string CommandOptions = "Commands:\n" +
                                             "HELP \t\t Reveals a letter.\n" +
                                             "TOP \t\t Displays high scores.\n" +
                                             "RESTART \t Starts a new game.\n" +
                                             "EXIT \t\t Quits the game.";

        public const string SecretWord = "\nThe secret word is: ";
        public const string EnterLetterOrCommand = "\nEnter your guess letter or command: ";
        public const string IncorrectGuessOrCommand = "Incorrect guess or command!";

        public const string OneLetterRevealed = "Good job! You revealed {0} letter.";
        public const string MultipleLettersRevealed = "Good job! You revealed {0} letters.";
        public const string LetterNotRevealed = "Sorry! There are no \"{0}\"-s.";

        public const string WinWithHelp = "You won with {0} mistakes but you have used help. Your result will not be entered into the scoreboard.";
        public const string Win = "You won with {0} mistakes.";
        
       
    }
}
