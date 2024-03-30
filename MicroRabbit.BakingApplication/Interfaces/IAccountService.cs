using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.BakingApplication.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
