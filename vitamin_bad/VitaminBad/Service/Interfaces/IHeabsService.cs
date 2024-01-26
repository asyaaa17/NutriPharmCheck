using VitaminBad.Domain;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Service.Interfaces
{
    public interface IHeabsService
    {
        Task<BaseResponse<List<Heabs>>> FindHeabsByName(string name);
    }
}
