using Microsoft.AspNetCore.Mvc;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Implements;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrugsController : ControllerBase
    {
        private readonly IDrugService _drugService;
        public DrugsController(IDrugService drugService) {
            _drugService = drugService;
        }
        [HttpPost(Name = "GetDrugsByName")]
        public async Task<List<Drugs>> GetInteraction(DrugViewModel input)
        {
            var r = await _drugService.FindDrugsByNames(input.Name);

            return r.Data;
        }
    }
}