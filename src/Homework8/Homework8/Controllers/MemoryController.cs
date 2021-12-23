using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
    public class Memory:Controller
    {
        public static string str = "";

        public IActionResult Index()
        {
            for (int i = 0; i < 100; i++)
            {
                str += i.ToString();
                
            }

            return Ok();
        }
    }
}