using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;
using System.Net.NetworkInformation;
using VitaminBad.Data.Interface;
using VitaminBad.Data.Repository;
using VitaminBad.Domain;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Service.Implements
{
    public class InteractionService : IInteractionService
    {
        private readonly IBaseRepository<Domain.Entity.Interaction> _interactionRepository;
        private readonly IBaseRepository<Drugs> _drugRepo;
        private readonly IBaseRepository<Heabs> _heabsRepo;

        public InteractionService(IBaseRepository<Domain.Entity.Interaction> interactionRepository, IBaseRepository<Drugs> drugRepo, IBaseRepository<Heabs> heabsRepo)
        {
            _interactionRepository = interactionRepository;
            _drugRepo = drugRepo;
            _heabsRepo = heabsRepo;
        }

        public async Task<BaseResponse<InteractionByNameViewModel2>> FindInteractionByLikeName(string idHearb, string idDrug)
        {
            try { 
            var heabs = await _heabsRepo.Select().Where(x => x.Name.Contains(idHearb) == true).ToListAsync();
            var drugs = await _drugRepo.Select().Where(x => x.Name.Contains(idDrug) == true).ToListAsync();
                InteractionByNameViewModel2 res = new InteractionByNameViewModel2()
                {
                    drug = drugs,
                    bad = heabs
                };
                return new BaseResponse<InteractionByNameViewModel2>()
                {
                    Data = res,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<InteractionByNameViewModel2>();
                z.Description = $"[GetInteraction]:{ex.Message}";

                return z;

            }
        }

        public async Task<BaseResponse<Domain.Entity.Interaction>> FindInteractionByNames(long iding, long idDrug)
        {
            try
            {
                var interaction = await _interactionRepository.Select().FirstOrDefaultAsync(x => x.DrugsId == idDrug && x.IngredientsId== iding);
                if (interaction == null)
                {
                    return new BaseResponse<Domain.Entity.Interaction>()
                    {
                        Description = "Найдено 0 эл-в",
                        StatusCode = StatusCode.NotFound
                    };
                }

                return new BaseResponse<Domain.Entity.Interaction>()
                {
                    Data = interaction,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<Domain.Entity.Interaction>();
                z.Description = $"[GetInteraction]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<List<Domain.Entity.Interaction>>> FindInteractionV2(long idHearb, long idDrug)
        {
            try
            {

                var heabs = await _heabsRepo.Select().Where(x => x.Id==idHearb)
                    .Include(x=>x.Ingredients)
                    .ToListAsync();
                var interaction = await _interactionRepository.Select().Include(x=>x.Ingredients).Include(x=>x.Drugs).Where(x => x.DrugsId == idDrug).ToListAsync();
                var res = new List<Domain.Entity.Interaction>();
                foreach (var item in heabs[0].Ingredients)
                {
                    foreach (var dr in interaction)
                    {
                        if (dr.IngredientsId == item.Id)
                        {
                            res.Add(dr);
                        }
                    }
                }
                if (interaction == null)
                {
                    return new BaseResponse<List<Domain.Entity.Interaction>>()
                    {
                        Description = "Найдено 0 эл-в",
                        StatusCode = StatusCode.NotFound
                    };
                }

                return new BaseResponse<List<Domain.Entity.Interaction>>()
                {
                    Data = res,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<List<Domain.Entity.Interaction>>();
                z.Description = $"[GetInteraction]:{ex.Message}";

                return z;
            }
        }
    }
}
