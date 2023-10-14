using Microsoft.AspNetCore.Mvc;
using OpenFreight.Carriers;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly CarrierDbContext _carrierDbContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        CarrierDbContext carrierDbContext)
    {
        _logger = logger;
        _carrierDbContext = carrierDbContext;
    }

    [HttpGet(Name = "GetCarriers")]
    public IEnumerable<CarrierModel> Get()
    {
        return _carrierDbContext.Carriers;
    }
}
