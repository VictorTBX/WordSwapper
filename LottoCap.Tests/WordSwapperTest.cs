using LottoCap.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LottoCap.Tests
{
    [TestClass]
    public class WordSwapperTest
    {
        [TestMethod]
        public void WhenSourceEqualsDestiny_ReturnZero()
        {
            var swapper = new WordSwapper();
            var model = new WordSwapperModelRequest
            {
                Source = "teste",
                Destiny = "teste"
            };

            var result = swapper.TransformWords(model);

            Assert.AreEqual(0, result.TotalMoves);
        }

        [TestMethod]
        public void WhenSourceContainsDestiny_ReturnDifference()
        {
            var swapper = new WordSwapper();
            var model = new WordSwapperModelRequest
            {
                Source = "testemais",
                Destiny = "teste"
            };

            var result = swapper.TransformWords(model);

            Assert.AreEqual(4, result.TotalMoves);
        }

        [TestMethod]
        public void WhenDestinyContainsSource_ReturnDifference()
        {
            var swapper = new WordSwapper();
            var model = new WordSwapperModelRequest
            {
                Source = "teste",
                Destiny = "maistestemais"
            };

            var result = swapper.TransformWords(model);

            Assert.AreEqual(8, result.TotalMoves);
        }

        [TestMethod]
        public void WhenWordsSameLength_ReturnNumberDifferentLettersInSamePosition()
        {
            var swapper = new WordSwapper();
            var model = new WordSwapperModelRequest
            {
                Source = "victor",
                Destiny = "vucyoe"
            };

            var result = swapper.TransformWords(model);

            Assert.AreEqual(3, result.TotalMoves);
        }

        [TestMethod]
        public void WhenWordsDifferentLength_AndWordsBeginEqually_ReturnDifferenceAffterEquality()
        {
            var swapper = new WordSwapper();
            var model = new WordSwapperModelRequest
            {
                Source = "teste",
                Destiny = "tespro"
            };

            var result = swapper.TransformWords(model);

            Assert.AreEqual(3, result.TotalMoves);
        }

        [TestMethod]
        public void WhenWordsDifferentLength_AndWordsBeginDifferently_ReturnTotalDifference()
        {
            var swapper = new WordSwapper();
            var model = new WordSwapperModelRequest
            {
                Source = "aboloas",
                Destiny = "bola"
            };

            var result = swapper.TransformWords(model);

            Assert.AreEqual(3, result.TotalMoves);
        }
    }
}
