
using CalculateSalaryApp.Model;

namespace CalculateSalaryApp.Domain
{
    public interface IAuthService
    {
        Employee Login(string lastName);
    }
}
