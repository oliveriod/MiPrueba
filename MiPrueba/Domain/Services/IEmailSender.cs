using System.Threading.Tasks;

namespace ByblosMiPH.API.Domain.Services
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string message);
	}
}
