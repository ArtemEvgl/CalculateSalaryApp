using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Controllers
{
    interface IDataWorker
    {
        List<T> Load<T>(string fileName) where T : class;
        void Save<T>(List<T> employees, string fileName) where T : class;
    }
}
