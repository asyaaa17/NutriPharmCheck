using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class DrugRepository : IBaseRepository<Drugs>
    {
        private readonly ApplicationDbContext appDbCon;
        public DrugRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Drugs entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Drugs entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Drugs> Get(long id)
        {
            return await appDbCon.Drugs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Drugs> Select()
        {
            return appDbCon.Drugs;
        }

        public async Task<Drugs> Update(Drugs entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
