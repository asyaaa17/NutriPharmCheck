using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Data.Repository;
using VitaminBad.Domain;
using VitaminBad.Domain.Entity;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Service.Implements
{
    public class DrugService : IDrugService
    {

        private readonly IBaseRepository<Domain.Entity.Drugs> _drugsRepository;

        public DrugService(IBaseRepository<Drugs> drugsRepository)
        {
            _drugsRepository = drugsRepository;
        }

        public async Task<BaseResponse<List<Drugs>>> FindDrugsByNames(string drugName)
        {
            try
            {
                var drugs = await _drugsRepository.Select().Where(x=> x.Name.Contains(drugName)==true).ToListAsync();
                if (drugs == null)
                {
                    return new BaseResponse<List<Drugs>>()
                    {
                        Description = "Найдено 0 эл-в",
                        StatusCode = StatusCode.NotFound
                    };
                }

                return new BaseResponse<List<Drugs>> ()
                {
                    Data = drugs,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<List<Drugs>>();
                z.Description = $"[GetInteraction]:{ex.Message}";

                return z;
            }
        }
    }
}
