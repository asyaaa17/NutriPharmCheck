using VitaminBad.Domain;

namespace VitaminBad.Service.Interfaces
{
    public interface IImportExcel
    {
        Task<BaseResponse<string>> SaveDataFromExcel();
    }
}
