using Microsoft.EntityFrameworkCore;

namespace DirectId.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {

        }
    }
}
