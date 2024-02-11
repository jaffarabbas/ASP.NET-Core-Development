using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotnetWebApiFilters.Configuration.Filters;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotnetWebApiFilters.Controllers;

[ApiController]
[Route("api/[controller]")]
[DriverFilter]
public class DriversController : ControllerBase {
    private List<string> drivers = new List<string>(){
        "Lewis Hamilton",
        "Max Verstappen",
        "Valtteri Bottas",
        "Lando Norris",
        "Sergio Perez",
        "Charles Leclerc",
        "Daniel Ricciardo",
        "Carlos Sainz",
        "Fernando Alonso",
        "Esteban Ocon",
        "Pierre Gasly",
        "Sebastian Vettel",
        "Lance Stroll",
        "Yuki Tsunoda",
        "Kimi Raikkonen",
        "Antonio Giovinazzi",
        "Mick Schumacher",
        "Nikita Mazepin",
        "Nicholas Latifi",
        "George Russell"
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(drivers);
    }

    [HttpPost]
    public IActionResult Post(string driver)
    {
        drivers.Add(driver);
        return Ok("Yes");
    }
}