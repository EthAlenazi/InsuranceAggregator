using InsuranceAggregator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAggregator.Data
{
    public class InsuranceAggregatorsContext:IdentityDbContext<ApplicationUser>
    {
        public InsuranceAggregatorsContext(DbContextOptions<InsuranceAggregatorsContext> options):base(options)
        {
            
        }
       
    }
}
