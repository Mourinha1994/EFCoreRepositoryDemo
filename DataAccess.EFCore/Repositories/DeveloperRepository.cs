using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EFCore.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            return _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
        }
    }
}
