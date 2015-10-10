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

        public void PlayerNameNullOrWhitespaceShouldReturnFalse(string playerName)
        {
            var validator = new Validator();

            bool result = validator.PlayerNameIsNullOrWhiteSpace(playerName);

            Assert.True(result, "PlayerNameNullOrWhitespaceShouldReturnFalse method should return \"true\"");
        }

        [TestCase("01234567890123456789000001")]

        public void PlayerNameTooLongShouldReturnTrue(string playerName)
        {
            var validator = new Validator();

            bool result = validator.PlayerNameIsTooLong(playerName);

            Assert.True(result, "PlayerNameTooLongShouldReturnTrue method should return \"true\"");
        }

        [TestCase("M")]
        [TestCase("Mike")]
        [TestCase("Mike Mike")]
        [TestCase("01234567890123456789")]

        public void PlayerNameTooLongShouldReturnFalse(string playerName)
        {
            var validator = new Validator();

            bool result = validator.PlayerNameIsTooLong(playerName);

            Assert.False(result, "PlayerNameTooLongShouldReturnFalse method should return \"false\"");
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("0")]
        [TestCase("ab")]

        public void InvalidCommandShouldReturnFalse(string command)
        {
            var validator = new Validator();

            bool result = validator.InputCommandIsValid(command);

            Assert.False(result, "InputCommandValidator method should return \"false\"");
        }

        [TestCase("a")]

        public void ValidCommandShouldReturnTrue(string command)
        {
            var validator = new Validator();

            bool result = validator.InputCommandIsValid(command);

            Assert.True(result, "InputCommandValidator method should return \"true\"");
        }
    }
}