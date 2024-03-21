using Microsoft.AspNetCore.Mvc;
using MSTesting.Controllers;

namespace MSTestCase
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeController_IndexAction_ValidateLargeNumberGuessResult()
        {
            HomeController homeController = new HomeController();
            int guessNumber = 200;
            JsonResult res = new JsonResult($"Wrong! Try a bigger number! You Guess : {guessNumber}");

            JsonResult result = homeController.Index(guessNumber);

            Assert.AreEqual( res.Value, result.Value );
        }

        [TestMethod]
        public void HomeController_IndexAction_ValidateSmallerNumberGuessResult()
        {
            HomeController homeController = new HomeController();
            int guessNumber = 60;
            JsonResult res = new JsonResult($"Wrong! Try a bigger number! You Guess : {guessNumber}");

            JsonResult result = homeController.Index(guessNumber);

            Assert.AreEqual(res.Value, result.Value);
        }

        [TestMethod]
        public void HomeController_IndexAction_ValidateCorrectNumberGuessResult()
        {
            HomeController homeController = new HomeController();
            int guessNumber = 100;
            JsonResult res = new JsonResult($"Hurray! Correct guess ! Number is {guessNumber}");

            JsonResult result = homeController.Index(guessNumber);

            Assert.AreEqual(res.Value, result.Value);
        }
    }
}