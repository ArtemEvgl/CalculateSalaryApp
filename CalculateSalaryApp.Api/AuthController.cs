using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Api
{
    public class AuthController
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public Employee Login(string lastName)
        {
            return _authService.Login(lastName);
        }

    }
}
