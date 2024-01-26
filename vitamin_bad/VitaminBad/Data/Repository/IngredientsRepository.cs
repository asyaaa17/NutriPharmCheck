using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class IngredientsRepository : IBaseRepository<Ingredients>
    {
        private readonly ApplicationDbContext appDbCon;
        public IngredientsRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Ingredients entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Ingredients entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Ingredients> Get(long id)
        {
            return await appDbCon.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Ingredients> Select()
        {
            return appDbCon.Ingredients;
        }

        public async Task<Ingredients> Update(Ingredients entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
