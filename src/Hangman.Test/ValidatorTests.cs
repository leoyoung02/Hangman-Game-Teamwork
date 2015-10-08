namespace Hangman.Tests
{
    using NUnit.Framework;
    using Logic.Utils;
    using Logic;

    [TestFixture]
    public class ValidatorTests
    {        
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("012345678901234567891")] //trying to enter name with length more than maximum

        public void InvalidImputForPlayerNameShouldReturnFalse(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.PlayerNameValidator(input);

            Assert.False(result, "PlayerNameValidator method should return \"false\"");
        }

        [TestCase("M")]
        [TestCase("Mike")]
        [TestCase("Mike Mike")]
        [TestCase("01234567890123456789")] //trying to enter name with length equal to maximum

        public void ValidImputForPlayerNameShouldReturnTrue(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.PlayerNameValidator(input);

            Assert.True(result, "PlayerNameValidator method should return \"true\"");
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("0")]
        [TestCase("ab")]

        public void InvalidImputForInputCommandShouldReturnFalse(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.InputCommandValidator(input);

            Assert.False(result, "InputCommandValidator method should return \"false\"");
        }

        [TestCase("a")]

        public void ValidImputForInputCommandShouldReturnTrue(string input)
        {
            var validator = new Validator(new ConsolePrinter());

            bool result = validator.InputCommandValidator(input);

            Assert.True(result, "InputCommandValidator method should return \"true\"");
        }
    }
}
