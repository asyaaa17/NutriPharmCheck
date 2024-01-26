using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class HeabsRepostitory : IBaseRepository<Heabs>
    {
        private readonly ApplicationDbContext appDbCon;
        public HeabsRepostitory(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Heabs entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Heabs entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Heabs> Get(long id)
        {
            return await appDbCon.Heabs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Heabs> Select()
        {
            return appDbCon.Heabs;
        }

        public async Task<Heabs> Update(Heabs entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
