using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        protected TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
        }
    }
}
