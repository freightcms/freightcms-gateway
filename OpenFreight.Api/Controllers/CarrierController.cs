using Microsoft.AspNetCore.Mvc;
using OpenFreight.Carriers;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Controllers;

[ApiController]
[Route("[controller]")]
public class CarrierController : ControllerBase
{
    private readonly ILogger<CarrierController> _logger;
    private readonly CarrierDbContext _carrierDbContext;

    public CarrierController(ILogger<CarrierController> logger,
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
