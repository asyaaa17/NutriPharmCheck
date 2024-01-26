using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class InteractionTypeRepository : IBaseRepository<InteractionType>
    {
        private readonly ApplicationDbContext appDbCon;
        public InteractionTypeRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(InteractionType entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(InteractionType entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<InteractionType> Get(long id)
        {
            return await appDbCon.InteractionType.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<InteractionType> Select()
        {
            return appDbCon.InteractionType;
        }

        public async Task<InteractionType> Update(InteractionType entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
