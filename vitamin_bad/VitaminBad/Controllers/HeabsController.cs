using Microsoft.AspNetCore.Mvc;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Implements;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeabsController : ControllerBase
    {
        private readonly IHeabsService _heabsService;
        public HeabsController(IHeabsService heabs)
        {
            _heabsService=heabs;
        }
        [HttpPost(Name = "GetHeabs")]
        public async Task<List<Heabs>> GetInteraction(DrugViewModel input)
        {
            var r = await _heabsService.FindHeabsByName(input.Name);

            return r.Data;
        }
    }
}
