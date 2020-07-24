using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Entities;
using MovieStore.Core.RepositoryInterfaces;
using MovieStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Infrastructure.Repositories
{
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieStoreDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Review>> GetReviewByUserId(int UserId)
        {
            var review = await _dbContext.Reviews
                .Include(r => r.Movie)
                .Where(r => r.UserId == UserId).ToListAsync();
            return review;
        }
    }
}
