using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.DataWorker
{
    public interface IRepository
    {
        List<T> Load<T>(string fileName) where T : class;
        void Save<T>(List<T> employees, string fileName) where T : class;
    }
}
