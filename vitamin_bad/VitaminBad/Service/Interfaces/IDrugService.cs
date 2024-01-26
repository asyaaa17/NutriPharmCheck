using VitaminBad.Domain;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Service.Interfaces
{
    public interface IDrugService
    {
        Task<BaseResponse<List<Drugs>>> FindDrugsByNames(string drugName);
    }
}
