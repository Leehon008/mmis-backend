using Microsoft.EntityFrameworkCore;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Quality.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.API.Controllers.Quality
{
    public class VUsageMethods
    {
        private readonly MMISDbContext _context;

        public VUsageMethods(MMISDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VUsage>> GetQualityVUsage()
        {
            return await _context.QualityVUsage.ToListAsync();
        }

        //public async Task<VUsage> GetVUsage(int id)
        //{
        //    var vUsage = await _context.QualityVUsage.FindAsync(id);

        //    if (vUsage == null)
        //    {
        //        return null;
        //    }
        //    return vUsage;
        //}

        public async Task<VUsage> GetVUsage(string name)
        {
            var vUsage = await _context.QualityVUsage.Where(m => m.Name == name).FirstOrDefaultAsync();

            if (vUsage == null)
            {
                return null;
            }
            return vUsage;
        }

        public async Task UpdateVUsage(string name, bool IsEmpty)
        {
            var vUsage = await GetVUsage(name);
            if (vUsage!=null)
            {
                vUsage.Empty = IsEmpty;
                _context.Entry(vUsage).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
        }

        public async Task<bool> Clean(string name, DateTime dateTime)
        {
            var vUsage = await GetVUsage(name);
            if (vUsage != null)
            {
                if (vUsage.Empty)
                {
                    vUsage.LastCIP = dateTime;
                    _context.Entry(vUsage).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
            }
            return false;
        }

        public async Task<VUsage> DeleteVUsage(int id)
        {
            var vUsage = await _context.QualityVUsage.FindAsync(id);
            if (vUsage != null)
            {
                _context.QualityVUsage.Remove(vUsage);
                await _context.SaveChangesAsync();

                return vUsage;
            }
            return null;
        }

        private bool VUsageExists(int id)
        {
            return _context.QualityVUsage.Any(e => e.Id == id);
        }
    }
}
