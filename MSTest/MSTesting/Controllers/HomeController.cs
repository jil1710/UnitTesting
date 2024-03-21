using Microsoft.AspNetCore.Mvc;
using MSTesting.Models;
using System.Diagnostics;

namespace MSTesting.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public JsonResult Index(int number)
        {
            if(number < 100)
            {
                return new JsonResult($"Wrong! Try a bigger number! You Guess : {number}");
            }
            else if(number > 100)
            {
                return new JsonResult($"Wrong! Try a bigger number! You Guess : {number}");
            }
            return new JsonResult($"Hurray! Correct guess ! Number is {number}");
        }

        
    }
}
