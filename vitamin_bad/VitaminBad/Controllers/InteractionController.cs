using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _interactionService;

        public InteractionController(IInteractionService interactionService,IImportExcel iexcel)
        {
            _interactionService = interactionService;
            
        }
        [HttpGet(Name = "GetInteraction")]
        public async Task<Interaction> GetInteraction(InteractionFyIdsViewModel input)
        {
            var r = await _interactionService.FindInteractionByNames(input.IdIngradient,input.IdDrug);

            return r.Data;
        }
        [HttpPost(Name = "GetInteractionByLikeName")]
        public async Task<InteractionByNameViewModel2> GetInteractionByLikeName(InteractionByNameViewModel input)
        {
            var r = await _interactionService.FindInteractionByLikeName(input.Name_bad, input.Name_drug);

            return r.Data;
        }


    }
}
