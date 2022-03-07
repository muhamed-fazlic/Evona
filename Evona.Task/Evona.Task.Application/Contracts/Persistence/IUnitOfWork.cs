using System;
namespace Evona.Task.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IStudentBackupRepository StudentBackupRepository { get; }
        System.Threading.Tasks.Task Save();
    }
}
