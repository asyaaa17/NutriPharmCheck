using VitaminBad.Domain;
using VitaminBad.Domain.ViewModel;

namespace VitaminBad.Service.Interfaces
{
    public interface IInteractionService
    {
        Task<BaseResponse<Domain.Entity.Interaction>> FindInteractionByNames(long idHearb,long idDrug);
        Task<BaseResponse<InteractionByNameViewModel2>> FindInteractionByLikeName(string idHearb, string idDrug);

        Task<BaseResponse<List<Domain.Entity.Interaction>>> FindInteractionV2(long idHearb, long idDrug);
    }
}
