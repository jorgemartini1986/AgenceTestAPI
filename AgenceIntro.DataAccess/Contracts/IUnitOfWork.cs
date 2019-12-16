using AgenceIntro.Core.Models;

namespace AgenceIntro.DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IRepository<PermissaoSistema> SystemPermissionRepository { get; }

        IRepository<CaoFatura> BillRepository { get; }

        IRepository<CaoSalario> SalaryRepository { get; }

        IRepository<CaoOs> ServiceOrderRepository { get; }

        void SaveChages();
    }
}
