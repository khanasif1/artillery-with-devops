using Microsoft.AspNetCore.Mvc;

namespace AWSLambda.ArtilleryTest.Controllers;

[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        #region BadCode
        Random random = new Random();
        int rInt = random.Next(100, 5000);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(rInt.ToString());
        Console.ForegroundColor = ConsoleColor.Black;
        Thread.Sleep(rInt);
        #endregion
        return new string[] { "value1", "value2" };
    }
}