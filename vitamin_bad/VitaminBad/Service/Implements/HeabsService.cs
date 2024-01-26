using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Data.Repository;
using VitaminBad.Domain;
using VitaminBad.Domain.Entity;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Service.Implements
{
    public class HeabsService : IHeabsService
    {
        private readonly IBaseRepository<Domain.Entity.Heabs> _heabsRepository;
        public HeabsService(IBaseRepository<Domain.Entity.Heabs> he)
        {
            _heabsRepository = he;
        }
        public async Task<BaseResponse<List<Heabs>>> FindHeabsByName(string name)
        {
            try
            {
                var heabs = await _heabsRepository.Select().Where(x => x.Name.Contains(name) == true).ToListAsync();
                if (heabs == null)
                {
                    return new BaseResponse<List<Heabs>>()
                    {
                        Description = "Найдено 0 эл-в",
                        StatusCode = StatusCode.NotFound
                    };
                }

                return new BaseResponse<List<Heabs>>()
                {
                    Data = heabs,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<List<Heabs>>();
                z.Description = $"[GetInteraction]:{ex.Message}";

                return z;
            }
        }
    }
}
