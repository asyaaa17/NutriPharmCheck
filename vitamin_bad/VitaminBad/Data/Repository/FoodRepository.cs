using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class FoodRepository : IBaseRepository<Food>
    {
        private readonly ApplicationDbContext appDbCon;
        public FoodRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Food entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Food entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Food> Get(long id)
        {
            return await appDbCon.Food.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Food> Select()
        {
            return appDbCon.Food;
        }

        public async Task<Food> Update(Food entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
