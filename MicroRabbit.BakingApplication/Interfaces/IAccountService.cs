using MicroRabbit.BakingApplication.Models;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.BakingApplication.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
