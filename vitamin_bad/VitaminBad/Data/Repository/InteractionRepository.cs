using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class InteractionRepository : IBaseRepository<Interaction>
    {
        private readonly ApplicationDbContext appDbCon;
        public InteractionRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Interaction entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Interaction entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Interaction> Get(long id)
        {
            return await appDbCon.Interactions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Interaction> Select()
        {
            return appDbCon.Interactions;
        }

        public async Task<Interaction> Update(Interaction entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
