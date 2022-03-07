using Evona.Task.Application.Models.Emails;
using System.Threading.Tasks;

namespace Evona.Task.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
