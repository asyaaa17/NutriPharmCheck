using Microsoft.AspNetCore.Mvc;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteractionV2Controller : ControllerBase
    {
        private readonly IInteractionService _interactionService;

        public InteractionV2Controller(IInteractionService interactionService, IImportExcel iexcel)
        {
            _interactionService = interactionService;

        }
        
        [HttpPost(Name = "GetInteractionV2")]
        public async Task<List<Domain.Entity.Interaction>> GetInteractionV2(InteractionV2ViewModel input)
        {
            var r = await _interactionService.FindInteractionV2(input.IdHeab, input.IdDrug);

            return r.Data;
        }
    }
}
