namespace Hangman.Tests
{
    using Logic;
    using Logic.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class ValidatorTests
    {        
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("012345678901234567891")] //trying to enter name with length more than maximum

        public void InvalidPlayerNameShouldReturnFalse(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.PlayerNameValidator(input);

            Assert.False(result, "PlayerNameValidator method should return \"false\"");
        }

        [TestCase("M")]
        [TestCase("Mike")]
        [TestCase("Mike Mike")]
        [TestCase("01234567890123456789")] //trying to enter name with length equal to maximum

        public void ValidPlayerNameShouldReturnTrue(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.PlayerNameValidator(input);

            Assert.True(result, "PlayerNameValidator method should return \"true\"");
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("0")]
        [TestCase("ab")]

        public void InvalidCommandShouldReturnFalse(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.InputCommandValidator(input);

            Assert.False(result, "InputCommandValidator method should return \"false\"");
        }

        [TestCase("a")]

        public void ValidCommandShouldReturnTrue(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.InputCommandValidator(input);

            Assert.True(result, "InputCommandValidator method should return \"true\"");
        }
    }
}
